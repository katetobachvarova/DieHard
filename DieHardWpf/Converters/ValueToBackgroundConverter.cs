using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace DieHardWpf.Converters
{
    public class ValueToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            int input = -1;
            try
            {

                if (value is DataGridCell)
                {
                    DataGridCell dgc = (DataGridCell)value;
                    DataRowView rowView = (DataRowView)dgc.DataContext;
                    //input = (int)rowView.Row.ItemArray[dgc.Column.DisplayIndex];
                    input = int.Parse(rowView.Row.ItemArray[dgc.Column.DisplayIndex] as string);
                }
            }
            catch (Exception ex)
            {
                return DependencyProperty.UnsetValue;

            }
            switch (input)
            {
                case 1: return Brushes.Red;
                //case 0: return Brushes.White;
                //case -1: return Brushes.Blue;
                default: return DependencyProperty.UnsetValue;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
