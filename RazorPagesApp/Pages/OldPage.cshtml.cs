using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApp.Pages
{
    public class OldPageModel : PageModel
    {
        public IActionResult OnGet()
        {
            return RedirectToPage("Index");
        }
    }
}
