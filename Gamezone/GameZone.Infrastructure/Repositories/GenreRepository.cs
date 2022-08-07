using GameZone.Application;
using GameZone.Domain;
using GameZoneModels;

namespace GameZone.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly GameZoneContext _context;

        public GenreRepository(GameZoneContext context)
        {
            _context = context;
        }

        public void Create(Genre Genre)
        {
            _context.Genres.Add(Genre);
            _context.SaveChanges();
        }

        public Genre ReturnById(Guid id)
        {
            var genreToReturn = _context.Genres.Find(id);
            if (genreToReturn == null)
            {
                throw new KeyNotFoundException("Genre not found");
            }
            return genreToReturn;
        }
        public IEnumerable<Genre> ReturnAll()
        {
            return _context.Genres;
        }

        public void Update(Genre genre)
        {
            var genreAux = _context.Genres.Where(genre => genre.Id == genre.Id).FirstOrDefault();
            if (genreAux == null)
            {
                throw new NullReferenceException("Genre doesnt exist");
            }
            _context.Genres.Remove(genreAux);
            _context.Genres.Add(genre);
            _context.SaveChanges();

        }
        public void Delete(Guid id)
        {
            var genreToBeDeleted = ReturnById(id);
            _context.Genres.Remove(genreToBeDeleted);
            _context.SaveChanges();
        }
    }
}
