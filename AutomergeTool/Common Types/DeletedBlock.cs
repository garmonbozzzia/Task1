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

    public DeletedBlock(int first, int last)
    {
      First = first;
      Last = last;
      Type = AutomergeTool.Type.deleted;
    }

    public DeletedBlock(int index)
    {
      First = index;
      Last = index;
      Type = AutomergeTool.Type.deleted;
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
