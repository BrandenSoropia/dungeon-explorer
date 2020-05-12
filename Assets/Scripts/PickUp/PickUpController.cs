using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
  public string type = PickUpConstants.TYPE_KEY;
  public string name;
  public Sprite sprite;

  void Start()
  {
    GetComponent<SpriteRenderer>().sprite = sprite;
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log("Colliding!");

    // TODO: Only trigger on "interact" key pressed. Input system???
    if (other.gameObject.CompareTag("Player"))
    {
      Debug.Log("Colliding with player, deactivating!");
      gameObject.SetActive(false);

      other.gameObject.GetComponent<PlayerController>().AddToInventory(new Dictionary<string, string>{
        { type, name }
      });
    }
  }
}