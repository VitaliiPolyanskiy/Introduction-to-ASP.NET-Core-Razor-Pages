using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApp.Pages
{
    public class ImageModel : PageModel
    {
        public string Message { get; private set; } = "";
        public void OnGet()
        {
            Message = "Изображения в приложениях ASP.NET Core Razor Pages";
        }
    }
}
