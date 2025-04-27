using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public interface IDamageable
    {
        int Health { get; }
        void TakeDamage(int amount);
    }

    public interface ICollectible
    {
        string Name { get; }
        void Collect();
    }

}
