namespace Wpf.DataBinding.Model {
    using System;
    using Wpf.Common.Infrastructure;

    public class Person : ObservableObject {

        DateTime? _birthday;
        String _favoriteChairThumbnail;
        String _firstName;
        Boolean _isActive;
        String _lastName;
        String _profession;

        public DateTime? Birthday {
            get { return _birthday; }
            set {
                _birthday = value;
                RaisePropertyChanged();
            }
        }

        public String FavoriteChairThumbnail {
            get { return _favoriteChairThumbnail; }
            set {
                _favoriteChairThumbnail = value;
                RaisePropertyChanged();
            }
        }

        public String FirstName {
            get { return _firstName; }
            set {
                _firstName = value;
                RaisePropertyChanged();
            }
        }

        public Boolean IsActive {
            get { return _isActive; }
            set {
                _isActive = value;
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

        public String Profession {
            get { return _profession; }
            set {
                _profession = value;
                RaisePropertyChanged();
            }
        }

        public Person() {
        }

        //Note:  ToString is NOT dynamically updated in the UI like an INotifyPropertyChanged property
        public override string ToString() {
            return (String.Concat(_firstName, " ", _lastName)).Trim();
        }

    }
}
