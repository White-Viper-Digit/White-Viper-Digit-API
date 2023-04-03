﻿using White.Viper.Digit.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace White.Viper.Digit.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base (options)
            { }
        public DbSet<Item> Items { get; set; }
    }
}

