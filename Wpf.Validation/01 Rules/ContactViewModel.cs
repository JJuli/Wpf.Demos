namespace Wpf.Validation.Rules {
    using System;
    using System.Windows;
    using System.Windows.Input;
    using Wpf.Common.Infrastructure;
    using Wpf.Validation.Infrastructure;
    using Wpf.Validation.Model;

    public class ContactViewModel : MaintenanceFormViewModelBase {

        Contact _contact;
        ICommand _newCommand;
        ICommand _saveCommand;

        public Contact Contact {
            get { return _contact; }
            set {
                _contact = value;
                RaisePropertyChanged();
            }
        }

        public ICommand NewCommand => _newCommand ?? (_newCommand = new RelayCommand(NewExecute));

        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new RelayCommand(SaveExecute, CanSaveExecute));

        public ContactViewModel() {
            _contact = new Contact {Birthday = new DateTime(1990, 11, 1), FirstName = "Albert", LastName = "Smith", NumberOfComputers = 2};
        }

        Boolean CanSaveExecute() {
            return this.Contact?.Errors.Count == 0;
        }

        void NewExecute() {
            //TODO: Technically you should save old one,etc  
            this.Contact = new Contact();
        }

        void SaveExecute() {
            //In a real application implement saving the Contact to the database
            //In M-V-VM applications the ViewModel does not raise UI Message Boxes.
            //  Instead, a Logger or Dialog service is used.
            MessageBox.Show("Saved");
        }

    }
}
