
var db = new GameDB();

// run this line once, 
// db.InitializeDatabase(); // creates the file


db.InsertGame(new Game("Diablo Iasdsds", "Get primed for ", 4.99, "ConsoleA"));
db.InsertGame(new Game("Super Mario 64", "Joiach asdsdds.", 19.99,"ConsoleA"));


Console.WriteLine("Games in the database:");
var games = db.GetAllGames();

foreach (var game in games)
{
    Console.WriteLine($"{game.Title}, {game.Description}, {game.Price}, {game.Console}");
}

