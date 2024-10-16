using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//name file in Folder Data
//builder.Services.AddDbContext<TypeProductContext>(options =>
//    {
//        options.UseSqlServer(
//            builder.Configuration.GetConnectionString("DefaultConnection"));
//    });

builder.Services.AddDbContext<CustomerContext>(options =>
    {
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection"));
    });

//DefaultConnection in program.cs

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Index}/{id?}"); //first start controller / view / index
                                        //action = view

//add controller click folder controller / add / controller 

app.Run();
