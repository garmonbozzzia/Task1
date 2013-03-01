using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomergeTool
{
  public class MarkedUserCode
  {
    public SourceCode UserCode { get; set; }
    public SourceCode SourceCode { get; set; }

    public List<InsertedBlock> InsertedBlocks { get; set; }
    public List<Link> Mapping { get; set; }


    public MarkedUserCode(SourceCode source, SourceCode user)
    {
      UserCode = user;
      SourceCode = source;

      Mapping = (new Marker(user.Data, source.Data).Mapping);
      InsertedBlocks = new List<InsertedBlock>();

      FindInsertedBlocks();
    }

    private void FindInsertedBlocks()
    {
      Link lastLink = new Link() { SourceLineIndex = -1, UserLineIndex = -1 };
      foreach (Link link in Mapping)
      {
        if (lastLink.UserLineIndex + 1 < link.UserLineIndex )
        {
          InsertedBlock inserted = new InsertedBlock(UserCode);
          inserted.After = lastLink.SourceLineIndex;
          inserted.FirstLine = lastLink.UserLineIndex + 1;
          inserted.LastLine = link.UserLineIndex - 1;
          InsertedBlocks.Add(inserted);
        }
        lastLink = link;
      }
      if (lastLink.UserLineIndex < UserCode.Data.Count - 1)
      {
        InsertedBlock inserted = new InsertedBlock(UserCode);
        inserted.After = lastLink.SourceLineIndex;
        inserted.FirstLine = lastLink.UserLineIndex + 1;
        inserted.LastLine = UserCode.Data.Count - 1;
        InsertedBlocks.Add(inserted);
      }
    }

    public InsertedBlock GetInsertedBlock(int index)
    {
      return InsertedBlocks.Find( item => item.After == index);
    }

    public bool HasInsertedBlocks(int first, int last)
    {
      return InsertedBlocks.Find(item => (item.After >= first) && (item.After <= last)) != null;
    }
  }
}
