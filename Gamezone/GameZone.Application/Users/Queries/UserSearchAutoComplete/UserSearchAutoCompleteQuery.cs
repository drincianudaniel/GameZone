using GameZone.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Users.Queries.UserSearchAutoComplete
{
    public class UserSearchAutoCompleteQuery : IRequest<IEnumerable<User>>
    {
        public string SearchString { get; set; }
    }
}
