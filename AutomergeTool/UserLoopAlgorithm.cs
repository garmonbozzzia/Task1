using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomergeTool
{
  public class UserLoopAlgorithm : IMarkerAlgorithm
  {
    class Arguments
    {
      public Arguments()
      {
        SourceStart = 0;
        UserStart = 0;
      }

      public int SourceStart { get; set; }
      public int UserStart { get; set; }
      public List<Link> ResultTail { get; set; }
    }

    List<Arguments> Branches { get; set; }
    public int Count { get; set; }

    public List<String> Source { get; set; }
    public List<String> User { get; set; }

    List<Link> longest = new List<Link>();

    public void Do(Marker marker)
    {
      Count = 0;
      Source = marker.SourceData;
      User = marker.UserData;
      Branches = new List<Arguments>();

      Branches.Add(new Arguments() );
      Branches[0].ResultTail = new List<Link>();
      ConstructLongest();

      while (Branches.Count > 0)
      {
        Count++;
        Action(Branches[0]);
        Branches.RemoveAt(0);              
      }

      marker.Mapping = longest;
      Console.WriteLine(Count);
    }

    void ConstructLongest()
    {
      int sourceStart = 0;
      for (int i = 0; i < User.Count && 0 < Source.Count; i++)
      {
        int index = Source.IndexOf(User[i], sourceStart);
        if (index != -1)
        {
          Link newLink = new Link() { SourceLineIndex = index, UserLineIndex = i };
          longest.Add(newLink);
          sourceStart = index + 1;
        }
      }
      
    }

    void Action(Arguments args)
    {
      if (IsNotLongest(args.ResultTail))
      {
        return;
      }
      for (int i = args.UserStart; i < User.Count && args.SourceStart < Source.Count ; i++)
      {
        int index = Source.IndexOf( User[i], args.SourceStart );
        if (index != -1)
        {
          if (CheckForBranches(args.SourceStart, index - args.SourceStart, i))
          {
            Arguments branchArgs = new Arguments();
            branchArgs.ResultTail = args.ResultTail.GetRange(0, args.ResultTail.Count);
            branchArgs.SourceStart = args.SourceStart;
            branchArgs.UserStart = i+1;
            Branches.Add(branchArgs);
          }
          Link newLink = new Link() { SourceLineIndex = index, UserLineIndex = i };
          args.ResultTail.Add(newLink);
          args.SourceStart = index + 1;

          if (IsNotLongest(args.ResultTail))
          {
            return;
          }
          //int linkIndex = longest.FindIndex(item => 
          //  item.SourceLineIndex == newLink.SourceLineIndex && item.UserLineIndex <= newLink.UserLineIndex);

          //if (args.ResultTail.Count < linkIndex)
          //{            
          //  return;
          //}          

                 
        }
      }

      if (args.ResultTail.Count >= longest.Count)
      {
        longest = args.ResultTail;
      }
    }

    private bool IsNotLongest(List<Link> tail)
    {
      if( tail.Count != 0 && longest.Count >= tail.Count)      
      {
        Link checkLink = longest[tail.Count - 1];

        return checkLink.SourceLineIndex <= tail.Last().SourceLineIndex 
          && checkLink.UserLineIndex <= tail.Last().UserLineIndex;
      }

      return false;
    }

    private bool SimpleCheckForBranches(int sourceStart, int sourceCount, int userStart)
    {
      return sourceCount != 1;
    }

    private bool CheckForBranches(int sourceStart, int sourceCount, int userStart)
    {
      for (int i = 0; i < sourceCount; i++)
      {
        int index = User.IndexOf( Source[sourceStart+i] );
        if (index != -1)
        {
          return true;
        }
      }
      return false;
    }

  }
}
