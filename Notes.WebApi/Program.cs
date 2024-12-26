using Notes.Application.Common.Mappings;
using Notes.Application.interfaces;
using Notes.Persistence;
using System.Reflection;
using Notes.Application;
using AutoMapper;
using Notes.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

var conf = builder.Configuration;

builder.Services.AddControllers();

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    cfg.AddProfile(new AssemblyMappingProfile(typeof(INotesDbContext).Assembly));
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddApplication();

builder.Services.AddPersistence(conf);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("Allowall", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});


var app = builder.Build();


app.UseRouting();

app.UseCustomExeptionHandler();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseEndpoints(endpoint =>
{
    endpoint.MapControllers();
});

app.MapGet("/", () => "Hello World!");

app.Run();
