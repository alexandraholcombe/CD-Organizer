using System.Collections.Generic;
using Nancy;

namespace CDOrganizer.Objects
{
  public class CD
  {
    private string _name;
    private int _id;
    private static List<CD> _instances = new List<CD>{};

    private CD(string name)
    {
      _name = name;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetName()
    {
      return _name;
    };

    public void SetName(string inputName)
    {
      _name = inputName;
    };

    public static List<CD> GetAll()
    {
      return _instances;
    };

    public int GetId()
    {
      return _id;
    };
  }
}
