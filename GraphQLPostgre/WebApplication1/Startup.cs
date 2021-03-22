using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.GraphQLCore;
using WebApplication1.GraphQLModels.ObjectTypes;
using WebApplication1.IServices;
using WebApplication1.Models;
using WebApplication1.Models.ModelContext;
using WebApplication1.Services;
using WebApplication1.Entities;

namespace WebApplication1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Db Postgre
            services.AddEntityFrameworkNpgsql().AddDbContext<DataDbContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("MyWebApiConection")));

            // Add authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration.GetSection("TokenSettings").GetValue<string>("Issuer"),
                        ValidateIssuer = true,
                        ValidAudience = Configuration.GetSection("TokenSettings").GetValue<string>("Audience"),
                        ValidateAudience = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("TokenSettings").GetValue<string>("Key"))),
                        ValidateIssuerSigningKey = true
                    };
                });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("user-policy", policy =>
            //    {
            //        policy.RequireRole(_context.Roles.Select(x => x.Name));
            //    });
            //});

            // Add Scoped Service
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IFarmerService, FarmerService>();
            services.AddScoped<ICattleService, CattleService>();
            services.AddScoped<IByreService, ByreService>();
            services.AddScoped<ITypeOfCattleService, TypeOfCattleService>();

            // Add scoped ObjectType
            services.AddScoped<QueryObjectType>();
            services.AddScoped<MutationObjectType>();

            // Add GraphQL
            services.AddGraphQLServer()
            .AddQueryType<QueryObjectType>()
            .AddMutationType<MutationObjectType>().AddAuthorization();

            // Config Token
            services.Configure<TokenSettings>(Configuration.GetSection("TokenSettings"));

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Add playground GraphQL
                app.UsePlayground(new PlaygroundOptions
                {
                    QueryPath = "/api",
                    Path = "/playground"
                });
            }

            app.UseRouting();
            app.UseGraphQL("/api");
            app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
