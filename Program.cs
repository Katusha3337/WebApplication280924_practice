using WebApplication280924_practice;

var builder = WebApplication.CreateBuilder(args);

// Добавляем BookService в коллекцию сервисов
builder.Services.AddSingleton<BookService>();

// Добавляем контроллеры с представлениями
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Конфигурируем HTTP-конвейер
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Book}/{action=Index}/{id?}");

app.Run();
