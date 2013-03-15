using System.Web.Security;
using WebMatrix.WebData;

namespace OneStream.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<OneStream.Models.OneStreamContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OneStream.Models.OneStreamContext context)
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
            SeedMembership();
        }

        private void SeedMembership()
        {
            //WebSecurity.InitializeDatabaseConnection("DefaultConnection",
            //    "UserProfile", "UserId", "UserName", autoCreateTables: true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }

            if (!roles.RoleExists("User"))
            {
                roles.CreateRole("User");
            }
            //if (membership.GetUser("sallen", false) == null)
            //{
            //    membership.CreateUserAndAccount("sallen", "imalittleteapot");
            //}
            //if (!roles.GetRolesForUser("sallen").Contains("Admin"))
            //{
            //    roles.AddUsersToRoles(new[] { "sallen" }, new[] { "admin" });
            //}
        }
    }
}
