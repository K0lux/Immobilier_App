using System;
using System.Collections.Generic;
using System.Text;

namespace FirebaseAuth.Models
{
    public class ImageData
    {
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        public ImageData(string imageUrl, string description)
        {
            ImageUrl = imageUrl;
            Description = description;
        }
    }
}
