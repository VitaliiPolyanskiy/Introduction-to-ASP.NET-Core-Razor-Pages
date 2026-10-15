using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages;

public class UploadFileModel(ApplicationContext context, IWebHostEnvironment appEnvironment) : PageModel
{
    public IEnumerable<FileModel> FileModels { get; set; } = [];

    [BindProperty]
    public IFormFile? UploadedFile { get; set; }

    public async Task OnGetAsync()
    {
        if (context.Files != null)
        {
            FileModels = await context.Files.ToListAsync();
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (UploadedFile != null)
        {
            // Шлях до папки Files
            string path = "/Files/" + UploadedFile.FileName;

            // Зберігаємо файл у папку Files в каталозі wwwroot
            // Для отримання повного шляху до каталогу wwwroot застосовується властивість WebRootPath об'єкта IWebHostEnvironment
            string fullPath = appEnvironment.WebRootPath + path;

            await using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await UploadedFile.CopyToAsync(fileStream); // копіюємо файл у потік
            }

            var file = new FileModel { Name = UploadedFile.FileName, Path = path };
            context.Files.Add(file);
            await context.SaveChangesAsync();
        }

        return RedirectToPage("./UploadFile");
    }
}