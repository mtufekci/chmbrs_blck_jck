using System.Net;
using Chambers.BlackJack.Common.Domain;
using Chambers.BlackJack.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chambers.BlackJack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly Game _game;

        public GameController(Game game)
        {
            _game = game;
        }

        [HttpPost]
        [Route("start")]
        public ActionResult<ResultModel> Start()
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
            return _game.Start();

        }

        [HttpGet]
        [Route("hit")]
        public ResultModel Hit()
        {
            return _game.Hit();
        }

        [HttpGet]
        [Route("stick")]
        public ResultModel Stick()
        {
            return  _game.Stick();
        }
    }
}