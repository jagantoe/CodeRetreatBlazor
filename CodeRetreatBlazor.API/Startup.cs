using CodeRetreatBlazor.API.Hubs;
using CodeRetreatBlazor.API.Hubs.InfiniteDoorsHub;
using CodeRetreatBlazor.App.Services;
using CodeRetreatBlazor.DataAccess;
using CodeRetreatBlazor.Service;
using CodeRetreatBlazor.Service.InfiniteDoors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CodeRetreatBlazor.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //API
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CodeRetreatBlazor.API", Version = "v1" });
            });

            //SignalR
            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
            });
            services.AddSingleton<ChallengeManager<InfinitePrimeDoorChallenge>>();

            //Blazor
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpClient();

            services.AddScoped<ChallengeDataService>();

            //DataAccess
            services.ConfigureDataAccess();

            //Service
            services.ConfigureService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CodeRetreatBlazor.API v1"));

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<InfiniteDoorsHub>("hub/infinitedoors");
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
