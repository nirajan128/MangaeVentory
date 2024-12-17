var builder = WebApplication.CreateBuilder(args);

//Service required for MapControllerRoute
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Allows progarm to use public files in wwwroot
app.UseStaticFiles();

//Alows program to use routing
app.UseRouting();

//Route taken from the controller where controller name is Home and action is index
app.MapControllerRoute(
    name: "default," ,
    pattern: "{controller=Home}/{action=index}/{id?}"
    );

app.Run();
