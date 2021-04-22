using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyApi.Models
{
    public class BikeStoreContext : DbContext
    {
        public BikeStoreContext()
        {
        }
        public BikeStoreContext(DbContextOptions<BikeStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bike> Bike { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Store> Store { get; set; }
    }
}
