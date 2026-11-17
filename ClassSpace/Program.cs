using Microsoft.EntityFrameworkCore;
using DAL.Data;
using DAL.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler =
            ReferenceHandler.IgnoreCycles);   
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//========sql server===========
builder.Services.AddDbContext<ClassSpaceDB>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlConnection")));

//==========DAL================
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ITeacherSubjectRepository, TeacherSubjectRepository>();
builder.Services.AddScoped<IStudyUnitRepository, StudyUnitRepository>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IAssignmentUnitRepository, AssignmentUnitRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IVoteRepository, VoteRepository>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();


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
