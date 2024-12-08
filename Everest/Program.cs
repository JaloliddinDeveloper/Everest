var builder = WebApplication.CreateBuilder(args);

// HTTPS majburiy yoqish
builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;  // 308 - 301 ga o'xshash, ammo saqlash
    options.HttpsPort = 443;  // HTTPS uchun port
});

builder.Services.AddControllersWithViews();  // MVC uchun kerakli xizmatlarni qo'shish

var app = builder.Build();

// HTTPS-ni majburiy qilish
app.UseHttpsRedirection();  // Agar foydalanuvchi HTTP orqali kelsa, HTTPS ga yo'naltirish

// Avtorizatsiya va boshqa o‘rnatishlar
app.UseAuthorization();

// MVC marshrutini sozlash
app.MapControllerRoute(
    name: "def",  // Yo‘naltirish nomi
    pattern: "{controller=Home}/{action=Index}/{id?}"  // Default marshrut
);

// API marshrutlarini qo'shish (agar siz API ham ishlatayotgan bo'lsangiz)
app.MapControllers();

app.Run();
