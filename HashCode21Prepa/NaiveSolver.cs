using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode21Prepa
{
    // MODEL
    public class Pizza
    {
        public int Index;
        public int NumberOfIngredients;
        public List<string> Ingredients;
    }

    // SOLVER

    class NaiveSolver
    {
        public NaiveSolver(string inputFileName, string outputFileName, char delimiter)
        {
            // Model initializations

            int M  = 0; // the number of pizz asavailable in the pizzeria
            int T2 = 0; // the number of 2-person teams
            int T3 = 0; // the number of 3-person teams
            int T4 = 0; // the number of 4-person teams

            List<Pizza> pizzas = new List<Pizza>();

            /**************************************************************************************
             *  Input loading
             **************************************************************************************/

            Console.WriteLine("Input loading... " + inputFileName);

            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
            string[] lines = File.ReadAllLines(inputFilePath);

            // Metadata parsing
            string[] line0 = lines[0].Split(delimiter);
            M = int.Parse(line0[0]);
            T2 = int.Parse(line0[1]);
            T3 = int.Parse(line0[2]);
            T4 = int.Parse(line0[3]);

            // Pizzas parsing
            for (int i = 1; i <= M; i++)
            {
                string[] linePizza = lines[i].Split(delimiter);

                Pizza newPizza = new Pizza()
                {
                    Index = i,
                    NumberOfIngredients = int.Parse(linePizza[0]),
                    Ingredients = new List<string>()
                };

                for (int j = 1; i <= newPizza.NumberOfIngredients; i++)
                {
                    newPizza.Ingredients.Add(linePizza[j]);
                }

                pizzas.Add(newPizza);
            }
            
            /**************************************************************************************
             *  Solver
             **************************************************************************************/

            //libraries[1].SentBooksIndexes = new List<int>() { 5, 2, 3 };
            //libraries[0].SentBooksIndexes = new List<int>() { 0, 1, 2, 3, 4 };

            //List<Library> signedUpLibraries = new List<Library>()
            //{
            //    libraries[1],
            //    libraries[0]
            //};

            /**************************************************************************************
             *  Output
             **************************************************************************************/

            //Console.WriteLine("Output to file...");

            //using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), outputFileName)))
            //{
            //    outputFile.WriteLine(signedUpLibraries.Count);

            //    foreach (Library l in signedUpLibraries)
            //    {
            //        outputFile.WriteLine(l.Id + " " + l.SentBooksIndexes.Count);
            //        outputFile.WriteLine(String.Join(' ', l.SentBooksIndexes));
            //    }
            //}

            Console.WriteLine("Done...");
            Console.WriteLine(Path.Combine(Directory.GetCurrentDirectory(), outputFileName));
        }
    }
}