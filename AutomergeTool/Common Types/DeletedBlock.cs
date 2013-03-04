using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomergeTool
{
  public class DeletedBlock : Block
  {
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

    public DeletedBlock(int first, int last, SourceCode source)
    {
      First = first;
      Last = last;
      Source = source;
      Type = AutomergeTool.Type.deleted;  
    }

    public DeletedBlock(int index, SourceCode source)
    {
      First = index;
      Last = index;
      Source = source;
      Type = AutomergeTool.Type.deleted;
    }

    public List<String> Lines
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

    public override List<string> Data
    {
      get 
      {
        return new List<string>();
      }
    }
  }
}
