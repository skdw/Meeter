using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Meeter.AuthorizationRequirements;
using Meeter.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace Meeter
{
  


    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<NormalDataContext>(opts => opts.UseInMemoryDatabase("MeeterDatabase"));
            var connection = Configuration["DatabaseConnectionString"];
            //services.AddDbContext<MeeterDbContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<NormalDataContext>(options => options.UseSqlServer(connection));
            //services.AddDefaultIdentity<User>()
            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequiredLength = 4;
                config.Password.RequireUppercase = false;
                config.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<NormalDataContext>()
                .AddDefaultTokenProviders()
                .AddRoles<IdentityRole>();

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "Identity.cookie";
                config.AccessDeniedPath = "/api/meeter/AccesDenied";
                config.LoginPath = "/api/meeter/Login";
            });

            //services.AddAuthorization(options =>
            //{
            //    //var defaultAuthBuilder = new AuthorizationPolicyBuilder();
            //    //var defaultAuthPolicy = defaultAuthBuilder
            //    //    .RequireAuthenticatedUser()
            //    //    .Build();

            //    //options.DefaultPolicy = defaultAuthPolicy;

            //    //options.AddPolicy("Claim.DoB", policyBuilder =>
            //    //{
            //    //    policyBuilder.RequireClaim(ClaimTypes.DateOfBirth);
            //    //});

            //    options.AddPolicy("Claim.DoB", policyBuilder =>
            //    {
            //        //policyBuilder.AddRequirements(new CustomRequireClaim(ClaimTypes.DateOfBirth));
            //        policyBuilder.RequireCustomClaim(ClaimTypes.DateOfBirth);
            //    });
            //});

            services.AddScoped<IAuthorizationHandler, CustomRequireClaimHandler>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            /*
            services.AddAuthorization(options =>
            {

                //options.AddPolicy("RequireAdministratorRole",
                //    policy => policy.RequireRole("Administrator"));

                //options.AddPolicy(Operations.Read.Name, policy =>
                //    policy.Requirements.Add(new SameAuthorRequirement()));
            }); */

            //services.AddSingleton<IAuthorizationHandler, EventAuthorizationHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            // app.UseAuthorization();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            //app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Meeter}/{action=Index}/{id?}");
            });
            CreateUserRoles(serviceProvider).Wait();
            
        }
        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();

            IdentityResult roleResult;
            //Adding Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                //create the roles and seed them to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }
            //Assign Admin role to the main User here we have given our newly registered 
            //login id for Admin management
            User user = await UserManager.FindByEmailAsync("kamil.gorzynski8@gmail.com");
            var User = new User();
            await UserManager.AddToRoleAsync(user, "Admin");
        }
    }
}
