using System.Collections.Generic;
using System.Globalization;

namespace FirebaseAuth.Models
{
    public class Property
    {
        public string ImageUrl { get; set; }
        public decimal Price { get; private set; }  // Propriété en lecture seule
        public string ShortDescription { get; set; }
        public string Location { get; set; }
        public List<ImageData> Images { get; set; } // Liste d'images associées à la propriété

        // Constructeur pour initialiser Price avec une chaîne
        public Property(string imageUrl, string priceString, string shortDescription, string location, List<ImageData> images)
        {
            ImageUrl = imageUrl;
            ShortDescription = shortDescription;
            Location = location;
            Price = ConvertPriceStringToDecimal(priceString);
            Images = images ?? new List<ImageData>(); // Initialiser avec une liste vide si null
        }

        // Méthode pour convertir une chaîne en decimal
        private decimal ConvertPriceStringToDecimal(string priceString)
        {
            var cultureInfo = new CultureInfo("fr-FR");
            if (decimal.TryParse(priceString, NumberStyles.Currency, cultureInfo, out var price))
            {
                return price;
            }
            else
            {
                // Gestion des erreurs, retourner une valeur par défaut
                return 0m;
            }
        }
    }
}
