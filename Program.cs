﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter player name: ");
            string playerName = Console.ReadLine();

            while (string.IsNullOrEmpty(playerName))
            {
                Console.WriteLine("Player name cannot be empty. Please enter a valid name: ");
                playerName = Console.ReadLine();
            }

            Game game = new Game(playerName);
            game.Start();
        }
    }
}
