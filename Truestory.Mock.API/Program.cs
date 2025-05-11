using Microsoft.AspNetCore.Diagnostics;
using Truestory.Mock.API.BusinessLogic;
using Truestory.Mock.API.BusinessLogic.Interfaces;
using Truestory.Mock.API.Exceptions;
using Truestory.Mock.API.Repository;
using Truestory.Mock.API.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IMockAPIRepository, MockAPIRepository>();
builder.Services.AddSingleton<IMockAPIService, MockAPIService>();
builder.Services.AddControllers();
builder.Services.AddHttpClient("MockApi", client =>
{
    client.BaseAddress = new Uri("https://api.restful-api.dev/");
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add global error handling
builder.Services.AddExceptionHandler<MockAPIExceptionHandler>();
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
