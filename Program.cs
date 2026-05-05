using System.Text;
using AspnetCoreMvcFull.Repositories;
using AspnetCoreMvcFull.Services;
using AspnetCoreMvcFull.Workers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<MetricsRepository>();
builder.Services.AddScoped<LiveMetricsRepository>();
builder.Services.AddScoped<LiveMetricsRepository>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<FacebookAdsService>();
builder.Services.AddScoped<ReportBuilderService>();
builder.Services.AddHttpClient<LarkService>();
builder.Services.AddHostedService<ReportWorker>();

Console.OutputEncoding = Encoding.UTF8;
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboards}/{action=Index}/{id?}");

app.Run();
