using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex_3_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Metodos.AddLocaisListbox(listBox1);
        }

        private void listBox1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Metodos.SelectLocal(listBox1.SelectedItem.ToString());
            Previsao novoform = new Previsao();
            this.Hide();
            novoform.ShowDialog();
            this.Close();
        }
    }
}
