using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DungeonExplorer
{
    // This class contains all the tests for the game
    internal class Testing
    {
        // This method runs all the tests
        public static void RunTests()
        {
            TestDamage();
            TestHealing();
            TestRoomEnemyInteraction();
            TestItemCollection();
        }

        // This method tests the damage dealt by a weapon
        public static void TestDamage() 
        {
            Player player = new Player("Test Player", 100);
            Room room = new Room("Test Room");
            Enemy enemy = new Enemy("Test Enemy", 50, room, 5);
            Weapon sword = new Weapon("Test Sword", "Deals 10 damage", 10);

            room.AddEnemy(enemy);

            int initialDamage = player.PlayerStatistics.TotalDamageDealt;
            sword.Use(enemy.CurrentRoom, player);

            Debug.Assert(player.PlayerStatistics.TotalDamageDealt == initialDamage + 10, "Damage dealt has not updated");

        }

        // This method tests the healing functionality of a potion
        private static void TestHealing()
        {
            Player player = new Player("Test Player", 100);
            Potion potion = new Potion("Test Potion", "Heals 20 health", 20);

            player.TakeDamage(20); 
            Debug.Assert(player.Health == 80, "Player health should be 80 after taking 20 damage");

            int initialHealthRestored = player.PlayerStatistics.TotalHealthRestored;
            potion.Use(player);

            Debug.Assert(player.Health == 100, "Player health should be 100 after healing 20 health");
            Debug.Assert(player.PlayerStatistics.TotalHealthRestored == initialHealthRestored + 20, "Player's total health restored stat should update by 20");
        }

        // This method tests the interaction between a room and an enemy
        private static void TestRoomEnemyInteraction()
        {
            Room room = new Room("Test Room");
            Enemy enemy = new Enemy("Test Enemy", 50, room, 10);
            room.AddEnemy(enemy);
            Debug.Assert(room.GetFirstEnemy() == enemy, "Room should contain the added enemy");
            room.RemoveEnemy(enemy);
            Debug.Assert(room.GetFirstEnemy() == null, "Room should not contain any enemies after removal");
        }

        // This method tests the item collection functionality
        private static void TestItemCollection()
        {
            Player player = new Player("Test Player", 100);
            Item item = new Item("Test Item", "This is a test item");
            player.Inventory.AddItem(item);
            Debug.Assert(player.Inventory.ContainsItem(item.Name), "Player inventory should contain the collected item");
        }
    }

}
