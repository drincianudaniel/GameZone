using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Users.Queries.UserSearchAutoComplete
{
    public class UserSearchAutoCompleteQueryHandler : IRequestHandler<UserSearchAutoCompleteQuery, IEnumerable<User>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserSearchAutoCompleteQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<IEnumerable<User>> Handle(UserSearchAutoCompleteQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.UserRepository.SearchUserAsync(request.SearchString);
            return query;
        }
    }
}
