using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._2._1
{
    public class Map
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Map(int width, int height)
        {
            Height = height;
            Width = width;
        }
    }
}
