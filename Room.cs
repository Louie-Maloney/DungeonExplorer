using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    // Room class which is used to represent a room in the game
    public class Room
    {
        // Properties for the room's description and items
        private string description;
        private List<string> items;

        // Constructor to create a new room
        public Room(string description, List<string> items = null)
        {
            this.description = description;
            this.items = items ?? new List<string>();
        }

        // Method to add an item to the room when the player drops an item
        public void AddItem(string item)
        {
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
                Console.WriteLine($"{item} added to the room");
            }
        }

        // Method to remove an item from the room when the player picks up an item
        public string TakeItem(string item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                Console.WriteLine($"{item} taken from the room.");
                return item;
            }
            else
            {
                Console.WriteLine($"Item {item} not found in the room.");
                return null;
            }
        }

        // Method to return a string of all the items in the room
        public string GetItems()
        {
            return items.Count > 0 ? string.Join(", ", items) : "No items in this room.";
        }

        // Method to display the room description and items
        public void GetRoomDescription()
        {
            Console.WriteLine(description);
            Console.WriteLine($"Items in the room: {GetItems()}");
        }


    }
}