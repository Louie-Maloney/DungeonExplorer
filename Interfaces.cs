using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // This interface defines the basic properties and methods for any damageable object in the game.
    public interface IDamageable
    {
        int Health { get; }
        void TakeDamage(int amount);
    }

    // This interface defines the basic properties and methods for any collectible item in the game.
    public interface ICollectible
    {
        string Name { get; }
        void Collect();
    }

}
