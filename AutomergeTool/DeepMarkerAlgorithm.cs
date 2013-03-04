using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomergeTool
{
  public class SequentialAlgorithm : IMarkerAlgorithm
  {
    class Arguments
    {
      public Arguments()
      {
        SourceStart = 0;
        UserStart = 0;
        ResultTail = new List<Link>();
      }

      public int SourceStart { get; set; }
      public int UserStart { get; set; }
      public List<Link> ResultTail { get; set; }
    }

    List<Arguments> Branches { get; set; }
    public List<String> Source { get; set; }
    public List<String> User { get; set; }

    List<Link> longest = new List<Link>();

    public SequentialAlgorithm ()
	  {
      Branches = new List<Arguments>();
	  }

    public void Do(Marker marker)
    {
      Source = marker.SourceData;
      User = marker.UserData;
      longest.Clear();
      int count = 0;

      Branches.Add(new Arguments());

      while (Branches.Count > 0)
      {
        Action(Branches[0]);
        Branches.RemoveAt(0);
        ++count;
      }
      
      marker.Mapping = longest;      
    }

    void Action(Arguments args)
    {
      List<Link> result = new List<Link>();
      int startFrom = args.UserStart;

      for (int i = args.SourceStart; i < Source.Count; ++i)
      {
        int index = User.IndexOf(Source[i], startFrom);
        if (index != -1)
        {
          List<String> tail = User.GetRange(startFrom, index - startFrom + 1);
          List<String> sourceTail = Source.GetRange(i + 1, Source.Count - i - 1);
          int tailRoot = TailRoot(tail, i+1);
          if ( tailRoot > -1)
          {
            Arguments param = new Arguments();
            param.ResultTail = result.GetRange(0, result.Count); //copy
            param.SourceStart = tailRoot;
            param.UserStart = startFrom;
            Branches.Add(param);
          }

          result.Add(new Link() { SourceLineIndex = i, UserLineIndex = index });            
          startFrom = index + 1;          
        }
      }

      if (result.Count > longest.Count)
      {
        longest = result;
      }
    }

    int TailRoot( List<String> tail, int sourceStart )
    {
      for (int i = sourceStart; i < Source.Count - 1; i++)
      {
        int index = tail.IndexOf(Source[i]);
        if (index != -1 && index + 1 < tail.Count - 1)
	      {
		      for (int j = i + 1; j < Source.Count; j++)
          {
            if (-1 != tail.IndexOf(Source[j], index + 1))
            {
              return i;
            }
          }
	      }        
      }
      return -1;
    }
  }
}
