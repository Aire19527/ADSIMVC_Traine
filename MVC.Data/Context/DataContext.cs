﻿using Microsoft.EntityFrameworkCore;
using MVC.Data.Entity;

namespace MVC.Data.Context
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        //Data

        public DbSet<ProductEntity> ProductEntity { get; set; }
        public DbSet<CategoryEntity> CategoryEntity { get; set; }
    }
}
