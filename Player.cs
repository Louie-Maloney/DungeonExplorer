using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Player : Creature, IDamageable
    {
        public Inventory Inventory { get; private set; }
        public Statistics PlayerStatistics { get; private set; }

        // Constructor to create a new player
        public Player(string name, int health)
        {
            Name = name;
            Health = health;
            Inventory = new Inventory();
            PlayerStatistics = new Statistics();
        }

        // Override the Attack method from Creature class
        public override void Attack()
        {
            Console.WriteLine($"{Name} attacks with a mighty blow!");

        }

        // Method to return the player's inventory contents
        public string InventoryContents()
        {
            return Inventory.GetItems().Count > 0
                ? string.Join(", ", Inventory.GetItems().Select(i => i.Name))
                : "Inventory is empty.";
        }

        // Method to return the players stats
        public void ShowPlayerStats()
        {
            Console.WriteLine($"Player: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Inventory: {InventoryContents()}");
        }

        // Method to allow the player to use an item
        public void UseItem(string itemName, Room currentRoom, Player player)
        {
            Item item = Inventory.GetItems()
                .FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));

            if (item != null)
            {
                if (item is Weapon weapon)
                {
                    weapon.Use(currentRoom, player);
                }
                else if (item is Potion potion)
                {
                    potion.Use(player);
                }
                else
                {
                    item.Use(player);
                }
            }
            else
            {
                Console.WriteLine($"Item {itemName} not found in inventory.");
            }
        }

        // Method to increase the player's health when they choose to heal
        public void Heal(int amount)
        {
            Health += amount;
            PlayerStatistics.AddHealthRestored(amount);
        }

        // Method to remove an item from the player's inventory
        public void DiscardItem(string itemName)
        {
            Item item = Inventory.GetItems().FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                Inventory.RemoveItem(item);
            }
            else
            {
                Console.WriteLine($"Item {itemName} not found in inventory.");
            }
        }
    }
}