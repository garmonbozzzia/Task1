using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;

namespace WpfApp
{
  [ValueConversion(typeof(object), typeof(AutomergeTool.Type))]
  public class TypeToColorConverter : IValueConverter
  {
    static private Dictionary<AutomergeTool.Type, SolidColorBrush> colors = new Dictionary<AutomergeTool.Type, SolidColorBrush>(){
      { AutomergeTool.Type.conflict, new SolidColorBrush(Colors.DarkRed) },
      { AutomergeTool.Type.inserted, new SolidColorBrush(Colors.DarkGreen)},
      { AutomergeTool.Type.deleted, new SolidColorBrush(Colors.Black) },
      { AutomergeTool.Type.shared, new SolidColorBrush(Colors.LightGray) },
    };

    public TypeToColorConverter()
    {

    }

    public object Convert(object value, Type targetType,
        object parameter, CultureInfo culture)
    {
      AutomergeTool.Type type = (AutomergeTool.Type)value;      
      return colors[type];
    }

    public object ConvertBack(object value, Type targetType,
        object parameter, CultureInfo culture)
    {
      return null;
    }
  }
}
