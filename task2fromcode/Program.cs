
namespace task2fromcode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.Use(async (count, next) =>
            {
                if (count.Request.Cookies.ContainsKey("reqnum"))
                {
                    int num = int.Parse(count.Request.Cookies["reqnum"]);
                    count.Response.Cookies.Append("reqnum", (++num).ToString());


                }
                else
                {
                    count.Response.Cookies.Append("reqnum", "1");
                }

                await next();
            });

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

