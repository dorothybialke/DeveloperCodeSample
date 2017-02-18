using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain
{

    public class SampleContext : DbContext, IDoughnutContext
    {
        public SampleContext() : base("DefaultConnection")
        {
           /* Database.SetInitializer<SampleContext>(null);*/ //as per Nick's email delete this line of code
        }

       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Doughnut> Doughnuts { get; set; }
        public DbSet<Flavor> Flavors { get; set; }

    }
}
