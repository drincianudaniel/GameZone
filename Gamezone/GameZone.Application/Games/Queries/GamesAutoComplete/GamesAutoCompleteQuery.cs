using GameZone.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Games.Queries.GamesAutoComplete
{
    public class GamesAutoCompleteQuery : IRequest<IEnumerable<Game>>
    {
        public string searchString { get; set; } = string.Empty;
    }
}
