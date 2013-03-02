using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomergeTool
{
  public class DeepMarker
  {
    List<String> UserData { get; set; }
    List<String> SourceData { get; set; }

    public List<Link> Mapping { get; set; }

    public DeepMarker(List<String> userData, List<String> sourceData)
    {
      Mapping = new List<Link>();
      UserData = userData;
      SourceData = sourceData;

    }
  }
}
