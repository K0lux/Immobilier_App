using FirebaseAuth.Models;
using FirebaseAuth.ViewModels;
using FirebaseAuth.Views;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirebaseAuth.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyImagesPage : ContentPage
    {
        public PropertyImagesPage(Property property)
        {
            InitializeComponent();
            BindingContext = new PropertyImagesViewModel(property);
        }


    
    }
}


