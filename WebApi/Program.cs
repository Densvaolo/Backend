using Microsoft.EntityFrameworkCore;
using WebApi.Data.Contexts;
using WebApi.Data.Repositories;
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

var app = builder.Build();
app.MapOpenApi();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();
