using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Npgsql;

namespace Klient
{
    public class BazaDanych
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Database=Game;Username=postgres;Password=1234;";
        public class PlayerData
        {
            public int PlayerId { get; }
            public string Nickname { get; }
            public int MessagesSent { get; }
            public DateTime JoinDate { get; }

            public PlayerData(int playerId, string nickname, int messagesSent, DateTime joinDate)
            {
                PlayerId = playerId;
                Nickname = nickname;
                MessagesSent = messagesSent;
                JoinDate = joinDate;
            }
        }

        public List<PlayerData> GetDataFromDatabase()
        {
            List<PlayerData> playerDataList = new List<PlayerData>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string getDataQuery = @"
                SELECT PlayerId, Nickname, Messages_send, JoinDate
                FROM Chat;";

                using (var getDataCommand = new NpgsqlCommand(getDataQuery, connection))
                {
                    using (var reader = getDataCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int playerId = reader.GetInt32(0);
                            string nickname = reader.GetString(1);
                            int messagesSent = reader.GetInt32(2);
                            DateTime joinDate = reader.GetDateTime(3);

                            PlayerData playerData = new PlayerData(playerId, nickname, messagesSent, joinDate);
                            playerDataList.Add(playerData);
                        }
                    }
                }
            }

            return playerDataList;
        }

        public void CreateTable()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Chat (
                        PlayerId SERIAL PRIMARY KEY,
                        Nickname VARCHAR(50) NOT NULL,
                        Messages_send INT NOT NULL,
                        JoinDate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
                    );";

                using (var createTableCommand = new NpgsqlCommand(createTableQuery, connection))
                {
                    createTableCommand.ExecuteNonQuery();
                    Console.WriteLine("Tabela 'Chat' została utworzona (lub już istnieje).");
                }
            }
        }

        public void InsertData(string playerName, int score)
        {
            CreateTable();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string insertDataQuery = @"
                    INSERT INTO Chat (Nickname, Messages_send)
                    VALUES (@Nickname, @Messages_send);";

                using (var insertDataCommand = new NpgsqlCommand(insertDataQuery, connection))
                {
                    insertDataCommand.Parameters.AddWithValue("@Nickname", playerName);
                    insertDataCommand.Parameters.AddWithValue("@Messages_send", score);
                    insertDataCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
