using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Отримуємо рядок підключення з файлу конфігурації
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Додаємо контекст ApplicationContext як сервіс у застосунок
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

// Додаємо в застосунок сервіси Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

// Обробляє запити до файлів у папці wwwroot
app.UseStaticFiles();

// Додаємо підтримку маршрутизації для Razor Pages
app.MapRazorPages();

app.Run();