using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace TernopilDotNetDatabase
{
    public class CommentContext : DbContext
    {
        public CommentContext(DbContextOptions<CommentContext> options)
            : base(options)
        {
            // Only temporary workaround for database setup delay in docker containers
            // TODO: introduce wait-for-it script when building image ( reference: https://docs.docker.com/compose/startup-order/)
            for (int i = 0; i < 200; i++)
            {
                try
                {
                    Database.EnsureCreated();
                    break;
                }
                catch(Exception e) when (e is MySqlException || e is SqlException)
                {
                    Thread.Sleep(1000);
                }
            }

        }

        public DbSet<Comment> Comments { get; set; }
    }
}
