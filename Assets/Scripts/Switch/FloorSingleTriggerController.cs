using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSingleTriggerController : MonoBehaviour
{

  public GameObject controlledDevice;
  private bool isPressed = false;

  public Sprite activeSprite;
  public Sprite inActiveSprite;

  void Start()
  {
    SetCurrentSprite();
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (!isPressed && other.gameObject.CompareTag(Tags.PLAYER))
    {
      HandleInteractionWithPlayer();
    }

  }

  void SetCurrentSprite()
  {
    GetComponent<SpriteRenderer>().sprite = isPressed ? activeSprite : inActiveSprite;
  }

  void HandleInteractionWithPlayer()
  {
    isPressed = !isPressed;
    SetCurrentSprite();
    controlledDevice.GetComponent<DoorController>().ToggleState();
  }
}