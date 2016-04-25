using System;
using System.Collections.Generic;
using System.Data.Entity;
using Vattenfall_IT_test.Models;

namespace Vattenfall_IT_test
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {
        }
    
        public virtual DbSet<FooModels> Foos { get; set; }

    }
}
