using ItemDashboard.UI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

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
