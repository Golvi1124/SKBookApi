using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using SKBookApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite("Data Source=" + Path.Combine(AppContext.BaseDirectory, "SKing.db"))); // This explicitly sets the database file inside your project folder.

builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.UseAuthorization();
app.UseDefaultFiles();
app.UseStaticFiles();




app.MapControllers();

app.Run();
