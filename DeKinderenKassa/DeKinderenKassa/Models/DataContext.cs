using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace DeKinderenKassa.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}