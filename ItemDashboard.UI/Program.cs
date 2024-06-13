using ItemDashboard.UI.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Host Configuration
builder.Host.UseSerilog((HostBuilderContext context, IServiceProvider services, LoggerConfiguration loggerConfiguration) =>
{
    loggerConfiguration
    .ReadFrom.Configuration(context.Configuration) // read configuration settings from built-in IConfiguration
    .ReadFrom.Services(services); // read out current app's services and make them available to serilog
});

// Services Configuration
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware Pipeline

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();    // development error page
}
else
{
    app.UseExceptionHandler("/Error");  // production error page
    app.UseMiddleware<ExceptionHandlingMiddleware>();   // exception safety net
}

app.UseStaticFiles();   // enable public folder (wwwroot)
app.UseSerilogRequestLogging(); // enable logging request to file
app.UseRouting();       // enable conventional routing
app.UseEndpoints(endpoints =>
{
    // conventional routing
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.MapControllers();   // enable attribute routing

app.Run();
