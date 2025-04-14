using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Models;

var builder = WebApplication.CreateBuilder(args);
// Получаем строку подключения из файла конфигурации
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
// Добавляем в приложение сервисы Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();
app.UseStaticFiles(); // обрабатывает запросы к файлам в папке wwwroot

// Добавляем поддержку маршрутизации для Razor Pages
app.MapRazorPages();

app.Run();
