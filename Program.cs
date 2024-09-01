using System;

namespace AgentSqlMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            string iniFilePath = @"C:\TESTE.INI";
            var iniFileReader = new IniFileReader(iniFilePath);

            string serverName = iniFileReader.Read("DATABASE", "servername");
            string databaseName = iniFileReader.Read("DATABASE", "database");

            Console.WriteLine($"Server Name: {serverName}");
            Console.WriteLine($"Database Name: {databaseName}");
        }
    }
}