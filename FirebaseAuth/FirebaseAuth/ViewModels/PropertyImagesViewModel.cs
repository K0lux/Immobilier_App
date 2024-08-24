using FirebaseAuth.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirebaseAuth.ViewModels
{
    public class PropertyImagesViewModel : BaseViewModel
    {
        public ObservableCollection<ImageData> PropertyImages { get; }
        public ICommand CloseCommand { get; }

        public PropertyImagesViewModel(Property property)
        {
            PropertyImages = new ObservableCollection<ImageData>(property.Images);
            CloseCommand = new Command(OnClose);
        }

        private async void OnClose()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }

}
