using System;
namespace RockPaperScissors
{
    /**
     * 
     * Copyright (c) April 2021 All Rights Reserved
     * Author : Faneva RATOANINA
     * Date 08th April 2021
     * 
     */
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
