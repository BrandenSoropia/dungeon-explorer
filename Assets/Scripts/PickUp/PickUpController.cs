using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
  public PickUp pickUp;

  public string name;
  public Sprite sprite;

  void Start()
  {
    pickUp = new PickUp(PickUpConstants.TYPE_KEY, name);
    GetComponent<SpriteRenderer>().sprite = sprite;
  }

  public void HandlePickUp()
  {
    gameObject.SetActive(false);
    Debug.Log("Picked up!");
  }
}