namespace Wpf.DataBinding.Infrastructure {
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    [ValueConversion(typeof(Boolean), typeof(Brush))]
    public class IsActiveToBrushConverter : IValueConverter {

        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) {
            if (value != null && value is Boolean && (Boolean)value) {
                return new SolidColorBrush(Colors.Black);
            }
            return new SolidColorBrush(Colors.Gray);
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

    }
}
