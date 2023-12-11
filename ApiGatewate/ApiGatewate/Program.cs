using ApiGatewate.Service;
using ApiGatewate.Service.Interface;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath).AddJsonFile("ocelot.json",optional:false,reloadOnChange:true).AddEnvironmentVariables();
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddHttpClient<ICatalogService, CatalogService>(c => c.BaseAddress = new Uri(builder.Configuration["ApiSettings: CatalogUrl"]));
builder.Services.AddHttpClient<IOrdersService, OrdersService>(c => c.BaseAddress = new Uri(builder.Configuration["ApiSettings: OrdersUrl"]));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
await app.UseOcelot();
app.Run();
