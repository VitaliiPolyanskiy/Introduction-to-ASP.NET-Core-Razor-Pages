using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages
{
    public class UploadFileModel : PageModel
    {
        public IEnumerable<FileModel> filemodel { get; set; } = default!;

        ApplicationContext _context;

        // IWebHostEnvironment предоставляет информацию об окружении, в котором запущено приложение
        IWebHostEnvironment _appEnvironment;

        public UploadFileModel(ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }
        public async Task OnGetAsync()
        {
            if (_context.Files != null)
            {
                filemodel = await _context.Files.ToListAsync(); 
            }
        }

        [BindProperty]
        public IFormFile uploadedFile { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (uploadedFile != null)
            {
                // Путь к папке Files
                string path = "/Files/" + uploadedFile.FileName; // имя файла

                // Сохраняем файл в папку Files в каталоге wwwroot
                // Для получения полного пути к каталогу wwwroot
                // применяется свойство WebRootPath объекта IWebHostEnvironment
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream); // копируем файл в поток
                }
                FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
                _context.Files.Add(file);
                _context.SaveChanges();
            }

            return RedirectToPage("./UploadFile");
        }
    }
}
