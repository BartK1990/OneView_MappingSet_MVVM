using System;
using System.Globalization;
using System.Windows.Data;

namespace OneView_MappingSet_MVVM.UI.View.Converters
{
    [ValueConversion(typeof(int), typeof(bool))]
    public class IsCheckedToIntegerConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(bool?))
                throw new InvalidOperationException("The target must be a Nullable<Boolean>");
            return int.Parse((string)parameter) == (int)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(int))
                throw new InvalidOperationException("The target must be a integer");
            return int.Parse((string)parameter);
        }

        #endregion
    }
}
