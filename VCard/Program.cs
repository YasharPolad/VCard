using Microsoft.EntityFrameworkCore;
using QRCode.Services;
using VCard.DAL;
using VCard.Repositories;
using VCard.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<VCardDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("VCardDbContext")));
builder.Services.AddHttpClient();
builder.Services.AddScoped<IGenerateQRString, GenerateQRString>();
builder.Services.AddScoped<ICreateQRImage, CreateQRImage>();
builder.Services.AddScoped<ICreateFromJson, CreateFromJson>(); //kimi kimin icinde cagirmaq olar ve sair. what is the logic behind scopes?
//builder.Services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
