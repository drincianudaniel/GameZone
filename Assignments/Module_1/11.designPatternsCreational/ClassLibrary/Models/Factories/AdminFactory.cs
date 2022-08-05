using GameZone.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Domain.Models.Factories
{
    public class AdminFactory : IUserFactory
    {
        public IUser CreateUser(string email, string username, string password, string firstName, string lastName)
        {
            return new Admin
            {
                Email = email,
                Username = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName
            };
        }
    }
}
