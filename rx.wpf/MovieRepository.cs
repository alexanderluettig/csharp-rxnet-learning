using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace rx.wpf
{
    public class MovieRepository
    {
        private readonly IList<Movie> _movieList = new List<Movie>
        {
            new Movie { Title = "The Matrix" },
            new Movie { Title = "The Matrix Reloaded" },
            new Movie { Title = "The Matrix Revolutions" },
            new Movie { Title = "The Matrix 4" },
            new Movie { Title = "The Lord of the Rings: The Fellowship of the Ring" },
            new Movie { Title = "The Lord of the Rings: The Two Towers" },
            new Movie { Title = "The Lord of the Rings: The Return of the King" },
            new Movie { Title = "The Hobbit: An Unexpected Journey" },
            new Movie { Title = "The Hobbit: The Desolation of Smaug" },
            new Movie { Title = "The Hobbit: The Battle of the Five Armies" },
            new Movie { Title = "Star Wars: Episode I - The Phantom Menace" },
            new Movie { Title = "Star Wars: Episode II - Attack of the Clones" },
            new Movie { Title = "Star Wars: Episode III - Revenge of the Sith" },
            new Movie { Title = "Star Wars: Episode IV - A New Hope" },
            new Movie { Title = "Star Wars: Episode V - The Empire Strikes Back" },
            new Movie { Title = "Star Wars: Episode VI - Return of the Jedi" },
            new Movie { Title = "Star Wars: Episode VII - The Force Awakens" },
            new Movie { Title = "Star Wars: Episode VIII - The Last Jedi" },
            new Movie { Title = "Jurassic Park" },
            new Movie { Title = "The Lost World: Jurassic Park" },
            new Movie { Title = "Jurassic Park III" },
            new Movie { Title = "Jurassic World" },
            new Movie { Title = "Jurassic World: Fallen Kingdom" },
            new Movie { Title = "Jurassic World: Dominion" },
            new Movie { Title = "The Avengers" },
            new Movie { Title = "Avengers: Age of Ultron" },
            new Movie { Title = "Avengers: Infinity War" },
            new Movie { Title = "Avengers: Endgame" },
            new Movie { Title = "Avengers: The Last Stand" },
            new Movie { Title = "The Dark Knight" },
            new Movie { Title = "The Dark Knight Rises" },
            new Movie { Title = "The Dark Knight Returns" },
            new Movie { Title = "The Dark Knight Falls" },
        };

        public List<Movie> Find(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return _movieList.ToList();
            }


            return _movieList.Where(m => m.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}