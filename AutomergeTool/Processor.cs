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



      }
      catch (Exception)
      {               
        throw;
      }
      //mergedCode.User1 = new UserCode
    }

    public void SetSource(IInputParser parser)
    {
      parser.ParseTo(SourceCode.Data);
      SetSource(SourceCode.Data);
    }

    public void SetSource(List<String> data)
    {
      //SourceCode = new SourceCode();
      SourceCode.Data = data;

      if (UserCode1 != null)
      {
        MergedCode.User1 = new MarkedUserCode(SourceCode, UserCode1);
      }

      if (UserCode2 != null)
      {
        MergedCode.User2 = new MarkedUserCode(SourceCode, UserCode2);
      }

    }

    public void SetUser1(IInputParser parser)
    {
      parser.ParseTo(UserCode1.Data);
      SetUser1(UserCode1.Data);    
    }

    public void SetUser1(List<String> data)
    {
      //UserCode1 = new SourceCode();
      UserCode1.Data = data;
      if (SourceCode != null)
      {
        //MergedCode.User1 = new MarkedUserCode(SourceCode, UserCode1);
      }
    }

    public void SetUser2(IInputParser parser)
    {
      parser.ParseTo(UserCode2.Data);
      SetUser2(UserCode2.Data);
    }

    public void SetUser2(List<String> data)
    {
      //UserCode2 = new SourceCode();
      UserCode2.Data = data;
      if (SourceCode != null)
      {
        //MergedCode.User2 = new MarkedUserCode(SourceCode, UserCode2);
      }
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

