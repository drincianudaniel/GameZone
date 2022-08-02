using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Games.Queries.GetGameById
{
    public class GameDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string GameDetails { get; set; }
    }
}
