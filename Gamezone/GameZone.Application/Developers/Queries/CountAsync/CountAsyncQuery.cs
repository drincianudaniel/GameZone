﻿using MediatR;

namespace GameZone.Application.Developers.Queries.CountAsync
{
    public class CountAsyncQuery : IRequest<int>
    {
        public string SearchString { get; set; }
    }
}
