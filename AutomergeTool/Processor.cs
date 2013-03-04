using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomergeTool
{
  public class Processor
  {
    public SourceCode SourceCode { get; set; }
    public SourceCode UserCode1 { get; set; }
    public SourceCode UserCode2 { get; set; }
    public MergedCode MergedCode { get; set; }

    public Processor()
    {
      try
      {
        SourceCode = new SourceCode();
        UserCode1 = new SourceCode();
        UserCode2 = new SourceCode();
        MergedCode = new MergedCode();
        MergedCode.Source = SourceCode;

        TestData test = new TestData();
        test.Init0(1500);
        test.User2 = test.Source;

        SourceCode.Data = test.Source;
        UserCode1.Data = test.User1;
        UserCode2.Data = test.User2;

        MarkedUserCode markedCode1 = new MarkedUserCode(SourceCode, UserCode1);
        MarkedUserCode markedCode2 = new MarkedUserCode(SourceCode, UserCode2);

        MergedCode.User1 = markedCode1;
        MergedCode.User2 = markedCode2;
        MergedCode.Merge();

      }
      catch (Exception)
      {               
        throw;
      }
      //mergedCode.User1 = new UserCode
    }

    public void Merge()
    {      
      MarkedUserCode markedCode1 = new MarkedUserCode(SourceCode, UserCode1);
      MarkedUserCode markedCode2 = new MarkedUserCode(SourceCode, UserCode2);
      MergedCode.User1 = markedCode1;
      MergedCode.User2 = markedCode2;      
      MergedCode.Merge();
    }
  }
}

