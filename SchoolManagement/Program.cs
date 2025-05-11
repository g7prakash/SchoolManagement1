using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;
using SchoolManagement.DataAccess.Interfaces;
using SchoolManagement.Models.Repositories;
using StudentManagement.Authorization;
using StudentManagement.DataAccess.Contexts;
using StudentManagement.DataAccess.Helpers;
using StudentManagement.DataAccess.Interfaces;
using StudentManagement.DataAccess.Repositories;
using StudentManagement.Models;
using System.Globalization;

namespace SchoolManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(LogLevel.Trace);
            });

            builder.Services.AddSingleton<ILoggerProvider, NLogLoggerProvider>();
            // Add services to the container.
            builder.Services.AddDbContextPool<SchoolDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolRoutineDB")));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 2;

                options.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<SchoolDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddControllersWithViews(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddRazorRuntimeCompilation();
            
            builder.Services.AddAuthentication().AddGoogle(options => 
            {
                options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
                options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
                });

            builder.Services.ConfigureApplicationCookie(options => {
                options.AccessDeniedPath = new PathString("/Administration/AccessDenied");
            });

            builder.Services.AddAuthorization(options => {
                options.AddPolicy("Delete Policy", 
                    policy => policy.RequireClaim("Delete Role"));

                options.AddPolicy("EditPolicy",
                    policy => policy.RequireAssertion(
                        context =>
                        context.User.IsInRole("admin") &&
                        context.User.HasClaim(claim => claim.Type == "Edit Role" && claim.Value == "true") ||
                        context.User.IsInRole("super admin")
                        ));

                options.AddPolicy("AdminRolePolicy", 
                    policy => policy.RequireRole("admin"));
            });
            builder.Services.AddScoped<ISchoolClassRepository, SchoolClassRepository>();
            builder.Services.AddScoped<IPeriodRepository, PeriodRepository>();
            builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
            builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
            builder.Services.AddScoped<ITimeTableEntryRepository, TimeTableEntryRepository>();
            builder.Services.AddScoped<IEmployeeDept, EmployeeDeptRepository>();
            // configure DI for application services
            builder.Services.AddScoped<IJwtUtils, JwtUtils>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Routine/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                //app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
            }

            app.UseHttpsRedirection();

            app.Use(async (context, next) =>
            {
                var cultureQuery = context.Request.Query["culture"];
                if (!string.IsNullOrWhiteSpace(cultureQuery))
                {
                    var culture = new CultureInfo(cultureQuery);

                    CultureInfo.CurrentCulture = culture;
                    CultureInfo.CurrentUICulture = culture;
                }

                // Call the next delegate/middleware in the pipeline.
                await next(context);
            });

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Routine}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
