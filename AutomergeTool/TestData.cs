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
      Source = new List<string>();
      for (int i = 0; i < 10; i++)
      {
        Source.Add(i.ToString());
      }

      User1 = new List<string>();
      User2 = new List<string>();

      for (int i = 0; i < 9; i++)
      {
        User1.Add(i.ToString());
        if (i < 5)
        {
          User1.Add("A");
          User1.Add("A");
          User1.Add("A");
        } 
      }

      for (int i = 1; i < 10; i++)
      {
        User2.Add(i.ToString());
        if (i > 4)
        {
          User2.Add("B");
        }
      }
    }
  }
}
