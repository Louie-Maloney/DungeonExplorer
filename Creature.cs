using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Creature
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"{Name} took {amount} damage.");
            if (Health <= 0)
            {
                Console.WriteLine($"{Name} has been defeated.");
            }
        }
        public abstract void Attack();
    }
}
