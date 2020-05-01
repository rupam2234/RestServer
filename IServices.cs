using Microsoft.AspNet.SignalR.Owin;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace RestServer
{
        [ServiceContract]

        interface IServices
        {

            #region GET DATA FROM SERVER

            [OperationContract]

            // for getting user details from the server (setting the URL structure and type of data for getting and sending)

            [WebGet(UriTemplate = "/users/{userid}", ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]

            List<UserDataCollection> GetUser(string userid);

            #endregion

            #region GET ALL DATA FROM DATABASE

            [OperationContract]
            // for getting user details from the server (setting the URL structure and type of data for getting and sending)
            [WebInvoke(Method = "GET", UriTemplate = "/users", ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
            List<UserDataCollection> GetAllUsers();

            #endregion

            #region POST DATA INTO THE SERVER

            [OperationContract]

            [WebInvoke(Method = "POST", UriTemplate = "/users", ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]

            ServerResponse PostData(UserDataCollection userDetails);

            #endregion

            #region UPDATE DATA INTO SERVER

            [OperationContract]

            [WebInvoke(Method = "PUT", UriTemplate = "/users", ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]

            ServerResponse PutData(UserDataCollection userDetails);

            #endregion

            #region DELETE DATA FROM SERVER

            /* [OperationContract]
             [WebInvoke(Method = "DELETE", UriTemplate = "/users/{userid}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
             ServerResponse DeleteData(UserDataCollection userid);*/

            #endregion

        }
    }
