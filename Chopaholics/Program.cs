using Chopaholics.Application.DataContext;
using Chopaholics.Application.MockDB;
using Chopaholics.Application.Repositories;
using Chopaholics.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IChowRepository, ChowsRepository>();
builder.Services.AddScoped<ICart, CartRepository>(sp => CartRepository.GetCart(sp));

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("ChopaholicsConnection");
builder.Services.AddDbContext<ChopaholicsDbContext>(options =>
{
    options.UseSqlServer(connection);
});
var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
DbInitializer.Seed(app);
app.Run();