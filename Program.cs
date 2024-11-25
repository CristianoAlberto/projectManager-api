using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ProjectManagerApi.src.Infrastructure.Config;
using ProjectManagerApi.src.Infrastructure.Persistence;
using dotenv.net;
using ProjectManagerApi.src.Infrastructure.Extensions;

DotEnv.Load();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAny",
            builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

});

string mysqlConnection = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddInfrastructure();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
{
    options.UseMySql(mysqlConnection, ServerVersion.AutoDetect(mysqlConnection));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseCors("AllowAny");

app.UseHttpsRedirection();

app.UseAuthentication();  // Verifica o token JWT

app.UseAuthorization();

app.MapControllers();

app.Run();