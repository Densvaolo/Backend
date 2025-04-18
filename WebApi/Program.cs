using Microsoft.EntityFrameworkCore;
using WebApi.Data.Contexts;
using WebApi.Data.Repositories;
using WebApi.Middleware;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<StatusService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<ProjectService>();


builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<StatusRepository>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<ProjectRepository>();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors(); 
app.UseMiddleware<WebApi.Middleware.ApiKeyMiddleware>();
app.MapOpenApi();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
