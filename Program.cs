using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestServer
{
    class Program
    {
        public static void Main(string[] args)
        {
            StartServer service = new StartServer();
            Uri url = new Uri("http://localhost:8080");

            service.startServer(url);

            Console.ReadKey();
        }
    }
}
