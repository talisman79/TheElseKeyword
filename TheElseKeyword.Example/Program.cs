using System;

namespace TheElseKeyword.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var recipeBook = new RecipeBook(Console.ReadLine, Console.WriteLine);
            var bartender = new Bartender(Console.ReadLine, Console.WriteLine, recipeBook);

            while (true)
            {
                bartender.AskForDrink();
            }
        }
    }
}