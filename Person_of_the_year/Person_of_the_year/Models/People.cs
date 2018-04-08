using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Collections;

namespace Person_of_the_year.Models
{
    /* Portions of this code were copied from Amanda Iverson */


    public class TimePerson
    {
        // Object Constructor 
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        //This creates a generics collection
        public List<TimePerson> GetPersons(int StartYear, int EndYear)
        {
              /* Portions of this code were copied from Amanda Iverson */


            List<TimePerson> people = new List<TimePerson>();

            //Creating a sting of path and redirects to root directory
            string path = Environment.CurrentDirectory;
            //SETTING THE NEW PATH TO TAKE IN TWO ARGUMENTS THE PATH AND THE ROOT DIRECTORY TO BUILD NEW PATH
        
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));

            
            //CREATES AN ARRAY THAT CALLS THE READ ALL FILE LINE ON NEW PATH
            string[] myFile = File.ReadAllLines(newPath);


            //For loop which iterates thru the entire file seperating them into bits
            for (int i = 1; i < myFile.Length; i++)
            {
                //using split method on file
                string[] fields = myFile[i].Split(',');
                // after iterating thru each index adds a person from the constructor function
                people.Add(new TimePerson
                {
                    Year = Convert.ToInt32(fields[0]),
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

            //Lambda expression for pending people
            List<TimePerson> listofPeople = people.Where(p => (p.Year >= StartYear) && (p.Year <= EndYear)).ToList();
            return listofPeople;
        }

    }
}
