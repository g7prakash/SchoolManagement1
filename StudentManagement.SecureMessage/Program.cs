
using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.KeyVault;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using SchoolManagement.DataAccess.Interfaces;
using SchoolManagement.Models.Repositories;
using StudentManagement.DataAccess.Contexts;
using StudentManagement.DataAccess.Helpers;
using StudentManagement.DataAccess.Interfaces;
using StudentManagement.DataAccess.Repositories;
using StudentManagement.SecureMessage.Authorization;
using StudentManagement.SecureMessage.Controllers;
using System.Text.Json.Serialization;

namespace StudentManagement.SecureMessage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.WebHost.ConfigureAppConfiguration((context, config) =>
            //{
            //    var builtConfig = config.Build();
            //    var vaultName = builtConfig["VaultName"];
            //    var keyVaultClient = new KeyVaultClient(async (authority, resource, scope) =>
            //    {
            //        var credential = new DefaultAzureCredential(false);
            //        var token = credential.GetToken(
            //            new Azure.Core.TokenRequestContext(
            //                new[] { "https://vault.azure.net/.default" }));
            //        return token.Token;
            //    });
            //    config.AddAzureKeyVault(vaultName, keyVaultClient, new DefaultKeyVaultSecretManager());
            //});
            // Add services to the container.
            builder.Services.AddCors();
            builder.Services.AddControllers().AddJsonOptions(options => 
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;

            }).AddXmlSerializerFormatters();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IMessageSender, AzureQueueMessageSender>();

            builder.Services.AddDbContextPool<SchoolDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolRoutineDB")));
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<SchoolDbContext>();

            builder.Services.AddTransient<IEmployeeDept, EmployeeDeptRepository>();

            // configure DI for application services
            builder.Services.AddScoped<IJwtUtils, JwtUtils>();
            builder.Services.AddScoped<IUserService, UserService>();
            //builder.Services.AddTransient<GlobalExceptionHandleMiddleware>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            //app.UseMiddleware<GlobalExceptionHandleMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();


            // global cors policy
            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            // global error handler
            //app.UseMiddleware<GlobalExceptionHandleMiddleware>();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
