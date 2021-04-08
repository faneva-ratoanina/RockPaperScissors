using System;
using System.Linq;

namespace RockPaperScissors
{ 
    class Program
    {
   

        static void Main(string[] args)
        {       
            Console.Title = "Rock - Paper - Scissors";
            Console.ForegroundColor = ConsoleColor.DarkMagenta;            
            Console.WriteLine("Welcome to Rock / Paper / Scissors application game developed by Faneva RATOANINA");
            
            Console.ResetColor();

            Console.WriteLine("Please enter 1 or 2 " +
                "\n 1 for two players " +
                "\n 2 against a computer player");
            String gameMode = Console.ReadLine();
          
            while (!gameMode.Equals("1") && !gameMode.Equals("2"))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("The value entered is incorrect, please enter " +
                    "\n 1 for two players and " +
                    "\n 2 against a computer player");
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

            play_MODE_1:
                while (player1.Point < 3 && player2.Point < 3)
                {                
                    Console.WriteLine("{0}: please make your choice " +
                        "\n 1 for Rock " +
                        "\n 2 for Paper " +
                        "\n 3 for Scissors ", player1.Name);

                    bool isNumeric = int.TryParse(Console.ReadLine(), out int choice1);

                    while (!numChoices.Contains(choice1) || !isNumeric)                    
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("The value entered for {0} is incorrect, please enter " +
                            "\n 1 for Rock " +
                            "\n 2 for Paper " +
                            "\n 3 for Scissors", player1.Name);
                        Console.ResetColor();
                        isNumeric = int.TryParse(Console.ReadLine(), out choice1);
                    }

                    Console.WriteLine("{0} : please make your choice " +
                        "\n 1 for Rock " +
                        "\n 2 for Paper " +
                        "\n 3 for Scissors ", player2.Name);
                    isNumeric = int.TryParse(Console.ReadLine(), out int choice2);

                    while (!numChoices.Contains(choice2) || !isNumeric)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("The value entered for {0} is incorrect, please enter " +
                            "\n 1 for Rock " +
                            "\n 2 for Paper " +
                            "\n 3 for Scissors", player2.Name);
                        Console.ResetColor();                      
                        isNumeric = int.TryParse(Console.ReadLine(), out choice2);
                    }

                    Choice choiceEnum1 = (Choice)choice1 - 1;
                    Choice choiceEnum2 = (Choice)choice2 - 1;
                    player1.Choice = choiceEnum1;
                    player2.Choice = choiceEnum2;
                    Console.WriteLine("{0} => {1}, {2} => {3}", player1.Name, choiceEnum1, player2.Name, choiceEnum2);
                    string result = Tools.getResult(choiceEnum1, choiceEnum2);
                    if (result.Equals("win"))
                    {
                        Console.WriteLine("{0} win", player1.Name);
                        player1.Point++;
                    }else if (result.Equals("lose"))
                    {
                        Console.WriteLine("{0} win", player2.Name);
                        player2.Point++;
                    }else
                    {
                        Console.WriteLine("It's a tie, this round will restart");                        
                        goto play_MODE_1;                        
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("On round {0}, here are the score : ", numRound);
                    Console.ResetColor();
                    ConsoleTable.showResult(numRound, player1, player2);
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

            play_MODE_2:
                while (player1.Point < 3 && player2.Point < 3)
                {
                    Console.WriteLine("{0} : please make your choice " +
                        "\n 1 for Rock " +
                        "\n 2 for Paper " +
                        "\n 3 for Scissors ", player1.Name);
                    
                    bool isNumeric = int.TryParse(Console.ReadLine(), out int choice1);                    

                    while (!numChoices.Contains(choice1) || !isNumeric)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("{0 }, The value entered is incorrect, please enter " +
                            "\n 1 for Rock " +
                            "\n 2 for Paper " +
                            "\n 3 for Scissors", player1.Name);
                        Console.ResetColor();
                        isNumeric = int.TryParse(Console.ReadLine(), out choice1);
                    }

                    int choice2 = 0;
                    if (numRound == 1)
                    {
                        choice2 = rand.Next(3);
                    }
                    else
                    {
                        choice2 = (int)Tools.choiceForComputer(choiceEnum2);
                    }               

                    Choice choiceEnum1 = (Choice)choice1 - 1;
                    choiceEnum2 = (Choice)choice2;
                    player1.Choice = choiceEnum1;
                    player2.Choice = choiceEnum2;
                    Console.WriteLine("{0} => {1}, {2} => {3}", player1.Name, choiceEnum1, player2.Name, choiceEnum2);
                    string result = Tools.getResult(choiceEnum1, choiceEnum2);
                    if (result.Equals("win"))
                    {
                        Console.WriteLine("{0} win", player1.Name);
                        player1.Point++;
                    }
                    else if (result.Equals("lose"))
                    {
                        Console.WriteLine("{0} win", player2.Name);
                        player2.Point++;
                    }
                    else
                    {
                        Console.WriteLine("It's a tie, this round will restart");
                        goto play_MODE_2;
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;              
                    Console.WriteLine("On round {0}, here are the score : ",numRound);
                    Console.ResetColor();
                    ConsoleTable.showResult(numRound, player1, player2);
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
              
    }
}
