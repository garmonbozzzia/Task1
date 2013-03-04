using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AutomergeTool
{
  public class StreamInputParser : IInputParser
  {
    private Stream stream;

    String Filename { get; set; }
    public StreamInputParser( String fileName) 
    {
      Filename = fileName;
    }

    public StreamInputParser(Stream stream)
    {
      this.stream = stream;
    }

    public void ParseTo( List<string> result)
    {
      StreamReader stream = File.OpenText(Filename);
      result.Clear();
      while (!stream.EndOfStream)
      {
        String str = stream.ReadLine();
        if (!String.IsNullOrEmpty(str))
        {
          result.Add(str);
        }
      }
      stream.Close();
    }
  }
}
