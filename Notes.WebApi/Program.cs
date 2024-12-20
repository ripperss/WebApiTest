using Notes.Application.Common.Mappings;
using Notes.Application.interfaces;
using Notes.Persistence;
using System.Reflection;
using Notes.Application;

var builder = WebApplication.CreateBuilder(args);

var conf = builder.Configuration;


builder.Services.AddApplication();

builder.Services.AddPersistence(conf);


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
