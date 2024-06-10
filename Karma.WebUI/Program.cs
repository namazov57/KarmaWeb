using Karma.Business;
using Karma.Data;
using Karma.Data.Repositories;
using Karma.Infrastructure.Commons;
using Karma.Infrastructure.Repositories;
using Karma.Infrastructure.Services.Abstracts;
using Karma.Infrastructure.Services.Concrates;
using Karma.Infrastructure.Services.Concretes;
using Karma.WebUI.Pipeline;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Karma.WebUI
{
    public class Program
    {
        internal static string[] policies = null;
        public static void Main(string[] args)
        {
            ReadAllPolicies();

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews(cfg =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

                cfg.Filters.Add(new AuthorizeFilter(policy));

            });

            DataServiceInjection.InstallDataServices(builder.Services, builder.Configuration);

            builder.Services.AddRouting(cfg => cfg.LowercaseUrls = true);

            builder.Services.Configure<EmailOptions>(cfg =>
            {
                builder.Configuration.GetSection(cfg.GetType().Name).Bind(cfg);
            });
            builder.Services.AddSingleton<IEmailService, EmailService>();
            builder.Services.AddSingleton<IDateTimeServive, DateTimeServive>();
            builder.Services.AddSingleton<IFileService, FileService>();
            builder.Services.AddSingleton<ICryptoService, CryptoService>();
            builder.Services.AddScoped<IIdentityService, IdentityService>();
            builder.Services.AddScoped<IClaimsTransformation, AppClaimProvider>();

            builder.Services.AddMediatR(cfg =>
            {

                cfg.RegisterServicesFromAssembly(typeof(IBusinessReferance).Assembly);

            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(cfg =>
                {
                    cfg.LoginPath = "/signin.html";
                    cfg.AccessDeniedPath = "/accessdenied.html";
                    cfg.ExpireTimeSpan = TimeSpan.FromMinutes(10);

                    cfg.Cookie.Name = "karma";
                    cfg.Cookie.HttpOnly = true;
                });
            builder.Services.AddAuthorization(cfg =>
            {
                foreach (var policyName in policies)
                {
                    cfg.AddPolicy(policyName, p => p.RequireAssertion(handler =>
                    {
                        return handler.User.IsInRole("superadmin") || handler.User.HasClaim(policyName, "1");
                    }));
                }
            });

            builder.Services.Configure<IdentityOptions>(cfg =>
            {

                cfg.User.RequireUniqueEmail = true;
                //cfg.User.AllowedUserNameCharacters = "abcdef123456789";

                cfg.Password.RequireUppercase = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireDigit = false;
                cfg.Password.RequiredUniqueChars = 1;
                cfg.Password.RequiredLength = 3;
                cfg.Password.RequireNonAlphanumeric = false;


                cfg.Lockout.AllowedForNewUsers = true;
                cfg.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                cfg.Lockout.MaxFailedAccessAttempts = 3;

            });

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                    );

                cfg.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");

            });

            app.Run();
        }

        private static void ReadAllPolicies()
        {
            var types = typeof(Program).Assembly.GetTypes();

            policies = types
                .Where(t => typeof(ControllerBase).IsAssignableFrom(t) && t.IsDefined(typeof(AuthorizeAttribute), true))
                .SelectMany(t => t.GetCustomAttributes<AuthorizeAttribute>())
                .Union(
                types
                .Where(t => typeof(ControllerBase).IsAssignableFrom(t))
                .SelectMany(type => type.GetMethods())
                .Where(method => method.IsPublic
                 && !method.IsDefined(typeof(NonActionAttribute), true)
                 && method.IsDefined(typeof(AuthorizeAttribute), true))
                 .SelectMany(t => t.GetCustomAttributes<AuthorizeAttribute>())
                )
                .Where(a => !string.IsNullOrWhiteSpace(a.Policy))
                .SelectMany(a => a.Policy.Split(new[] { "," }, System.StringSplitOptions.RemoveEmptyEntries))
                .Distinct()
                .ToArray();
        }


    }
}

