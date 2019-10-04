using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AreaCalculatorRestApi.Models
{
    //public class AreaContext
    public class AreaContext : DbContext
    {

        public AreaContext(DbContextOptions<AreaContext> options)
            : base(options)
        {
        }

        public DbSet<Area> AreaItems { get; set; }

    }
}
