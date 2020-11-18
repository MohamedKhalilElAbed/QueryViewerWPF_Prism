using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace Client.G_Converters
{
    public class IntToStringConverter : IValueConverter
    {
        public int EmptyStringValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;
            else if (value is string)
                return value;
            else if (value is int && (int)value == EmptyStringValue)
                return string.Empty;
            else
                return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string)
            {
                string s = (string)value;
                int result;
                if (int.TryParse(s, out result))
                    return result;
                else
                    return EmptyStringValue;
            }
            return value;
        }
    }
}
