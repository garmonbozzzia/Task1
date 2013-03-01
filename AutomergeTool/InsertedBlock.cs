using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomergeTool
{
  public class InsertedBlock : Block
  {
    public SourceCode Source { get; set; }
    public InsertedBlock( SourceCode source )
    {
      Source = source;
      Type = Type.inserted;
    }
    public int After { get; set; }

    public int FirstLine { get; set; }
    public int LastLine { get; set; }
    public int Count { get { return LastLine - FirstLine + 1; } }

    public override List<string> Data
    {
      get 
      {
        return Source.Data.GetRange(FirstLine, Count);
      }
    }
  }
}
