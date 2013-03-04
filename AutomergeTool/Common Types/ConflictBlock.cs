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

    public int MyProperty { get; set; }

    public int First { get; set; }
    public int Last { get; set; }
    public int Count { get { return Last - First + 1; } }

    List<Block> user1Blocks;
    public List<Block> User1Blocks 
    {
      get 
      {
        Init(ref user1Blocks, user1);
        return user1Blocks;
      }
    }

    List<Block> user2Blocks;    
    public List<Block> User2Blocks 
    {
      get
      {
        Init(ref user2Blocks , user2);
        return user2Blocks;
      }
    }

    void Init(ref List<Block> blocks, MarkedUserCode markedUserCode)
    {
      if (blocks == null)
      {
        blocks = new List<Block>();
        for (int i = 0; i < Count; i++)
        {
          InsertedBlock inserted = markedUserCode.GetInsertedBlock(i + First);
          if (inserted != null)
          {
            blocks.Add(inserted);
          }
        }
      } 
    }

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
