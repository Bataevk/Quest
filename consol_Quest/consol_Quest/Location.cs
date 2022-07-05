using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consol_Quest
{
    internal class Location
    {
        public string name { get; private set; }
        public string description { get; private set; }
        public List<MyObject> invetory { get; private set; }

        public Location(string name, string description, List<MyObject> invetory)
        {
            this.name = name;
            this.description = description;
            this.invetory = invetory;
        }

        public string GetDescription()
        {
            string secDes = "Оглядевшись вы заметили следующие предметы: ";
            foreach (MyObject m in invetory)
            {
                secDes += m.description + ", ";
            }
            return description + secDes + "...";
        }
        public List<MyObject> GetObjects()
        {
            return invetory;
        }
        public string[] GetObjectName()
        {
            string[] names = new string[invetory.Count];
            for (int i = 0; i < invetory.Count; i++)
            {
                names[i] = invetory[i].name;
            }
            return names;
        }
        public MyObject TakeObject(int index)
        {
            MyObject ob = invetory[index];
            invetory.RemoveAt(index);
            return ob;
        }
    }
}
