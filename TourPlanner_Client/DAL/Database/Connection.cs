using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Npgsql;

namespace TourPlanner_Client.DAL.Database
{
    public class Connection
    {
        public NpgsqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            return new NpgsqlConnection(connectionString);
        }
    }

}
