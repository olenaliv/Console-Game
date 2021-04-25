using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{
    class Fight
    {

        static Player Player
        {
            get { return Program.player; }

            set { Program.player = value; }

        }

        public static void FightEnemy(Enemy enemy)
        {
            int first = Program.random.Next(1, 2); //рандомно определю, кто ходит первый
            Console.WriteLine($"Договоримся, что если рандом покажет 1 - первый стреляет Игрок, 2 - первый стреляет {enemy.Name} ");
            Console.WriteLine($"Сила великого рандома определила - {first}");
    
            if (first == 1)
                goto player_step;

            else
                goto enemy_step;


        enemy_step:
            
            int enemy_step = Program.random.Next(1, 3); //рандомно определяется шаг Компьютера
            int uron_enemy = 0; //в зависимости от шага будет определен урон Компьютера
            
            if (enemy_step == 1) //умеренный урон (18-25)
            {
                uron_enemy = Program.random.Next(18, 25);
                Player.health -= uron_enemy;
            }
            else if (enemy_step == 2) //большой диапазон урона (10-35)
            {
                uron_enemy = Program.random.Next(10, 35);
                Player.health -= uron_enemy;
            }
            else if (enemy_step == 3)//исцеление Игрока в небольшом диапазоне
            {
                uron_enemy = Program.random.Next(18, 35);
                Player.health += uron_enemy;
            }

            Console.WriteLine($"На Вас напал {enemy.Name}  с уроном {uron_enemy} и жизнью {enemy.Health}");

            Console.WriteLine($"Теперь Ваша жизнь = {Player.health}");

            //каждый раз проверим не закончилась ли жизнь у кого-нибудь
            //если закончилась - выведу сообщение и закончу игру
            //если нет, то следующий шаг Игрока
            if (Player.health <= 0) 
            {
                goto lose;
            }
            else if (enemy.Health <= 0)
            {
                goto win;
            }
            else
            {
                goto player_step;
            }

        player_step:
            Console.WriteLine($"Имя врага - {enemy.Name} : {enemy.Health} HP");
            Console.WriteLine($"Имя игрока - {Player.name} : {Player.health} HP");

            Console.WriteLine("Ваш ход: 1.нанести умеренный урон, 2.нанести тяжелый урон, 3.исцелить ");

            var key = Program.GetButton();
            
            if (key == ConsoleKey.D1)
            {
                int umeren_uron = Program.random.Next(18, 25);
                enemy.Health -= umeren_uron;
                Console.WriteLine($"Вы нанесли урон {umeren_uron} и тепeрь здоровье врага {enemy.Name} = {enemy.Health}");
            
            }
            else if (key == ConsoleKey.D2)
            {
                int real_uron = Program.random.Next(10,35);
                enemy.Health -= real_uron;
                Console.WriteLine($"Вы нанесли урон {real_uron} и тепeрь здоровье врага {enemy.Name} = {enemy.Health}");
            }
            else if (key == ConsoleKey.D3)
            {
                int heal = Program.random.Next(18, 25);
                enemy.Health += heal;
                Console.WriteLine($"Вы исцелили врага на {heal} и тепeрь здоровье врага {enemy.Name} = {enemy.Health}");
            }
            else
            {
                Console.WriteLine("Выберите правильную команду!");
                Thread.Sleep(2000);
                Console.Clear();
                goto player_step;
            }


            //каждый раз проверим не закончилась ли жизнь у кого-нибудь
            //если закончилась - выведу сообщение и закончу игру
            //если нет, то следующий шаг Компьютера
            if (Player.health <= 0)
            {
                goto lose;
            }
            else if (enemy.Health <= 0)
            {
                goto win;
            }
            else
            {
                goto enemy_step;
            }


        win:
            Console.WriteLine("Вы выиграли!");
            return;

        lose:
            Console.WriteLine("Вы проиграли!");
            return;


        }

    }
}
