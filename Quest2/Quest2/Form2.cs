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
    public partial class Form2 : Form
    {
        public Gamer gamer;
        static string way = System.IO.Directory.GetCurrentDirectory();
        Image image = Image.FromFile(way + @"/pic/Fon1.jpg");
        Image zabor = Image.FromFile(way + @"/pic/zabor.png");
        Image zabor1 = Image.FromFile(way + @"/pic/zabor1.png");

        Image zamok = Image.FromFile(way + @"/pic/zamok.png");
        Image vorona = Image.FromFile(way + @"/pic/Vor.png");
        Image kam = Image.FromFile(way + @"/pic/Kam.png");
        Image key = Image.FromFile(way + @"/pic/Key.png");

        Form1 f1;
        Form3 f3;
        int index = 0;

        List<Obj> mapobj = new List<Obj>();
        List<Obj> objs = new List<Obj>();
        

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(image, new Rectangle(0, 0, 1000, 600));
            for(int i = 0; i < mapobj.Count; i++)
            {
                if (mapobj[i].flag)
                {
                    mapobj[i].ObjDraw(e.Graphics);
                }
            }

            for(int i = 0; i < objs.Count; i++)
            {
                if (objs[i].flag)
                {
                    objs[i].ObjDraw(e.Graphics);
                }

            }

            gamer.DrawPlayer(e.Graphics);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            mapobj.Add(new Obj("zabor_1","Забор", zabor, 800, 400, 300, 200,1));
            mapobj.Add(new Obj("zabor_2", "Забор", zabor, 550, 400, 145, 200,1));
            mapobj.Add(new Obj("zabor1_1", "Вы распахнули ворота.", zabor1, 700, 350, 90, 250,2));

            objs.Add(new Obj("Камень", "Вы нашли камень. Самое то, чтобы спугнуть ворону.", kam, 300, 532, 40, 40,1));
            objs.Add(new Obj("Ворона", "Вы спугнули ворону, она выронила из лап ключ.", vorona, 780, 350, 70, 70,2));
            objs.Add(new Obj("Ключ", "Вы нашли ключ, наверное это он открывает ворота.", key, 810, 370, 20, 20,3));
            objs.Add(new Obj("Замок", "Вы сняли замок с ворот.", zamok, 720, 450, 50, 50,4));

            gamer.notes.Add("Вы открываете глаза и понимаете, что лежите на земле. Ночь.");
            gamer.notes.Add("К Вам приходит воспоминание, что вы попращались с жизнью.");
            gamer.notes.Add("Успокоившись, вы решаете добраться до своего последнего места.");
            gamer.notes.Add("Оглядевшись по сторонам, Вы обнаруживает, что рядом вход на кладбище, но ворота закрыты на ключ.");
            f3 = new Form3();
            f3.SetForm(this);

            textBox1.Text = "";
            for (int i = 0; i < gamer.notes.Count; i++)
            {
                textBox1.Text += gamer.notes[i] + Environment.NewLine;
            }
            Refresh();
        }

        public void SetGamer(Gamer g)
        {
            gamer = g;
        }

        public void SetForm1(Form1 f)
        {
            f1 = f;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {

            bool flag = true;

            for(int i = 0; i < objs.Count; i++)
            {
                if(objs[i].Touch(e.X,e.Y) && objs[i].flag)
                {
                    if(gamer.invetory.Count == 0 && objs[i].name == "Камень")
                    {
                        objs[i].flag = false;
                        flag = false;
                        gamer.AddObject(objs[i]);
                        gamer.notes.Add(objs[i].description);
                        break;
                    }

                    if (gamer.invetory.Count == 1 && gamer.GetObj(objs[0]) && gamer.invetory[0].name == "Камень")
                    {
                        objs[i].flag = false;
                        flag = false;
                        gamer.AddObject(objs[i]);
                        gamer.notes.Add(objs[i].description);
                        objs[2].y = 530;
                        gamer.notes.Add("Вы увидели как ключ упал на землю");
                        Refresh();
                        break;
                    }

                    if (gamer.invetory.Count == 2 && gamer.GetObj(objs[1]))
                    {
                        objs[i].flag = false;
                        flag = false;
                        gamer.AddObject(objs[i]);
                        gamer.notes.Add(objs[i].description);
                        break;

                    }

                    if (gamer.invetory.Count == 3 && gamer.GetObj(objs[1]))
                    {
                        objs[i].flag = false;
                        flag = false;
                        gamer.AddObject(objs[i]);
                        gamer.notes.Add(objs[i].description);
                        break;

                    }

                    
                }
            }

            for(int j =0; j < mapobj.Count; j++)
            {
                if (mapobj[j].Touch(e.X, e.Y) && mapobj[j].flag)
                {
                    
                    if(gamer.invetory.Count == 4 && gamer.GetObj(objs[3]) && mapobj[j].name == "zabor1_1")
                    {
                        flag = false;
                        mapobj[j].flag = false;
                        gamer.notes.Add(mapobj[j].description);
                    }

                    if (mapobj[2].flag == false)
                    {
                        button1.Visible = true;
                        
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

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            f3.SetGamer(gamer);
            gamer.x = 10; gamer.y = 400;
            f3.Show();
            this.Hide();
        }
    }
}
