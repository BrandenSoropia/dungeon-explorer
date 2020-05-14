using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
  public float speed = 10;
  private Rigidbody2D rb2d;

  private List<PickUp> inventory = new List<PickUp>();

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
    if (other.gameObject.CompareTag("PickUp") && Input.GetKeyDown(KeyCode.E))
    {
      PickUpController pickUpController = other.gameObject.GetComponent<PickUpController>();

      AddToInventory(pickUpController.pickUp);
      pickUpController.HandlePickUp();
    }
  }

  public void AddToInventory(PickUp item)
  {
    inventory.Add(item);
    PrintInventory();
  }

  void PrintInventory()
  {
    if (inventory.Count != 0)
    {
      Debug.Log("Inventory:");

      foreach (PickUp item in inventory)
      {
        Debug.Log(item);
      }
    }
    else
    {
      Debug.Log("Inventory Empty!");
    }
  }
}
