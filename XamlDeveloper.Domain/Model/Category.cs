namespace XamlDeveloper.Domain.Model {
    using System;

    public class Category : DomainBase {

        Int32 _categoryIdent;
        String _name;

        public Int32 CategoryIdent {
            get { return _categoryIdent; }
            set {
                _categoryIdent = value;
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

        public Category() {
        }

    }
}
