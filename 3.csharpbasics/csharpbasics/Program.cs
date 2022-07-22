using ClassLibrary;
using System;

namespace csharpbasics
{
    class Program
    {
        static void Main(string[] args)
        {   
            //game developers
            Developer Ubisoft = new Developer("Ubisoft");

            //genres
            Genre Action = new Genre("Action");

            //platform

            //games
            Game AssassinsCreed = new Game("Assassins Creed");
            
            AssassinsCreed.Developers = new List<Developer> { Ubisoft };
            AssassinsCreed.Genres = new List<Genre> { Action };

            Console.WriteLine(AssassinsCreed.GetEnumerator());
            //Console.WriteLine(AssassinsCreed.GetAllDevelopers());
            foreach(var i in AssassinsCreed)
            {
                Console.WriteLine(i.name);
            }

        }
    }
}