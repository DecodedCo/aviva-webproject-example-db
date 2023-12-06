using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;



namespace GameStoreApi.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GamesController : ControllerBase
    {
        //roughly,
        // const games = [{name: "Diablo 1", "...", 4.99, "ConsoleA"}, ...]

        private readonly List<Game> games = new List<Game>
        {
            new Game("Diablo I", "Get primed for a gambling addiction.", 4.99, "ConsoleA"),
            new Game("Super Mario 64", "Join Mario in his 3D adventure to rescue Princess Peach from Bowser's clutches.", 19.99, "ConsoleA"),
            new Game("The Legend of Zelda: Ocarina of Time", "Embark on a legendary quest as Link to stop Ganondorf and save Hyrule.", 24.99, "ConsoleA"),
            new Game("Final Fantasy VII", "Experience the epic journey of Cloud Strife and his allies to stop Sephiroth and save the planet.", 29.99, "ConsoleA"),
            new Game("Metal Gear Solid", "Infiltrate Shadow Moses Island and thwart the plans of the rogue terrorist group, FOXHOUND.", 17.99, "ConsoleA"),
            new Game("Resident Evil 2", "Survive a zombie apocalypse in Raccoon City as Leon Kennedy and Claire Redfield.", 14.99, "ConsoleA"),
            
        };


        // localhost:xxx/api/games
        [HttpGet]
        public IActionResult GetGames()
        {
            var db = new GameDB();
            return Ok(db.GetAllGames()); // wrapping http response headers/metadata
        }
    }
}
