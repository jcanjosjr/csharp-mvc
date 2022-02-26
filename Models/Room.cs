using System.Collections.Generic;

namespace Models
{
    public class Room
    {
        // Attributes of class Room.
        public static int RoomId = 0;
        private static List<Room> Rooms = new List<Room>();
        public int Id { set; get; }
        public string Number { set; get; }
        public string Equipaments { set; get; }

        // The public constructor, will be call when Room will instantiated.
        public Room(
            string Number,
            string Equipaments
        ) : this(++RoomId, Number, Equipaments)
        { }

        // The private constructor, will be call when Public where called.
        private Room(
            int Id,
            string Number,
            string Equipaments
        )
        {
            this.Id = Id;
            this.Number = Number;
            this.Equipaments = Equipaments;

            // Add a Room in a List of Rooms.
            Rooms.Add(this);
        }

        // The method ToString of Room.
        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\n - Identifier: {this.Number}"
                + $"\n - Equipaments: {this.Equipaments}";
        }

        // Method to check equality of two Room Objects.
        public override bool Equals(object obj)
        {
            if (obj == null || !Room.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Room iterable = (Room) obj;
            return iterable.Id == this.Id;
        }

        // Give the numeric identifier of object.
        // Good to quick checks object equality.
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Method to return all List of Rooms.
        public static List<Room> GetRooms()
        {
            return Rooms;
        }

        // Method remove a Obeject Room from list of Rooms.
        public static void RemoveRoom(Room room)
        {
            Rooms.Remove(room);
        }
    }
}