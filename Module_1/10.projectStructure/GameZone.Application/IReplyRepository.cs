using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application
{
    public interface IReplyRepository
    {
        void Create(Reply reply);
        void Delete(int id);
        IEnumerable<Reply> ReturnAll();
        Reply ReturnById(int id);
        void Update(int id, Reply reply);
    }
}
