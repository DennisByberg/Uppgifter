﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämning3
{
    public class Player
    {
        Random rnd = new Random();

        public string name { get; set; } = "";
        public int coins { get; set; } = 0;
        public int level { get; set; } = 1;
        public int xp { get; set; } = 0;
        public int health { get; set; } = 10;
        public int damage { get; set; } = 1;
        public int armor { get; set; } = 0;
        public int potion { get; set; } = 5;
        public int weapon { get; set; } = 1;
        public int mods { get; set; } = 0;

        public int GetHealth()
        {
            int upper = (2 * mods + 7);
            int lower = (mods + 2);
            return rnd.Next(lower, upper);
        }
        public int GetPower()
        {
            int upper = (2 * mods + 2);
            int lower = (mods + 1);
            return rnd.Next(lower, upper);
        }
        public int GetCoins()
        {
            int upper = (50 * mods + 100);
            int lower = (40 * mods + 60);
            return rnd.Next(lower, upper);
        }

        public int GetXP()
        {
            int upper = (25 * mods + 55);
            int lower = (20 * mods + 15);
            return rnd.Next(lower, upper);
        }

        public int GetLevelUp()
        {
            return 20 * level + 75;
        }

        public bool CanLevelUp()
        {
            if (xp >= GetLevelUp())
                return true;
            else
                return false;
        }

        public void LevelUp()
        {
            while (CanLevelUp())
            {
                xp -= GetLevelUp();
                level++;
            }
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            TextAndStory.Print($"Congrats! You are now level {level}!");
            Console.ResetColor();
        }

        public static void ProgressBar(string fillerChar, string backgroundChar, decimal value, int size)
        {
            int diff = (int)(value * size);
            for (int i = 0; i < size; i++)
            {
                if (i < diff)
                {
                    Console.Write(fillerChar);
                }
                else
                {
                    Console.Write(backgroundChar);
                }
            }
        }
    }
}