using EchooPays.Repository;
using EchoPOS.Data;
using EchoPOS.Repositories;
using EchoPOS.Repository;

namespace EchoPOS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<DbHelper>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IMenuRepository, MenuRepository>();
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();
            builder.Services.AddScoped<ITablesRepository, TablesRepository>();
            builder.Services.AddScoped<IReservationsRepository, ReservationsRepository>();
            builder.Services.AddScoped<ISuppliersRepository, SuppliersRepository>();
            builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
            builder.Services.AddScoped<IEmployee_ShiftsRepository, Employee_ShiftsRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
            builder.Services.AddScoped<IDiscountsRepository, DiscountRepository>();
            builder.Services.AddScoped<ITaxesRepository, TaxesRepository>();
            builder.Services.AddScoped<IExpensesRepository, ExpensesRepository>();
            builder.Services.AddScoped<IBillRepository, BillRepository>();



            // Configure session
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
                options.Cookie.HttpOnly = true; // Ensure cookie is only accessible via HTTP
                options.Cookie.IsEssential = true; // Make sure session cookie is always sent
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts(); // The default HSTS value is 30 days
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Add session middleware
            app.UseSession(); // Ensure session middleware is added here

            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
