using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }
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

        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}