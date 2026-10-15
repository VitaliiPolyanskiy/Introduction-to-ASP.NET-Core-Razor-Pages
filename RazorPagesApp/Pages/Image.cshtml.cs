using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApp.Pages;

public class ImageModel : PageModel
{
    public string Message { get; private set; } = string.Empty;

    public void OnGet()
    {
        Message = "Зображення в застосунках ASP.NET Core Razor Pages";
    }
}