namespace WpfDesignTimeData.Model {
    using System;
    using System.ComponentModel;
    using System.Windows;

    public abstract class ViewModelBase : BindableBase {

        public Boolean IsInDesignMode => DesignerProperties.GetIsInDesignMode(new DependencyObject());

        protected ViewModelBase() {
        }

    }
}
