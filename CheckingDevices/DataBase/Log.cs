using System;
using System.ComponentModel.DataAnnotations;

namespace CheckingDevices.DataBase
{
    public class Log
    {
        [Key]
        public int id { get; set; }

        public string status { get; set; }

        public string ip { get; set; }

        public DateTime date { get; set; }
    }
}