using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
var mvcBuilder = builder
    .Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        var cool = JsonConvert.SerializeObject(new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
        var cool2 = JsonConvert.DeserializeObject<int[,]>(cool);
        Console.WriteLine(cool);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
