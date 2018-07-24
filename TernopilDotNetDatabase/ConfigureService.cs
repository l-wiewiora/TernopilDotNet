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
            // MS Sql Server connection
            //var msSqlConnection = @"Data Source=ternopildotnetmssqlserverdb;Initial Catalog=ternopildotnetdb;User Id=SA;Password=<YourStrong!Passw0rd>;ConnectRetryCount=0";
            //services.AddDbContext<CommentContext>(options => options.UseSqlServer(msSqlConnection));


            // My Sql database connection
            var mySqlConnection = @"Data Source=ternopildotnetmysqldb;Initial Catalog=ternopildotnetdb;User=root;Password=<YourStrong!Passw0rd>;";
            services.AddDbContext<CommentContext>(options => options.UseMySql(mySqlConnection));


            services.AddScoped<ICommentRepository, CommentRepository>();
        }
    }
}
