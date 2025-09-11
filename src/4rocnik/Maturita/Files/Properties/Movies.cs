using System;
using System.IO;

namespace Files.Properties
{
    public class Movies
    {
        private string film;
        private string genre;
        private string leadStudio;
        private string audienceScore;
        private string profit;
        private string rottenTomatoes;
        private string year;

        public Movies(string film, string genre, string leadStudio, string audienceScore, string profit,
            string rottenTomatoes,
            string year)
        {
            this.film = film;
            this.genre = genre;
            this.leadStudio = leadStudio;
            this.audienceScore = audienceScore;
            this.profit = profit;
            this.rottenTomatoes = rottenTomatoes;
            this.year = year;
        }

        public override string ToString()
        {
            return film;
        }
    }
}