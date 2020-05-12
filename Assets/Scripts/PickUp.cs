using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
  public string Type { get; set; }

  public int Name { get; set; }

  public PickUp(string type, string name)
  {
    Type = type;
    Name = name;
  }
}
