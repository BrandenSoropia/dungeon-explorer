using System.Collections;
using System.Collections.Generic;

public class PickUp
{
  private string Type { get; set; }
  private string Name { get; set; }


  public PickUp(string type, string name)
  {
    Type = type;
    Name = name;
  }

  public override string ToString()
  {
    return $"Type: {Type}\nName: {Name}";
  }
}
