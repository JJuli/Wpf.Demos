namespace Wpf.Validation.Infrastructure {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Wpf.Common.Infrastructure;

    /// <summary>
    /// Represents the MaintenanceFormViewModelBase.  
    /// Provides UI Validation Error Management; keeps the view model informed of all exceptions thrown in the data binding pipeline in the view and view model.
    /// Provides properties for surfacing validation and data binding pipeline exceptions to the view.
    /// </summary>
    public abstract class MaintenanceFormViewModelBase : ObservableObject {

        readonly IDictionary<String, ViewValidationError> _viewValidationErrorDictionary = new Dictionary<String, ViewValidationError>();

        /// <summary>
        /// Gets the view validation error count.
        /// </summary>
        /// <value>The view validation error count.</value>
        public Int32 ViewValidationErrorCount => _viewValidationErrorDictionary.Count;

        /// <summary>
        /// Gets the view validation error messages.
        /// </summary>
        /// <value>The view validation error messages.</value>
        public String ViewValidationErrorMessages {
            get {
                if (this.ViewValidationErrorCount == 0) {
                    return String.Empty;
                }

                var sb = new StringBuilder();
                foreach (var kvp in _viewValidationErrorDictionary) {
                    sb.AppendLine(kvp.Value.ToFriendlyErrorMessage());
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Adds the view validation error.
        /// </summary>
        /// <param name="e">The e <see cref="ViewValidationError"/></param>
        public void AddViewValidationError(ViewValidationError e) {
            _viewValidationErrorDictionary.Add(e.Key, e);
            RaisePropertyChanged("ViewValidationErrorMessages");
            RaisePropertyChanged("ViewValidationErrorCount");
        }

        /// <summary>
        /// Removes the view validation error.
        /// </summary>
        /// <param name="e">The e <see cref="ViewValidationError"/></param>
        public void RemoveViewValidationError(ViewValidationError e) {
            _viewValidationErrorDictionary.Remove(e.Key);
            RaisePropertyChanged("ViewValidationErrorMessages");
            RaisePropertyChanged("ViewValidationErrorCount");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MaintenanceFormViewModelBase"/> class.
        /// </summary>
        protected MaintenanceFormViewModelBase() {
        }

        /// <summary>
        /// Clears all view validation errors.
        /// </summary>
        protected void ClearViewValidationErrors() {
            _viewValidationErrorDictionary.Clear();
            RaisePropertyChanged("ViewValidationErrorMessages");
            RaisePropertyChanged("ViewValidationErrorCount");
        }

    }
}
