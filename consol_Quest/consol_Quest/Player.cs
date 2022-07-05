using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consol_Quest
{
    internal class Player
    {
        public string name { get; private set; }
        public List<MyObject> invetory { get; private set; }

        public Player(string name, List<MyObject> invetory)
        {
            this.name = name;
            this.invetory = invetory;
        }
        public void AddObject(MyObject ob) //добавить объект
        {
            invetory.Add(ob);
        }
    }
}
