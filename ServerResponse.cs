using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RestServer
{
    [DataContract]
    class ServerResponse
    {
        [DataMember]
        public int error_code { set; get; }

        [DataMember]
        public string error_message { set; get; }


        public ServerResponse(int error_code, string error_message)
        {
            this.error_code = error_code;

            this.error_message = error_message;
        }
    }
}
