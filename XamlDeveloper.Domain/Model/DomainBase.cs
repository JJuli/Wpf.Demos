namespace XamlDeveloper.Domain.Model {
    using System;

    public abstract class DomainBase : BindableBase {

        String _createdBy = String.Empty;
        DateTime _dateCreated;
        DateTime? _dateModified;
        String _modifiedBy = String.Empty;
        Byte[] _timestamp;

        public String CreatedBy {
            get { return _createdBy; }
            set {
                _createdBy = value;
                RaisePropertyChanged();
            }
        }

        public DateTime DateCreated {
            get { return _dateCreated; }
            set {
                _dateCreated = value;
                RaisePropertyChanged();
            }
        }

        public DateTime? DateModified {
            get { return _dateModified; }
            set {
                _dateModified = value;
                RaisePropertyChanged();
            }
        }

        public String ModifiedBy {
            get { return _modifiedBy; }
            set {
                _modifiedBy = value;
                RaisePropertyChanged();
            }
        }

        public Byte[] Timestamp {
            get { return _timestamp; }
            set {
                _timestamp = value;
                RaisePropertyChanged();
            }
        }

        protected DomainBase() {
        }

    }
}
