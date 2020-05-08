using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSwitchController : MonoBehaviour
{

  public GameObject controlledObject;
  private bool isActive;
  private Sprite inactiveSprite;
  public Sprite activeSprite;
  // Start is called before the first frame update
  void Start()
  {
    isActive = true;
    inactiveSprite = GetComponent<SpriteRenderer>().sprite;
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
    if (other.gameObject.CompareTag("Player"))
    {
      isActive = true;
      GetComponent<SpriteRenderer>().sprite = activeSprite;
    }
  }
}
