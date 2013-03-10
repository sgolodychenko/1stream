using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OneStream.Models
{
    public class OneStreamContext : DbContext
    {
        public OneStreamContext() : base("DefaultConnection")
        {
        }

        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<OneStream.Models.OneStreamContext>());

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //var prop = modelBuilder.Entity<IBaseModel>().Property(p => p.CreatedOn);
        }

        protected override System.Data.Entity.Validation.DbEntityValidationResult ValidateEntity(System.Data.Entity.Infrastructure.DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            return base.ValidateEntity(entityEntry, items);
        }

        public DbSet<OneStream.Models.Channel> Channels { get; set; }

        public DbSet<OneStream.Models.Broadcast> Broadcasts { get; set; }

        public DbSet<OneStream.Models.UserInfo> UserInfoes { get; set; }
    }
}