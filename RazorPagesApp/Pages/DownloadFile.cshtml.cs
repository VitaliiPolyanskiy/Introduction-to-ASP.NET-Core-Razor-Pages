using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApp.Pages;

public class DownloadFileModel : PageModel
{
    public string Message { get; private set; } = string.Empty;

    public IActionResult OnGet()
    {
        // Шлях до файлу
        string filePath = "~/Images/IMG_20170504_170840.jpg";
        // Тип файлу (MIME-type)
        string fileType = "image/jpeg";
        // Назва файлу (необов'язково)
        string fileName = "Капрі.jpg";

        Message = $"Файл {fileName} надіслано клієнту";

        return File(filePath, fileType, fileName);
    }
}