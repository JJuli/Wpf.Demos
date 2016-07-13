namespace Wpf.Common.Controls {
    using System.Windows;
    using System.Windows.Controls;

    public class StopLight : Control {

        public Light Light {
            get { return (Light)GetValue(LightProperty); }
            set { SetValue(LightProperty, value); }
        }

        public static readonly DependencyProperty LightProperty =
            DependencyProperty.Register("Light", typeof(Light), typeof(StopLight), new PropertyMetadata(Light.Green));

        static StopLight() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StopLight), new FrameworkPropertyMetadata(typeof(StopLight)));
        }

    }
}
