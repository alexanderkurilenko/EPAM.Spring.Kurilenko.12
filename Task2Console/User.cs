using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Logic;

namespace Task2Console
{
    class User
    {
        public string Name { get; set; }

        public User(string name)
        {
            Name = name;
        }

        public void React(object sender, EventArgs e)
        {
            Console.WriteLine($"User '{Name}' has message from {sender.GetType()}");
        }

        public void Subscribe(Clock clock)
        {
            clock.TimeIsOver += React;
        }

        public void UnSubscribe(Clock clock)
        {
            clock.TimeIsOver -= React;
        }
    }
}
