using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace BikeRentalAgencyApi.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            BikeStoreContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<BikeStoreContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Bikes.Any()){
                context.Bikes.AddRange(
                    new Bike
                    {
                        StoreID = 1,
                        HourlyRate = 3.50M,
                        Price = 225.99M,
                        FrameSize = 17,
                        IsRented = false,
                        Motorized = false,
                        MTBSuspension = false,
                        AllTerrainTires = false,
                        BikeStyle = "RoadBike",
                    });
                context.SaveChanges();
            }
            if (!context.Stores.Any())
            {
                context.Stores.AddRange(
                    new Store
                    {
                        AddressLine1 = "122 Easy St",
                        AddressLine2 = "",
                        City = "Bloomsburgh",
                        State = "NY",
                        Zip = "14228",
                        Phone = "8105555125",
                        Email = "store1@mybikerentalchoice.org",
                    });
                context.SaveChanges();
            }
            if (!context.Employees.Any())
            {
                context.Employees.AddRange(
                    new Employee
                    {
                        FirstName = "Kat",
                        LastName = "Williams",
                        StoreID = 1,
                        Supervisor = false,
                    });
                context.SaveChanges();
            }
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    new Customer
                    {
                        FirstName = "Jody",
                        LastName = "Smith",
                        Phone = "8135555100",
                        Email = "j.smith99@domain.org",
                    });
                context.SaveChanges();
            }
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(
                    new Order
                    {
                        CustomerID = 1,
                        EmployeeID = 2,
                    });
                context.SaveChanges();
            }
            if (!context.Reservations.Any())
            {
                context.Reservations.AddRange(
                    new Reservation
                    {
                        BikeID = 1,
                        StartDate = DateTime.Today,
                        EndDate = DateTime.Today,
                        IsComplete = false,
                        HomeStoreID = 5,
                        RentedStoreID = 5,
                        ReservationTotal = 12.00M,
                        AccessoriesTotal = 0.00M,
                        IsStarted = false,
                        OrderID = 1,
                    });
                context.SaveChanges();
            }
        }
    }
}
