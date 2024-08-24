using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using FirebaseAuth.Models;
using System.Diagnostics;
using System;
using FirebaseAuth.Views;
using System.Collections.Generic;

namespace FirebaseAuth.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set => SetProperty(ref _searchQuery, value);
        }

        public ObservableCollection<Property> Properties { get; set; }
        public ICommand OpenMenuCommand { get; }
        public ICommand PerformSearchCommand { get; }
        public ICommand PropertySelectedCommand { get; }
        public ICommand ViewDetailsCommand { get; }
        public ICommand AddToFavoritesCommand { get; }
        public ICommand ShowImagesCommand { get; }
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateFavoritesCommand { get; }
        public ICommand NavigateProfileCommand { get; }
        

        public MainPageViewModel()
        {

            Properties = new ObservableCollection<Property>
    {
        new Property(
            "https://example.com/house1.jpg",
            "200000 €",
            "Belle maison avec piscine",
            "Paris",
            new List<ImageData>
            {
                new ImageData("https://example.com/house1_img1.jpg", "Piscine extérieure"),
                new ImageData("https://example.com/house1_img2.jpg", "Salon spacieux")
            }
        ),
        new Property(
            "https://example.com/house2.jpg",
            "350000 €",
            "Appartement moderne au centre-ville",
            "Lyon",
            new List<ImageData>
            {
                new ImageData("https://example.com/house2_img1.jpg", "Cuisine équipée"),
                new ImageData("https://example.com/house2_img2.jpg", "Chambre principale")
            }
        ),
        new Property(
            "https://example.com/villa_abidjan.jpg",
            "150000 €",
            "Villa luxueuse avec jardin tropical",
            "Abidjan, Côte d'Ivoire",
            new List<ImageData>
            {
                new ImageData("https://example.com/villa_abidjan_img1.jpg", "Jardin tropical"),
                new ImageData("https://example.com/villa_abidjan_img2.jpg", "Vue sur l'océan")
            }
        )
    };

            

            ShowImagesCommand = new Command<Property>(OnShowImages);
            OpenMenuCommand = new Command(async () => await OpenMenu());
            PerformSearchCommand = new Command(async () => await PerformSearch());
            PropertySelectedCommand = new Command<Property>(async (property) => await OnPropertySelected(property));
            ViewDetailsCommand = new Command<Property>(async (property) => await ViewDetails(property));
            AddToFavoritesCommand = new Command<Property>(async (property) => await AddToFavorites(property));
            NavigateHomeCommand = new Command(OnNavigateHome);
            NavigateFavoritesCommand = new Command(OnNavigateFavorites);
            NavigateProfileCommand = new Command(OnNavigateProfile);
            ShowImagesCommand = new Command<Property>(OnShowImages);
        }


        private void OnNavigateHome()
        {
           
            try
            {
                
                Shell.Current.GoToAsync("//HomePage"); 
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in OnNavigateHome: {ex.Message}");
            }
        }

        private void OnNavigateFavorites()
        {
            
            try
            {
                
                Shell.Current.GoToAsync("//FavoritesPage"); 
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in OnNavigateFavorites: {ex.Message}");
            }
        }

        private void OnNavigateProfile()
        {
            
            try
            {
                
                Shell.Current.GoToAsync("//ProfilePage"); 
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in OnNavigateProfile: {ex.Message}");
            }
        }
        private async void OnShowImages(Property property)
        {

            if (property == null) return;

            var imagesPage = new PropertyImagesPage(property);
            await Application.Current.MainPage.Navigation.PushModalAsync(imagesPage);
        }
        private async Task OpenMenu()
        {
            try
            {
                await Shell.Current.DisplayAlert("Menu", "Menu ouvert", "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in OpenMenu: {ex.Message}");
            }
        }

        private async Task PerformSearch()
        {
            try
            {
                await Shell.Current.DisplayAlert("Recherche", $"Recherche de : {SearchQuery}", "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in PerformSearch: {ex.Message}");
            }
        }

        private async Task OnPropertySelected(Property property)
        {
            try
            {
                if (property == null)
                {
                    Debug.WriteLine("OnPropertySelected: property is null");
                    return;
                }
                await Shell.Current.DisplayAlert("Propriété sélectionnée", $"{property.ShortDescription}", "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in OnPropertySelected: {ex.Message}");
            }
        }

        private async Task ViewDetails(Property property)
        {
            try
            {
                if (property == null)
                {
                    Debug.WriteLine("ViewDetails: property is null");
                    return;
                }
                await Shell.Current.DisplayAlert("Détails", $"Détails de : {property.ShortDescription}", "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in ViewDetails: {ex.Message}");
            }
        }

        private async Task AddToFavorites(Property property)
        {
            try
            {
                if (property == null)
                {
                    Debug.WriteLine("AddToFavorites: property is null");
                    return;
                }
                await Shell.Current.DisplayAlert("Favoris", $"{property.ShortDescription} ajouté aux favoris", "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in AddToFavorites: {ex.Message}");
            }
        }
    }
}
