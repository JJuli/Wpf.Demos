namespace XamlDeveloper.Presentation.Converters {
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    public class ValueToBrushConverter : IValueConverter {

        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) {
            if (value == null) {
                return new SolidColorBrush(Colors.Red);
            }
            var sliderValue = System.Convert.ToSingle(value);

            return new SolidColorBrush(ConvertIntegerToColor(sliderValue, 0, 255));
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

        Color ConvertIntegerToColor(Single inputValue, Single redValue, Single blueValue) {
            var value = (Int32)(1023 * (inputValue - redValue) / (blueValue - redValue));

            if (value < 256) {
                return Color.FromRgb(255, (Byte)value, 0);
            } else if (value < 512) {
                value = value - 256;
                return Color.FromRgb((Byte)(255 - value), 255, 0);
            } else if (value < 768) {
                value = value - 512;
                return Color.FromRgb(0, 255, (Byte)value);
            } else {
                value = value - 768;
                return Color.FromRgb(0, (Byte)(255 - value), 255);
            }
        }

    }
}
