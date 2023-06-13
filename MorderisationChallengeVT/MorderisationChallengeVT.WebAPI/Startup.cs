using Microsoft.EntityFrameworkCore;
using MorderisationChallengeVT.Business;
using MorderisationChallengeVT.Contracts.Businesses;
using MorderisationChallengeVT.Domain.Repositories;
using MorderisationChallengeVT.Persistence;
using MorderisationChallengeVT.Persistence.Extensions;
using MorderisationChallengeVT.Persistence.Repositories;

namespace MorderisationChallengeVT.WebAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MorderisationChallengeDbContext>(x =>
            {
                var connectionString = _configuration.GetConnectionString("Database");

                x.UseSqlServer(connectionString);

                x.RegisterDbContextTrigger();
            });

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("VueCorsPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins("http://localhost:8080", "https://localhost:8080");
                });
            });

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<ITaskBusiness, TaskBusiness>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("VueCorsPolicy");

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
