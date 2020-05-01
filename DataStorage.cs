using System.Runtime.Serialization;

namespace RestServer
{
    #region Data Members
    [DataContract]
    class UserDataCollection
    {

            [DataMember]
            public string id { get; set; }

            [DataMember]
            public string name { get; set; }

            [DataMember]
            public string age { get; set; }

            public UserDataCollection()
            {

            }
     }

    #endregion
 }
