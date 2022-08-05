﻿using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Users.Queries.GetUsersList
{
    public class GetUsersListQuery : IRequest<IEnumerable<UserDto>>
    {

    }
}
