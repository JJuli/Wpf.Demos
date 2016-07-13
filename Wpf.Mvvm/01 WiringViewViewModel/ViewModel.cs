namespace Wpf.Mvvm.WiringViewViewModel {
    using System;
    using System.Windows.Input;
    using Wpf.Common.Infrastructure;
    using Wpf.Mvvm.Model;

    public class ViewModel : ObservableObject {

        String _message;
        Person _person = new Person();
        ICommand _saveCommand;

        public String Message {
            get { return _message; }
            private set {
                _message = value;
                RaisePropertyChanged();
            }
        }

        public Person Person {
            get { return _person; }
            set {
                _person = value;
                RaisePropertyChanged();
            }
        }

        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new RelayCommand<Person>(SaveExecute));

        public ViewModel() {
        }

        void SaveExecute(Person person) {
            this.Message = $"{person.FirstName} {person.LastName} saved to database.";
        }

    }
}
