using Common.Enums;
using Common.Extensions;
using Db.Model;
using System.Data.Entity.Migrations;

namespace Db.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BuildingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BuildingContext context)
        {
            context.Roles.SeedEnumValues<Role, RoleEnum>(@enum => @enum);
            context.Units.SeedEnumValues<Unit, UnitEnum>(@enum => @enum);

            context.SaveChanges();
        }
    }
}

