using Microsoft.EntityFrameworkCore;
using Source.Data;
using Source.Repositories;
using Source.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddDistributedRedisCache
(
    options => options.Configuration=builder.Configuration.GetConnectionString("AzureRedisConnection")
);
builder.Services.AddDbContext<AppDbContext>
(
    options => options.UseSqlite
    (
        builder.Configuration.GetConnectionString("Development")
    )
);

builder.Services.AddScoped<ToDoService>();
builder.Services.AddScoped<ToDoRepository>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

