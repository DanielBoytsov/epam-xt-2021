using System;
using System.Collections.Generic;
using System.Text;
using Task_2._2._1.Interfaces;

namespace Task_2._2._1
{
    public class GameObject : Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public IConduct Conduct { get; set; }

        public GameObject(int x, int y, string name, string type)
            : base(x, y)
        {
            Name = name;
            Type = type;
        }

        public GameObject(int x, int y, string name, string type, IConduct conduct)
            : this(x, y, name, type)
        {
            Conduct = conduct;
        }
    }
}
