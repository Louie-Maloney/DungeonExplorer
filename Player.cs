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

        public string InventoryContents()
        {
            return Inventory.GetItems().Count > 0
                ? string.Join(", ", Inventory.GetItems().Select(i => i.Name))
                : "Inventory is empty.";
        }

        public void ShowPlayerStats()
        {
            Console.WriteLine($"Player: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Inventory: {InventoryContents()}");
        }

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

        public void Heal(int amount)
        {
            Health += amount;
            PlayerStatistics.AddHealthRestored(amount);
        }

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