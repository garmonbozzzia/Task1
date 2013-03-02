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

    void Init1()
    {
      Source = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
      User1 = new List<string>() { "6", "7", "8", "9", "3", "4", "5", "1", "2", "0" };
      User2 = new List<string>() { "B", "B", "B", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "B" };    
    }

    void Init2()
    {
      Source.Clear();
      for (int i = 0; i < 1000; i++)
      {
        Source.Add(i.ToString());
      }
      User1 = Source;
      User2.Clear();

      for (int i = 0, k = 1; i < Source.Count; i += k, ++k)
      {
        List<string> subseq = new List<string>();
        for (int j = 0; j < k; j++)
        {
          subseq.Add((i + j).ToString());
        }

        User2.InsertRange(0, subseq);
      }    
    }

    public TestData()
    {
      Source = new List<string>();
      User1 = new List<string>();
      User2 = new List<string>();

      Init2();
    }
  }
}
