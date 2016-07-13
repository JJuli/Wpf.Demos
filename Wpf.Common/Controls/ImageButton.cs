namespace Wpf.Common.Controls {
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public class ImageButton : Button {

        public ImageSource Image {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public double ImageHeight {
            get { return (double)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }

        public double ImageWidth {
            get { return (double)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }

        public static readonly DependencyProperty ImageHeightProperty = DependencyProperty.Register("ImageHeight", typeof(double), typeof(ImageButton), new PropertyMetadata(Double.NaN));
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null));
        public static readonly DependencyProperty ImageWidthProperty = DependencyProperty.Register("ImageWidth", typeof(double), typeof(ImageButton), new PropertyMetadata(Double.NaN));

        static ImageButton() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

    }
}
