using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain
{
    //Interface to allow mutiple contexts in situation of test vs. live environments
    public interface IDoughnutContext
    {
        DbSet<Doughnut> Doughnuts { get; set; }
        DbSet<Flavor> Flavors { get; set; }
        int SaveChanges();
    }

}

