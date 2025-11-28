namespace UserManagement.Domain.Entities.Users
{
    public class GeoLocation
    {
        public double Latitude { get; }
        public double Longitude { get; }

        public GeoLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        // Haversine formula za udaljenost u km
        public double DistanceTo(GeoLocation other)
        {
            var R = 6371; 
            var lat1Rad = DegreesToRadians(Latitude);
            var lat2Rad = DegreesToRadians(other.Latitude);
            var deltaLat = DegreesToRadians(other.Latitude - Latitude);
            var deltaLng = DegreesToRadians(other.Longitude - Longitude);

            var a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                    Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                    Math.Sin(deltaLng / 2) * Math.Sin(deltaLng / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c;
        }

        private double DegreesToRadians(double deg) => deg * (Math.PI / 180);
    }
}
