using System.Text.Json;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VoiceCastMasters_api.Auth;
using VoiceCastMasters_api.DAL;
using VoiceCastMasters_api.Model;
using VoiceCastMasters_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("LocalNetwork", 
        builder => builder.WithOrigins(
                "http://localhost:3000",
                "http://192.168.1.248:3000",
                "http://192.168.0.110:3000", 
                "http://192.168.0.115:3000"
                )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
        );
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
    );
});



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
        {
            
            /*options.Events.OnRedirectToLogin = context =>
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return Task.CompletedTask;
            };
            options.Events.OnRedirectToAccessDenied = context =>
            {
                context.Response.BodyWriter.WriteAsync("No user is logged in") ;
            }*/
            options.Cookie.Name = "VoiceCastMastersCookie";
            options.Cookie.SameSite = SameSiteMode.None;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        });

// builder.Services.AddControllers().AddJsonOptions(options =>
// {
//     options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
//     options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
// });

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddDbContext<DatabaseContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("CloudDb"));
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRepository<Actor>, InMemoryActorRepository>();
builder.Services.AddSingleton<IRepository<User>, InMemoryUserRepository>();
builder.Services.AddScoped<IAuthorization, Authorization>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IActorService, ActorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseCors("LocalNetwork");

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();