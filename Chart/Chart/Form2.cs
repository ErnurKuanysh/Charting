using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chart
{
    public partial class Form2 : Form
    {

        public List<Cordinates> Cordi = new List<Cordinates>();//массив кординат

        public Form2()
        {
            InitializeComponent();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("X = " + numericUpDown1.Value + "  Y = " + numericUpDown2.Value); // Для показа данных введенных пользователем
            Cordi.Add(new Cordinates(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value))); // для добавления данных введенных пользователем в массив данных
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cordi.Clear(); // для очистки данных введенных пользователем
            listBox1.Items.Clear(); // для очистки данных массива
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
