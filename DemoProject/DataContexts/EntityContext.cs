using DemoProject.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoProject.DataContexts
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base("DefaultConnection")
        {

        }
        public DbSet<Country> CountryDB { get; set; }
        public DbSet<State> StateDB { get; set; }
        public DbSet<City> CityDB { get; set; }
        public DbSet<User> UserDB { get; set; }
    }
}