using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Toolbox
{
    public class Connection
    {
        private readonly string _connectionString;

        public Connection(string connectionString)
        {
            _connectionString = connectionString;
        }
        public int ExecuteNonQuery(Command command)
        {
            using (SqlConnection sqlConnection = CreateConnection(_connectionString))
            {
                using (SqlCommand sqlCommand = CreateCommand(sqlConnection, command))
                {
                    sqlConnection.Open();
                    return sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}


