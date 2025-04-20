using Microsoft.EntityFrameworkCore;
using WebApi.Data.Contexts;
using WebApi.Data.Repositories;
using WebApi.Middleware;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<StatusRepository>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<ProjectRepository>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<StatusService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<ProjectService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .SetIsOriginAllowed(_ => true)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
