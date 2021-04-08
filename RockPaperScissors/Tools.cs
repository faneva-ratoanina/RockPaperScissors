using System;
namespace RockPaperScissors
{
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

    }
}
