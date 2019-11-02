using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MobileApp.Converters
{
  public class FirstValidationErrorConverter : Xamarin.Forms.IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      IEnumerable<string> errors = value as IEnumerable<string>;
      return errors != null && errors.Count() > 0 ? errors.ElementAt(0) : null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
