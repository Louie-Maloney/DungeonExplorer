using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private List<string> items;

        public Room(string description, List<string> items = null)
        {
            this.description = description;
            this.items = items ?? new List<string>();
        }

        public void AddItem(string item)
        {
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
                Console.WriteLine($"{item} added to the room");
            }
        }

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

        public string GetItems()
        {
            return items.Count > 0 ? string.Join(", ", items) : "No items in this room.";
        }

        public void GetRoomDescription()
        {
            Console.WriteLine(description);
            Console.WriteLine($"Items in the room: {GetItems()}");
        }


    }
}