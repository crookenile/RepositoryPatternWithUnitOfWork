using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUnitOfWork.API;
using RepositoryPatternWithUnitOfWork.Core.Interfaces;
using RepositoryPatternWithUnitOfWork.EF.Context;
using RepositoryPatternWithUnitOfWork.EF.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader = true;
    options.InputFormatters.Insert(0, MyJPIF.GetJsonPatchInputFormatter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// add services to the container

//builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddCors();
//Contection String

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(
             builder.Configuration.GetConnectionString("DefualtConnection"),
             b => b.MigrationsAssembly(typeof(DataContext).Assembly.FullName));
});
builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
