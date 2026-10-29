using ITHelpdeskTicketSystem.Data;
using ITHelpdeskTicketSystem.Services;
using ITHelpdeskTicketSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));//

builder.Services.AddScoped<ITicketRepository, SqlTicketRepository>();
builder.Services.AddScoped<INotifier, SmsNotifier>();
builder.Services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "ticketSearch",
//    pattern: "ticket/{search:alpha}",
//    defaults: new { controller = "Tickets", action = "Index"}
//);

//app.MapControllerRoute(
//    name: "gtticket",
//    pattern: "ticket/{id:int}",
//    defaults: new { controller = "Tickets", action = "Details"}
//);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
