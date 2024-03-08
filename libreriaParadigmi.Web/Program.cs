using libreriaParadigmi.Application.Abstractions;
using libreriaParadigmi.Application.Options;
using libreriaParadigmi.Application;
using libreriaParadigmi.Models.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using libreriaParadigmi.Application.Services;
using libreriaParadigmi.Models.Repositories;
using libreriaParadigmi.Web.Results;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(opt =>
{
    opt.InvalidModelStateResponseFactory = (context) =>
    {
        return new BadRequestResultFactory(context);
    };
}); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Libreria",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddDbContext<MyDbContext>(conf =>
{
    conf.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext"));
});


var jwt = new JwtAuthenticationOption();
builder.Configuration.GetSection("JwtAuthentication")
.Bind(jwt);

builder.Services.Configure<JwtAuthenticationOption>(builder.Configuration.GetSection("JwtAuthentication"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
               .AddJwtBearer(options =>
               {
                   string key = jwt.Key;
                   var securityKey = new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes(key)
                       );
                   options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                   {
                       ValidateIssuer = true,
                       ValidateLifetime = true,
                       ValidateAudience = false,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = jwt.Issuer,
                       IssuerSigningKey = securityKey
                   };
               });
//adding services
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<LibroRepository>();
builder.Services.AddScoped<UtenteRepository>();
//adding repositories
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped<IUtenteService, UtenteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
