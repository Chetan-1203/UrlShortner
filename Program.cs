using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using UrlShortner.Entities;
using UrlShortner.Infrastructure.Repositories;
using UrlShortner.Models;
using UrlShortner.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
builder.Services.AddScoped<IUrlShortenerRepository ,UrlShortenerRepository>();
builder.Services.AddScoped<UrlShortenerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("api/shorten", async (
    UrlShortenerRequest request,
    UrlShortenerService urlShortnerService,
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
