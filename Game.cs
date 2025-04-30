using System;
using System.Collections.Generic;
using System.Media;
using System.Xml.Serialization;

namespace DungeonExplorer
{
    // Game class which is used to represent the game
    internal class Game
    {
        // Properties for the game
        private Player player;
        private GameMap map;
        private Room currentRoom;
        private Statistics statistics;

        // Constructor to initialize the game
        public Game(string playerName)
        {
            // Initialize player, map, and rooms
            player = new Player(playerName, 100);  // Default health is 100
            map = new GameMap();

            statistics = new Statistics();

            // Create some items
            Weapon sword = new Weapon("Sword", "Inflicts 20 damage", 20);
            Weapon axe = new Weapon("Axe", "Inflicts 5 damage.", 5);
            Potion potion = new Potion("Potion", "Increases health by 10.", 10);
            Weapon shield = new Weapon("Shield", "Increases health by 10.", 5);

            // Create rooms
            Room dungeon = new Room("A dark and eerie dungeon room.");
            Room garden = new Room("A bright and peaceful garden.");
            Room cave = new Room("A dark and damp cave.");
            Room forest = new Room("A dense and mysterious forest.");
            Room castle = new Room("An old castle.");

            // Create some enemies
            Enemy goblin = new Enemy("Goblin", 30, dungeon, 5);
            Enemy troll = new Enemy("Troll", 50, garden, 10);
            Enemy dragon = new Enemy("Dragon", 100, cave, 50);
            Enemy skeleton = new Enemy("Skeleton", 20, forest, 5);
            Enemy ghost = new Enemy("Ghost", 25, castle, 20);

            // Add items to the rooms
            dungeon.AddItem(sword);
            dungeon.AddItem(axe);
            garden.AddItem(potion);
            forest.AddItem(shield);

            // Add enemies to the rooms
            dungeon.AddEnemy(goblin);
            cave.AddEnemy(dragon);
            garden.AddEnemy(troll);
            forest.AddEnemy(skeleton);
            castle.AddEnemy(ghost);

            // Add rooms to the map
            map.AddRoom("Dungeon", dungeon);
            map.AddRoom("Garden", garden);
            map.AddRoom("Cave", cave);
            map.AddRoom("Forest", forest);
            map.AddRoom("Castle", castle);
           

            // Set the initial room
            currentRoom = dungeon;
        }

        // Method to start the game
        public void Start()
        {
            Console.WriteLine($"Welcome to the game, {player.Name}!");

            while (true)
            {
                if (player.Health <= 0)
                {
                    Console.WriteLine("You have died. Game over.");
                    Console.WriteLine("Here are your stats: ");
                    statistics.DisplayStatistics();
                    RestartGame();
                }

                Console.WriteLine("Choose an action: ");
                Console.WriteLine("1. Show player status");
                Console.WriteLine("2. Show current room description");
                Console.WriteLine("3. Take item from room");
                Console.WriteLine("4. Go to another room");
                Console.WriteLine("5. Use Item");
                Console.WriteLine("6. Show map");
                Console.WriteLine("7. Show enemy stats");
                Console.WriteLine("8. Show player statistics");
                Console.WriteLine("9. Drop an item");
                Console.WriteLine("10. Show strongest weapon");
                Console.WriteLine("11. Show all healing items in inventory");
                Console.WriteLine("12. Exit game");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        player.ShowPlayerStats();
                        break;
                    case "2":
                        currentRoom.GetRoomDescription();
                        break;
                    case "3":
                        Console.WriteLine("Enter the name of the item to take: ");
                        string itemName = Console.ReadLine();
                        TakeItemFromRoom(itemName);
                        statistics.AddItemCollected();
                        break;
                    case "4":
                        map.ShowMap();
                        Console.WriteLine("Enter the name of the room to go to: ");
                        string roomName = Console.ReadLine();
                        GoToRoom(roomName.ToLower());
                        break;
                    case "5":
                        Console.WriteLine("Enter the name of the item to use: ");
                        string itemToUse = Console.ReadLine();
                        player.UseItem(itemToUse, currentRoom, player);
                        break;
                    case "6":
                        map.ShowMap();
                        break;
                    case "7":
                        Console.WriteLine("Enter the name of the enemy to show stats: ");
                        string enemyName = Console.ReadLine();
                        Enemy enemy = currentRoom.GetEnemy(enemyName);
                        if (enemy != null)
                        {
                            enemy.ShowEnemyStats();
                        }
                        else
                        {
                            Console.WriteLine($"Enemy {enemyName} not found in the room.");
                        }
                        break;
                    case "8":
                        statistics.DisplayStatistics();
                        break;
                    case "9":
                        Console.WriteLine("Enter the name of the item to drop: ");
                        string itemToDrop = Console.ReadLine();
                        player.DiscardItem(itemToDrop);
                        break;
                    case "10":
                        ShowStrongestWeapon();
                        break;
                    case "11":
                        ShowAllPotions();
                        break;
                    case "12":
                        Console.WriteLine("Exiting game...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Pick from numbers 1-7. Please try again.");
                        break;
                }
            }
        }

        // Method to take an item from the current room
        private void TakeItemFromRoom(string itemName)
        {
            Item item = currentRoom.TakeItem(itemName);
            if (item != null)
            {
                bool added = player.Inventory.AddItem(item);
                if (! added)
                {
                    Console.WriteLine("Inventory is full. Cannot add item.");
                    currentRoom.AddItem(item); 
                }
            }
        }

        // Method to move the player to another room
        private void GoToRoom(string roomName)
        {
            if (map.RoomExists(roomName))
            {
                currentRoom = map.GetRoom(roomName);
                Console.WriteLine($"You have entered the {roomName}.");
            }
            else
            {
                Console.WriteLine($"The room '{roomName}' doesn't exist.");
            }
        }

        // Method to show the strongest weapon in the player's inventory
        private void ShowStrongestWeapon()
        {
            Weapon strongestWeapon = player.Inventory.GetStrongestWeapon();
            if (strongestWeapon != null)
            {
                Console.WriteLine($"The strongest weapon in your inventory is: {strongestWeapon.Name} with damage {strongestWeapon.weaponDamage}");
            }
            else
            {
                Console.WriteLine("No weapons found in your inventory.");
            }
        }

        // Method to show all healing items in the player's inventory
        private void ShowAllPotions()
        {
            var potions = player.Inventory.GetAllPotions();
            if (potions.Count > 0)
            {
                Console.WriteLine("Healing items in your inventory:");
                foreach (var potion in potions)
                {
                    Console.WriteLine($"{potion.Name} - Restores {potion.HealingAmount} health.");
                }
            }
            else
            {
                Console.WriteLine("No healing items found in your inventory.");
            }
        }

        // Method to restart the game 
        private void RestartGame()
        {
            Console.WriteLine("Do you want to restart the game? (yes/no)");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "yes")
            {
                Game newGame = new Game(player.Name);
                newGame.Start();
            }
            else
            {
                Console.WriteLine("Thank you for playing!");
                Environment.Exit(0);
            }
        }
    }
}