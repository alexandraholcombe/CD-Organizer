using System.Collections.Generic;
using Nancy;

namespace CDOrganizer.Objects
{
  public class Artist
  {
    private string _name;
    private int _id;
    private static List<Artist> _instances = new List<Artist>{};
    private List<CD> _cds;

    public Artist (string name)
    {
      _name = name;
      _instances.Add(this);
      _id = _instances.Count;
      _cds = new List<CD>{};
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string inputName)
    {
      _name = inputName;
    }

    public int GetId()
    {
      return _id;
    }

    public List<CD> GetCds()
    {
      return _cds;
    }

    public void AddCd(CD inputCd)
    {
      _cds.Add(inputCd);
    }

    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static Artist Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
