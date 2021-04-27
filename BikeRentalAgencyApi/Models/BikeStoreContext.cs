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

        public virtual DbSet<Bike> Bikes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
