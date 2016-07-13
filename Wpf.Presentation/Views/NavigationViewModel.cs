namespace Wpf.Presentation.Views {
    using System;
    using System.Linq;
    using System.Windows.Input;
    using Prism.Regions;
    using Wpf.Common.Data;
    using Wpf.Common.Events;
    using Wpf.Common.Infrastructure;
    using Wpf.Common.Model;

    public class NavigationViewModel : ObservableObject {

        Lessons _lessons;
        ICommand _lessonSelectedCommand;
        readonly IEventResolver<LessonSelectedEvent> _lessonSelectedResolver;
        readonly IRegionManager _regionManager;

        public Lessons Lessons {
            get { return _lessons; }
            set {
                _lessons = value;
                RaisePropertyChanged();
            }
        }

        public ICommand LessonSelectedCommand => _lessonSelectedCommand ?? (_lessonSelectedCommand = new RelayCommand<Lesson>(LessonSelectedExecute));

        public NavigationViewModel(
            Lessons lessons,
            IRegionManager regionManager,
            IEventResolver<LessonSelectedEvent> lessonSelectedResolver) {
            if (lessons == null) {
                throw new ArgumentNullException(nameof(lessons));
            }
            if (regionManager == null) {
                throw new ArgumentNullException(nameof(regionManager));
            }
            if (lessonSelectedResolver == null) {
                throw new ArgumentNullException(nameof(lessonSelectedResolver));
            }
            if (lessons.Count == 0) {
                throw new InvalidOperationException("lessons collection was empty.");
            }

            _lessons = lessons;
            _regionManager = regionManager;
            _lessonSelectedResolver = lessonSelectedResolver;

            // navigate to the initial view, HomeView
            LessonSelectedExecute(Lessons[0]);
        }

        void LessonSelectedExecute(Lesson selectedLesson) {
            if (selectedLesson == null) {
                throw new ArgumentNullException(nameof(selectedLesson));
            }

            // ************************************************************
            // this block of code is one way to work around the fact that
            // the button that was clicked ate the mouse click, preventing
            // the ListBox from getting it.
            foreach (var lesson in Lessons.Where(l => l.IsSelected)) {
                lesson.IsSelected = false;
            }
            selectedLesson.IsSelected = true;

            // ************************************************************

            // navigate to the selected lesson
            // if successful set the title, otherwise, display an error message
            _regionManager.Regions[Constants.ContentRegionName].RequestNavigate(selectedLesson.View,
                result => {
                    if (result.Error == null) {
                        _lessonSelectedResolver.Resolve().Publish(selectedLesson.Title);
                    } else {
                        _lessonSelectedResolver.Resolve().Publish(result.Error.Message);
                    }
                });
        }

    }
}
