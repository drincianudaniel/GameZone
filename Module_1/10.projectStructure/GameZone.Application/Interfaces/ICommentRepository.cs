using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application
{
    public interface ICommentRepository
    {
        void Create(Comment comment);
        void Delete(int id);
        IEnumerable<Comment> ReturnAll();
        Comment ReturnById(int id);
        void Update(int id, Comment comment);
    }
}
