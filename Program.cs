using Microsoft.EntityFrameworkCore;
using Source.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>
(
    options => options.UseSqlite
    (
        builder.Configuration.GetConnectionString("Development")
    )
);


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

