namespace Wpf.Common.Infrastructure {
    using System;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;

    public static class FocusExtension {

        public static Boolean GetIsFocused(DependencyObject obj) {
            return (Boolean)obj.GetValue(IsFocusedProperty);
        }

        public static readonly DependencyProperty IsFocusedProperty =
            DependencyProperty.RegisterAttached(
                "IsFocused", typeof(Boolean), typeof(FocusExtension),
                new UIPropertyMetadata(false, OnIsFocusedPropertyChanged));

        public static void SetIsFocused(DependencyObject obj, Boolean value) {
            obj.SetValue(IsFocusedProperty, value);
        }

        static void OnIsFocusedPropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e) {
            var uie = (UIElement)d;
            if ((Boolean)e.NewValue) {
                uie.Dispatcher?.BeginInvoke(DispatcherPriority.Normal, (Action)(() => {
                    uie.Focus();
                    Keyboard.Focus(uie);
                }));
            }
        }

    }
}
