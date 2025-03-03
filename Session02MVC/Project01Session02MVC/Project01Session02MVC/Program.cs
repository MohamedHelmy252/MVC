namespace Project01Session02MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {





            var builder = WebApplication.CreateBuilder(args);

            // إضافة خدمات الـ Controllers
            builder.Services.AddControllersWithViews(); // أضف هذه السطر

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapGet("/", () => "Hello World ");
            app.MapGet("/Index", () => "Hello Mohamed in index Page ");
            app.MapGet("/index/{id}", () => "Hello Page ");

            app.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=MoviesController}/{action=Index}/{id?}");

            app.Run();
        }
        
    }

}
