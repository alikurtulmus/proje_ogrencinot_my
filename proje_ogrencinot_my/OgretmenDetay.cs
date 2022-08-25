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


namespace proje_ogrencinot_my
{
    public partial class OgretmenDetay : Form
    {
        public OgretmenDetay()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QBFPK40\\SQLEXPRESS;Initial Catalog=yb_ogrencinot;Integrated Security=True");


        private void OgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yb_ogrencinotDataSet.tablo' table. You can move, or remove it, as needed.
            this.tabloTableAdapter.Fill(this.yb_ogrencinotDataSet.tablo);

               
            
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("insert into tablo (ogrnumara,ograd,ogrsoyad) values (@p1,@p2,@p3)",baglanti);

            komut.Parameters.AddWithValue("@p1", mtxtno.Text);
            komut.Parameters.AddWithValue("@p2", txtad.Text);
            komut.Parameters.AddWithValue("@p3", txtsoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci kaydedildi..");
            this.tabloTableAdapter.Fill(this.yb_ogrencinotDataSet.tablo);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("update tablo set ogrs1=@p1,ogrs2=@p2,ogrs3=@p3,ortalama=@p5,durum=@p6 where ogrnumara=@p4", baglanti);

            komut.Parameters.AddWithValue("@p1", txt1.Text);
            komut.Parameters.AddWithValue("@p2", txt2.Text);
            komut.Parameters.AddWithValue("@p3", txt3.Text);
            komut.Parameters.AddWithValue("@p4", mtxtno.Text);
            komut.Parameters.AddWithValue("@p5", txtogrort.Text);
            komut.Parameters.AddWithValue("@p6", durum);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Not kaydedildi..");
            this.tabloTableAdapter.Fill(this.yb_ogrencinotDataSet.tablo);
        }
        public bool durum;


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            
            mtxtno.Text= dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtad.Text= dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtsoyad.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txt1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txt2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txt3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

            int sınav1;
            int sınav2;
            int sınav3;
            double ortalama;
           
            sınav1 = Convert.ToInt16(txt1.Text);
            sınav2 = Convert.ToInt16(txt2.Text);
            sınav3 = Convert.ToInt16(txt3.Text);
            ortalama = (sınav1 + sınav2 + sınav3) / 3;
            txtogrort.Text = ortalama.ToString();
           if(ortalama>50)
            {
                durum = true;
            }
            else { durum= false; }

           if(durum==true)
            { lbldurum.Text = "Geçti"; }
            else
            {
                lbldurum.Text = "Kaldı";
            }
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
