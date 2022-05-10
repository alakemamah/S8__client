using Microsoft.EntityFrameworkCore;
using S8_API.Models;
using Microsoft.Extensions.DependencyInjection;
using S8_API.Data;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<S8_APIContext>(options =>

    //options.UseSqlServer(builder.Configuration.GetConnectionString("S8_APIContext") ?? throw new InvalidOperationException("Connection string 'S8_APIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<S8_APIContext>(opt =>
    opt.UseInMemoryDatabase("List"));
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "S8_API", Version = "v1" });
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "S8_API v1"));}
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
