using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessThatNumber
{
    public class Program
    {
       
        //this is the number the user needs to guess.  Set its value in your code using a RNG.
        static int NumberToGuess;
        
        //creating random variable 
        static Random rng = new Random();
        
        //create number variable for use input
        static string userInput = string.Empty;
        
        //create counter for times guessed 
        static int TimesGuessed = 0;
        
        //create an out for validating userInput
        static int GuessedNumber;

        //create a bool to set to false for my loop
        static bool Guessing = true;

        static void Main(string[] args)
        {
            //sets random number to numbertoguess
            SetNumberToGuess(NumberToGuess);
            //loops til solution is found
            while (Guessing == true)
            {
                Console.WriteLine("Input a number between 1 and 100");
                userInput = Console.ReadLine();
                //if string input is a number between 1 and 100
                if (ValidateInput(userInput))
	            {
                    //adds to times guessed
                    TimesGuessed++;
                    //checks if guess is too high
                    if (IsGuessTooHigh(GuessedNumber))
                    {
                        Console.WriteLine("Your number is too high! Try again!");
                        TimesGuessed++;
                    }
                    //checks if number is too low
                    else if (IsGuessTooLow(GuessedNumber))
                    {
                        Console.WriteLine("Your number is too low! Try again!");
                        TimesGuessed++;
                    }
                    //must be the number and ends loop 
                    else
                    {
                        Console.WriteLine("you got it it only took you {0} trys!", TimesGuessed);
                        Guessing = false;
                        Console.ReadKey();
                    }

	            }
                //if input is not an integer
                else
                {
                    Console.WriteLine("I said a number between 1 and 100");
                }
            }
        }  
        /// <summary>
        /// Checks to make sure value is a number between 1 and 100
        /// </summary>
        /// <param name="userInput">the user's input</param>
        /// <returns>either true or false</returns>
        public static bool ValidateInput(string userInput)
        {
            // creates temporary boolean variable and tests to see if string is an integer and within 1 and 100
            bool tempInput = int.TryParse(userInput, out GuessedNumber);
            if (tempInput == true && GuessedNumber > 0 && GuessedNumber < 101)
            {
                return true;
            }
            
            return false;
        }
        /// <summary>
        /// Sets random number
        /// </summary>
        /// <param name="number">any integer</param>
        public static void SetNumberToGuess(int number)
        {
            //sets number to random
            number = rng.Next(1, 101);
            NumberToGuess = number;
        }
        /// <summary>
        /// checks if a number is higher then the number to guess
        /// </summary>
        /// <param name="userGuess">user's guess</param>
        /// <returns>bool</returns>
        public static bool IsGuessTooHigh(int userGuess)
        {
            //checks if guessed number is greater than number to guess 
            if (userGuess > NumberToGuess)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// checks if number is lower then number to guess
        /// </summary>
        /// <param name="userGuess">user's guess</param>
        /// <returns>bool</returns>
        public static bool IsGuessTooLow(int userGuess)
        {
            //checks if guessed number is lower than number to guess
            if (userGuess < NumberToGuess)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
