using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace RestServer
{
    class StartServer
    {
        public void startServer(Uri url)
        {
            WebServiceHost host = new WebServiceHost(typeof(ServerOperations), url);  // Create a WebServiceHost object.

            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(IServices), new WebHttpBinding(), "");  // Adding a ServiceEndpoint 

            //(Adding a non-SOAP endpoint with a URL of "" causes unexpected behavior)

            ServiceDebugBehavior sdb = host.Description.Behaviors.Find<ServiceDebugBehavior>();
            sdb.HttpHelpPageEnabled = false;   // to prevent non - SOAP end point exception

            // starting the service host

            host.Open();
            Console.WriteLine("Starting the service...");
            Console.WriteLine("Press enter to keep it live!");
            Console.ReadKey();
            Console.WriteLine("Service is running...");
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine("You can press enter to quit...");
            Console.ReadLine();
            host.Close();


        }
    }
}
