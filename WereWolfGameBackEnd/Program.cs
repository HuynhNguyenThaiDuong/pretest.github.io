using Microsoft.EntityFrameworkCore;
using WereWolfGameBackEnd.Data;
using WereWolfGameBackEnd.Service.AdminService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IAdminService, AdminService>();

builder.Services.AddDbContext<WereWolfGameDbContext>(
    option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("WereWolfGameDB"));
    }
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Show useCors with CorsPolicyBuilder
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
