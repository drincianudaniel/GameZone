using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Comments.Queries.GetCommentsList
{
    public class GetCommentsListQueryHandler : IRequestHandler<GetCommentsListQuery, IEnumerable<CommentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCommentsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper=mapper;
        }

        public async Task<IEnumerable<CommentDto>> Handle(GetCommentsListQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.CommentRepository.ReturnAllAsync();
            var mappedResult = _mapper.Map<IEnumerable<CommentDto>>(query);

            return mappedResult;
        }
    }
}
