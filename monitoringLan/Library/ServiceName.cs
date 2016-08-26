using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monitoringLan.Library
{
    public static class ServiceDescription
    {
        /// <summary>
        /// Collector
        /// </summary>
        public static readonly Module Collector = new Module
        (
            name: "сборщик состояний о wifi точках",
            displayName: "Wifi State Collector",
            description: "Сборщик информации о wifi",
            journalSource: "Wifi State Collector",
            login: "isea\\blabla",
            password: "passwords2"
        );
    }

    public class Module
    {
        public Module(string name, string displayName, string description, string journalSource, string login, string password)
        {
            this.Name = name;
            this.DisplayName = displayName;
            this.Description = description;
            this.JournalSource = journalSource;
            this.Login = login;
            this.Password = password;
        }

        public string Name { get; }
        public string DisplayName { get; }
        public string Description { get; }
        public string JournalSource { get; }
        public string Login { get; }
        public string Password { get; }
    }

}
