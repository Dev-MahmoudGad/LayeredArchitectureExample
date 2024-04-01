using Test.Infrastructure;
using Test.Application.Contracts.Features;
using Test.Application.Contracts.Persistance;
using Test.Application.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
builder.Services.AddScoped<PetrobelAppContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IDepartmentAppService, DepartmentAppService>();
builder.Services.AddScoped<IEmployeeAppService, EmployeeAppService>();

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
