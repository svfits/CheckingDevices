using System;
using System.Net.NetworkInformation;
using System.Text;
using CheckingDevices.DataBase;
using System.Linq;
using System.Timers;

namespace monitoringLan
{
    class Service
    {
        Timer tm = new Timer();      

        public void Start()
        {
            //puskService();
            tm.Elapsed += new ElapsedEventHandler(puskService); 
            tm.Interval = 30000;
            tm.Start();         
        }      

        public void Stop()
        {
            tm.Stop();
        }      

     public  void puskService(object source, ElapsedEventArgs eventArgs)
        {
            Console.WriteLine(DateTime.Now + "  запустился ");
            using (DeviceContext db = new DeviceContext())
            {
                var deviceList = db.Device;
                foreach (var dd in deviceList)
                {
                    pinger(dd.ip);
                }
            }

            using (DeviceContext db = new DeviceContext())
            {
                var bandList = db.BandsIp;

                foreach (var dd in bandList)
                {
                    string[] ip2 = dd.band.Split('.');
                    string tokens = ip2[0] + "." + ip2[1] + "." + ip2[2] + ".";

                    for (int i = 10; i <= 253; i++)
                    {
                        string ip1 = tokens + i.ToString();
                        //Console.WriteLine(ip1);
                        pingSearchNewDevice(ip1);
                    }
                }
            }
        }

        private void pinger(string address)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            PingReply reply = pingSender.Send(address, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                saveStatus(address,"Работает");
            }
            else
            {
                saveStatus(address, "НЕ доступна");
            }
        }

     

        private void saveStatus(string ip, string status)
        {          
            using (DeviceContext db = new DeviceContext())
            {
              var  myDevice = db.Device.Where(c => c.ip == ip).FirstOrDefault();
               
                if (myDevice.status != status )
                {
                    if (status == "Работает")
                    {
                        db.Log.Add(new Log()
                        {
                            status = status,
                            ip = ip,
                            date = DateTime.Now
                        });

                        myDevice.up_device = DateTime.Now;
                        TimeSpan ts = myDevice.up_device - myDevice.down_device;
                     
                        Console.WriteLine(string.Format("{0:00} дней {1:00}:{2:00}:{3:00}",ts.Days, ts.Hours, ts.Minutes, ts.Seconds));
                        myDevice.uptime = string.Format("{0:00} дней {1:00}:{2:00}:{3:00}", ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
                    }
                    if (status == "НЕ доступна")
                    {
                        db.Log.Add(new Log()
                        {
                            status = status,
                            ip = ip,
                            date = DateTime.Now
                        });

                        myDevice.down_device = DateTime.Now;
                        myDevice.up_device = DateTime.Now;
                        TimeSpan ts = myDevice.up_device - myDevice.down_device;
                        myDevice.uptime = string.Format("{0:00} дней {1:00}:{2:00}:{3:00}", ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
                    }                 
                    
                    myDevice.status = status;
                    db.Entry(myDevice).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                }
            }
        }

        private void pingSearchNewDevice(string ip)
        {         
            Ping pingSender = new Ping();

            // When the PingCompleted event is raised,
            // the PingCompletedCallback method is called.
            pingSender.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            // Wait 12 seconds for a reply.
            int timeout = 1000;

            // Set options for transmission:
            // The data can go through 64 gateways or routers
            // before it is destroyed, and the data packet
            // cannot be fragmented.
            PingOptions options = new PingOptions(64, true);

            //Console.WriteLine("Time to live: {0}", options.Ttl);
            //Console.WriteLine("Don't fragment: {0}", options.DontFragment);

            // Send the ping asynchronously.
            // Use the waiter as the user token.
            // When the callback completes, it can wake up this thread.
            pingSender.SendAsync(ip, timeout, buffer, options);

            // Prevent this example application from ending.
            // A real application should do something useful
            // when possible.
           
            //Console.WriteLine("Ping example completed.");

        }

        private void PingCompletedCallback(object sender, PingCompletedEventArgs e)
        {        
            PingReply reply = e.Reply;
            
            if (reply.Status == IPStatus.Success)
            {
                addNewDevice(reply.Address.ToString());
            }          
        }

        private void addNewDevice(string address)
        {
            using (DeviceContext db = new DeviceContext())
            {
                var conn = db.Device.Where(c => c.ip == address).FirstOrDefault();

                if (conn == null)
                {
                    db.Device.Add(new Device()
                    {
                        ip = address,
                        status = "новое устройство",
                        down_device = DateTime.Now,
                        uptime = "",
                        type_device = "не известно",
                        up_device = DateTime.Now
                    });

                    db.Log.Add(new Log()
                    {
                        status = "новое устройство",
                        ip = address,
                        date = DateTime.Now
                    });
                }              

                db.SaveChanges();
            }
        }
     

    }
}
