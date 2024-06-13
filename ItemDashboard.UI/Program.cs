using ItemDashboard.UI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Services Configuration
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware Pipeline

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseMiddleware<ExceptionHandlingMiddleware>();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
