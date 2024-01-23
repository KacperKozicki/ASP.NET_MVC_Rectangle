using Rectangle.Data;

namespace Rectangle.Models
{
    public class KKRectangleService : IKKRectangleService
    {
        private readonly KKRectangleDbContext _dbContext;

        public KKRectangleService(KKRectangleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public double CalculateArea(KKRectangleModel input)
        {
            // Przeliczanie na metry kwadratowe
            double heightInMeters = ConvertToMeters(input.Height, input.HeightUnit);
            double widthInMeters = ConvertToMeters(input.Width, input.WidthUnit);
            double area = heightInMeters * widthInMeters;
            return area;
        }

        public void AddRectangle(KKRectangleModel input, double area)
        {
            var rectangle = new KKRectangleEntity
            {
                Height = input.Height,
                HeightUnit = input.HeightUnit,
                Width = input.Width,
                WidthUnit = input.WidthUnit,
                Time = DateTime.Now,
                Area=area
            };
            _dbContext.Rectangles.Add(rectangle);
            _dbContext.SaveChanges();
        }

        public List<KKRectangleEntity> GetRectangles()
        {
            return _dbContext.Rectangles.OrderByDescending(r => r.Time).ToList();
        }

        public double ConvertToMeters(double value, string unit)
        {
            switch (unit)
            {
                case "mm":
                    return value / 1000.0;
                case "cm":
                    return value / 100.0;
                case "m":
                    return value;
                default:
                    throw new ArgumentException("Invalid unit.");
            }
        }
        public KKRectangleModel GetRectangleById(int id)
        {
            var rectangleEntity = _dbContext.Rectangles.FirstOrDefault(r => r.Id == id);

            if (rectangleEntity == null)
            {
                return null; // lub odpowiednia obsługa braku rekordu
            }

            return new KKRectangleModel
            {
                Id = id,
                Height = rectangleEntity.Height,
                Width = rectangleEntity.Width,
                HeightUnit = rectangleEntity.HeightUnit,
                WidthUnit = rectangleEntity.WidthUnit,
                Area= rectangleEntity.Area,
                Time = rectangleEntity.Time
            };
        }


    }
}
