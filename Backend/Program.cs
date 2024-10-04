using System.Text;
using Backend.Data;
using Backend.Interfaces;
using Backend.Repositories;
using Backend.Services.Category;
using Backend.Services.Category.Validator;
using Backend.Services.Product;
using Backend.Services.Product.Validator;
using Backend.Services.Token;
using Backend.Services.User;
using Backend.Services.User.Validator;
using Backend.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserValidator>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<CategoryValidator>();
builder.Services.AddScoped<CategoryService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductValidator>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddScoped<TokenService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddDbContext<DataContext>(
    options => { options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)); });

// Configure JWT Authentication
builder.Services.AddAuthentication(
    options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(
    options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
                                                    {
                                                        ValidateIssuer = true,
                                                        ValidateAudience = true,
                                                        ValidateLifetime = true,
                                                        ValidateIssuerSigningKey = true,
                                                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                                                        ValidAudience = builder.Configuration["Jwt:Issuer"],
                                                        IssuerSigningKey = new SymmetricSecurityKey(
                                                            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                                                    };
        });

builder.Services.AddAuthorization(
    options =>
        {
            options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
            options.AddPolicy("AnyUser", policy => policy.RequireRole("Admin", "User"));
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();