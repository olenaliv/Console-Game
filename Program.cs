using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{
    class Program
    {
        public static Random random;
        public static Player player;
 

        static void Main(string[] args)
        {
            random = new Random();
            player = new Player();

            DataBase.Load();

        go:
            Console.Clear();
            Console.WriteLine("1. Играть");
            Console.WriteLine("2. Выход");

            ConsoleKey key = GetButton();

            Console.Clear();

            if (key == ConsoleKey.D1)
            {
                Console.WriteLine("Введите Ваше имя ");
                player.name = Console.ReadLine();

                Game();
            }
            else if (key == ConsoleKey.D2)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine(key);
                Console.WriteLine("Выберите правильную команду!");
                Thread.Sleep(2000);
                goto go;
            }

            
        }

        public static void Game()
        {
            
            Console.Clear();

            Console.WriteLine("Выберите команду!");
            Thread.Sleep(1500);

        go:
            Console.Clear();
            Console.WriteLine("1.информация, 2.бой, 3.выход");

            ConsoleKey key = GetButton();

            if (key == ConsoleKey.D1)
            {
                Console.WriteLine($"Ваше имя: {player.name}");
                Console.WriteLine($"Ваше здоровье: {player.health}/{player.healthMax}");
                Console.WriteLine("Нажмите любую клавишу");
                Console.ReadKey();
                goto go;
            }
            else if (key == ConsoleKey.D2)
            {
                player.health = 100;//новая игра - устанвливаю здоровье 100
                Fight.FightEnemy(DataBase.GetEnemy(0));
            }
            else if (key == ConsoleKey.D3)
            {
               Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Выберите правильную команду!");
                Thread.Sleep(2000);
                goto go;
            }

            Console.WriteLine("Нажмите на любую кнопку!");
            Console.ReadKey();
            goto go;


        }

        public static ConsoleKey GetButton() 
        {
            var but = Console.ReadKey(true).Key;

            return but;
        }
    }
}
