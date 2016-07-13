namespace Wpf.Validation.Infrastructure {
    using System;
    using Wpf.Common.Infrastructure;

    /// <summary>
    /// Represents ViewValidationError
    /// </summary>
    public class ViewValidationError {

        /// <summary>
        /// Gets or sets the name of the data item.
        /// </summary>
        /// <value>The name of the data item.</value>
        public String DataItemName { get; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        public String ErrorMessage { get; }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        public String Key => $"{this.DataItemName}:{this.PropertyName}";

        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>The name of the property.</value>
        public String PropertyName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewValidationError"/> class.
        /// </summary>
        /// <param name="dataItemName">Name of the data item.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errorMessage">The error message.</param>
        public ViewValidationError(String dataItemName, String propertyName, String errorMessage) {
            this.DataItemName = dataItemName;
            this.PropertyName = propertyName;
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Create an error message with properties separated by white space
        /// </summary>
        public String ToErrorMessage() {
            return String.Concat(CamelCaseString.GetWords(this.PropertyName), Constants.StringWhiteSpace, this.ErrorMessage);
        }

        /// <summary>
        /// Create a friendly error message.
        /// </summary>
        public String ToFriendlyErrorMessage() {
            String errorMessage;

            if (this.ErrorMessage.Contains("not recognized as a valid DateTime")) {
                errorMessage = "date is not a valid format";
            } else if (this.ErrorMessage.Contains("not in a correct format.")) {
                errorMessage = "entered value is not the correct data type";

                //TODO - developers - add more ElseIf tests here if required to return back the best message possible without using the default
            } else {
                errorMessage = this.ErrorMessage;
            }

            var propertyName = CamelCaseString.GetWords(this.PropertyName.Contains(".") ? this.PropertyName.Substring(this.PropertyName.LastIndexOf(".") + 1) : this.PropertyName);

            return string.Concat(propertyName, Constants.StringWhiteSpace, errorMessage);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override String ToString() {
            return $"DataItem {this.DataItemName}, PropertyName {this.PropertyName}, Error {this.ErrorMessage}";
        }

    }
}
