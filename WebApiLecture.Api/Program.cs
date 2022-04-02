using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApiLecture.Data.Models;
using WebApiLecture.Domain.Repositories.Implementations;
using WebApiLecture.Domain.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var webApilectureContext = builder.Configuration.GetConnectionString(nameof(WebApiLectureContext));

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WebApiLectureContext>(options => options.UseSqlServer(webApilectureContext));
builder.Services.AddTransient<ITodoItemRepository, TodoItemRepository>();
builder.Services.AddTransient<ITodoRepository, TodoRepository>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Internship Web Api", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "/swagger/{documentName}/swagger.json";
    });

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
