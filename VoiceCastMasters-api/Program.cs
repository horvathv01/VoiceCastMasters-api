using System.Text.Json;
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

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRepository<Actor>, InMemoryActorRepository>();
builder.Services.AddTransient<IUserProvider, UserProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseCors("LocalNetwork");

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();