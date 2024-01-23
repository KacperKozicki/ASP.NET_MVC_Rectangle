using System.ComponentModel.DataAnnotations;

namespace Rectangle.Models
{
    public class KKRectangleModel
    {
        public int Id { get; set; }

        [Required]
        [Range(0.01, 1000000)]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public double Height { get; set; }

        [Required]
        public string HeightUnit { get; set; } // Jednostka dla wysokości

        [Required]
        [Range(0.01, 1000000)]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public double Width { get; set; }

        [Required]
        public string WidthUnit { get; set; } // Jednostka dla szerokości

        public double Area { get; set; }

        public DateTime Time { get; set; }
    }
}
