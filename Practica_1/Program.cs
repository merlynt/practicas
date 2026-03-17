using Practica_1.Data;
using Microsoft.EntityFrameworkCore;
using Practica_1.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Añadir manualmente
builder.Services.AddDbContext<AplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaulDbConnection"))
);

builder.Services.AddScoped<SpecialtyRepository>();
builder.Services.AddScoped<StaffCategoryRepository>();
builder.Services.AddScoped<StaffRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
