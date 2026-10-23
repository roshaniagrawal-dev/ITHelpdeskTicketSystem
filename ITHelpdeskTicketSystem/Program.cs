using ITHelpdeskTicketSystem.Data;
using ITHelpdeskTicketSystem.Models;
using ITHelpdeskTicketSystem.Models.Enums;
using ITHelpdeskTicketSystem.Services;
using ITHelpdeskTicketSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ITicketRepository, SqlTicketRepository>();
builder.Services.AddScoped<INotifier, SmsNotifier>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

using (var scope = app.Services.CreateScope()){
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!db.Tickets.Any())
    {
        db.Tickets.AddRange(
            new HardwareTicket("LPU001", "Need new laptop", "Old laptop not working.", TicketPriority.High),
            new SoftwareTicket("VS2022", "Install VS 2022", "Need it for .NET work.", TicketPriority.Medium),
            new AccessRequestTicket("VPN", "VPN access", "Can't work without it.", TicketPriority.Critical, DateTime.Now.AddDays(-1))
        );
        db.SaveChanges();
    }
}
    

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
