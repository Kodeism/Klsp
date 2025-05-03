using System;
using System.Data.SqlClient;
using System.Security.Principal;
using SQL;

string connectionsstring = "Server = localhost; Database = TestDB; User ID = em; Password = 1234; Trusted_Connection = True;";

SqlConnection connection = new SqlConnection(connectionsstring);
SqlCommand command = connection.CreateCommand();