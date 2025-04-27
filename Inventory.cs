using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Inventory
    {
        // List to store items in the inventory
        private List<Item> items;

        // Constructor to initialize the inventory
        public Inventory()
        {
            items = new List<Item>();
        }

        // Method to add an item to the inventory
        public void AddItem(Item item)
        {
            if (item != null)
            {
                items.Add(item);
                Console.WriteLine($"{item.Name} added to inventory.");
            }
        }

        // Method to remove an item from the inventory
        public void RemoveItem(Item item)
        {
            if (item != null && items.Contains(item))
            {
                items.Remove(item);
                Console.WriteLine($"{item.Name} removed from inventory.");
            }
            else
            {
                Console.WriteLine($"{item.Name} not found in inventory.");
            }
        }

        // Method to get a list of all items in the inventory
        public List<Item> GetItems()
        {
            return items;
        }

        // Method to check if the inventory contains a specific item by name
        public bool ContainsItem(string itemName)
        {
            return items.Any(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        }

        // Method to show all the items in the inventory (as a string)
        public void ShowInventory()
        {
            if (items.Count > 0)
            {
                Console.WriteLine("Inventory contains:");
                foreach (var item in items)
                {
                    Console.WriteLine($"- {item.Name}: {item.Description}");
                }
            }
            else
            {
                Console.WriteLine("Inventory is empty.");
            }
        }
    }
}
