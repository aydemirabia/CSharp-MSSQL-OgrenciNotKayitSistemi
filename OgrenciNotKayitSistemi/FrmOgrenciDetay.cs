using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OgrenciNotKayitSistemi
{
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }
        
        SqlConnection baglanti = new SqlConnection(@"Data Source=RABIA-AYDEMIR;Initial Catalog=OgrNotKayıtSistemi;Integrated Security=True");
        public String numara;

        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            lblNumara.Text = numara;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM tblogr where ogrNumara = @p1", baglanti);
            komut.Parameters.AddWithValue("@p1", lblNumara.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdsoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                lblSinav1.Text = dr[4].ToString();
                lblSinav2.Text = dr[5].ToString();
                lblSinav3.Text = dr[6].ToString();
                lblOrtalama.Text = dr[7].ToString();
                lblDurum.Text = dr[8].ToString();
            }
            baglanti.Close();

        }
    }
}
