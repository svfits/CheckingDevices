using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckingDevices.DataBase
{
  public  class DeviceContext : DbContext
    {
        public DeviceContext() :   base("data source = (localdb)\\MSSQLLocalDB; Initial Catalog = Device; Integrated Security = True; TrustServerCertificate=False") { }

        public DbSet<Device> Device { get; set; }

        public DbSet<Log> Log { get; set; }

       public DbSet<BandsIp> BandsIp { get; set; }
    }
}
