using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BiesterlanDbContext>
    {
        public BiesterlanDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<BiesterlanDbContext>();
            var connectionString = configuration.GetConnectionString("BiesterlanDatabase");
            builder.UseSqlServer(connectionString);
            return new BiesterlanDbContext(builder.Options);
        }

        public BiesterlanDbContext CreateDbContext(string connectionstring, string connectionname)
        {
            
            var builder = new DbContextOptionsBuilder<BiesterlanDbContext>();
            var connectionString = connectionstring;
            builder.UseSqlServer(connectionString);
            
            return new BiesterlanDbContext(builder.Options);
        }
    }
}
