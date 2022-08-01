using GameZone.Infrastructure.Interfaces;
using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        public List<Genre> Genres { get; set; }

        public GenreRepository()
        {
            Genres = new List<Genre>();
        }

        public void Create(Genre Genre)
        {
            Genres.Add(Genre);
        }

        public Genre ReturnById(int id)
        {
            var genreToReturn = Genres.Find(genre => genre.Id == id);
            if (genreToReturn == null)
            {
                throw new KeyNotFoundException("Genre not found");
            }
            return genreToReturn;
        }
        public List<Genre> ReturnAll()
        {
            return Genres;
        }

        public void Update(int id, Genre genre)
        {
            var genreToEdit = ReturnById(id);
            genreToEdit.Name = genre.Name;
        }
        public void Delete(int id)
        {
            var genreToBeDeleted = ReturnById(id);
            Genres.Remove(genreToBeDeleted);
        }
    }
}
