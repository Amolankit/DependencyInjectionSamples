using DependencyInjectionSample;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IGuidSingleton>(new GuidGenerator());
builder.Services.AddScoped<IGuidScoped, GuidGenerator>();
builder.Services.AddTransient<IGuidTransient, GuidGenerator>();

var app = builder.Build();

app.MapGet("/instance",
    (IGuidSingleton idSingleton,
    IGuidScoped idScoped1,
    IGuidScoped idScoped2,
    IGuidTransient idTransient1,
    IGuidTransient idTransient2) =>
{
    return
    $"Singleton instance: {idSingleton.Value}\r\n\r\n" +

    $"Scoped instance 1: {idScoped1.Value}\r\n" +
    $"Scoped instance 2: {idScoped2.Value}\r\n\r\n" +

    $"Transient instance 1: {idTransient1.Value}\r\n" +
    $"Transient instance 2: {idTransient2.Value}";
});

app.Run();