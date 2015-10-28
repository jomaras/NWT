using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Uber.Models;

namespace Uber.DAL
{
    public class UberInitializer : DropCreateDatabaseAlways<UberContext>
    {
        protected override void Seed(UberContext context)
        {            
            var users = new List<User>()
            {
                new User() { Name = "Ivo", Surname = "Ivić" },
                new User() { Name = "Mate", Surname = "Matić" }
            };

            users.ForEach(user => context.Users.Add(user));

            var drivers = new List<Driver>()
            {
                new Driver() { Name = "Alan", Surname = "Prost", Car = "Toyota" },
                new Driver() { Name = "Nigel", Surname = "Mansell", Car = "Ferrari" }
            };

            drivers.ForEach(driver => context.Drivers.Add(driver));

            var rides = new List<Ride>()
            {
                new Ride() { Users = new List<User>() { users[0] }, Driver = drivers[0], StartLocation = "Split", EndLocation = "Zagreb", Price = 1000 },
                new Ride() { Users = new List<User>() { users[0], users[1] }, Driver = drivers[1], StartLocation = "Šibenik", EndLocation = "Zadar", Price = 300 },
            };

            users[0].TakenRides = new List<Ride>() { rides[0], rides[1] };
            users[1].TakenRides = new List<Ride>() { rides[1] };

            drivers[0].GivenRides = new List<Ride>() { rides[0] };
            drivers[1].GivenRides = new List<Ride>() { rides[1] };

            drivers.ForEach(driver => context.Drivers.Add(driver));

            context.SaveChanges();
        }
    }
}