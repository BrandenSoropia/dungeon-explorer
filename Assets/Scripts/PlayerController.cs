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
    else if (other.gameObject.CompareTag(Tags.DOOR_INTERACTION_AREA) && Input.GetKeyDown(KeyCode.E))
    {
      Debug.Log("Interacting with door!");
      HandleDoorAreaInteraction(other);
    }
    else if (other.gameObject.CompareTag(Tags.INTERACTION_AREA) && Input.GetKeyDown(KeyCode.E))
    {
      Debug.Log("Interacting with interaction area");
      HandleInteractionArea(other);
    }
  }

  private void HandlePickUpInteraction(Collider2D other)
  {
    PickUpController pickUpController = other.gameObject.GetComponent<PickUpController>();

    AddToInventory(pickUpController.pickUp);
    pickUpController.HandlePickUp();
  }

  private void HandleDoorAreaInteraction(Collider2D doorInteractiveArea)
  {
    DoorController doorController = doorInteractiveArea.gameObject.GetComponentInParent<DoorController>();
    if (doorController.openWithKeyName != "")
    {
      PickUp requiredKey = FindInInventory(PickUpConstants.TYPE_KEY, doorController.openWithKeyName);

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
    else
    {
      Debug.Log("The door doesn't use a key!");
    }
  }

  private void HandleInteractionArea(Collider2D interactiveArea)
  {
    GameStateManager.EndGame();
  }

  private PickUp FindInInventory(string category, string name)
  {
    List<PickUp> items = new List<PickUp>();

    if (inventory.TryGetValue(category, out items))
    {
      return items.Find(item => item.Name == name);
    }
    else
    {
      return null;
    }
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
    bool isSuccessful = false;
    isSuccessful = inventory[item.Type].Remove(item);

    if (inventory[item.Type].Count == 0)
    {
      inventory.Remove(item.Type);
    }

    return isSuccessful;
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
