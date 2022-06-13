using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SGAWebApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SGAWebApplication.Models
{
    public class DataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            optionsBuilder.UseMySql(configuration["ConnectionStrings:Defaultconnection"]);
        }
        public DbSet<User> user { get; set; }
        public DbSet<AboutUs> aboutus { get; set; }
        public DbSet<SliderImages> sliderimages { get; set; }
        public DbSet<ServicesMstr> servicesmstr { get; set; }
        public DbSet<ServicesHeaderContent> servicesheadercontent { get; set; }
    }

    
}
