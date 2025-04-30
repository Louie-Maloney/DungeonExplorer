using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Creature
    {
        // Properties for creature's name and health
        public string Name { get; protected set; }
        public int Health { get; protected set; }

        // Method to damage the creature    
        public void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"{Name} took {amount} damage.");
            if (Health <= 0)
            {
                Console.WriteLine($"{Name} has been defeated.");
            }
        }

        // Method to heal the creature
        public abstract void Attack();
    }
}
