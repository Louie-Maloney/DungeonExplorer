﻿using System;
using System.Collections.Generic;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game(string playerName)
        {
            // Initialize the game with one room and one player
            player = new Player(playerName, 100);
            currentRoom = new Room("You are in a dark room.", new List<string> { "torch", "sword", "axe" });

        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                // Code your playing logic here
                Console.WriteLine("What would you like to do?: ");
                Console.WriteLine("1. View room description");
                Console.WriteLine("2. View player status");
                Console.WriteLine("3. Pick up item");
                Console.WriteLine("4. Drop item");
                Console.WriteLine("5. Exit game");

                string choice = Console.ReadLine()?.Trim(); 

                switch (choice)
                {
                    case "1":
                        currentRoom.GetRoomDescription();
                        break;
                    
                    case "2":
                        player.ShowPlayerStats();
                        break;
                    
                    case "3":
                        Console.WriteLine("What item would you like to pick up?");
                        string itemToPickup = Console.ReadLine()?.Trim().ToLower();
                        if (string.IsNullOrWhiteSpace(itemToPickup))
                        {
                            Console.WriteLine("Invalid item");
                        }
                        else
                        {
                            player.TakeItemFromRoom(currentRoom, itemToPickup);
                        }
                        break;
                    
                    case "4":
                        Console.WriteLine("What item would you like to drop?");
                        string itemToDrop = Console.ReadLine()?.Trim().ToLower();
                        if (string.IsNullOrWhiteSpace(itemToDrop))
                        {
                            Console.WriteLine("Invalid item");
                        }
                        else if (player.InventoryContents().Contains(itemToDrop))
                        {
                            player.DropItem(itemToDrop);
                            currentRoom.AddItem(itemToDrop);
                        }
                        else
                        {
                            Console.WriteLine("Item not found in inventory");
                        }
                        break;
                    
                    case "5":
                        playing = false;
                        break;
                   
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}