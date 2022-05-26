using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OgrenciNotKayitSistemi
{
    public partial class OgretmenDetay : Form
    {
        public OgretmenDetay()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=RABIA-AYDEMIR;Initial Catalog=OgrNotKayıtSistemi;Integrated Security=True");

        private void OgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ogrNotKayıtSistemiDataSet.tblogr' table. You can move, or remove it, as needed.
            this.tblogrTableAdapter.Fill(this.ogrNotKayıtSistemiDataSet.tblogr);
            //bu komut otomatik doldurma komutudur.

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblogr (ogrNumara, ogrAd, ogrSoyad) values (@p1, @p2, @p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", mskNumara.Text);
            komut.Parameters.AddWithValue("@p2", txtogrAd.Text);
            komut.Parameters.AddWithValue("@p3", txtogrSoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Öğrenci Sisteme Kaydedildi.");

            //bu komut otomatik doldurma komutudur
            this.tblogrTableAdapter.Fill(this.ogrNotKayıtSistemiDataSet.tblogr);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            mskNumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtogrAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtogrSoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            txtSinav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtSinav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtSinav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            double ortalama, s1, s2, s3;
            s1 = Convert.ToDouble(txtSinav1.Text);
            s2 = Convert.ToDouble(txtSinav2.Text);
            s3 = Convert.ToDouble(txtSinav3.Text);

            string durum;

            ortalama = (s1 + s2 + s3) / 3;
            lblOrt.Text = ortalama.ToString();
            
            if(ortalama > 46)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }

            if(durum == "True")
            {
                lblGecenS.Text = "GEÇTİ";
                lblKalanS.Text = "-";
            }
            else
            {
                lblGecenS.Text = "-";
                lblKalanS.Text = "KALDI";
            }


            baglanti.Open();
            SqlCommand komut = new SqlCommand("update tblogr set ogrSinav1 = @p1, ogrSinav2 = @p2, ogrSinav3 = @p3, ortalama = @p4, durum = @p5 where ogrNumara = @p6", baglanti);
            komut.Parameters.AddWithValue("@p6", mskNumara.Text);
            komut.Parameters.AddWithValue("@p1", txtSinav1.Text);
            komut.Parameters.AddWithValue("@p2", txtSinav2.Text);
            komut.Parameters.AddWithValue("@p3", txtSinav3.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(lblOrt.Text));
            komut.Parameters.AddWithValue("@p5", durum);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Notları Güncellendi.");

            //bu komut otomatik doldurma komutudur
            this.tblogrTableAdapter.Fill(this.ogrNotKayıtSistemiDataSet.tblogr);
        }

        
    }
}
