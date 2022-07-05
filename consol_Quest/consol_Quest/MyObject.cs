using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consol_Quest
{
    internal class MyObject
    {
        public string name { get; private set; }
        public string description { get; private set; }
        public bool flag; // можем ли взаимодействовать с объектом

        public MyObject(string name, string description, bool flag = true)
        {
            this.name = name;
            this.description = description;
            this.flag = flag;
        }
    }
}
