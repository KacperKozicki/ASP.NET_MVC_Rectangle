namespace Rectangle.Data
{
    public class KKRectangleEntity
    {
        public int Id { get; set; }
        public double Height { get; set; }
        public string HeightUnit { get; set; } // Jednostka dla wysokości
        public double Width { get; set; }
        public string WidthUnit { get; set; } // Jednostka dla szerokości
        public double Area { get; set; }
        public DateTime Time { get; set; }
    }
}
