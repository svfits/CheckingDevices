using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using monitoringLan.Library;

namespace monitoringLan
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создаем источник в журнале событий Windows
            if (!EventLog.SourceExists(ServiceDescription.Collector.JournalSource))
            {
                EventLog.CreateEventSource(ServiceDescription.Collector.JournalSource, "Application");
            }

            //Запускаем сервис
            HostFactory.Run(x =>
            {
                x.Service<Service>(s =>
                {
                    s.ConstructUsing(name => new Service());
                    s.WhenStarted(svc => svc.Start());
                    s.WhenStopped(svc => svc.Stop());
                });

            
                x.SetDescription(ServiceDescription.Collector.Description);
                x.SetDisplayName(ServiceDescription.Collector.DisplayName);
                x.SetServiceName(ServiceDescription.Collector.Name);
            });

        }
    }
}
