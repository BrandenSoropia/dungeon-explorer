using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
  public float speed = 10;
  private Rigidbody2D rb2d;

  public List inventory = new List();

  void Start()
  {
    rb2d = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate()
  {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");
    Vector2 movement = new Vector2(moveHorizontal, moveVertical);

    rb2d.AddForce(movement * speed);
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (!isPressed && other.gameObject.CompareTag("Player"))
    {

      isPressed = !isPressed;
      GetComponent<SpriteRenderer>().sprite = isPressed ? pressedSprite : unpressedSprite;

      // TODO: A generic class to controll doors to make this more flexible!!!
      controlledObject.GetComponent<DoorController>().ToggleState();
    }
    else if (other.gameObject.CompareTag("PickUp"))
    {
      // TODO: Figure out how to instatiate pickup for key
      other.gameObject.SetActive(false);
    }
  }
}
