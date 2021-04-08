using System;
using System.Linq;

namespace RockPaperScissors
{
    class Player
    {
        private String name;
        private int point = 0;

        public Player(String name)
        {
            this.name = name;
        }

        public string Name   
        {
            get { return name; }
            set { name = value; }
        }

        public int Point
        {
            get { return point; }
            set { point = value; }
        }
    }
    class Program
    {
        enum Choice
        {
            Rock,
            Paper,
            Scissors
        }

        static int tableWidth = 73;

        static void Main(string[] args)
        {
            /*****/
            //Console.Clear();
            //PrintLine();
            //PrintRow("Column 1", "Column 2", "Column 3", "Column 4");
            //PrintLine();
            //PrintRow("", "", "", "");
            //PrintRow("", "", "", "");
            //PrintLine();
            //Console.ReadLine();

            /*****/
            Console.Title = "Rock - Paper - Scissors";
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Welcome to Rock / Paper / Scissors application game developed by Faneva RATOANINA");
            Console.ResetColor();

            Console.WriteLine(" 1 for two players and \n 2 against a computer player");
            String gameMode = Console.ReadLine();

            //int intGameMode;
            //Boolean isNumeric = int.TryParse(gameMode, out int n);
            //Console.WriteLine(isNumeric);
            while (!gameMode.Equals("1") && !gameMode.Equals("2"))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("The value entrered is incorrect, please enter \n 1 for two players and \n 2 against a computer player");
                Console.ResetColor();
                gameMode = Console.ReadLine();
            }

            Random rand = new Random();

            int[] numChoices = { 1, 2, 3 };
            int numRound = 1;

            if (gameMode.Equals("1")) // Two players
            {
                Console.WriteLine("Player 1 : please enter your name ");       
                Player player1 = new Player(Console.ReadLine());
                Console.WriteLine("Player 2 : please enter your name ");
                Player player2 = new Player(Console.ReadLine());

                play:
                while (player1.Point < 3 && player2.Point < 3)
                {                
                    Console.WriteLine("{0}: please enter your choice \n 1 for Rock \n 2 for Paper \n 3 for Scissors ", player1.Name);
                    int choice1 = int.Parse(Console.ReadLine());
                   
                    while (!numChoices.Contains(choice1))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("The value entered for {0} is incorrect, please enter \n 1 for Rock \n 2 for Paper \n 3 for Scissors", player1.Name);
                        Console.ResetColor();
                        choice1 = int.Parse(Console.ReadLine());
                    }

                    Console.WriteLine("{0} : please enter your choice \n 1 for Rock \n 2 for Paper \n 3 for Scissors ", player2.Name);
                    int choice2 = int.Parse(Console.ReadLine());

                    while (!numChoices.Contains(choice2))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("The value entered for {0} is incorrect, please enter \n 1 for Rock \n 2 for Paper \n 3 for Scissors", player2.Name);
                        Console.ResetColor();
                        choice2 = int.Parse(Console.ReadLine());
                    }

                    Choice choiceEnum1 = (Choice)choice1 - 1;
                    Choice choiceEnum2 = (Choice)choice2 - 1;
                    Console.WriteLine("{0} => {1}, {2} => {3}", player1.Name, choiceEnum1, player2.Name, choiceEnum2);
                    if (getResult(choiceEnum1, choiceEnum2).Equals("win"))
                    {
                        Console.WriteLine("{0} win", player1.Name);
                        player1.Point++;
                    }else if (getResult(choiceEnum1, choiceEnum2).Equals("lose"))
                    {
                        Console.WriteLine("{0} win", player2.Name);
                        player2.Point++;
                    }else
                    {
                        Console.WriteLine("It's a tie, this round will restarted");                        
                        goto play;                        
                    }
                    Console.WriteLine("On round {0} {1} have {2} point and {3} have {4} point", numRound, player1.Name, player1.Point, player2.Name, player2.Point);
                    numRound++;
                }

                if(player1.Point >= 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congratulations {0}, you are the winner !!!", player1.Name);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congratulations {0}, you are the winner !!!", player2.Name);
                    Console.ResetColor();
                }
            }
            else // Against computer player
            {
                Console.WriteLine("Player 1 : please enter your name ");
                Player player1 = new Player(Console.ReadLine());

                Player player2 = new Player("ComputerBot");

                Choice choiceEnum2 = Choice.Rock;

            play:
                while (player1.Point < 3 && player2.Point < 3)
                {
                    Console.WriteLine("{0} : please enter your choice \n 1 for Rock \n 2 for Paper \n 3 for Scissors ", player1.Name);
                    int choice1 = int.Parse(Console.ReadLine());

                    while (!numChoices.Contains(choice1))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("{0 }, The value entered is incorrect, please enter \n 1 for Rock \n 2 for Paper \n 3 for Scissors", player1.Name);
                        Console.ResetColor();
                        choice1 = int.Parse(Console.ReadLine());
                    }

                    int choice2 = 0;
                    if (numRound == 1)
                    {
                        choice2 = rand.Next(3);
                    }
                    else
                    {
                        choice2 = (int)choiceForComputer(choiceEnum2);
                    }               

                    Choice choiceEnum1 = (Choice)choice1 - 1;
                    choiceEnum2 = (Choice)choice2;
                    Console.WriteLine("{0} => {1}, {2} => {3}", player1.Name, choiceEnum1, player2.Name, choiceEnum2);
                    if (getResult(choiceEnum1, choiceEnum2).Equals("win"))
                    {
                        Console.WriteLine("{0} win", player1.Name);
                        player1.Point++;
                    }
                    else if (getResult(choiceEnum1, choiceEnum2).Equals("lose"))
                    {
                        Console.WriteLine("{0} win", player2.Name);
                        player2.Point++;
                    }
                    else
                    {
                        Console.WriteLine("It's a tie, this round will restart");
                        goto play;
                    }
                    Console.WriteLine("On round {0} {1} have {2} point and {3} have {4} point", numRound, player1.Name, player1.Point, player2.Name, player2.Point);
                    numRound++;
                }

                if (player1.Point >= 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congratulations {0}, you are the winner !!!", player1.Name);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unfortunately {0}, you lose the game !!!", player1.Name);
                    Console.ResetColor();
                }
            }
            
        }

        static String getResult(Choice choice1, Choice choice2)
        { 
            if (choice1.Equals(Choice.Rock)) {
                if (choice2.Equals(Choice.Paper))
                {
                    return "lose";
                }
                else if (choice2.Equals(Choice.Scissors))
                {
                    return "win";
                }
            }else if (choice1.Equals(Choice.Paper))
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

        static Choice choiceForComputer(Choice lastChoice)
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

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
