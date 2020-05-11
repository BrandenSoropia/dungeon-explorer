using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: A generic class for switches to make this more flexible!!!
public class SingleToggleController : MonoBehaviour
{

  public GameObject controlledObject;
  private bool isPressed = false;


  public Sprite pressedSprite;
  public Sprite unpressedSprite;

  void Start()
  {
    GetComponent<SpriteRenderer>().sprite = isPressed ? pressedSprite : unpressedSprite;
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
  }
}