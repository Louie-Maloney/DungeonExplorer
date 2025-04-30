using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // This class represents an item in the game, which can be collected and used.
    public class Item : ICollectible
    {
        // Properties for the item's name and description
        public string Name { get; private set; }
        public string Description { get; private set; }

        // Constructor to initialize the item with a name and description
        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        // Method to collect the item
        public void Collect()
        {
            Console.WriteLine($"Collected {Name}: {Description}");
        }
        
        // Method to use the item
        public virtual void Use(Player player)
        {
            Console.WriteLine($"Using {Name}: {Description}");
        }
    }

    // This class represents a weapon item that can be used to attack enemies.
    public class Weapon : Item
    {
        // Property for the weapon's damage
        public int weaponDamage { get; private set; }
        
        public Weapon(string name, string description, int damage) : base(name, description)
        {
            weaponDamage = damage;
        }

        // Method to use a weapon on an enemy in the room
        public void Use(Room room, Player player)
        {
            Enemy target = room.GetFirstEnemy();
            if (target != null)
            {
                Console.WriteLine($"{player.Name} attacks {target.Name} with {Name} for {weaponDamage} damage!");
                target.TakeDamage(weaponDamage);
                player.PlayerStatistics.AddDamageDealt(weaponDamage);

                if (target.Health <= 0)
                {
                    Console.WriteLine($"{target.Name} has been defeated!");
                    room.RemoveEnemy(target);
                }
                else
                {
                    target.Attack();
                    player.TakeDamage(target.Damage);
                }
            }
            else
            {
                Console.WriteLine("There are no enemies in the room to attack.");
            }
        }
    }

    // This class represents a potion item that can be used to restore health.
    public class Potion : Item
    {
        // Property for the amount of health restored by the potion
        public int HealingAmount { get; private set; }

        // Constructor to initialize the potion with a name, description, and healing amount
        public Potion(string name, string description, int healingAmount) : base(name, description)
        {
            HealingAmount = healingAmount;
        }

        // Method to use the potion on a player
        public override void Use(Player player)
        {
            if (player != null)
            {
                Console.WriteLine($"{player.Name} used {Name} and restored {HealingAmount} health.");
                player.Heal(HealingAmount);
            }
        }
    }
}
