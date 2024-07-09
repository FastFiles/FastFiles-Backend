using FastFiles.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FastFiles.Services;
using FastFiles.Helpers;
using FastFiles.Providers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Controllers
builder.Services.AddControllers();

// Cors 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

//Agregamos la configiuracion de Jwt
builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters{
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = @Environment.GetEnvironmentVariable("Jwturl"), //Agregamos variable de entorno Jwt
        ValidAudience = @Environment.GetEnvironmentVariable("JwtUrl"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mcrfnief3ie84r4hrffrñ@dnrcnjfcnfnjcnjr232N"))
    };
});

// Config DB
builder.Services.AddDbContext<FastFilesContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

// Scopes de los servicios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFolderRepository, FolderRepository>();
builder.Services.AddScoped<IMailerSendRepository, MailerSendRepository>();
builder.Services.AddScoped<IFilesRepository, FilesRepository>();

//Agregamos los servicios de las carpetas Helpers y Providers
builder.Services.AddSingleton<HelperUploadFiles>();
builder.Services.AddSingleton<PathProvider>();

// Cliente Http (MailerSend)
builder.Services.AddHttpClient();

var app = builder.Build();

// Cors
app.UseCors("AllowAnyOrigin");

app.UseHttpsRedirection();

// Controllers
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//Jwt
app.UseAuthentication();
app.UseAuthorization();

app.Run();

