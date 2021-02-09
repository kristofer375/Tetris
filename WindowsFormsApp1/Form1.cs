using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Width = 240;
            dataGridView1.Height = 480;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Rows.Add(16);
            dataGridView1.ReadOnly = true;

            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;

            comboBox1.SelectedIndex = 0;

            dataGridView1 = Reset(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            int x = random.Next(0, 6);

            dataGridView1.ClearSelection();
            

            dataGridView1 = Start(dataGridView1, x, comboBox1.SelectedIndex);
            
            Application.DoEvents();
            Thread.Sleep(200);
            W_Dół(x, comboBox1.SelectedIndex);

        }
        private void dataGridView1_SelectionChanged(Object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        public Color Kolor(int x)
        {
            switch (x)
            {
                case 1:
                    return Color.Blue;
                case 2:
                    return Color.Green;
                case 3:
                    return Color.Yellow;
                case 4:
                    return Color.Purple;
                case 5:
                    return Color.Brown;
                default:
                    return Color.Red;
            }
        }
        public DataGridView Start(DataGridView dataGridView, int x, int index)
        {
            for (int i = x; i < x + 3; i++)
            {
                dataGridView.Rows[0].Cells[i].Style.BackColor = Kolor(index);
            }
            return dataGridView;
        }
        public DataGridView Reset(DataGridView dataGridView)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 16; j++)
                    dataGridView.Rows[j].Cells[i].Style.BackColor = Color.White;
            return dataGridView;
        }
        public void W_Dół(int x, int index)
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = x; j < x + 3; j++)
                {
                    if (dataGridView1.Rows[i+1].Cells[j].Style.BackColor == Color.White)
                    {

                    }
                    else
                        return;
                }
                for (int j = x; j < x + 3; j++)
                {
                    dataGridView1.Rows[i+1].Cells[j].Style.BackColor = Kolor(index);
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
                Application.DoEvents();
                Thread.Sleep(200);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reset(dataGridView1);
        }
    }
}
