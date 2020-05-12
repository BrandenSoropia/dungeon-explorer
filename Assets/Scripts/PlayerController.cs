using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
  public float speed = 10;
  private Rigidbody2D rb2d;

  private List<Dictionary<string, string>> inventory = new List<Dictionary<string, string>>();

  void Start()
  {
    rb2d = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.I))
    {
      // Temp show inventory
      foreach (Dictionary<string, string> item in inventory)
      {
        foreach (KeyValuePair<string, string> kvp in item)
        {
          Debug.Log("Key = " + kvp.Key + " Value = " + kvp.Value);
        }
      }
    }
  }

  void FixedUpdate()
  {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");
    Vector2 movement = new Vector2(moveHorizontal, moveVertical);

    rb2d.AddForce(movement * speed);
  }

  public void AddToInventory(Dictionary<string, string> item)
  {
    Debug.Log("Inventory before: " + inventory.ToString());
    inventory.Add(item);
    Debug.Log("Inventory after: " + inventory.ToString());
  }
}
