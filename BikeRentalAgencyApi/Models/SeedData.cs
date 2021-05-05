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
                        BikeStyle = "Road Bike",
                    },
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
                        BikeStyle = "Road Bike",
                    },
                    new Bike
                    {
                        StoreID = 1,
                        HourlyRate = 3.50M,
                        Price = 190.99M,
                        FrameSize = 16,
                        IsRented = false,
                        Motorized = false,
                        MTBSuspension = false,
                        AllTerrainTires = true,
                        BikeStyle = "Mountain Bike",
                    },
                    new Bike
                    {
                        StoreID = 1,
                        HourlyRate = 3.50M,
                        Price = 190.99M,
                        FrameSize = 15,
                        IsRented = true,
                        Motorized = false,
                        MTBSuspension = false,
                        AllTerrainTires = true,
                        BikeStyle = "Mountain Bike",
                    },
                    new Bike
                    {
                        StoreID = 1,
                        HourlyRate = 3.50M,
                        Price = 190.99M,
                        FrameSize = 15,
                        IsRented = false,
                        Motorized = false,
                        MTBSuspension = false,
                        AllTerrainTires = true,
                        BikeStyle = "Mountain Bike",
                    },
                    new Bike
                    {
                        StoreID = 1,
                        HourlyRate = 4.00M,
                        Price = 250.00M,
                        FrameSize = 18,
                        IsRented = false,
                        Motorized = false,
                        MTBSuspension = true,
                        AllTerrainTires = true,
                        BikeStyle = "Hybrid Bike",
                    },
                    new Bike
                    {
                        StoreID = 1,
                        HourlyRate = 4.00M,
                        Price = 250.00M,
                        FrameSize = 18,
                        IsRented = true,
                        Motorized = false,
                        MTBSuspension = true,
                        AllTerrainTires = true,
                        BikeStyle = "Hybrid Bike",
                    },
                    new Bike
                    {
                        StoreID = 1,
                        HourlyRate = 4.00M,
                        Price = 250.00M,
                        FrameSize = 17,
                        IsRented = false,
                        Motorized = false,
                        MTBSuspension = true,
                        AllTerrainTires = true,
                        BikeStyle = "Hybrid Bike",
                    },
                    new Bike
                    {
                        StoreID = 1,
                        HourlyRate = 4.00M,
                        Price = 250.00M,
                        FrameSize = 18,
                        IsRented = false,
                        Motorized = false,
                        MTBSuspension = true,
                        AllTerrainTires = true,
                        BikeStyle = "Hybrid Bike",
                    },
                    new Bike
                    {
                        StoreID = 2,
                        HourlyRate = 4.00M,
                        Price = 250.00M,
                        FrameSize = 18,
                        IsRented = true,
                        Motorized = false,
                        MTBSuspension = true,
                        AllTerrainTires = true,
                        BikeStyle = "Hybrid Bike",
                    },
                    new Bike
                    {
                        StoreID = 2,
                        HourlyRate = 4.00M,
                        Price = 250.00M,
                        FrameSize = 17,
                        IsRented = false,
                        Motorized = false,
                        MTBSuspension = true,
                        AllTerrainTires = true,
                        BikeStyle = "Hybrid Bike",
                    },
                    new Bike
                    {
                        StoreID = 2,
                        HourlyRate = 4.00M,
                        Price = 225.99M,
                        FrameSize = 16,
                        IsRented = false,
                        Motorized = false,
                        MTBSuspension = true,
                        AllTerrainTires = true,
                        BikeStyle = "Road Bike",
                    },
                    new Bike
                    {
                        StoreID = 2,
                        HourlyRate = 4.00M,
                        Price = 225.99M,
                        FrameSize = 15,
                        IsRented = false,
                        Motorized = true,
                        MTBSuspension = false,
                        AllTerrainTires = true,
                        BikeStyle = "Road Bike",
                    },
                    new Bike
                    {
                        StoreID = 2,
                        HourlyRate = 4.00M,
                        Price = 225.99M,
                        FrameSize = 16,
                        IsRented = false,
                        Motorized = true,
                        MTBSuspension = false,
                        AllTerrainTires = true,
                        BikeStyle = "Road Bike",
                    },
                    new Bike
                    {
                        StoreID = 2,
                        HourlyRate = 4.00M,
                        Price = 225.99M,
                        FrameSize = 16,
                        IsRented = false,
                        Motorized = true,
                        MTBSuspension = false,
                        AllTerrainTires = true,
                        BikeStyle = "Road Bike",
                    },
                    new Bike
                    {
                        StoreID = 2,
                        HourlyRate = 4.00M,
                        Price = 235.99M,
                        FrameSize = 16,
                        IsRented = false,
                        Motorized = false,
                        MTBSuspension = true,
                        AllTerrainTires = true,
                        BikeStyle = "MountainBike",
                    },
                    new Bike
                    {
                        StoreID = 3,
                        HourlyRate = 3.50M,
                        Price = 225.99M,
                        FrameSize = 16,
                        IsRented = true,
                        Motorized = false,
                        MTBSuspension = false,
                        AllTerrainTires = false,
                        BikeStyle = "Road Bike",
                    },
                    new Bike
                    {
                        StoreID = 3,
                        HourlyRate = 3.50M,
                        Price = 225.99M,
                        FrameSize = 17,
                        IsRented = false,
                        Motorized = false,
                        MTBSuspension = false,
                        AllTerrainTires = false,
                        BikeStyle = "Road Bike",
                    },
                    new Bike
                    {
                        StoreID = 3,
                        HourlyRate = 3.50M,
                        Price = 225.99M,
                        FrameSize = 18,
                        IsRented = false,
                        Motorized = false,
                        MTBSuspension = false,
                        AllTerrainTires = false,
                        BikeStyle = "Road Bike",
                    },
                    new Bike
                    {
                        StoreID = 4,
                        HourlyRate = 3.50M,
                        Price = 225.99M,
                        FrameSize = 16,
                        IsRented = false,
                        Motorized = false,
                        MTBSuspension = false,
                        AllTerrainTires = false,
                        BikeStyle = "Road Bike",
                    },
                    new Bike
                    {
                        StoreID = 4,
                        HourlyRate = 3.50M,
                        Price = 225.99M,
                        FrameSize = 17,
                        IsRented = false,
                        Motorized = false,
                        MTBSuspension = false,
                        AllTerrainTires = false,
                        BikeStyle = "Road Bike",
                    },
                    new Bike
                    {
                        StoreID = 4,
                        HourlyRate = 3.50M,
                        Price = 225.99M,
                        FrameSize = 18,
                        IsRented = false,
                        Motorized = false,
                        MTBSuspension = false,
                        AllTerrainTires = false,
                        BikeStyle = "Road Bike",
                    },
                    new Bike
                    {
                        StoreID = 5,
                        HourlyRate = 3.50M,
                        Price = 225.99M,
                        FrameSize = 16,
                        IsRented = false,
                        Motorized = false,
                        MTBSuspension = false,
                        AllTerrainTires = false,
                        BikeStyle = "Road Bike",
                    },
                    new Bike
                    {
                        StoreID = 5,
                        HourlyRate = 3.50M,
                        Price = 225.99M,
                        FrameSize = 16,
                        IsRented = false,
                        Motorized = false,
                        MTBSuspension = false,
                        AllTerrainTires = false,
                        BikeStyle = "Road Bike",
                    },
                    new Bike
                    {
                        StoreID = 5,
                        HourlyRate = 3.50M,
                        Price = 225.99M,
                        FrameSize = 17,
                        IsRented = false,
                        Motorized = false,
                        MTBSuspension = false,
                        AllTerrainTires = false,
                        BikeStyle = "Road Bike",
                    },
                    new Bike
                    {
                        StoreID = 5,
                        HourlyRate = 4.00M,
                        Price = 250.00M,
                        FrameSize = 17,
                        IsRented = false,
                        Motorized = true,
                        MTBSuspension = false,
                        AllTerrainTires = true,
                        BikeStyle = "Hybrid Bike",
                    },
                    new Bike
                    {
                        StoreID = 5,
                        HourlyRate = 4.00M,
                        Price = 250.00M,
                        FrameSize = 17,
                        IsRented = false,
                        Motorized = true,
                        MTBSuspension = false,
                        AllTerrainTires = true,
                        BikeStyle = "Hybrid Bike",
                    });
                context.SaveChanges();
            }
            if (!context.Stores.Any())
            {
                context.Stores.AddRange(
                    new Store
                    {
                        AddressLine1 = "6127 Jerry Frasier Cir",
                        AddressLine2 = "",
                        City = "Bloomsburgh",
                        State = "NY",
                        Zip = "14228",
                        Phone = "8105555125",
                        Email = "store1@mybikerentalchoice.org",
                    }, 
                    new Store
                    {
                        AddressLine1 = "122 Easy St",
                        AddressLine2 = "",
                        City = "Bloomsburgh",
                        State = "NY",
                        Zip = "14230",
                        Phone = "8105555140",
                        Email = "store2@mybikerentalchoice.org",
                    },
                    new Store
                    {
                        AddressLine1 = "26865 Prembrook Pines",
                        AddressLine2 = "",
                        City = "Brooklyn",
                        State = "NY",
                        Zip = "15521",
                        Phone = "8105555145",
                        Email = "store3@mybikerentalchoice.org",
                    },
                    new Store
                    {
                        AddressLine1 = "330 Shady Acres Blvd",
                        AddressLine2 = "",
                        City = "Brooklyn",
                        State = "NY",
                        Zip = "15520",
                        Phone = "8105555135",
                        Email = "store4@mybikerentalchoice.org",
                    },
                    new Store
                    {
                        AddressLine1 = "4468 Eccentric St",
                        AddressLine2 = "",
                        City = "Staten Island",
                        State = "NY",
                        Zip = "16288",
                        Phone = "8105555130",
                        Email = "store5@mybikerentalchoice.org",
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
                    },
                    new Employee
                    {
                        FirstName = "Jack",
                        LastName = "Litton",
                        StoreID = 1,
                        Supervisor = true,
                    }, new Employee
                    {
                        FirstName = "Sam",
                        LastName = "Sparrow",
                        StoreID = 2,
                        Supervisor = false,
                    }, new Employee
                    {
                        FirstName = "Katelyn",
                        LastName = "Ingrid",
                        StoreID = 2,
                        Supervisor = true,
                    }, new Employee
                    {
                        FirstName = "Rory",
                        LastName = "Jackson",
                        StoreID = 3,
                        Supervisor = false,
                    }, new Employee
                    {
                        FirstName = "Kimberly",
                        LastName = "Lexington",
                        StoreID = 3,
                        Supervisor = true,
                    }, new Employee
                    {
                        FirstName = "Alex",
                        LastName = "Summers",
                        StoreID = 4,
                        Supervisor = true,
                    }, new Employee
                    {
                        FirstName = "Mark",
                        LastName = "Trabek",
                        StoreID = 4,
                        Supervisor = false,
                    }, new Employee
                    {
                        FirstName = "Henry",
                        LastName = "Chevrolet",
                        StoreID = 5,
                        Supervisor = true,
                    }, new Employee
                    {
                        FirstName = "Carson",
                        LastName = "Buffalo",
                        StoreID = 5,
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
                    },
                    new Customer
                    {
                        FirstName = "Eric",
                        LastName = "Felperin",
                        Phone = "8135553123",
                        Email = "e.felp@domain.org",
                    },
                    new Customer
                    {
                        FirstName = "Ryan",
                        LastName = "Killington",
                        Phone = "8135555122",
                        Email = "ryan.killington01@domain.org",
                    },
                    new Customer
                    {
                        FirstName = "Valerie",
                        LastName = "Ulrich",
                        Phone = "8135556105",
                        Email = "valgal.ul@domain.org",
                    });
                context.SaveChanges();
            }
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(
                    new Order
                    {
                        CustomerID = 1,
                        EmployeeID = 1,
                    },
                    new Order
                    {
                        CustomerID = 2,
                        EmployeeID = 1,
                    },
                    new Order
                    {
                        CustomerID = 3,
                        EmployeeID = 3,
                    },
                    new Order
                    {
                        CustomerID = 4,
                        EmployeeID = 7,
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
                        RentedStoreID = 1,
                        ReservationTotal = 14.00M,
                        AccessoriesTotal = 0.00M,
                        IsStarted = true,
                        OrderID = 1,
                    },
                    new Reservation
                    {
                        BikeID = 1,
                        StartDate = DateTime.Today,
                        EndDate = DateTime.Today,
                        IsComplete = false,
                        HomeStoreID = 3,
                        RentedStoreID = 1,
                        ReservationTotal = 12.00M,
                        AccessoriesTotal = 0.00M,
                        IsStarted = true,
                        OrderID = 2,
                    },
                    new Reservation
                    {
                        BikeID = 1,
                        StartDate = DateTime.Today,
                        EndDate = DateTime.Today,
                        IsComplete = false,
                        HomeStoreID = 5,
                        RentedStoreID = 2,
                        ReservationTotal = 14.00M,
                        AccessoriesTotal = 0.00M,
                        IsStarted = true,
                        OrderID = 3,
                    },
                    new Reservation
                    {
                        BikeID = 1,
                        StartDate = DateTime.Today,
                        EndDate = DateTime.Today,
                        IsComplete = false,
                        HomeStoreID = 4,
                        RentedStoreID = 3,
                        ReservationTotal = 12.00M,
                        AccessoriesTotal = 0.00M,
                        IsStarted = true,
                        OrderID = 4,
                    });
                context.SaveChanges();
            }
        }
    }
}
