namespace XamlDeveloper.Domain.Model {
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class BindableBase : INotifyPropertyChanged {

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
