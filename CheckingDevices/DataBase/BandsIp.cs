using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckingDevices.DataBase
{
  public  class BandsIp
    {
        [Key]
        public int id { get; set; }

        public string band { get; set; }

        public string description { get; set; }
    }
}
