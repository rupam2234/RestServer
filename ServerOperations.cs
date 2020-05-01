using Microsoft.AspNet.SignalR.Owin;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestServer
{

        // to create a service object which will hold the number of services instance available for handling calls 

        // spacify the internal execution behaviour of of a service contract

        // Also get the value when a new service is initiated

        [System.ServiceModel.ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]

        class ServerOperations : IServices
        {
            // connection string
            string connectionString = "Host=localhost; Username=postgres; Password=Rupom@223456; Database=postgres";

            #region METHOD TO POST SERVER INTO THE SERVER

            public ServerResponse PostData(UserDataCollection userDetails)
            {

                // initializing a new instance of NpgSqlConnection with connection string
                var Connection = new NpgsqlConnection(connectionString);
                Connection.Open();

                // assigning members of DataCollection to local variable 
                string id = userDetails.id;
                string name = userDetails.name;
                string age = userDetails.age;

                try
                {

                    // request a function to execute against PostgreeSql  
                    var command = new NpgsqlCommand();

                    // get the sql connection 
                    command.Connection = Connection;


                    // setting the sql statement or query which need to executed 
                    command.CommandText = "INSERT INTO \"Test\" VALUES('" + id + "', '" + name + "', ' " + age + "');";

                    // execute the SQL query against the connection and returns the no of row affected 
                    command.ExecuteNonQuery();
                }

                catch
                {
                    // this massage will appears if some error encountered during the try block execution

                    MessageBox.Show("Error encountered during INSERT operation.");
                }

                finally
                {
                    // once the process of posting is done we will close the connection

                    Connection.Close();
                }

                // Server will send this response to the client once this method executed succesfully 

                return new ServerResponse(200, "Value stored into the database");
            }

            #endregion


            #region METHOD TO UPDATE DATA IN SERVER

            public ServerResponse PutData(UserDataCollection userDetails)
            {
                // connection string

                //string ConnectionString = "Host=localhost; Username=postgres; Password=Rupom@223456; Database=postgres";

                // initializing a npgsqlConnection with the connection string 
                var Connection = new NpgsqlConnection(connectionString);

                // initiate the connection
                Connection.Open();


                // assigning the datamembers of the UserDataCollection to local varibale
                string id = userDetails.id;
                string name = userDetails.name;
                string age = userDetails.age;

                try
                {
                    // request a function to execute against postgresql 
                    var command = new NpgsqlCommand();

                    // get the sql connection
                    command.Connection = Connection;

                    // setting the sql query to be executed 
                    command.CommandText = "UPDATE \"Test\" SET \"id\" = '" + id + "', \"name\" = '" + name + "', \"age\" = '" + age + "' WHERE \"id\" = '" + id + "';";

                    // after executing the query against connection return the no of affected rows in the postgre table
                    command.ExecuteNonQuery();
                }

                catch
                {
                    // for any error during try block this message will appear
                    MessageBox.Show("Error encountered during UPDATE operation.");
                }

                finally
                {
                    // close the conection after executig the process
                    Connection.Close();
                }

                // return the following perameters if the method executed fuccesfully
                return new ServerResponse(200, "Value updated in the database");
            }

            #endregion


            #region TO GET DATA FROM THE DATABASE

            public List<UserDataCollection> GetUser(string userid)
            {

                List<UserDataCollection> User = new List<UserDataCollection>();

                //string cs = "Host=localhost; Username=postgres; Password=Rupom@223456; Database=postgres";

                var Connection = new NpgsqlConnection(connectionString);
                Connection.Open();

                try
                {

                    // request a function to execute against PostgreeSql  
                    var command = new NpgsqlCommand();

                    // get the sql connection 
                    command.Connection = Connection;

                    command.CommandText = "SELECT * FROM \"Test\" WHERE name = '" + userid + "'; ";

                    command.ExecuteNonQuery();

                    NpgsqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        UserDataCollection userInfo = new UserDataCollection();
                        userInfo.age = dr[0].ToString();
                        userInfo.id = dr[2].ToString();
                        userInfo.name = dr[1].ToString();
                        User.Add(userInfo);
                    }

                    dr.Close();
                }

                catch
                {
                    MessageBox.Show("unable to fetch the value");
                }

                finally
                {
                    Connection.Close();
                }


                return User;

            }

            #endregion


            #region GET ALL DATA FROM DATABASE

            public List<UserDataCollection> GetAllUsers()
            {
                List<UserDataCollection> Users = new List<UserDataCollection>();

                //string cs = "Host=localhost; Username=postgres; Password=Rupom@223456; Database=postgres";

                var Connection = new NpgsqlConnection(connectionString);
                Connection.Open();

                try
                {

                    // request a function to execute against PostgreeSql  
                    var command = new NpgsqlCommand();
                    // get the sql connection 
                    command.Connection = Connection;

                    command.CommandText = "SELECT * From \"Test\";";

                    command.ExecuteNonQuery();

                    NpgsqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        UserDataCollection getAllUsers = new UserDataCollection();
                        getAllUsers.age = dr[0].ToString();
                        getAllUsers.id = dr[2].ToString();
                        getAllUsers.name = dr[1].ToString();
                        Users.Add(getAllUsers);
                    }

                    dr.Close();


                }

                catch
                {
                    MessageBox.Show("Unable to fetch the value");
                }

                finally
                {
                    Connection.Close();
                }

                return Users;

                #endregion


                #region TO DELETE DATA FROM DATABASE

                /*public ServerResponse DeleteData(UserDataCollection userid)
                {
                }*/

                #endregion

            }
        }
    }
