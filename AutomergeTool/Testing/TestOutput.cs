using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AutomergeTool
{
  public class TestOutput
  {
    public TestOutput()
    {
      TestData td = new TestData();
      StreamWriter source = File.CreateText("source.txt");
      StreamWriter user1 = File.CreateText("user1.txt");
      StreamWriter user2 = File.CreateText("user2.txt");

      td.Init3(5000);

      Save(source, td.Source);
      Save(user1, td.User1);
      Save(user2, td.User2);
    }

    private void Save(StreamWriter source, List<string> list)
    {
      foreach (string item in list)
      {
        source.WriteLine(item);        
      }
      source.Close();
    }
  }
}
