namespace XamlDeveloper.Domain.Model {
    using System;

    public class Season : DomainBase {

        Int32 _beginMonth;
        Int32 _endMonth;
        String _name;
        Int32 _seasonIdent;
        Int32 _sortOrder;

        public Int32 BeginMonth {
            get { return _beginMonth; }
            set {
                _beginMonth = value;
                RaisePropertyChanged();
            }
        }

        public Int32 EndMonth {
            get { return _endMonth; }
            set {
                _endMonth = value;
                RaisePropertyChanged();
            }
        }

        public String Name {
            get { return _name; }
            set {
                _name = value;
                RaisePropertyChanged();
            }
        }

        public Int32 SeasonIdent {
            get { return _seasonIdent; }
            set {
                _seasonIdent = value;
                RaisePropertyChanged();
            }
        }

        public Int32 SortOrder {
            get { return _sortOrder; }
            set {
                _sortOrder = value;
                RaisePropertyChanged();
            }
        }

        public Season() {
        }

    }
}
