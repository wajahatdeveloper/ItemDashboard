using ItemDashboard.UI.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Host Configuration
// add support to logging with SERILOG
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

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
