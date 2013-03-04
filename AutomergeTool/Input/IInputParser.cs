using System;
using System.Collections.Generic;

namespace AutomergeTool
{
  public interface IInputParser
  {
    void ParseTo( List<string> result);
  }
}
