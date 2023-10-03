using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoWindows
{
    internal class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        protected Random rnd { get; } = new Random();
        public User()
        {
            Id = rnd.Next();
            Name = "UserName" + rnd.Next();
            Email = $"email{rnd.Next()}@email.com";
            Password = "Password";
        }
        public User(string name, string email, string password)
        {
            Id = rnd.Next();
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
