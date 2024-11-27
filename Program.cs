using Microsoft.EntityFrameworkCore;
using snippets.Data;

var builder = WebApplication.CreateBuilder(args);

var devDbConnectionString = builder.Configuration["ApiDbContext"];
var productionDbConnectionString = builder.Configuration["ProductionApiDbContext"];

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<ApiDbContext>(options =>
        options.UseNpgsql(devDbConnectionString));
}
else
{
    builder.Services.AddDbContext<ApiDbContext>(options =>
        options.UseNpgsql(productionDbConnectionString));
}

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages()
   .WithStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "api/v1/{controller=Home}/{action=Index}/{id?}"
);



app.Run();
