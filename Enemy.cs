using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Enemy
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
    


    public Enemy(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} took {damage} damage.");
            if (Health <= 0)
            {
                Console.WriteLine($"{Name} has been defeated.");
            }
        }

        public void ShowEnemyStats()
        {
            Console.WriteLine($"Enemy: {Name}");
            Console.WriteLine($"Health: {Health}");
        }
    }
}