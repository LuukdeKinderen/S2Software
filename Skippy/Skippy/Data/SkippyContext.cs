using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skippy.Models;

namespace Skippy.Data
{
    public class SkippyContext : DbContext
    {
        public SkippyContext (DbContextOptions<SkippyContext> options)
            : base(options)
        {
        }

        public DbSet<Skippy.Models.Product> Product { get; set; }
    }
}
