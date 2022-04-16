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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Form2 Adding = new Form2();
        Form3 Video = new Form3();



        public void Switch(bool Main)
        {// для того чтобы показывать начальный график или меняться на главный график
            chart.Series["Chart"].Enabled = !Main ? true : false;
            chart.Series["MainChart"].Enabled = Main ? true : false;
            chart.ChartAreas["ChartArea1"].Visible = !Main ? true : false;
            chart.ChartAreas["ChartArea2"].Visible = Main ? true : false;
        }

        public void Form1_Load(object sender, EventArgs e)
        {// для рисования начального графика
            chart.ChartAreas["ChartArea2"].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            Adding.Cordi.Add(new Cordinates(0, -1));
            Adding.Cordi.Add(new Cordinates(-2, 1));
            Adding.Cordi.Add(new Cordinates(-1, 2));
            Adding.Cordi.Add(new Cordinates(0, 1));
            Adding.Cordi.Add(new Cordinates(1, 2));
            Adding.Cordi.Add(new Cordinates(2, 1));
            Adding.Cordi.Add(new Cordinates(0, -1));
            chart.ChartAreas["ChartArea1"].AxisX.Minimum = -4;
            chart.ChartAreas["ChartArea1"].AxisX.Maximum = 4;
            chart.Series["Chart"].Color = Color.HotPink;
            for (int i = 0; i < Adding.Cordi.Count(); i++)
            {
                chart.Series["Chart"].Points.AddXY(Adding.Cordi[i].X, Adding.Cordi[i].Y);
            }
            Adding.Cordi.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Switch(true);
            Adding.ShowDialog();
            chart.Series["MainChart"].Points.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Adding.Cordi.Count(); i++)
            {
                chart.Series["MainChart"].Points.AddXY(Adding.Cordi[i].X, Adding.Cordi[i].Y);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                chart.Series["MainChart"].Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
                chart.Series["MainChart"].Color = Color.Black;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                chart.Series["MainChart"].Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
                chart.Series["MainChart"].Color = Color.SeaGreen;
            }
            else
            {
                chart.Series["MainChart"].Palette = comboBox1.SelectedIndex == 2 ?
                System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen :
                System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Video.ShowDialog();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            chart.Series["MainChart"].BorderWidth = Convert.ToInt32(numericUpDown1.Value);
        }
    }
}
