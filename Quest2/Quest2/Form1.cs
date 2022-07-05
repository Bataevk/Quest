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
    public partial class Form1 : Form
    {
        static string way = System.IO.Directory.GetCurrentDirectory();
        Image image = Image.FromFile(way + @"\pic\Fon1.jpg");
        Gamer gamer;
        List<Obj> objs = new List<Obj>();
        Form2 f2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(image, new Rectangle(0, 0, 1000, 600));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            f2 = new Form2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                gamer = new Gamer(textBox1.Text, objs, 10, 400, 150, 200);
                f2.SetGamer(gamer);
                f2.Show();
                f2.SetForm1(this);
                this.Hide();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
