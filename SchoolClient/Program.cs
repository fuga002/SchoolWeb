using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using SchoolClient.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(); 
builder.Services.AddBlazorise(options =>
    {
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();
builder.Services.AddScoped<HttpService>();
builder.Services.AddHttpClient();
builder.Services
    .AddBlazorise(options =>
    {
       
    })
    .AddBootstrapProviders();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
