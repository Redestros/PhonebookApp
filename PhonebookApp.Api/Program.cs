using PhonebookApp.Infrastructure.Extensions;
using PhonebookApp.UseCases.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddApplicationServices();
builder.AddInfrastructureServices();

const string defaultPolicy = "default";

builder.Services.AddCors(options => options.AddPolicy(defaultPolicy,
    configurePolicy => configurePolicy
        .WithOrigins("http://localhost:5094")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(defaultPolicy);

app.MapControllers();
app.Run();