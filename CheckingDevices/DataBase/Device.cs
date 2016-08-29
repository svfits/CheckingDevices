using System;
using System.ComponentModel.DataAnnotations;

namespace CheckingDevices.DataBase
{
    public class Device
    {
        [Key]
        public int id { get; set; }

        public string ip { get; set; }

        public string type_device { get; set; }

        public string description { get; set; }

        public string status { get; set; }

        public string uptime { get; set; }

        public DateTime down_device { get; set; }

        public DateTime up_device { get; set; }
    }
}