using AgentSqlMonitor;
using System;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string iniFilePath = @"C:\TESTE.INI";
        var iniFileReader = new IniFileReader(iniFilePath);

        string serverName = iniFileReader.Read("database", "servername");
        string databaseName = iniFileReader.Read("database", "database");

        Console.WriteLine($"Server Name: {serverName}");
        Console.WriteLine($"Database Name: {databaseName}");

        // Conectar ao banco de dados e executar a consulta
        string connectionString = $"Server={serverName};Database={databaseName};Trusted_Connection=True;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Connection successful.");

            string query = "SELECT * FROM monitoredServer";
            SqlCommand command = new SqlCommand(query, connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int serverId = reader.GetInt32(0);
                        string serverNameDb = reader.GetString(1);
                        DateTime createdAt = reader.GetDateTime(2);

                        Console.WriteLine($"ServerId: {serverId}  ServerName: {serverNameDb}  CreatedAt: {createdAt}");
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
            }

            connection.Close();
            Console.WriteLine("Connection closed.");
        }
    }
}
