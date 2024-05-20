using System;
using Npgsql;

namespace BazaDanych2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Host=localhost;Port=5432;Database=Game;Username=postgres;Password=1234;";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Tworzenie tabeli
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Players (
                        PlayerId SERIAL PRIMARY KEY,
                        PlayerName VARCHAR(50) NOT NULL,
                        Score INT NOT NULL,
                        JoinDate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
                    );";

                using (var createTableCommand = new NpgsqlCommand(createTableQuery, connection))
                {
                    createTableCommand.ExecuteNonQuery();
                    Console.WriteLine("Tabela 'Players' została utworzona (lub już istnieje).");
                }

                // Wstawianie danych
                string insertDataQuery = @"
                    INSERT INTO Players (PlayerName, Score)
                    VALUES (@PlayerName, @Score);";

                using (var insertDataCommand = new NpgsqlCommand(insertDataQuery, connection))
                {
                    insertDataCommand.Parameters.AddWithValue("@PlayerName", "Alice");
                    insertDataCommand.Parameters.AddWithValue("@Score", 1500);

                    insertDataCommand.ExecuteNonQuery();
                    Console.WriteLine("Dane zostały wstawione do tabeli 'Players'.");
                }
            }
        }
    }
}
