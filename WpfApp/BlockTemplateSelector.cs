using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace WpfApp
{
  public class BlockTemplateSelector : DataTemplateSelector
  {
    public DataTemplate Shared { get; set; }
    public DataTemplate Deleted { get; set; }
    public DataTemplate Conflict { get; set; }
    public DataTemplate Inserted { get; set; }

    private Dictionary<AutomergeTool.Type, DataTemplate> templates;

    public BlockTemplateSelector()
    {

    }

    private void Init()
    {
      templates = new Dictionary<AutomergeTool.Type, DataTemplate>();
      templates.Add(AutomergeTool.Type.conflict, Conflict);
      templates.Add(AutomergeTool.Type.deleted, Deleted);
      templates.Add(AutomergeTool.Type.inserted, Inserted);
      templates.Add(AutomergeTool.Type.shared, Shared);
    }

    public override DataTemplate SelectTemplate( object obj, DependencyObject container)
    {
      if (templates == null) { Init(); }
      AutomergeTool.Block block = (AutomergeTool.Block)obj;      
      return templates[block.Type];
    }
  }
}
