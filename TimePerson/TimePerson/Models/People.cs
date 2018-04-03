using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TimePerson.Models
{
    public class People
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        public List<People> GetThePeople(int startYear, int endYear)
        {
            // Creating a new List of type People
            List<People> people = new List<People>();

            // Declaring thePath as a string type and setting it to the root directory
            string thePath = Environment.CurrentDirectory;

            // Declaring sneakyPath as a string and setting it to the full path to the personOfTheYear.csv file
            // .Combine is concatinating thePath and the other string into one string, GetFullPath returns the
            // path of that combination
            string sneakyPath = Path.GetFullPath(Path.Combine(thePath, @"wwwroot\personOfTheYear.csv"));

            // Declaring a peopleFile as a string array and putting all the data from the csv file into it
            string[] peopleFile = File.ReadAllLines(sneakyPath);

            // Creates an array for each person in the csv file and then creates a people object of them
            // It starts at i = 1 to skip the first line which gives the headers
            for (int i = 1; i < peopleFile.Length; i++)
            {
                string[] fields = peopleFile[i].Split(','); // Splits all data at commas
                people.Add(new People
                {
                    // assigns the data to the proper index
                    Year = Convert.ToInt32(fields[0]), // converts the string to a int
                    Honor = fields[1],
                    Name = fields[2],
                    Country = fields[3],
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    Title = fields[6],
                    Category = fields[7],
                    Context = fields[8],
                });
            }

            // LINQ query to get the people between the start and end years from the list
            List<People> allPeeps = people.Where(p => (p.Year >= startYear) && (p.Year <= endYear)).ToList();
            return allPeeps;
        }
    }
}
