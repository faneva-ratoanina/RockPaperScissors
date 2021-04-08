using System;
namespace RockPaperScissors
{
    public class Player
    {

        private String name;
        private int point = 0;
        private Choice choice;

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

        public Choice Choice
        {
            get { return choice; }
            set { choice = value; }
        }
    }
}
