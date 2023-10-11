using Domain.Entities;
using Infrastructure;
using Infrastructure.Data;

using Infrastructure.Servises.CourseServises;
using Infrastructure.Servises.GroupServises;

using Infrastructure.Servises.AnswerServices;
using Infrastructure.Servises.QuestionServices;
using Infrastructure.Servises.TestServices;


using Infrastructure.Servises.UserServise;
using Microsoft.EntityFrameworkCore;
using Web;

var builder = WebApplication.CreateBuilder(args);
var con = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(c => c.UseNpgsql(con));
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddScoped<IUserServise,UserServise>();

builder.Services.AddScoped<ICourseServise,CourseServise>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IGroupServise, GroupServise>();

builder.Services.AddScoped<ITestService,TestService>();
builder.Services.AddScoped<IQuestionService,QuestionService>();
builder.Services.AddScoped<IAnswerService,AnswerService>();


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

app.MapControllers();

app.Run();
