using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex_3_
{
    public partial class Previsao : Form
    {
        public Previsao()
        {
            InitializeComponent();
        }
        private void Previsao_Load(object sender, EventArgs e)
        {

            Metodos.GiveNameLocal(label1);
            PrimeiroDia();
            SegundoDia();
            TerceiroDia();
            QuartoDia();
            QuintoDia();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        public void PrimeiroDia()
        {

            Metodos.GiveNameDate(label2, 0);
            Metodos.GiveNameTmin(label3, 0);
            label3.Text = label3.Text + "º";
            Metodos.GiveNameTmax(label4, 0);
            label4.Text = label4.Text + "º";
            Metodos.GiveNameWind(label5, 0);
            Metodos.GiveNamePrec(label6, 0);
            label6.Text = label6.Text + "%";

        }

        public void SegundoDia()
        {

            Metodos.GiveNameDate(label7, 1);
            Metodos.GiveNameTmin(label8, 1);
            label8.Text = label8.Text + "º";
            Metodos.GiveNameTmax(label9, 1);
            label4.Text = label4.Text + "º";
            Metodos.GiveNameWind(label10, 1);
            Metodos.GiveNamePrec(label11, 1);
            label11.Text = label11.Text + "%";

        }

        public void TerceiroDia()
        {

            Metodos.GiveNameDate(label12, 2);
            Metodos.GiveNameTmin(label13, 2);
            label13.Text = label13.Text + "º";
            Metodos.GiveNameTmax(label14, 2);
            label14.Text = label14.Text + "º";
            Metodos.GiveNameWind(label15, 2);
            Metodos.GiveNamePrec(label16, 2);
            label16.Text = label16.Text + "%";

        }

        public void QuartoDia()
        {

            Metodos.GiveNameDate(label17, 3);
            Metodos.GiveNameTmin(label18, 3);
            label18.Text = label18.Text + "º";
            Metodos.GiveNameTmax(label19, 3);
            label19.Text = label19.Text + "º";
            Metodos.GiveNameWind(label20, 3);
            Metodos.GiveNamePrec(label21, 3);
            label21.Text = label21.Text + "%";

        }

        public void QuintoDia()
        {

            Metodos.GiveNameDate(label22, 4);
            Metodos.GiveNameTmin(label23, 4);
            label23.Text = label23.Text + "º";
            Metodos.GiveNameTmax(label24, 4);
            label24.Text = label24.Text + "º";
            Metodos.GiveNameWind(label25, 4);
            Metodos.GiveNamePrec(label26, 4);
            label26.Text = label26.Text + "%";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 novoForm = new Form1();
            this.Hide();
            novoForm.ShowDialog();
            this.Close();
        }
    }
}
