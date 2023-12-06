using Microsoft.Data.Sqlite;

public class GameDB
{
    private readonly string dbFileName;

    public GameDB(string dbFilePath="database.db")
    {
        dbFileName = $"Data Source={dbFilePath}";
        InitializeDatabase();
    }

    public void InitializeDatabase()
    {
        using (var connection = new SqliteConnection(dbFileName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Games (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT,
                        Description TEXT,
                        Price REAL,
                        Console TEXT
                    );
                ";

                command.ExecuteNonQuery();
            }
        }
    }

    public void InsertGame(Game game)
    {
        using (var connection = new SqliteConnection(dbFileName))
        {
            connection.Open();

            using (var insertCommand = connection.CreateCommand())
            {
                insertCommand.CommandText = @"
                    INSERT INTO Games (Title, Description, Price, Console)
                    VALUES (@Title, @Desc, @Price, @Console);
                ";
                
                insertCommand.Parameters.AddWithValue("@Title", game.Title);
                insertCommand.Parameters.AddWithValue("@Desc", game.Description);
                insertCommand.Parameters.AddWithValue("@Price", game.Price);
                insertCommand.Parameters.AddWithValue("@Console", game.Console);
                insertCommand.ExecuteNonQuery();
            }
        }
    }

    public List<Game> GetAllGames()
    {
        var games = new List<Game>();
        using (var connection = new SqliteConnection(dbFileName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Games;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        games.Add(new Game(
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetDouble(3),
                            reader.GetString(4)
                        ));
                    }
                }
            }
        }

        return games;
    }
}
