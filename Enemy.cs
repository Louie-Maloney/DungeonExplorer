using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Enemy : Creature
    {
        public Room CurrentRoom { get; private set; }
        public int Damage { get; private set; }

        public Enemy(string name, int health, Room room, int damage)
        {
            Name = name;
            Health = health;
            CurrentRoom = room;
            Damage = damage;
        }

        public override void Attack()
        {
            Console.WriteLine($"{Name} attacks and deals {Damage} damage!");
        }

        public void ShowEnemyStats()
        {
            Console.WriteLine($"Enemy: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Damage: {Damage}");
        }

        // Optionally override TakeDamage to add extra behavior
        public new void TakeDamage(int amount)
        {
            base.TakeDamage(amount);

            if (Health <= 0)
            {
                CurrentRoom.RemoveEnemy(this);
            }
        }
    }
}