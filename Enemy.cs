using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // This class represents an enemy in the game, inheriting from Creature.
    public class Enemy : Creature
    {
        // Properties for the enemy's name, health, current room, and damage
        public Room CurrentRoom { get; private set; }
        public int Damage { get; private set; }

        // Constructor to initialize the enemy with a name, health, room, and damage
        public Enemy(string name, int health, Room room, int damage)
        {
            Name = name;
            Health = health;
            CurrentRoom = room;
            Damage = damage;
        }

        // Method to attack the player
        public override void Attack()
        {
            Console.WriteLine($"{Name} attacks and deals {Damage} damage!");
        }

        // Method to display the enemy's stats
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