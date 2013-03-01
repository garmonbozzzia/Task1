using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WpfApp
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    public AutomergeTool.Processor AutomergeTool { get; set; }

    public MainWindow()
    {
      InitializeComponent();
      AutomergeTool = (AutomergeTool.Processor)DataContext;

    }

    private void TextBlock_DragEnter(object sender, DragEventArgs e)
    {

    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      Button button = (Button)sender;
      OpenFileDialog dialog = new OpenFileDialog();
      if (dialog.ShowDialog() == true)
      { 
        AutomergeTool.SourceCode sc = (AutomergeTool.SourceCode)button.DataContext;
        AutomergeTool.StreamInputParser parser = new AutomergeTool.StreamInputParser(dialog.FileName);
        parser.ParseTo(sc.Data);
        button.Content = button.Content.ToString() + ": Loaded!";
        button.IsEnabled = false;
      }

      AutomergeTool.Merge();
      itemsControl1.Items.Refresh();
            
    }
  }
}
