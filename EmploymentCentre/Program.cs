using Microsoft.EntityFrameworkCore; 
using EmploymentCentre.Data;        

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString)); 

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer(); 

var app = builder.Build();
try
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.OpenConnection();
        Console.WriteLine("Connection to the database was successful.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Failed to connect to the database: {ex.Message}");
}


app.UseHttpsRedirection();

app.UseStaticFiles(); 

app.UseRouting();

app.UseAuthorization(); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();