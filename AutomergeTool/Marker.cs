using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomergeTool
{
  public class Marker
  {
    public List<String> UserData { get; set; }
    public List<String> SourceData { get; set; }

    public List<Link> Mapping { get; set; }

    public IMarkerAlgorithm Algorythm { get; set; }

    public Marker( List<String> userData, List<String> sourceData)
    {
      Mapping = new List<Link>();
      UserData = userData;
      SourceData = sourceData;
      Algorythm = new UserLoopAlgorithm();

      Action();
    }

    public void Action()
    {
      Mapping.Clear();
      Algorythm.Do(this);
    }

  }
}
