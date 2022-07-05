using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Quest2
{
    public class Gamer
    {
        static string way = System.IO.Directory.GetCurrentDirectory();
        public string name { get; private set; }
        public List<Obj> invetory { get; private set; }
        public Image image = Image.FromFile(way + @"/pic/Play.png");
        public int x, y;
        public int sizex, sizey;
        public List<string> notes = new List<string>();

        public Gamer(string name, List<Obj> invetory, int x, int y, int sizex, int sizey)
        {
            this.name = name;
            this.invetory = invetory;
            this.x = x; this.y = y;
            this.sizex = sizex; this.sizey = sizey;
    }

        public void AddNotes(string s)
        {
            notes.Add(s);
        }

        public void AddObject(Obj ob) // Добавление объекта в инвентарь;
        {
            invetory.Add(ob);
        }

        public void DrawPlayer(Graphics g)
        {
            g.DrawImage(this.image, new Rectangle(this.x, this.y, sizex, sizey));
        }

        public bool Touch(int xx, int yy)
        {
            return x < xx && x + sizex > xx && y < yy && yy + sizey > yy;
        }

        public bool GetObj(Obj j)
        {
            for (int i = 0; i < invetory.Count; i++)
            {
                if(j.name == invetory[i].name)
                {
                    return true;
                }
            }
            return false;
        }

        public void MovePlayer(int x1)
        {
            if (x < x1)
            {
                while (x < x1)
                {
                    x += 5;
                }
            }

            if (x > x1)
            {
                while (x > x1)
                {
                    x -= 5;
                }
            }
        }
    }


    public class Obj
    {
        public string name { get; private set; }
        public string description { get; private set; } // описание объекта;
        public bool flag; // можем ли взаимодействовать с объектом
        public Image image;
        public int x, y;
        public int sizex, sizey;
        public int index;

        public Obj(string name, string description, Image i, int x, int y, int sizex, int sizey, int ind, bool flag = true)
        {
            this.name = name;
            this.description = description;
            this.flag = flag;
            this.image = i;
            this.x = x; this.y = y;
            this.sizex = sizex; this.sizey = sizey;
        }

        public void ObjDraw(Graphics g)
        {
            g.DrawImage(this.image, new Rectangle(this.x, this.y, sizex, sizey));
        }

        public void MovePoshition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Touch(int xx, int yy)
        {
            return x < xx && x + sizex > xx && y < yy && yy + sizey > yy;
        }

        

    }
}
