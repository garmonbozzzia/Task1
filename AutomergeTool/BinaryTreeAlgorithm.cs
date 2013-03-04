using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomergeTool
{
  public class BinaryTreeAlgorithm : IMarkerAlgorithm
  {
    List<String> Source { get; set; }
    List<String> User { get; set; }

    public int Count { get; set; }

    public void Do(Marker marker)
    {
      Source = marker.SourceData;
      User = marker.UserData;
      Count = 0;

      marker.Mapping = Action(0, Source.Count, 0, User.Count);
    }

    void TailConstruction(ref int sourceStart, ref int sourceCount, ref int userStart, ref int userCount)
    {
      
    }

    void Fit(ref int sourceStart, ref int sourceCount, ref int userStart, ref int userCount)
    {
      try
      {
        if (userCount == 0 || sourceCount == 0)
        {
          return;
        }

        int index = User.IndexOf(Source[sourceStart], userStart, userCount);
        
        while (index == -1 && sourceCount > 1)
        {
          sourceStart++;
          sourceCount--;
          index = User.IndexOf(Source[sourceStart], userStart, userCount);
        }

        index = User.IndexOf(Source[sourceStart + sourceCount - 1], userStart, userCount);
        while (index == -1 && sourceCount > 1)
        {
          sourceCount--;
          index = User.IndexOf(Source[sourceStart + sourceCount - 1], userStart, userCount);
        }

        index = Source.IndexOf(User[userStart], sourceStart, sourceCount);
        while (index == -1 && userCount > 1)
        {
          userStart++;
          userCount--;
          index = Source.IndexOf(User[userStart], sourceStart, sourceCount);
        }

        index = Source.IndexOf(User[userStart + userCount - 1], sourceStart, sourceCount);
        while (index == -1 && userCount > 1)
        {
          userCount--;
          index = Source.IndexOf(User[userStart + userCount - 1], sourceStart, sourceCount);
        }
      }
      catch { }
    }

    List<Link> Action(int sourceStart, int sourceCount, int userStart, int userCount )
    {
      List<Link> result = new List<Link>();
      Count++;


      Fit(ref sourceStart, ref sourceCount, ref userStart, ref userCount);

      if (sourceCount == 0 || userCount == 0)
      {
        return result;
      }

      if (sourceCount == 1)
      {
        int index = User.IndexOf(Source[sourceStart], userStart, userCount);
        if (index > -1)
        {
          result.Add(new Link() { SourceLineIndex = sourceStart, UserLineIndex = index });
        }
      }
      else
      {
        int sourceCenter = sourceCount / 2;

        for (int userCenter = 0; userCenter < userCount; userCenter++)
        {
          List<Link> subtree1 = Action(sourceStart, sourceCenter, userStart, userCenter);
          List<Link> subtree2 = Action(sourceStart + sourceCenter, sourceCount - sourceCenter, userStart + userCenter, userCount - userCenter);

          if (subtree1.Count + subtree2.Count > result.Count)
          {
            result = subtree1;
            result.AddRange(subtree2);
          }
        }
      }      
      return result;
    }
  }
}
