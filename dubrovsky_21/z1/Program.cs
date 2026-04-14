using Microsoft.EntityFrameworkCore;
using z1.Data;
using z1.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ShoppingContext>(options =>
    options.UseInMemoryDatabase("ShoppingListDb"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ShoppingContext>();
    if (!context.ShoppingItems.Any())
    {
        context.ShoppingItems.AddRange(
            new ShoppingItem { Name = "Milk", Quantity = 1, IsBought = false },
            new ShoppingItem { Name = "Bread", Quantity = 2, IsBought = false },
            new ShoppingItem { Name = "Apples", Quantity = 6, IsBought = true }
        );
        context.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shopping}/{action=Index}/{id?}");

app.Run();
