using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIModel.Model;

namespace WebAPIModel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        static List<Player> listplayers = new List<Player>
        {
            new Player{PId=1,PName="Virat Kohli",PDOB=DateTime.Parse("12/12/1996"),PTeam="India"},
            new Player{PId=2,PName="Sam Curran",PDOB=DateTime.Parse("05/12/1998"),PTeam="England"},
            new Player{PId=3,PName="KL Rahul",PDOB=DateTime.Parse("07/12/1991"),PTeam="India"},
        };
        [HttpGet]
        public IEnumerable<Player> GetPlayers()
        {
            return listplayers;
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = listplayers.SingleOrDefault(n => listplayers.IndexOf(n) == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result =listplayers.SingleOrDefault(n => listplayers.IndexOf(n) == id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {



                listplayers.RemoveAt(id);
                return NoContent();
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Player ply)
        {
            listplayers.Add(ply);
            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult put(int id, [FromBody] Player p)
        {
            var result = listplayers.SingleOrDefault(n => listplayers.IndexOf(n) == id);
            if (result != null)
            {
                result.PId = p.PId;
                result.PName = p.PName;
                result.PTeam = p.PTeam;
                result.PDOB = p.PDOB;
                return NoContent();
            }
            else
            {
                return BadRequest("Not a valid Id");
            }
        }
    }
}