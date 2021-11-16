using NetTopologySuite.Geometries;

namespace Domain.Entities.Common
{
    public record Location
    {
        public Point Value { get; }

        private Location(Point value)
        {
            Value = value;
        }

        public static Location From(Point value) => new(value);
        public static Location FromCoordinates(double longitude, double latitude) => new(new Point(longitude, latitude));
    }
}
