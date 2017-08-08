using Xamarin.Forms.Maps;

namespace App1
{
    public class CustomMap : Map
    {
        public Position firstPosition;

        public CustomMap(MapSpan mapspan) : base(mapspan)
        {
            firstPosition = mapspan.Center;
        }
    }
}
