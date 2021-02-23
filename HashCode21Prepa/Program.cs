using System;

namespace HashCode21Prepa
{
    class Program
    {
        static void Main(string[] args)
        {
            NaiveSolver naiveSolverA = new NaiveSolver("a_example.txt", "a_example.out", ' ');
            NaiveSolver naiveSolverB = new NaiveSolver("b_little_bit_of_everything.txt", "b_little_bit_of_everything.out", ' ');
            NaiveSolver naiveSolverC = new NaiveSolver("c_many_ingredients.txt", "c_many_ingredients.out", ' ');
            NaiveSolver naiveSolverD = new NaiveSolver("d_many_pizzas.txt", "d_many_pizzas.out", ' ');
            NaiveSolver naiveSolverE = new NaiveSolver("e_many_teams.txt", "e_many_teams.out", ' ');

            Console.ReadKey();
        }
    }
}
