using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ToDoApp;
using File = System.IO.File;
using HeadOutlet = Microsoft.AspNetCore.Components.Web.HeadOutlet;
using HttpClient = System.Net.Http.HttpClient;
using Uri = System.Uri;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<MyDbContext>();

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