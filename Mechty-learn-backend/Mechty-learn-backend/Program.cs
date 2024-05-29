using System.Text.Json.Serialization;
using Mechty_learn_backend.Data;
using Mechty_learn_backend.Models;
using Mechty_learn_backend.Repositories;
using Mechty_learn_backend.Repositories.EducationRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var config =
    new ConfigurationBuilder()
        .AddUserSecrets<Program>()
        .Build();

var builder = WebApplication.CreateBuilder(args);
var connectionString = config["ConnectionString"] ?? Environment.GetEnvironmentVariable("CONNECTIONSTRING");
Console.WriteLine(Environment.GetEnvironmentVariable("DB"));
ConfigureSwagger();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IKidsRepository, KidsRepository>();
builder.Services.AddTransient<IAdultsRepository, AdultsRepository>();
builder.Services.AddTransient<ILessonRepository, LessonRepository>();
builder.Services.AddTransient<IChapterRepository, ChapterRepository>();
builder.Services.AddTransient<IChapterPageRepository, ChapterPageRepository>();
builder.Services.AddTransient<IChapterPageSoundRepository, ChapterPageSoundRepository>();
builder.Services.AddTransient<IChapterPageTextRepository, ChapterPageTextRepository>();
builder.Services.AddTransient<IChapterPage3DModeRepository, ChapterPage3DModelRepository>();
builder.Services.AddTransient<IProgressRepository, ProgressRepository>();
builder.Services.AddDbContext<ApplicationDbContext>((options) =>
    options.UseSqlServer(connectionString));
Console.WriteLine(connectionString);

AddCors();
AddIdentity();

var app = builder.Build();

app.UseCors("MyAllowSpecificOrigins");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

void ConfigureSwagger()
{
    builder.Services.AddSwaggerGen(option =>
    {
        option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });
    });
}

void AddCors()
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "MyAllowSpecificOrigins",
            policy  =>
            {
                policy
                    .WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                //.AllowCredentials();
                // .SetIsOriginAllowed(origin =>
                // {
                //     if (string.IsNullOrWhiteSpace(origin)) return false;
                //     if (origin.StartsWith("http://localhost", StringComparison.CurrentCultureIgnoreCase)) return true;
                //     if (origin.StartsWith("https://mechty-learn-frontend.onrender.com", StringComparison.CurrentCultureIgnoreCase)) return true;
                //     return false;
                // });
            });
    });
}

void AddIdentity()
{
    builder.Services
        .AddIdentityCore<Adult>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.User.RequireUniqueEmail = true;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>();
    
}