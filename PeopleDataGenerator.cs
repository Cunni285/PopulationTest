using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SciPlay_Test
{
    class Program
    {
        string[] firstNameArray = new string[] {"Oliver","Jack","Harry","Jacob","Charlie","Thomas","George","Oscar","James","Willaim",
                "Amelia","Olivia","Isla","Emily","Poppy","Ava","Isabella","Jessica","Lily","Sophie" };
        string[] lastNameArray = new string[] {"Smith","Jones","Williams","Brown","Taylor","Davies","Wilson","Evans","Thomas","Roberts","Jones", "Miller"
                ,"Davis","Garcia","Rodriguez" };

        Random random = new Random();

        int maxYear = 2000;
        int minYear = 1900;

        string MakePerson()
            {
                int birthYear = random.Next(minYear, maxYear + 1);
                int deathYear = random.Next(birthYear, maxYear + 1);

                String person = firstNameArray[random.Next(0, firstNameArray.Length)] + " " +
                    lastNameArray[random.Next(0, lastNameArray.Length)] + " " +
                    birthYear + " " + deathYear + Environment.NewLine;
                return person;
            }

        string output;

        void MakeListOfPeople(int numberOfPeople)
            {
                for(int i = 0; i < numberOfPeople; i++)
                {
                    output += (i+1).ToString() + " " + MakePerson();
                }
            }


        static void Main(string[] args)
        {
            Program program = new Program();

            program.MakeListOfPeople(100);

            string text = program.output;

            System.IO.File.WriteAllText(@"C:\Users\tybor\OneDrive\Documents\Code Projects\SciPlay Test\SciPlay Test\People.txt", text);
        }



    }
}
