using Microsoft.EntityFrameworkCore;
using Rectangle.Data;

namespace Rectangle.Models

{
    public interface IKKRectangleService
    {
        double CalculateArea(KKRectangleModel input);
        void AddRectangle(KKRectangleModel input, double area);
        List<KKRectangleEntity> GetRectangles();
        KKRectangleModel GetRectangleById(int id);
       

    }
}
