using Microsoft.EntityFrameworkCore;
using SistemaDeGestiónDeEmpleados.BL;
using SistemaDeGestiónDeEmpleados.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql")));

// Repositorio
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();

// Gestor (BL)
builder.Services.AddScoped<GestorDeEmpleados>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Empleados}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
