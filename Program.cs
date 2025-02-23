using Microsoft.EntityFrameworkCore;
using UrlShortner.Entities;
using UrlShortner.Infrastructure;
using UrlShortner.Infrastructure.Extension;
using UrlShortner.Infrastructure.Repositories;
using UrlShortner.Models;
using UrlShortner.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(o =>
o.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddScoped<IUrlShortnerRepository ,UrlShortnerRepository>();
//builder.Services.AddScoped<HttpContext>();
builder.Services.AddScoped<UrlShortnerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.MapPost("api/shorten", async (
    UrlShortnerRequest request,
    UrlShortnerService urlShortnerService,
    HttpContext context
    ) => {

        if(!Uri.TryCreate(request.Url,UriKind.Absolute, out _))
        {
            return Results.BadRequest("Invalid url");
        }

        var shortnedUrl =  await urlShortnerService.SaveShortenedUrl(request,context);

        return Results.Ok(shortnedUrl);

    });

app.UseHttpsRedirection();


//app.MapControllers();

app.Run();
