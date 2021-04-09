using System;
using System.Threading;

namespace RockPaperScissors
{
    /**
     * 
     * Copyright (c) April 2021 All Rights Reserved
     * Author : Faneva RATOANINA
     * Date 08th April 2021
     * 
     */
    public static class Tools
    {
        public static String getResult(Choice choice1, Choice choice2)
        {
            
            if (choice1.Equals(Choice.Rock))
            {
                if (choice2.Equals(Choice.Paper))
                {
                    return "lose";
                }
                else if (choice2.Equals(Choice.Scissors))
                {
                    return "win";
                }
            }
            else if (choice1.Equals(Choice.Paper))
            {
                if (choice2.Equals(Choice.Rock))
                {
                    return "win";
                }
                else if (choice2.Equals(Choice.Scissors))
                {
                    return "lose";
                }
            }
            else if (choice1.Equals(Choice.Scissors))
            {
                if (choice2.Equals(Choice.Rock))
                {
                    return "lose";
                }
                else if (choice2.Equals(Choice.Paper))
                {
                    return "win";
                }
            }

            return "tie";
        }

        public static Choice choiceForComputer(Choice lastChoice)
        {
            if (lastChoice.Equals(Choice.Rock))
            {
                return Choice.Paper;
            }
            else if (lastChoice.Equals(Choice.Paper))
            {
                return Choice.Scissors;
            }
            else
            {
                return Choice.Rock;
            }
        }

        public static Boolean checkReplay()
        {
            Console.WriteLine("Do you want to play again ? " +
                    "\n Y => for yes " +
                    "\n N => No to quit the game");
            String confirm = Console.ReadLine();
            while (!String.Equals(confirm, "Y", StringComparison.CurrentCultureIgnoreCase)
                && !String.Equals(confirm, "N", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("The value you entered is incorrect, Do you want to play again ? " +
                "\n Y => for yes " +
                "\n N => No to quit the game");
                Console.ResetColor();
                confirm = Console.ReadLine();
            }

            return (String.Equals(confirm, "Y", StringComparison.CurrentCultureIgnoreCase));        
        }

        public static void exit()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Thank you for your participation, Good bye !!!");
            Console.ResetColor();
            Thread.Sleep(3000);
            Environment.Exit(0);
        }

    }
}
