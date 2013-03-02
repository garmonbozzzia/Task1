using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomergeTool
{
  public class Link
  {
    public int SourceLineIndex { get; set; }
    public int UserLineIndex { get; set; }
    
    public override string ToString()
    {
      return "S:" + SourceLineIndex.ToString() + " U:" + UserLineIndex.ToString() ;
    }
  }
}
