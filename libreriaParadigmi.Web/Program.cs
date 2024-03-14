using libreriaParadigmi.Application.Extensions;
using libreriaParadigmi.Models.Extensions;
using libreriaParadigmi.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddWebServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddModelServices(builder.Configuration);

var app = builder.Build();

app.AddWebMiddleware();

app.Run();
