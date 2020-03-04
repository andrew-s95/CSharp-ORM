using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = MusicStore.GetData().AllArtists;
            List<Group> Groups = MusicStore.GetData().AllGroups;

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            var VernArtist = Artists.Where(art => art.Hometown.Contains("Mount Vernon")) //Where grabs the artist the artist
                .Select(art => new {art.Age, art.ArtistName}); //Select grabs the artist att
            foreach (var artist in VernArtist)
            {
                Console.WriteLine("Artist: " + artist.ArtistName + " Age: " + artist.Age);
            }

            //Who is the youngest artist in our collection of artists?
            var youngest = Artists.OrderByDescending(art => art.Age).Last();
            Console.WriteLine("Artist: " + youngest.ArtistName + " Age: " + youngest.Age);

            //Display all artists with 'William' somewhere in their real name
            var will = Artists.Where(art => art.RealName.Contains("William"))
                .Select(art => art.RealName);
            foreach (var artist in will)
            {
                Console.WriteLine(artist);
            }

            //Display the 3 oldest artist from Atlanta
            var atlanta = Artists.Where(art => art.Hometown == "Atlanta").OrderByDescending(art => art.Age).Take(3);
            foreach (var artist in atlanta)
            {
                Console.WriteLine("Artist: " + artist.ArtistName + " Age: " + artist.Age + " Hometown: " + artist.Hometown);
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
	        Console.WriteLine(Groups.Count);
        }
    }
}
