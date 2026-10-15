using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApp.Pages;

public class IndexModel : PageModel
{
    public string Message { get; } = "ASP.NET Core Razor Pages";

    public void OnGet()
    {
        ViewData["Message"] = "ASP.NET Core MVC";
    }

    public string PrintTime() => DateTime.Now.ToShortTimeString();
}