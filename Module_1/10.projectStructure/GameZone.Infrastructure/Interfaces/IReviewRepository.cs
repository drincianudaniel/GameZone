using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Infrastructure.Interfaces
{
    internal interface IReviewRepository
    {
        void Create(Review review);
        void Delete(int id);
        List<Review> ReturnAll();
        Review ReturnById(int id);
        void Update(int id, Review review);
    }
}
