using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Domain.Models.Interfaces
{
    public interface IUserFactory
    {
        IUser CreateUser(string email, string username, string password, string firstName, string lastName);
    }
}
