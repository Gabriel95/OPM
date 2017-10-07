using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpmData;
using OpmData.Entities;

namespace OpmImplement.Context
{
    public class OpmContext : DbContext
    {
        public OpmContext():base("OPMDataBase")
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Refraction> Refractions { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
