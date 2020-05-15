using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Can opened via switches or key, which is configured by flag
public class DoorController : MonoBehaviour
{
  public bool isOpen = false;
  public Sprite closedSprite;
  public Sprite openSprite;
  public string openWithKeyName = "";

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
