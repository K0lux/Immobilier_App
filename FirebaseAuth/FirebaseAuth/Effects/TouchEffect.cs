using Xamarin.Forms;

namespace FirebaseAuth.Effects
{
    public class TouchEffect : RoutingEffect
    {
        public Color TouchColor { get; set; }
        public bool Touchable { get; set; }

        public TouchEffect() : base("FirebaseAuth.TouchEffect")
        {
        }
    }
}

