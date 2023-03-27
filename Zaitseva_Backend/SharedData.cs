using System.Collections.Generic;
using Zaitseva_Backend.Models;

namespace Zaitseva_Backend
{
    public class SharedData
    {
        public static HashSet<string> Summaries { get; } = new HashSet<string>
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static List<User> Users { get; } = new List<User>
        {
            new User(){ Login = "user", Password = "user" },
            new User(){ Login = "admin", Password = "admin" },
        };
    }
}
