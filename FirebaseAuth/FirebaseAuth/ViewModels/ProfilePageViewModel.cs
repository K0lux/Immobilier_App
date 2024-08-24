using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirebaseAuth.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        private string _agency;
        public string Agency
        {
            get => _agency;
            set => SetProperty(ref _agency, value);
        }

        private string _bio;
        public string Bio
        {
            get => _bio;
            set => SetProperty(ref _bio, value);
        }

        private string _profileImage;
        public string ProfileImage
        {
            get => _profileImage;
            set => SetProperty(ref _profileImage, value);
        }

        public ICommand UpdateProfileCommand { get; }
        public ICommand LogoutCommand { get; }

        public ProfilePageViewModel()
        {
            // Initialiser avec des données fictives
            FullName = "KASSA Malipita Luc";
            Email = "kassaluc9770@gmail.com";
            PhoneNumber = "+228 93131874";
            Agency = "Agence Immobilière Futuriste";
            Bio = "Agent immobilier passionné avec 10 ans d'expérience dans le secteur de l'immobilier de luxe.";
            ProfileImage = "profile_placeholder.jpg";

            UpdateProfileCommand = new Command(async () => await UpdateProfile());
            LogoutCommand = new Command(async () => await Logout());
        }

        private async Task UpdateProfile()
        {
            // Logique pour mettre à jour le profil
            await Shell.Current.DisplayAlert("Profil", "Profil mis à jour avec succès", "OK");
        }

        private async Task Logout()
        {
            // Logique pour la déconnexion
            await Shell.Current.DisplayAlert("Déconnexion", "Vous avez été déconnecté", "OK");
            // Rediriger vers la page de connexion
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
