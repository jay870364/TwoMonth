using Bossinfo.Caller.LocalDB.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace Bossinfo.Caller.LocalDB.Entity
{
    public class CallerContext : DbContext
    {
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public CallerContext() : base("name=CallerDbContext")
        {

            //string path = System.AppDomain.CurrentDomain.BaseDirectory;
            //string DataBaseName = Database.Connection.ConnectionString.Replace("Data Source=", "").Replace(";integrated security=True;", "");

            //string dataBasePath = $@"Data Source={path}\Data\LocalDB\{DataBaseName}";

            //Database.Connection.ConnectionString = dataBasePath;

            //Disable initializer
            //Database.SetInitializer<CallerContext>(null);

        }


        public DbSet<User> User { get; set; }
    }
}
