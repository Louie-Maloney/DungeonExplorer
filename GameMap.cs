using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // This class represents the game map, which contains rooms and their connections.
    public class GameMap
    {
        // Dictionary to store rooms by name for quick access
        private Dictionary<string, Room> rooms;

        // Constructor to create a new game map with a list of rooms
        public GameMap()
        {
            rooms = new Dictionary<string, Room>();
        }

        // Method to add a room to the game map
        public void AddRoom(string roomName, Room room)
        {
            if (!rooms.ContainsKey(roomName))
            {
                rooms.Add(roomName.ToLower(), room);
            }
        }

        // Method to get a room by its name
        public Room GetRoom(string roomName)
        {
            if (rooms.ContainsKey(roomName))
            {
                return rooms[roomName];
            }
            else
            {
                Console.WriteLine($"Room '{roomName}' not found.");
                return null;
            }
        }

        // Method to display all rooms in the map
        public void ShowMap()
        {
            Console.WriteLine("Game Map:");
            foreach (var room in rooms)
            {
                Console.WriteLine($"- {room.Key}: ");
                Console.WriteLine($"  Items: {room.Value.GetItems()}");
                Console.WriteLine($"  Enemies: {string.Join(", ", room.Value.GetEnemies())}");
            }
        }

        // Method to check if a room exists in the map
        public bool RoomExists(string roomName)
        {
            return rooms.ContainsKey(roomName);
        }
    }
}
