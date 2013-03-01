using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomergeTool
{
  public enum Type
  {
    conflict,
    shared,
    inserted,
    deleted
  }

  abstract public class Block
  {
    public Type Type { get; set; }
    public abstract List<String> Data { get; }
    //abstract public void GetText();
  }
}
