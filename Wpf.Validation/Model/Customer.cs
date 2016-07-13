namespace Wpf.Validation.Model {
    using System;
    using Wpf.Common.Infrastructure;

    public class Customer : ObservableObject {

        String _firstName;
        String _lastName;

        public String FirstName {
            get { return _firstName; }
            set {
                _firstName = value;
                RaisePropertyChanged();
            }
        }

        public String LastName {
            get { return _lastName; }
            set {
                _lastName = value;
                RaisePropertyChanged();
            }
        }

        public Customer() {
        }

    }
}
