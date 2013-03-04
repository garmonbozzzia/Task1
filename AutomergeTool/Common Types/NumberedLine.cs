using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomergeTool.Common_Types
{
  public class NumberedLine
  {
    public int SourceLine { get; set; }
    public int User1Line { get; set; }
    public int User2Line { get; set; }

    public String Prefix { get; set; }
    public String Body { get; set; }
    public String Suffix { get; set; }

    public NumberedLine()
    {
      SourceLine = -1;
      User1Line = -1;
      User2Line = -1;
    }
  }
}
