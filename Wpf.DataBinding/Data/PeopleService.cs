using System.Collections.ObjectModel;
using System.Linq;
using Wpf.DataBinding.Model;

namespace Wpf.DataBinding.Data {

    public static class PeopleService {

        public static ObservableCollection<Person> People { get; }

        public static Person Person => People.FirstOrDefault();

        static PeopleService() {
            People = new ObservableCollection<Person> {
                new Person {Birthday = new System.DateTime(1960, 11, 1), FavoriteChairThumbnail = "/Wpf.DataBinding;component/Resources/image01.png", FirstName = "Albert", LastName = "Smith", IsActive = true, Profession = "Developer"}, 
                new Person {Birthday = new System.DateTime(1980, 1, 11), FavoriteChairThumbnail = "/Wpf.DataBinding;component/Resources/image02.png", FirstName = "Ellen", LastName = "Adams", IsActive = false, Profession = "Designer"}, 
                new Person {Birthday = new System.DateTime(1984, 1, 11), FavoriteChairThumbnail = "/Wpf.DataBinding;component/Resources/image03.png", FirstName = "Lori", LastName = "Jones", IsActive = true, Profession = "Designer"}
            };
        }
    }
}
