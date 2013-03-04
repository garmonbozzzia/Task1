using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomergeTool
{
  public class SharedBlock : Block
  {
    private int index;
    public int First { get; set; }
    public int Last { get; set; }

    public SourceCode Source { get; set; }

    public SharedBlock(int index, SourceCode source)
    {
      Source = source;
      // TODO: Complete member initialization
      First = index;
      Last = index;
      Type = AutomergeTool.Type.shared;
    }

    public override List<string> Data
    {
      get 
      {
        return Source.Data.GetRange(First, Last-First+1);  
      }
    }    
  }
}
