namespace XamlDeveloper.Presentation.Converters {
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    [ValueConversion(typeof(Object), typeof(Visibility))]
    public class ObjectNullToVisibilityConverter : IValueConverter {
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) {
            if (value == null) {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture) {
            return DependencyProperty.UnsetValue;
        }
    }

}