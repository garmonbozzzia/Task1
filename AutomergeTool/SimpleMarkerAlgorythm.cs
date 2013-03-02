using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomergeTool
{
  public class SimpleMarkerAlgorythm : IMarkerAlgorythm
  {     
    public void Do(Marker marker)
    {
      int startFrom = 0;
      for (int i = 0; i < marker.SourceData.Count; ++i)
      {
        int index = marker.UserData.IndexOf(marker.SourceData[i], startFrom);
        if (index != -1)
        {
          marker.Mapping.Add(new Link() { SourceLineIndex = i, UserLineIndex = index });
          startFrom = index + 1;
        }
      } 
    }
  }
}
