using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApp.Pages
{
    public class SquareModel : PageModel
    {
        public string Message { get; private set; } = "";

        [BindProperty(SupportsGet = true, Name = "a")]
        public int BaseTriangle { get; set; }

        [BindProperty(SupportsGet = true, Name = "h")]
        public int HeightTriangle { get; set; }

        public void OnGet()
        {
            double Square = BaseTriangle * HeightTriangle / 2;
            Message = $"Площадь треугольника с основанием {BaseTriangle} и высотой {HeightTriangle} равна {Square}";
        }
    }
}
