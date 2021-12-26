global using DataAccessLayer.Context;
using ComunicationLayer.Middleware;
using Microsoft.EntityFrameworkCore;

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*
string connectionString = configuration.GetSection("DbConnection")?.Value ?? string.Empty;
builder.Services.AddSingleton(connectionString);
var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

services.AddDbContext<_dbContext>(builder =>
builder.UseNpgsql(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)));  */


//builder.AddTransient<IUserService, UserService>();

builder.Services.AddControllers();
//builder.Services.AddTransient<IEntityDB, EntityDB>();
//builder.Services.AddTransient<IUserService, UserService>();
IoC.AddDependency(builder.Services);

builder.Services.AddDbContext<EntityDB>(options => {

    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"),
                                        b => b.MigrationsAssembly("ComunicationLayer"));
     
});



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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
