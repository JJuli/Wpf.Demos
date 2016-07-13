namespace Wpf.Common.Infrastructure {
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    /// <summary>
    ///     Represents ObservableObject, provides base implementation for INPC
    /// </summary>
    [Serializable]
    public abstract class ObservableObject : INotifyPropertyChanged {

        /// <summary>
        ///     Occurs when a property value changes.
        /// </summary>
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Warns the developer if this Object does not have a public property with
        ///     the specified name. This method does not exist in a Release build.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(String propertyName) {
            Debug.Assert(this.GetType().GetProperty(propertyName) != null, "Invalid property name: " + propertyName);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ObservableObject" /> class.
        /// </summary>
        protected ObservableObject() {
        }

        /// <summary>
        ///     Raises the <see cref="PropertyChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs" /> instance containing the event data.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e) {
            PropertyChanged?.Invoke(this, e);
        }

        /// <summary>
        ///     Verifies the property name exists, calls OnPropertyChanged.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void RaisePropertyChanged([CallerMemberName] String propertyName = null) {
            VerifyPropertyName(propertyName);
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

    }
}
