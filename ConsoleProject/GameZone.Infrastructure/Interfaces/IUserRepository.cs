using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        void Create(User user);
        void Delete(int id);
        List<User> ReturnAll();
        User ReturnById(int id);
        void Update(int id, User user);
    }
}
