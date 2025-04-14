using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApp.Pages
{
    public class DownloadFileModel : PageModel
    {
        public string Message { get; private set; } = "";
        public IActionResult OnGet()
        {
            // Путь к файлу
            string file_path = "~/Images/IMG_20170504_170840.jpg";
            // Тип файла - content-type
            string file_type = "image/jpeg";
            // Имя файла - необязательно
            string file_name = "Капри.jpg";
            Message = $"Файл {file_name} отправлен клиенту";
            return File(file_path, file_type, file_name);
        }
    }
}
