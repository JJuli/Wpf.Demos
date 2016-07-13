namespace Wpf.Demonstrations {
    using System;
    using Wpf.Common.Events;
    using Wpf.Common.Infrastructure;

    public class ShellViewModel : ObservableObject {

        String _lessonTitle;

        public String LessonTitle {
            get { return _lessonTitle; }
            private set {
                _lessonTitle = value;
                RaisePropertyChanged();
            }
        }

        public ShellViewModel(IEventResolver<LessonSelectedEvent> lessonSelectedResolver) {
            if (lessonSelectedResolver == null) {
                throw new ArgumentNullException(nameof(lessonSelectedResolver));
            }
            lessonSelectedResolver.Resolve().Subscribe(t => this.LessonTitle = t);
        }

    }
}
