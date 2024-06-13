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
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
