using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Enemy : ICloneable
    {
        public string Name;
        public int Id;
        public int Health, MaxHealth;


        public Enemy(string name, int id, int maxhealth) 
        {
            Name = name;
            Id = id;
            MaxHealth = maxhealth;


            Health = maxhealth;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
