using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class DataBase
    {
       
        public static List<Enemy> enemies;

        public static void Load()
        {

            enemies = new List<Enemy>();

            enemies.Add(new Enemy("Компьютер",0, 100)); //Создам врага с именем Компьютер id=0 и здоровьем=100

        }

        public static Enemy GetEnemy(int ID)
        {
            Enemy enemy = (Enemy)enemies.Find(L => L.Id == ID).Clone();

            if (enemy != null)
                return enemy;
            else
                return null;
        }


    }
}
