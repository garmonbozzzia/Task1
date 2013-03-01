using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomergeTool
{
  public class Marker
  {
    List<String> UserData { get; set; }
    List<String> SourceData { get; set; }

    public List<Link> Mapping { get; set; }

    public Marker( List<String> userData, List<String> sourceData)
    {
      Mapping = new List<Link>();
      UserData = userData;
      SourceData = sourceData;

      int startFrom = 0;
      for (int i = 0; i < SourceData.Count; ++i)
      {
        int index = UserData.IndexOf(SourceData[i], startFrom);
        if (index != -1)
        {
          Mapping.Add(new Link() { SourceLineIndex = i, UserLineIndex = index });
          startFrom = index + 1;
        }
      } 
    }

  }
}
