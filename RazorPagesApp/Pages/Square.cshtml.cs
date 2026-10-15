using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApp.Pages;

public class SquareModel : PageModel
{
    public string Message { get; private set; } = string.Empty;

    [BindProperty(SupportsGet = true, Name = "a")]
    public int BaseTriangle { get; set; }

    [BindProperty(SupportsGet = true, Name = "h")]
    public int HeightTriangle { get; set; }

    public void OnGet()
    {
        double square = BaseTriangle * HeightTriangle / 2.0;
        Message = $"Площа трикутника з основою {BaseTriangle} та висотою {HeightTriangle} дорівнює {square}";
    }
}