﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skippy.Models;

namespace Skippy.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext (DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Skippy.Models.Product> Product { get; set; }

        public DbSet<Skippy.Models.Categorie> Categorie { get; set; }
    }
}
