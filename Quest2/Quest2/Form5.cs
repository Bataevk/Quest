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
    public partial class Form5 : Form
    {
        static string way = System.IO.Directory.GetCurrentDirectory();
        Image image = Image.FromFile(way + @"/pic/Fon1.jpg");
        Form3 f3;
        Gamer gamer;

        Image zabor = Image.FromFile(way + @"/pic/zabor.png");
        Image mag = Image.FromFile(way + @"/pic/mag.png");
        


        List<Obj> mapobj = new List<Obj>();
        List<Obj> objs = new List<Obj>();

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            mapobj.Add(new Obj("Забор", "Забор.", zabor, 0, 400, 300, 200, 2));
            mapobj.Add(new Obj("Забор", "Забор.", zabor, 300, 400, 300, 200, 2));

            mapobj.Add(new Obj(gamer.name, "Надгробие, на табличке написано ваше имя.", mag, 650, 400, 150, 200, 2));
            mapobj.Add(new Obj(" ", "Надгробие, таблички с именем нет.", mag, 750, 400, 150, 200, 2));
            mapobj.Add(new Obj(" ", "Надгробие, таблички с именем нет.", mag, 850, 400, 150, 200, 2));

            textBox1.Text = "";
            for (int i = 0; i < gamer.notes.Count; i++)
            {
                textBox1.Text += gamer.notes[i] + Environment.NewLine;
            }
        }

        public void SetGamer(Gamer g)
        {
            gamer = g;
        }

        public void SetForm(Form3 f)
        {
            f3 = f;
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form5_Paint(object sender, PaintEventArgs e)
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

        private void Form5_MouseDown(object sender, MouseEventArgs e)
        {
            bool flag = true;

            bool finish = false;

            for (int i = 0; i < mapobj.Count; i++)
            {

                if (mapobj[i].Touch(e.X, e.Y) && gamer.invetory.Count != 6 && mapobj[i].name != "Забор")
                {
                    gamer.notes.Add("На улице очень темно, вы не можете разобрать надпись, которая написана на надгробии.");
                    gamer.notes.Add(" ");
                    flag = false;
                    break;
                }



                if (mapobj[i].Touch(e.X,e.Y) && gamer.invetory.Count == 6 && mapobj[i].name == gamer.name)
                {
                    gamer.notes.Add(mapobj[i].description);

                    flag = false;
                    finish = true;
                    break;
                    
                    
                }

                if (mapobj[i].Touch(e.X, e.Y) && gamer.invetory.Count == 6 && mapobj[i].name == " " && !finish)
                {
                    gamer.notes.Add(mapobj[i].description);


                    flag = false;
                    break;

                    
                }
            }

            if (finish)
            {
                gamer.notes.Add(" ");
                gamer.notes.Add("Вы нашли, то, что хотели, Вы начинаете раскапывать.");
                gamer.notes.Add("Во время копки, Вы понимаете, что засыпаете.");
                gamer.notes.Add("Вы заснули и упали с лопатой в руках.");

                gamer.notes.Add(" ");
                gamer.notes.Add("Через некоторое время Вы приходите в себя и понимаете, что Вы в больнице.");
                gamer.notes.Add("Свет слепит Вас. Вы понимаете, что это был сон.");

                mapobj[0].flag = false;
                mapobj[1].flag = false;
                mapobj[2].flag = false;
                mapobj[3].flag = false;
                mapobj[4].flag = false;

                flag = false;
                button2.Visible = false;
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
            gamer.x = 880; gamer.y = 400;
            gamer.sizex = 150; gamer.sizey = 200;
            f3.SetGamer(gamer);
            f3.Show();
            this.Hide();
        }
    }
}
