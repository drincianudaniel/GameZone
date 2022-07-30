using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Infrastructure.Interfaces
{
    internal interface IReplyRepository
    {
        void Create(Reply reply);
        void Delete(int id);
        List<Reply> ReturnAll();
        Reply ReturnById(int id);
    }
}
