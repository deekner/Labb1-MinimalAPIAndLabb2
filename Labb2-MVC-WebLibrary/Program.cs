using Labb2_MVC_WebLibrary;
using Labb2_MVC_WebLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IBookService, BookService>();
builder.Services.AddScoped<IBookService, BookService>();

StaticDetails.BookApiBase = builder.Configuration["ServiceUrls:Labb2BookAPI"];


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.Use(async (context, next) =>
//{
//    await next();
//    if(context.Response.StatusCode == 404)
//    {
//        context.Request.Path = "/Book/Details/";
//        await next();
//    }
//});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
