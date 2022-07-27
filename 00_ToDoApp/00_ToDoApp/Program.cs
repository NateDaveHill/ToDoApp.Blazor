using _00_ToDoApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddDbContext<MyDbContext>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

string dbName = "ToDo.db";

if (File.Exists(dbName))
{
    File.Delete(dbName);
}

using (var context = new MyDbContext())
{
    context.Database.EnsureCreated();
    context.SaveChanges();
}

await builder.Build().RunAsync();