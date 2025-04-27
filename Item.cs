using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Item : ICollectible
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public void Collect()
        {
            Console.WriteLine($"Collected {Name}: {Description}");
        }
        public virtual void Use(Player player)
        {
            Console.WriteLine($"Using {Name}: {Description}");
        }
    }

    public class Weapon : Item
    {
        public int weaponDamage { get; private set; }
        
        public Weapon(string name, string description, int damage) : base(name, description)
        {
            weaponDamage = damage;
        }
        
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

    public class Potion : Item
    {
        public int HealingAmount { get; private set; }
        public Potion(string name, string description, int healingAmount) : base(name, description)
        {
            HealingAmount = healingAmount;
        }
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
