using PowkeApp.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PowkeApp.Data;
using PowkeApp.Api; 

var builder = WebApplication.CreateBuilder(args);

// Register the DBContext with the DEVELOPMENT connexion string
builder.Services.AddDbContextFactory<PowkeAppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PowkeAppDbContext") ?? throw new InvalidOperationException("Connection string 'PowkeAppDbContext' not found.")));

// Register the QuickGrid Adapter for EF Core. This allows QuickGrid component to query directly the data
builder.Services.AddQuickGridEntityFrameworkAdapter();

// Register a developer-friendly error page filter for database exceptions
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Registers HttpClient for Blazor components to consume internal API endpoints
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7078") });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // In production: redirects unhandled exceptions to the /Error page.
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
     // In development: displays a UI page when pending EF Core migrations are detected, allowing the developer to apply them directly from the browser.
     app.UseMigrationsEndPoint();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// API Endpoints
//app.MapSeedEndpoints(); //  seed to get datas from poke api Go to https://localhost:7078/api/seed
app.MapPokemonEndpoints();




app.Run();
