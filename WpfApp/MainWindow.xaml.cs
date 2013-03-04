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

    public AutomergeTool.Processor AutomergeProcessor { get; set; }

    public MainWindow()
    {
      TestingList();
      InitializeComponent();
      AutomergeProcessor = (AutomergeTool.Processor)DataContext;
      AutomergeTool.TestData test = new AutomergeTool.TestData();
      test.Init3(500);

      //AutomergeProcessor.SetSource(test.Source);
      //AutomergeProcessor.SetUser1(test.User1);
      //AutomergeProcessor.SetUser2(test.Source);

      //AutomergeProcessor.Merge();
      
      itemsControl1.Items.Refresh();

    }

    public void TestingList()
    {
      List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
      for (int i = 0; i < list.Count; i++)      
      {
        if (i < 3)
        {
          list.Add(10);                
        }
      }
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

      AutomergeProcessor.Merge();
      itemsControl1.Items.Refresh();
            
    }
  }
}
