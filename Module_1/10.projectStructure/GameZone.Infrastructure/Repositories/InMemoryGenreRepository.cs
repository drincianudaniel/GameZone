using GameZone.Application;
using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Infrastructure.Repositories
{
    public class InMemoryGenreRepository : IGenreRepository
    {
        private readonly List<Genre> _genres;

        public InMemoryGenreRepository()
        {
            _genres = new List<Genre>
            {
                new("Action"),
                new("Adventure"),
                new("Fantasy"),
                new("Moba")
            };
        }

        public void Create(Genre Genre)
        {
            _genres.Add(Genre);
        }

        public Genre ReturnById(int id)
        {
            var genreToReturn = _genres.Find(genre => genre.Id == id);
            if (genreToReturn == null)
            {
                throw new KeyNotFoundException("Genre not found");
            }
            return genreToReturn;
        }
        public IEnumerable<Genre> ReturnAll()
        {
            if (_genres.Count() == 0)
            {
                throw new NullReferenceException("Genres list is null");
            }
            return _genres;
        }

        public void Update(int id, Genre genre)
        {
            var genreToEdit = ReturnById(id);
            genreToEdit.Name = genre.Name;
        }
        public void Delete(int id)
        {
            var genreToBeDeleted = ReturnById(id);
            _genres.Remove(genreToBeDeleted);
        }
    }
}
