using ABCD.Company.Repository;
using ABCD.Company.Services;
using Microsoft.EntityFrameworkCore;
using ABCD.Company.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
//builder.Services.AddScoped<IDepartmentRepo, test>();




// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddDbContext<AppDBcontext>(options =>
    options.UseLazyLoadingProxies()
           .UseSqlServer(builder.Configuration.GetConnectionString("constr"),
               o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
