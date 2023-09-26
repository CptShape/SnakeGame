using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StajProje2.Classes
{
    public class ConsumableClass
    {
        public string name { get; set; }
        public string description { get; set; }
        public float lifetime { get; set; }
        public float spawnRate { get; set; }
        public float point { get; set; }
        public Color color { get; set; }
        public bool spawned { get; set; }
        public int expand { get; set; }
        public int speedUp { get; set; }
        public int speedDown { get; set; }
    }
}
