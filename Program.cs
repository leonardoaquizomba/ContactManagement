using ContactManagement.Data.Context;
using ContactManagement.Data.Repository;
using ContactManagement.Interfaces;
using ContactManagement.Model;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => { });

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IUser, AspNetUser>();
builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddRazorPages().AddMvcOptions(options => options.Filters.Add(new AuthorizeFilter()));

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
