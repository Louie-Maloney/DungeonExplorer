using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DungeonExplorer
{
    // Testing class which is used to run tests on the game
    internal class Testing
    {
        // Method to run tests on the player and room classes
        public static void Test()
        {
            TestPlayer();
            TestRoom();
        }

        // Method to run tests on the room class
        public static void TestRoom() 
        {
            Room room = new Room("Test Room", new List<string> { "item1", "item2" });
            Debug.Assert(room.GetItems() == "item1, item2", "GetItems() should return 'item1, item2'");
            Debug.Assert(room.TakeItem("item1") == "item1", "TakeItem('item1') should return 'item1'");
            Debug.Assert(room.GetItems() == "item2", "GetItems() should return 'item2'");
            Debug.Assert(room.TakeItem("item1") == null, "TakeItem('item1') should return null");
            Debug.Assert(room.GetItems() == "item2", "GetItems() should return 'item2'");
            Debug.Assert(room.TakeItem("item2") == "item2", "TakeItem('item2') should return 'item2'");
            Debug.Assert(room.GetItems() == "No items in this room.", "GetItems() should return 'No items in this room.'");
        }

        // Method to run tests on the player class
        public static void TestPlayer()
        {
            Player player = new Player("Test Player", 100);
            Debug.Assert(player.InventoryContents() == "Inventory is empty.", "InventoryContents() should return 'Inventory is empty.'");
            player.PickUpItem("item1");
            Debug.Assert(player.InventoryContents() == "item1", "InventoryContents() should return 'item1'");
            player.PickUpItem("item2");
            Debug.Assert(player.InventoryContents() == "item1, item2", "InventoryContents() should return 'item1, item2'");
            player.DropItem("item1");
            Debug.Assert(player.InventoryContents() == "item2", "InventoryContents() should return 'item2'");
            player.DropItem("item1");
            Debug.Assert(player.InventoryContents() == "item2", "InventoryContents() should return 'item2'");
            player.DropItem("item2");
            Debug.Assert(player.InventoryContents() == "Inventory is empty.", "InventoryContents() should return 'Inventory is empty.'");
        }
    }
}
