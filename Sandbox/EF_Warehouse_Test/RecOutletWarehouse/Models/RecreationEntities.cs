using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RecOutletWarehouse.Models;

namespace RecOutletWarehouse.Models
{   
    //  READ ME FIRST 
    /// <summary>
    /// This class has been deprecated
    /// Please refer to RecreationOutlet_Test1Context.cs
    /// for the new DbContext Model
    /// </summary>
    public class RecreationEntities : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Application>().ToTable("DBA_APPLICATIONS");
            //modelBuilder.Entity<ItemManagement.Item>().ToTable("ITEM");
            //modelBuilder.Entity<ItemManagement.Category>().ToTable("ITEM_CATEGORY");
            //modelBuilder.Entity<ItemManagement.SubCategory>().ToTable("ITEM_SUBCATEGORY");
            //modelBuilder.Entity<ItemManagement.Department>().ToTable("ITEM_DEPARTMENT");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<ItemManagement.Item> Items { get; set; }
        public DbSet<ItemManagement.Category> Categories { get; set; }
        public DbSet<ItemManagement.SubCategory> SubCategories { get; set; }
        public DbSet<ItemManagement.Department> Departments { get; set; }
    }
}