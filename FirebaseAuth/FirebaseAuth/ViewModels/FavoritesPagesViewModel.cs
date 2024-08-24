using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using FirebaseAuth.Models;

namespace FirebaseAuth.ViewModels
{
    public class FavoritesPageViewModel : BaseViewModel
    {
        public ObservableCollection<Property> FavoriteProperties { get; set; }
        public ICommand RemoveFromFavoritesCommand { get; }
        public ICommand ViewDetailsCommand { get; }

        public FavoritesPageViewModel()
        {
            FavoriteProperties = new ObservableCollection<Property>
            {
                
            };

            RemoveFromFavoritesCommand = new Command<Property>(async (property) => await RemoveFromFavorites(property));
            ViewDetailsCommand = new Command<Property>(async (property) => await ViewDetails(property));
        }

        private async Task RemoveFromFavorites(Property property)
        {
            FavoriteProperties.Remove(property);
            await Shell.Current.DisplayAlert("Favoris", $"{property.ShortDescription} retiré des favoris", "OK");
        }

        private async Task ViewDetails(Property property)
        {
            await Shell.Current.DisplayAlert("Détails", $"Détails de : {property.ShortDescription}", "OK");
        }
    }
}
