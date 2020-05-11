using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

  public bool isOpen = false;
  public Sprite closedSprite;
  public Sprite openSprite;

  void Start()
  {
    GetComponent<SpriteRenderer>().sprite = isOpen ? openSprite : closedSprite;
  }

  public void ToggleState()
  {
    isOpen = !isOpen;
    GetComponent<SpriteRenderer>().sprite = isOpen ? openSprite : closedSprite;
    GetComponent<Collider2D>().enabled = !isOpen;
  }

}
