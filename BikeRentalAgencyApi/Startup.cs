using BikeRentalAgencyApi.Models;
using BikeRentalAgencyApi.Repository;
using BikeRentalAgencyApi.Repository.Repositories;
using BikeRentalAgencyApi.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BikeRentalAgencyApi
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BikeRentalAgencyApi", Version = "v1" });
            });

            services.AddTransient<IBikeRepository, BikeRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IStoreRepository, StoreRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();


            services.AddDbContext<BikeStoreContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:BikeStoreContext"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BikeRentalAgencyApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
