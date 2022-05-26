using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OgrenciNotKayitSistemi
{
    public partial class FrmOgrenciGiris : Form
    {
        public FrmOgrenciGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmOgrenciDetay frm = new FrmOgrenciDetay(); //Giriş butonuna bastıktan sonra OgrenciDetay sayfasına ulaşmaktır.
            frm.numara = maskedTextBox1.Text;
            frm.Show();
            this.Hide();
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(maskedTextBox1.Text == "1200" || maskedTextBox1.Text == "1300")
            {
                OgretmenDetay frm = new OgretmenDetay();
                frm.Show();
                this.Hide();
            }
        }
    }
}
