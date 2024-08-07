using eshop.Application.Services;
using eshop.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, FakeProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, FakeCategoryRepository>();

builder.Services.AddSession(option=> option.IdleTimeout = TimeSpan.FromMinutes(1440));  // one day

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "pagination",
    pattern: "Sayfa{pageNo}",
    defaults: new { controller = "Home", action = "Index", pageNo = 1 }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
