using System;

namespace LemonApp
{
    public class User
    {
        public string Username { get; set; } = "";
        public int Lemons { get; set; }
        public int Bonuses { get; set; }
        public int TreeState { get; set; } = 1;
        public DateTime LastActiveTime { get; set; } = DateTime.UtcNow;
        public string About { get; set; } = "";
    }
}
