using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using UsersApiStudy.src.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services database.

var connectionString = builder.Configuration.GetConnectionString("stringdatabase");

builder.Services.AddDbContext<UsersContext>(options =>
    options.UseLazyLoadingProxies().UseMySql(
        connectionString, 
        ServerVersion.AutoDetect(connectionString)
    )
);;

/// add jsonSerializeOptions to ignore cycles

builder.Services.AddControllers().AddJsonOptions(options => 
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);

// automapper
builder.Services.AddAutoMapper(
    AppDomain.CurrentDomain.GetAssemblies()
);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run(); 