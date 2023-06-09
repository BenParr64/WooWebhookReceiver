using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using PdfOrders.Repositories;
using Reports.Repositories;
using Services;
using Services.Interfaces;
using Services.ViewRendering;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

const string localSettingFileName = "local.settings.json";
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(localSettingFileName, true, true)
    .AddEnvironmentVariables()
    .Build();

const string configurationSettings = "ConfigurationSettings";

builder.Services.Configure<ConfigurationSettings>(configuration.GetSection(configurationSettings));

builder.Services.AddSignalR();
builder.Services.AddSingleton(x => new ServiceBusClient(configuration.GetSection(configurationSettings).GetSection("ServiceBusSenderConnectionString").Value));
builder.Services.AddSingleton<IPdfGeneratorService, PdfGeneratorService>();
builder.Services.AddHttpClient<IWoocommerceClient, WoocommerceClient>();
builder.Services.AddScoped<ITemplateGeneratorService, TemplateGeneratorServiceService>();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddScoped<ViewRenderer>();

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
app.MapHub<OrderHub>("/orderhub");

app.Run();
