using BlazorRouteParameterSSR;

var builder = WebApplication.CreateBuilder(args);

var netCoreVer = System.Environment.Version;
var runtimeVer = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
Console.WriteLine($"netCoreVer: {netCoreVer}");
Console.WriteLine($"runtimeVer: {runtimeVer}");

builder.Services.AddRazorComponents();

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

app.MapRazorComponents<App>();

// This way, the route parameter is working, without @page directive
//app.Map("route-parameter/{text}", (string text) => new RazorComponentResult<RouteParameter>(new { Text = text }));

app.Run();
