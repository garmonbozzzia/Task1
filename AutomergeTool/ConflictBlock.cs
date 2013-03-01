using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomergeTool
{
  public class ConflictBlock : Block
  {
    MarkedUserCode user1;
    MarkedUserCode user2;

    public ConflictBlock(MarkedUserCode user1, MarkedUserCode user2)
    {
      this.user1 = user1;
      this.user2 = user2;
      Type = AutomergeTool.Type.conflict;
    }

    public int First { get; set; }
    public int Last { get; set; }
    public int Count { get { return Last - First + 1; } }


    public override List<string> Data
    {
      get 
      {
        List<string> result =  new List<string>() { "<Conflict>" };
        result.Add("<User1:>");
        for (int i = 0; i < Count; i++)
        {
          InsertedBlock inserted = user1.GetInsertedBlock(i + First);
          if (inserted != null)
          {
            result.AddRange(inserted.Data);
          }
        }
        result.Add("<User2:>");
        for (int i = 0; i < Count; i++)
        {
          InsertedBlock inserted = user2.GetInsertedBlock(i + First);
          if (inserted != null)
          {
            result.AddRange(inserted.Data);
          }
        } 
        result.Add("</Conflict>");
        return result;
      }
    }
  }
}
