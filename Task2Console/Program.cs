using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Logic;

namespace Task2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            User al = new User("Alexander");
            bool isWorking = true;
            while (isWorking)
            {
                Console.WriteLine("1)Set time 2)Subscribe 3)Unsubscribe 4)Turn On");
                string key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter Countdown time");
                            clock.SetSeconds(int.Parse(Console.ReadLine()));
                        }
                        break;

                    case "2":
                        {
                            al.Subscribe(clock);
                           
                        }
                        break;
                    case "3":
                        al.UnSubscribe(clock);
                        break;
                    case "4":
                        {
                            clock.BeginTicks();
                        }
                        break;
                    default:
                        isWorking = false;
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
