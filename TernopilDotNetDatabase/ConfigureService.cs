using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TernopilDotNetDatabase
{
    public class ConfigureService
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Data Source=ternopildotnetdb;Initial Catalog=ternopildotnetdb;User Id=SA;Password=<YourStrong!Passw0rd>;ConnectRetryCount=0";
            services.AddDbContext<CommentContext>(options => options.UseSqlServer(connection));
            // Automatically create DB
            services.BuildServiceProvider().GetService<CommentContext>().Database.EnsureCreated();
            services.AddScoped<ICommentRepository, CommentRepository>();
        }
    }
}
