using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    // Player class which is used to represent the player in the game
    public class Player
    {
        // Properties for the player's name and health
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        // Constructor to create a new player
        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }

        // Method to pick up an item and add it to the player's inventory
        public void PickUpItem(string item)
        {
            if (string.IsNullOrEmpty(item))
            {
                Console.WriteLine("Invalid item");
            }
            else
            {
                inventory.Add(item);
                Console.WriteLine($"{Name} picked up {item}");
            }
        }

        // Method to remove an item from the player's inventory
        public void DropItem(string item)
        {
            if (inventory.Contains(item))
            {
                inventory.Remove(item);
                Console.WriteLine($"{Name} dropped {item}");
            }
            else
            {
                Console.WriteLine($"{Name} does not have {item}");
            }
        }

        // Method to show the contents of the player's inventory
        public string InventoryContents()
        {
            return inventory.Count > 0 ? string.Join(", ", inventory) : "Inventory is empty.";
        }

        // Method to show the player's stats
        public void ShowPlayerStats()
        {
            Console.WriteLine($"Player: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Inventory: {InventoryContents()}");
        }

        // Method to remove an item from a room when the player adds the item to their inventory
        public void TakeItemFromRoom(Room room, string item)
        {
            string retrievedItem = room.TakeItem(item);
            if (retrievedItem != null)
            {
                PickUpItem(retrievedItem);
            }
        }
    }
}