using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomergeTool
{
  public class MergedCode
  {
    public SourceCode Source { get; set; }
    public MarkedUserCode User1 { get; set; }
    public MarkedUserCode User2 { get; set; }

    public List<Block> Result{ get; set; }

    public List<String> DebugResult
    {
      get
      {
        List<String> result = new List<string>();
        foreach (Block block in Result)
        {
          foreach (String item in block.Data)
          {
            result.Add(item);
          }
        }
        return result;
      }
    }

    public MergedCode()
    {
      Result = new List<Block>();
    }

    void FindSharedSourceLines( List<int> result )
    {
      foreach (Link mapping in User1.Mapping)
      {
        if (User2.Mapping.Exists( item => item.SourceLineIndex == mapping.SourceLineIndex ) )
        {
          result.Add(mapping.SourceLineIndex);          
        }
      }
    }

    public void Merge()
    {
      List<int> sharedLines = new List<int>();
      FindSharedSourceLines(sharedLines);

      int start = -1;

      foreach (int index in sharedLines)
      {
        Process(start, index);   
        start = index;
        AddSharedLine(index);
      }
      Process(start, Source.Data.Count );      
    }

    void Process(int start, int index)
    {
      //проверяем на конфликт
      if (CheckConflict(start, index-1))
      {
        ConflictBlock conflict = new ConflictBlock(User1, User2) { First = start, Last = index };
        Result.Add(conflict);

        if (index - start > 1)
        {
          Result.Add(new DeletedBlock(start + 1, index - 1) { Type = Type.deleted });
        }
      }
      else
      {
        for (int i = start; i < index; i++)
        {
          InsertedBlock inserted = GetInsertedBlock(i);
          if (inserted != null)
          {
            Result.Add(inserted);            
          }
          if (i > start)
          {
            AddDeletedLine(i);
          }
        }
      }
    }

    private void AddDeletedLine(int index)
    {
      if ( Result.Count == 0 || Result.Last().Type != Type.deleted )
      {
        Result.Add(new DeletedBlock(index));
      }
      else
      {
        ((DeletedBlock)Result.Last()).Last = index;        
      }
    }

    private void AddSharedLine(int index)
    {
      if (Result.Count == 0 || Result.Last().Type != Type.shared)
      {
        Result.Add(new SharedBlock(index, Source));        
      }
      else
      {
        ((SharedBlock)Result.Last()).Last = index;
      }
    }
      
    InsertedBlock GetInsertedBlock( int index )
    {          
      InsertedBlock result;
      result = User1.GetInsertedBlock(index);
      if (result == null)
	    {
        result = User2.GetInsertedBlock(index);		 
	    }

      return result;
    }
    
    private bool CheckConflict(int first, int last)
    {
      return User1.HasInsertedBlocks(first, last) && User2.HasInsertedBlocks(first, last); 
    }
  }
}
