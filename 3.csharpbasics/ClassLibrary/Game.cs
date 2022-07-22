using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary 
{
    public class Game : IEnumerable<Developer>, IEnumerable<Genre>
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime releaseDate { get; set; }
        public double totalRating { get; set; }
        public string gameDetails { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Genre> Genres { get; set; }
        public Game(string name)
        {
            this.name = name;
        }

        public IEnumerator<Developer> GetEnumerator()
        {
            return Developers.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Developers.GetEnumerator();
        }

        IEnumerator<Genre> IEnumerable<Genre>.GetEnumerator()
        {
            return Genres.GetEnumerator();
        }
    }
}
