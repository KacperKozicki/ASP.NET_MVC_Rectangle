using Microsoft.AspNetCore.Mvc;
using Rectangle.Models;

namespace Rectangle.Controllers
{
    public class KKRectangleController : Controller
    {
        private readonly IKKRectangleService _rectangleService;

        public KKRectangleController(IKKRectangleService rectangleService)
        {
            _rectangleService = rectangleService;
        }

        public IActionResult Index()
        {
            var rectangleEntities = _rectangleService.GetRectangles(); // Get entities from the service
            var rectangleModels = rectangleEntities.Select(r => new KKRectangleModel
            {
                Id = r.Id,
                Height = r.Height,
                Width = r.Width,
                HeightUnit = r.HeightUnit,
                WidthUnit = r.WidthUnit,
                Time = r.Time
            }).ToList();

            return View(rectangleModels); // Pass the list of models to the view
        }


        [HttpPost]
        public IActionResult Calculate(KKRectangleModel input)
        {
            if (ModelState.IsValid)
            {
                double area = _rectangleService.CalculateArea(input);
                _rectangleService.AddRectangle(input, area);
                return RedirectToAction("List");
            }
            else
            {
                var units = new List<string> { "mm", "cm", "m" };
                ViewBag.Units = units;
                return View("Index", input);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Units = new List<string> { "mm", "cm", "m" }; // Lista jednostek dla widoku
            return View();
        }


        
        [HttpPost]
        public IActionResult Create(KKRectangleModel input)
        {
            ViewBag.Units = new List<string> { "mm", "cm", "m" }; // Ponowne przypisanie listy jednostek

            if (ModelState.IsValid)
            {
                double area = _rectangleService.CalculateArea(input);
                _rectangleService.AddRectangle(input, area);
                return RedirectToAction("Index");
            }
            else
            {
                return View(input);
            }
        }

        public IActionResult Details(int id)
        {
            var rectangle = _rectangleService.GetRectangleById(id);

            if (rectangle == null)
            {
                return NotFound();
            }

            return View(rectangle);
        }


    }
}
