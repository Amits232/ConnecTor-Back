using ConnecTor_Back.Interfaces;
using ConnecTor_Back.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());


var jwtSecretKey = builder.Configuration["JwtSettings:SecretKey"];
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>(provider =>
    new JwtTokenGenerator(jwtSecretKey));

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
