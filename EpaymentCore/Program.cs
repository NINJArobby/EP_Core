using System.Text;
using FimiEngine.HelpingClasses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = null;
// Add services to the container.

builder.Services.AddControllers();

//fimi injection 
builder.Services.AddSingleton<IFimiConfigManager, FimiConfigManager>(); //add session management
builder.Services.AddDistributedMemoryCache(); //inject/add session management
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(180);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.Name = ".EpCoreSession";
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "epcore.com",
        ValidAudience = "epcore.com",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This_is_the_best_secret_key_MyJwtP@$$w0rd"))
    };
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

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseSession();
app.MapControllers();
app.Run();