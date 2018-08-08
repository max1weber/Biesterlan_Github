

using BiesterlanOrders.Models;
using Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BiesterlanDbContext : DbContext, IDataContext
    {
        private readonly string _schemaName;

        public BiesterlanDbContext(DbContextOptions<BiesterlanDbContext> options, string schemaName = null)
            : base(options)
        {
            _schemaName = schemaName;

            #region Repository           

            // Instance repositories properties - Sample:
            // SampleRepository = new SampleRepository(this);

            #endregion
        }

        public  string SchemaName { get { return this._schemaName; } }

        #region DbSet        

        //Insert DbSet properties 
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Orderline> Orderlines { get; set; }

        #endregion

        #region Repository Properties  

        // Insert IRepository properties - Sample:
        // public ISampleRepository SampleRepository { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //var entityTypeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
            //    !string.IsNullOrEmpty(type.Namespace))
            //    .Where(type => type.GetInterfaces().Contains(typeof(IEntityTypeConfiguration<>)));


            //// Add all fluent API configurations
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new Articlemap());
            modelBuilder.ApplyConfiguration(new OrderMap());
           



        }

        public Task CommitAsync()
        {
            return this.SaveChangesAsync();
        }
    }
}
