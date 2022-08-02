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
        void AddGameToFavorite(User user, Game favoriteGame);
        void Create(User user);
        void Delete(int id);
        void DeleteComment(User userToDeleteComment, Game game, Comment comment);
        void PostReply(Comment comment, Reply reply);
        void PostReview(Game gameToBeReviewd, Review review);
        List<User> ReturnAll();
        User ReturnById(int id);
        void Update(int id, User user);
    }
}
