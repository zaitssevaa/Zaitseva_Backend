using System.Collections.Generic;
using Zaitseva_Backend.Models;

namespace Zaitseva_Backend
{
    public class SharedData
    {
        public static List<User> Users { get; } = new List<User>
        {
            new User(){ Login = "user", Password = "user" },
            new User(){ Login = "admin", Password = "admin" },
        };
    }
}
