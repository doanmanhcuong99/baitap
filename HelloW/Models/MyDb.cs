using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloW.Models
{
    public class MyDb : DbContext
    {
        public MyDb(DbContextOptions<MyDb> option)
            : base(option)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
