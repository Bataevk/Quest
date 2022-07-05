using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quest2
{
    public partial class Form4 : Form
    {
        static string way = System.IO.Directory.GetCurrentDirectory();
        Image image = Image.FromFile(way + @"/pic/Lok2.png");
        Image fon = Image.FromFile(way + @"/pic/Fon.png");

        Gamer gamer;
        Form3 f3;

        List<Obj> mapobj = new List<Obj>();
        List<Obj> objs = new List<Obj>();

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < gamer.notes.Count; i++)
            {
                textBox1.Text += gamer.notes[i] + Environment.NewLine;
            }

            objs.Add(new Obj("Фонарик", "Вы взяли фонарик, он может понадобится, чтобы найти нужную табличку.", fon, 550, 330, 100, 160, 6));
        }

        public void SetGamer(Gamer g)
        {
            gamer = g;
        }

        public void SetForm(Form3 f)
        {
            f3 = f;
        }

        private void Form4_Paint(object sender, PaintEventArgs e)
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

        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
            bool flag = true;

            for (int i = 0; i < objs.Count; i++)
            {
                if (objs[i].Touch(e.X, e.Y) && objs[i].flag)
                {
                    if (gamer.invetory.Count == 5)
                    {
                        flag = false;
                        objs[i].flag = false;
                        gamer.AddObject(objs[i]);
                        gamer.notes.Add(objs[i].description);
                        button1.Visible = true;
                        break;
                    }

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

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gamer.sizex = 150;
            gamer.sizey = 200;
            gamer.x = 880;
            gamer.y = 400;
            f3.SetGamer(gamer);
            f3.Show();
            this.Hide();
        }
    }
}
