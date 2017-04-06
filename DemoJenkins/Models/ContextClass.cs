using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoJenkins.Models
{
    public class ContextClass: DbContext
    {
        public DbSet<Item> Items { get; set; }
    }
}
