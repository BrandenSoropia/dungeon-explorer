using System.Collections;
using System.Collections.Generic;

public class PickUp
{
  public string Type { get; set; }
  public string Name { get; set; }
  public int PickUpId { get; set; }

  public PickUp(string type, string name, int id)
  {
    Type = type;
    Name = name;
    PickUpId = id;
  }

  public override string ToString()
  {
    return $"Type: {Type}\nName: {Name}";
  }

  public override bool Equals(object obj)
  {
    if (obj == null)
    {
      return false;
    }

    PickUp objAsPart = obj as PickUp;
    if (objAsPart == null)
    {
      return false;
    }

    else return Equals(objAsPart);
  }

  public override int GetHashCode()
  {
    return PickUpId;
  }

  public bool Equals(PickUp other)
  {
    if (other == null) return false;
    return (this.PickUpId.Equals(other.PickUpId));
  }
}
