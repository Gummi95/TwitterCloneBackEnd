using System.Text.Json.Serialization;
using TwitterCloneAPI.Data;
using TwitterCloneAPI.Repository;

var MyAllowSpecificOrigins = "http://localhost:3000";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000")
                                              .AllowAnyHeader()
                                              .AllowAnyMethod();
                      });                      
});
builder.Services.AddControllers();
builder.Services.AddScoped<IRepository, TwitterCloneRepository>();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("http://localhost:3000");

app.MapControllers();

app.Run();
