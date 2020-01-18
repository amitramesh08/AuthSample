using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Auth.AuthSample
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
            services.AddAuthentication("Cookies").AddCookie(config =>
            {
                config.Cookie.Name = "Grame.Cookies";
                config.LoginPath = "/Auth/AuthoizeMe";
                config.LogoutPath = "/Auth/Index";
                config.ExpireTimeSpan = TimeSpan.FromMinutes(1);
            });

          
            //services.AddAuthentication(config =>
            //{
            //    config.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //});

           // services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           //.AddCookie(options =>
           //{
           //    options.LoginPath = "/Auth/AuthoizeMe";
           //});


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseAuthentication();

            var cookiePolicyOptions = new CookiePolicyOptions() {  };
            app.UseCookiePolicy();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
