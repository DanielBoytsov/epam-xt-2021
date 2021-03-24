using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public class Session
    {
        public string Name { get; set; }

        public Session(string username)
        {
            if (username != null)
                Name = username;
            else
                throw new ArgumentException("Please input your name correctly");
        }
    }
}
