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
        private int MaxInventorySize;

        // Constructor to initialize the inventory
        public Inventory(int inventorySize = 3)
        {
            items = new List<Item>();
            MaxInventorySize = inventorySize;
        }

        // Method to add an item to the inventory
        public bool AddItem(Item item)
        {
            if (items.Count >= MaxInventorySize)
            {
                Console.WriteLine("Inventory is full. Cannot add more items.");
                return false;
            }
            if (item != null)
            {
                items.Add(item);
                Console.WriteLine($"{item.Name} added to inventory.");
                return true;
            }
            else
            {
                Console.WriteLine("Item cannot be null.");
                return false;
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

        // Method to return the strongest weapon in the inventory
        public Weapon GetStrongestWeapon()
        {
            return items.OfType<Weapon>().OrderByDescending(w => w.weaponDamage).FirstOrDefault();
        }

        // Method to return all potions in the inventory
        public List<Potion> GetAllPotions()
        {
            return items.OfType<Potion>().ToList();
        }

        // Method to check if the inventory contains a specific item by name
        public bool ContainsItem(string itemName)
        {
            return items.Any(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
