namespace Wpf.Common.Model {
    using System;
    using Wpf.Common.Infrastructure;

    public class Lesson : ObservableObject {

        Boolean _isSelected;

        public Boolean IsSelected {
            get { return _isSelected; }
            set {
                _isSelected = value;
                RaisePropertyChanged();
            }
        }

        public String Section { get; set; }

        public String Title { get; set; }

        public String View { get; set; }

        public Lesson() {
        }

    }
}
