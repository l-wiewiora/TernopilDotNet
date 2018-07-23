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
            //var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";
            //var connection = @"Server=ternopildotnetdb;Database=EFGetStarted.AspNetCore.NewDb;User Id=SA;Password=<YourStrong!Passw0rd>;Trusted_Connection=True;ConnectRetryCount=0";
            //var connection = @"Data Source=ternopildotnetdb;Initial Catalog=EFGetStarted.AspNetCore.NewDb;User Id=SA;Password=<YourStrong!Passw0rd>;ConnectRetryCount=0";
            var connection = @"Server=ternopildotnetdb;User Id=SA;Password=<YourStrong!Passw0rd>;ConnectRetryCount=0";
            services.AddDbContext<CommentContext>(options => options.UseSqlServer(connection));
            services.AddScoped<ICommentRepository, CommentRepository>();
        }
    }
}
