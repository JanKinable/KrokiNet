using KrokiClient.Demo;
using KrokiNet.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<IDemoGraph, DemoGraph>();
builder.Services.AddKroki();

using IHost host = builder.Build();

var demo = host.Services.GetRequiredService<IDemoGraph>();
await demo.GenerateImage();

host.RunAsync();