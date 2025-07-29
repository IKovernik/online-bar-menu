using backend.Models;

var builder = WebApplication.CreateBuilder(args);

// Добавляем CORS для фронтенда (чтобы React мог обращаться к API)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");

// Модель напитка (временно хардкод)
var drinks = new List<Drink>
{
    new Drink
    {
        Id = 1,
        Name = "Mojito",
        Description = "Освежающий коктейль с мятой и лаймом",
        Price = 120,
        ImageUrl = "/images/mojito.jpg"
    },
    new Drink
    {
        Id = 2,
        Name = "Negroni",
        Description = "Классический коктейль на основе джина и вермута",
        Price = 150,
        ImageUrl = "/images/negroni.jpg"
    }
};

// Endpoint API: GET /drinks
app.MapGet("/drinks", () =>
{
    return drinks;
})
.WithName("GetDrinks");

app.Run();
