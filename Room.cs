using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    // This class represents a room in the dungeon.
    public class Room
    {
        // Properties for the room's description, items and enemies
        private string description;
        private List<Item> items;
        private List<Enemy> enemies = new List<Enemy>(); 

        // Constructor to create a new room with a description and optional initial items
        public Room(string description, List<Item> items = null)
        {
            this.description = description;
            this.items = items ?? new List<Item>();
        }

        // Method to add an item to the room
        public void AddItem(Item item)
        {
            if (item != null)
            {
                items.Add(item);
            }
        }

        // Method to remove an item from the room and return it
        public Item TakeItem(string itemName)
        {
            // Find the item by name
            Item item = items.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));

            if (item != null)
            {
                items.Remove(item);
                Console.WriteLine($"{item.Name} taken from the room.");
                return item;
            }
            else
            {
                Console.WriteLine($"Item {itemName} not found in the room.");
                return null;
            }
        }

        // Method to return a string of all the items in the room
        public string GetItems()
        {
            return items.Count > 0 ? string.Join(", ", items.Select(i => i.Name)) : "No items in this room.";
        }

        // Method to add an enemy to the room
        public void AddEnemy(Enemy enemy)
        {
            if (enemy != null)
            {
                enemies.Add(enemy);
            }
        }

        // Method to remove an enemy from the room
        public void RemoveEnemy(Enemy enemy)
        {
            if (enemy != null && enemies.Contains(enemy))
            {
                enemies.Remove(enemy);
            }
        }

        // Method to return a string of all the enemies in the room
        public string GetEnemies()
        {
            return enemies.Count > 0 ? string.Join(", ", enemies.Select(e => e.Name)) : "No enemies in this room.";
        }

        // Method to get the first enemy in the room
        public Enemy GetFirstEnemy()
        {
            return enemies.FirstOrDefault();
        }

        // Method to get an enemy by name
        public Enemy GetEnemy(string enemyName)
        {
            return enemies.FirstOrDefault(e => e.Name.Equals(enemyName, StringComparison.OrdinalIgnoreCase));
        }

        // Method to display the room's description and the items within it
        public void GetRoomDescription()
        {
            Console.WriteLine(description);
            Console.WriteLine($"Items in the room: {GetItems()}");
            Console.WriteLine($"Enemies in the room: {GetEnemies()}");
        }
    }
}