using System;
namespace RockPaperScissors
{
    static public class ConsoleTable
    {
        static int tableWidth = 73;

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

        public static void showResult(int numRound, Player player1, Player player2)
        { 
            PrintLine();
            PrintRow("Player", "Points");
            PrintLine();
            PrintRow(player1.Name, player1.Point.ToString());
            PrintRow(player2.Name, player2.Point.ToString());
            PrintLine();
        }
    }
}
