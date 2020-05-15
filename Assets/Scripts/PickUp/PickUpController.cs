using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
  public PickUp pickUp;

  public string pickUpName;
  public Sprite sprite;
  public int pickUpId;

  void Start()
  {
    pickUp = new PickUp(PickUpConstants.TYPE_KEY, pickUpName, pickUpId);
    GetComponent<SpriteRenderer>().sprite = sprite;
  }

  public void HandlePickUp()
  {
    gameObject.SetActive(false);
    Debug.Log("Picked up!");
  }
}