using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RecOutletWarehouse.Models;

namespace RecOutletWarehouse.Models
{
    public class RecreationEntities : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<ItemManagement.Item> Items { get; set; }
        public DbSet<ItemManagement.Category> Categories { get; set; }
        public DbSet<ItemManagement.SubCategory> SubCategories { get; set; }
        public DbSet<ItemManagement.Department> Departments { get; set; }
    }
}