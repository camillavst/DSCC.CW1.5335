using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSCC_CW1_5335.Model;
using DSCC_CW1_5335.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DSCC_CW1_5335
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
            services.AddCors(); // добавляем сервисы CORS
            services.AddMvc();
            services.AddDbContext<Model.MyContextDb>(o => o.UseSqlServer(Configuration.GetConnectionString("RoomDb")));
            services.AddTransient<IRoomRepository<Room>, RoomRepository>();
            services.AddTransient<IRoomRepository<RoomCategory>, RoomCategoryRepository>();
            services.AddTransient<IRoomRepository<RoomType>, RoomTypeRepository>();

            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });
            app.UseMvc();
            
        }
    }
}
