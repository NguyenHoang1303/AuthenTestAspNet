namespace AuthenticationApp.Migrations
{
    using AuthenticationApp.Data;
    using AuthenticationApp.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AuthenticationApp.Data.MyIdentityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuthenticationApp.Data.MyIdentityDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var roles = new List<Role>
            {
                new Role {Name = "ADMIN"},
                new Role {Name = "USER"},
                new Role {Name = "EMPLOYEE"}
            };
            var users = new List<User>
            {
                new User {UserName = "admin", PasswordHash= "1234567", PhoneNumber= "12345678", Email = "admin@gmail.com", IdentityNumber= "7787872827"},
                new User {UserName = "user", PasswordHash= "1234567", PhoneNumber= "12345678", Email = "user@gmail.com", IdentityNumber= "123455555"},
                new User {UserName = "employee", PasswordHash= "1234567", PhoneNumber= "12345678", Email = "employee@gmail.com", IdentityNumber= "222222"}
            };
            
            users.ForEach(e => context.Users.Add(e));
            roles.ForEach(e => context.Roles.Add(e));
            context.SaveChanges();
        }
    }
}
