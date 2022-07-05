using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Quest2
{


    public partial class Form3 : Form
    {
        static string way = System.IO.Directory.GetCurrentDirectory();
        Image image = Image.FromFile(way + @"/pic/Fon1.jpg");
        Form2 f2;
        Form4 f4;
        Form5 f5;
        Gamer gamer;

        Image zabor = Image.FromFile(way + @"/pic/zabor.png");
        Image home = Image.FromFile(way + @"/pic/home.png");
        Image lap = Image.FromFile(way + @"/pic/lap.png");

        List<Obj> mapobj = new List<Obj>();
        List<Obj> objs = new List<Obj>();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < gamer.notes.Count; i++)
            {
                textBox1.Text += gamer.notes[i] + Environment.NewLine;
            }

            mapobj.Add(new Obj("Забор", "Забор.", zabor, 0, 400, 300, 200, 2));
            mapobj.Add(new Obj("Забор", "Забор.", zabor, 300, 400, 300, 200, 2));
            mapobj.Add(new Obj("Забор", "Забор.", zabor, 600, 400, 300, 200, 2));
            mapobj.Add(new Obj("Забор", "Забор.", zabor, 900, 400, 300, 200, 2));
            mapobj.Add(new Obj("Дом", "Вы увидели дом. Дверь дома подперта лопатой. Сквозь отверстия в двери виден тусклый свет.", home, 600, 250, 400, 400, 2));

            objs.Add(new Obj("Лопата", "Вы взяли лопату, может быть понадобится.", lap, 850, 470, 60, 100, 5));


            f5 = new Form5();
            f4 = new Form4();
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(image, new Rectangle(0, 0, 1000, 600));

            for (int i = 0; i < mapobj.Count; i++)
            {
                if (mapobj[i].flag)
                {
                    mapobj[i].ObjDraw(e.Graphics);
                }
            }

            for (int i = 0; i < objs.Count; i++)
            {
                if (objs[i].flag)
                {
                    objs[i].ObjDraw(e.Graphics);
                }
            }

            


            gamer.DrawPlayer(e.Graphics);
        }

        public void SetGamer(Gamer g)
        {
            gamer = g;
        }

        public void SetForm(Form2 f)
        {
            f2 = f;
        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            bool flag = true;

            for(int i = 0; i < objs.Count; i++)
            {
                if(objs[i].Touch(e.X,e.Y) && objs[i].flag)
                {
                    if(gamer.invetory.Count == 4)
                    {
                        flag = false;
                        objs[i].flag = false;
                        gamer.AddObject(objs[i]);
                        gamer.notes.Add(objs[i].description);
                        gamer.notes.Add("Дверь дома открылась");
                        break;
                    }

                }
            }

            for(int i = 0; i < mapobj.Count; i++)
            {
                if(mapobj[i].name == "Дом" && gamer.invetory.Count == 5 && mapobj[i].flag)
                {
                    
                    button3.Visible = true;
                }
            }


            if (flag)
            {
                gamer.MovePlayer(e.X);
                Refresh();
            }

            textBox1.Text = "";
            for (int i = 0; i < gamer.notes.Count; i++)
            {
                textBox1.Text += gamer.notes[i] + Environment.NewLine;
            }

            Refresh();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gamer.x = 880; gamer.y = 400;
            f2.SetGamer(gamer);
            f2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gamer.x = 10; gamer.y = 250;
            gamer.sizex = 300;
            gamer.sizey = 400;
            f4.SetGamer(gamer);
            f4.SetForm(this);
            f4.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gamer.x = 10; gamer.y = 400;
            f5.SetGamer(gamer);
            f5.SetForm(this);
            f5.Show();
            this.Hide();
        }
    }
}
