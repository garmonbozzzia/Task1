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
    public int Count
    {
      get
      {
        return Last - First + 1;
      }
    }

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
        if (Source != null && Source.Data.Count > 0)
        {
          return Source.Data.GetRange(First, Count);
        }
        else
        {
          return new List<string>();
        }

      }
    }    
  }
}
