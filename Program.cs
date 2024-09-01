using AgentSqlMonitor;
using System;

class Program
{
    static async Task Main(string[] args)
    {
        string iniFilePath = @"C:\TESTE.INI";
        var iniFileReader = new IniFileReader(iniFilePath);

        string serverName = iniFileReader.Read("database", "servername");
        string databaseName = iniFileReader.Read("database", "database");

        Console.WriteLine($"Server Name: {serverName}");
        Console.WriteLine($"Database Name: {databaseName}");

        string connectionString = $"Server={serverName};Database={databaseName};Trusted_Connection=True;";
        var databaseService = new DatabaseService(connectionString);

        try
        {
            ServerInfo serverInfo = databaseService.GetServerInfo();

            // Enviar as informações para a API
            var apiClient = new ApiClient();
            await apiClient.SendServerInfoAsync(serverInfo);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
