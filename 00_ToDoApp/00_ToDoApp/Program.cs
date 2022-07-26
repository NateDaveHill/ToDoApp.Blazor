using _00_ToDoApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

await builder.Build().RunAsync();




string dbName = "ToDo.db";
if (File.Exists(dbName))
{
    File.Delete(dbName);
}

using (var context = new MyDbContext())
{
    context.Database.EnsureCreated();
    context.SaveChanges();
} ;
