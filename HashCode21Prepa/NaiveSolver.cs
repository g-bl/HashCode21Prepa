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

    public class Delivery
    {
        public int NumberOfPeople;
        public List<int> PizzaIndexes;
    }
    
    // SOLVER

    class NaiveSolver
    {
        public NaiveSolver(string inputFileName, string outputFileName, char delimiter)
        {
            // Model initializations

            int  M; // the number of pizzas available in the pizzeria
            int T2; // the number of 2-person teams
            int T3; // the number of 3-person teams
            int T4; // the number of 4-person teams

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
                    Index = i -1,
                    NumberOfIngredients = int.Parse(linePizza[0]),
                    Ingredients = new List<string>()
                };

                for (int j = 1; j <= newPizza.NumberOfIngredients; j++)
                {
                    newPizza.Ingredients.Add(linePizza[j]);
                }

                pizzas.Add(newPizza);
            }

            /**************************************************************************************
             *  Solver
             **************************************************************************************/

            // Initialize all deliveries (as we have infinite number of pizzas)
            List<Delivery> infiniteDeliveries = new List<Delivery>();
            for (int i = 0; i < T2; i++)
            {
                infiniteDeliveries.Add(new Delivery()
                {
                    NumberOfPeople = 2,
                    PizzaIndexes = new List<int>()
                });
            }
            for (int i = 0; i < T3; i++)
            {
                infiniteDeliveries.Add(new Delivery()
                {
                    NumberOfPeople = 3,
                    PizzaIndexes = new List<int>()
                });
            }
            for (int i = 0; i < T4; i++)
            {
                infiniteDeliveries.Add(new Delivery()
                {
                    NumberOfPeople = 4,
                    PizzaIndexes = new List<int>()
                });
            }

            // Naive solver: fill the deliveries in order...
            int pizzaIndex = 0;
            foreach (Delivery delivery in infiniteDeliveries)
            {
                // S'il reste des pizza
                if (pizzaIndex + delivery.NumberOfPeople <= M)
                {
                    int lockedPizzaIndex = pizzaIndex;
                    // Donner autant de pizza que de personnes
                    for (int i = lockedPizzaIndex; i < lockedPizzaIndex + delivery.NumberOfPeople; i++)
                    {
                        delivery.PizzaIndexes.Add(pizzas[i].Index);
                        pizzaIndex++;
                    }
                }
                else
                    break;
            }

            // Remove unfulfilled orders
            List<Delivery> actualDeliveries = infiniteDeliveries.Where(d => d.PizzaIndexes.Count > 0).ToList();

            /**************************************************************************************
             *  Output
             **************************************************************************************/

            Console.WriteLine("Output to file...");

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), outputFileName)))
            {
                outputFile.WriteLine(actualDeliveries.Count);

                foreach (Delivery delivery in actualDeliveries)
                {
                    outputFile.WriteLine(delivery.PizzaIndexes.Count + " " + String.Join(' ', delivery.PizzaIndexes));
                }
            }

            Console.WriteLine("Done...");
            Console.WriteLine(Path.Combine(Directory.GetCurrentDirectory(), outputFileName));
        }
    }
}