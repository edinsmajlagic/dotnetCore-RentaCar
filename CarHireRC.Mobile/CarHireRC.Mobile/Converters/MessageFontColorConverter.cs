using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace CarHireRC.Mobile.Converters
{
    public class MessageFontColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Label procitano = (Label)parameter;
            string posiljaoc = (string)value;

            if (procitano.Text == "False" && posiljaoc=="Uposlenik")
                return "Black";
            else
                return "Gray";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
