using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSqlMonitor
{
    internal class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ServerInfo GetServerInfo()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "select * from monitoredserver";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return new ServerInfo
                            {
                                ServerName = reader.GetString(1)
                            };
                        }
                    }
                    else
                    {
                        throw new Exception("Nenhuma linha encontrada.");
                    }
                }
            }
            throw new Exception("Não foi possível retornar informação do servidor.");
        }
    }
}
