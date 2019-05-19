using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PeopleDataSetReader
{
    public class Person
    {
        int index;
        string fName;
        string lName;
        public int birthYear;
        public int deathYear;

        public Person(int ind, string first, string last, int birth, int death)
        {
            index = ind;
            fName = first;
            lName = last;
            birthYear = birth;
            deathYear = death;
        }
    }

    //not using right now
    public class Year
    {
        int year;
        int count = 0;

        Year(int y)
        {
            year = y;
        }
    }

    class DatasetReader
    {
        static readonly string textFile = @"C:\Users\tybor\OneDrive\Documents\Code Projects\PeopleDataSetReader\PeopleDataSetReader\People.txt";

        public static Person[] people = new Person[100];

        public static Dictionary<int, int> years = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            ParseDataset();
            InitializeYearsDictionary();

            UpdateCountForYears();

            FindYearWithHighestPopulation();
        }

        private static void FindYearWithHighestPopulation()
        {
            int yearWithMostPeople = 1900;

            for (int i = 1900; i < 2001; i++)
            {
                if (years[i] > years[yearWithMostPeople])
                {
                    yearWithMostPeople = i;
                }
                //Console.WriteLine(i + " " + years[i]);
                //Console.ReadKey();
            }

            Console.WriteLine("Year with the most people: " + yearWithMostPeople);
            Console.ReadKey();
        }

        //goes through each person and increments count for each year they were alive
        private static void UpdateCountForYears()
        {
            foreach (Person person in people)
            {
                for (int i = person.birthYear; i <= person.deathYear; i++)
                {
                    years[i] += 1;
                }
            }
        }

        //creates entries for each year in dictionary and sets count to 0
        private static void InitializeYearsDictionary()
        {
            for (int i = 1900; i < 2001; i++)
            {
                years.Add(i, 0);
            }
        }

        //takes lines from dataset and parses values to an array
        private static void ParseDataset()
        {
            string[] lines = File.ReadAllLines(textFile);

            foreach (string line in lines)
            {
                string[] items = line.Split(' ');
                people[Int32.Parse(items[0]) - 1] = new Person(Int32.Parse(items[0]), items[1], items[2], Int32.Parse(items[3]), Int32.Parse(items[4]));
            }
        }
    }
}
