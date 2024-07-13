using DBGestorsApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    connectionString: builder.Configuration.GetConnectionString("dbConnect")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(options =>
    options.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
