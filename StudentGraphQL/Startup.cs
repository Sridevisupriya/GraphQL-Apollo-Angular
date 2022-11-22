using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StudentGraphQL.Interfaces;
using StudentGraphQL.Models;
using StudentGraphQL.Mutation;
using StudentGraphQL.Query;
using StudentGraphQL.Repository;
using StudentGraphQL.Schema;
using StudentGraphQL.Services;
using StudentGraphQL.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGraphQL
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
            services.AddDbContext<StudentDbContext>(Option => Option.UseSqlServer(Configuration.GetConnectionString("constr")));
            services.AddControllers();
            services.AddTransient<IStudentRepo , StudentRepo>();
            services.AddTransient<IStudentService , StudentService>();
            services.AddTransient<StudentType>();
            services.AddTransient<StudentQuery>();
            services.AddTransient<StudentMutation>();
            services.AddTransient<ISchema ,StudentSchema>();           
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = false;
            }).AddSystemTextJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseGraphiQl("/graphql");
            app.UseGraphQL<ISchema>();
        }
    }
}
