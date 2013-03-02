using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomergeTool
{
  public class TestData
  {
    public List<String> User1 { get; set; }
    public List<String> User2 { get; set; }
    public List<String> Source { get; set; }

    public TestData()
    {
      Source = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
      User1 = new List<string>() { "5", "6", "7", "8", "9", "0", "1", "2", "A", "3" };
      User2 = new List<string>() { "B", "B", "B", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "B" };
    }
  }
}
