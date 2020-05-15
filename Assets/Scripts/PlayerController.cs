using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
  public float speed = 10;
  private Rigidbody2D rb2d;

  private Dictionary<string, List<PickUp>> inventory = new Dictionary<string, List<PickUp>>();

  void Start()
  {
    rb2d = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.I))
    {
      PrintInventory();
    }
  }

  void FixedUpdate()
  {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");
    Vector2 movement = new Vector2(moveHorizontal, moveVertical);

    rb2d.AddForce(movement * speed);
  }

  void OnTriggerStay2D(Collider2D other)
  {
    if (other.gameObject.CompareTag(Tags.PICKUP) && Input.GetKeyDown(KeyCode.E))
    {
      HandlePickUpInteraction(other);
    }
    else if (other.gameObject.CompareTag(Tags.DOOR) && Input.GetKeyDown(KeyCode.E))
    {
      Debug.Log("Colliding with door!");
      HandleDoorInteraction(other);
    }
  }

  private void HandlePickUpInteraction(Collider2D other)
  {
    PickUpController pickUpController = other.gameObject.GetComponent<PickUpController>();

    AddToInventory(pickUpController.pickUp);
    pickUpController.HandlePickUp();
  }

  private void HandleDoorInteraction(Collider2D other)
  {
    DoorController doorController = other.gameObject.GetComponent<DoorController>();

    PickUp requiredKey = FindInInventory(PickUpConstants.TYPE_KEY, doorController.openWithKeyName);
    Debug.Log($"Player has required key? {requiredKey}");

    if (requiredKey != null)
    {
      doorController.ToggleState();
      bool result = RemoveFromInventory(requiredKey);

      if (!result)
      {
        Debug.Log("There was an error trying to remove the required key from inventory.");
      }
    }
    else
    {
      Debug.Log("Doesn't have the right key!");
    }
  }

  private PickUp FindInInventory(string category, string name)
  {
    return inventory[category].Find(item => item.Name == name);
  }

  public void AddToInventory(PickUp item)
  {
    if (!inventory.ContainsKey(item.Type))
    {
      inventory.Add(item.Type, new List<PickUp>());
    }

    inventory[item.Type].Add(item);

    PrintInventory();
  }

  public bool RemoveFromInventory(PickUp item)
  {
    return inventory[item.Type].Remove(item);
  }

  void PrintInventory()
  {
    if (inventory.Count != 0)
    {
      Debug.Log("Inventory:");

      foreach (KeyValuePair<string, List<PickUp>> category in inventory)
      {
        Debug.Log($"Section: \"{category.Key}\"");

        foreach (PickUp item in category.Value)
        {
          Debug.Log(item);
        }
      }
    }
    else
    {
      Debug.Log("Inventory Empty!");
    }
  }
}
