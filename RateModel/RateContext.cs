using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace RateModel
{
    public class RateContext : DbContext
    {
        public DbSet<RateClass> RateClasses { get; set; }
    }
}
