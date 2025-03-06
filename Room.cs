using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private List<string> items = new List<string> { "Torch", "Sword", "Axe" };

        public Room(string description)
        {
            this.description = description;
        }

        public string GetDescription()
        {
            return description;
        }

        public string GetItem()
        {
            Random random = new Random();
            int index = random.Next(items.Count);
            string randomItem = items[index];

            return randomItem;
        }
    }
}