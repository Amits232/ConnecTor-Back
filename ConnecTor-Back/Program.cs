using ConnecTor_Back.Interfaces;
using ConnecTor_Back.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Determine which connection string to use based on the machine name
var machineName = Environment.MachineName;
string connectionString;

if (machineName == "DESKTOP-N6FQQ59")
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection1");
}
else
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection2");
}

// Configure the DbContext to use the determined connection string
builder.Services.AddDbContext<ConnecTorDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add service registrations
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

var reactEndPoint = builder.Configuration["EndPoint:Url"];
var jwtSecretKey = builder.Configuration["JwtSettings:SecretKey"];

// Register JWT token generator with the secret key
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>(provider =>
    new JwtTokenGenerator(jwtSecretKey));

// Add CORS policy configuration **before** building the app
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins(reactEndPoint)
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS policy
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
