using System;

namespace Qrt_1_Project_Number_Guessing_Game
{
    class Program
    {
        static void Main()
        {

            

            // This keeps track of the trials
            int trials = 0;

            /*
            // HERE FOR TESTING PERPOSES
            Console.WriteLine(answer);  
            Console.WriteLine("HERE FOR TESTING PERPOSES!!! \n\n");
            */


            // Dialogue Set-upE4B5DGFHNRT

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n Hello! What is your name?\n");
            string UserName = Console.ReadLine();

            Console.WriteLine("\n Happy Monday (or whatever day today is) to you, {0}! \n" + "\n Please give me two numbers which are far from each other. \n", UserName);

            string userInput = Console.ReadLine();
            int lowBounder = Convert.ToInt32(userInput);

            userInput = Console.ReadLine();
            int upBounder = Convert.ToInt32(userInput);
            
            while (lowBounder == upBounder || lowBounder + 1 == upBounder || lowBounder - 1 == upBounder)
            {
                Console.WriteLine("\n Give me a different value for the upper limit, and make sure it's much greater than the lower limit ({0}). \n", lowBounder);
                userInput = Console.ReadLine();
                upBounder = Convert.ToInt32(userInput);
            }
            if (lowBounder > upBounder)
            {
            
                int tempHigh = lowBounder;
                lowBounder = upBounder; 
                upBounder = tempHigh;
            }
            Console.WriteLine("\n In my \"mind\", I have  a number from {0} to {1}, can you guess it in 10 tries or less?\n", lowBounder, upBounder);

            // Generating the random number
            Random randomNumber = new();
            int answer = randomNumber.Next(lowBounder, upBounder+1);

            Console.WriteLine(" Guess the number\n");
            Console.ForegroundColor = ConsoleColor.White;

            // loop that check user's reply
            for (int i = 1; i <= 10; i++)
            {
                
                // keeping track of the trials
                trials++;
                
                // Checking for invalid input
                
                try
                {

                    // Notice board
                    Console.Write("\nGuess {0}: \t ",i);
                    if (i == 10)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("\n This is your last chance, good luck!\t ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }


                    // User Input
                    userInput = Console.ReadLine();
                    int userReply = Convert.ToInt32(userInput);


                    // User enter a number outside the range
                    if (userReply < lowBounder)
                    {
                        Console.WriteLine("\n You entered a number smaller than {0}. The range is from {0} to {1}, inclusive. Try again. :) \n", lowBounder, upBounder);
                        i--;
                        trials--;
                        continue;
                    }
                    if (userReply > upBounder)
                    {
                        Console.WriteLine("\n You entered a number greater than {1}. The range is from {0} to {1}, inclusive. Try again. :) \n", lowBounder, upBounder);
                        i--;
                        trials--;
                        continue;
                    }



                    // if the user's input is wrong
                    if (userReply != answer)
                    {
                        
                        // If the user used up all the guesses
                        if (i == 10)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\n You used up all your 10 guesses,{0}. The number on my mind was {1}. " +
                                "\n Don't worry, {0}, you'll do better next time! I wish you luck! :D\t ", UserName, answer);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }

                        // User's answer is too small
                        if (userReply < answer)
                        { 
                            // changing the lower bound to narrow the range
                            if (userReply > lowBounder)
                            {
                                lowBounder = userReply;
                            }
                            Console.WriteLine("\n No. Guess HIGHER, " + 
                                "the correst answer is GREATER than {0} and LOWER than {1}.\n", lowBounder, upBounder);
                        }
                        else // User's answer is too large
                        {
                            // changing the upper bound to narrow the range
                            if (userReply < upBounder)
                            {
                                upBounder = userReply;
                            }
                            Console.WriteLine("\n No. Guess LOWER, " +
                                "the correst answer is GREATER than {0} and LESS than {1} .\n", lowBounder, upBounder);
                        }

                        
                    } // End of the IF that test for wrong answer

                    // if the user's input is right
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\n CORRET! {0} you guessed it, the answer is {1}!", UserName,answer);
                        Console.WriteLine(" You only used {0} gueses, how brilliant! :D", trials);
                        break;
                    }


                } // End of try
                catch (Exception)
                {
                    Console.WriteLine("\n Error! Try agian, enter what was requested.\n");
                    i--;
                    trials--;
                }

            } // End of loop that check user's reply


            Console.ReadLine();

        }// End of Main
    } // End of program
} // End of namespace