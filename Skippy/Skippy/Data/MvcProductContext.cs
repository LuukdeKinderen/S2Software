using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skippy.Models;

namespace Skippy.Data
{
    public class MvcProductContext : DbContext
    {
        public MvcProductContext(DbContextOptions<MvcProductContext> options)
            : base(options)
        {
        }

        public DbSet<Skippy.Models.Product> Product { get; set; }
    }
}
