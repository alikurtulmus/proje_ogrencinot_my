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
    public partial class OgrenciDetay : Form
    {
        public OgrenciDetay()
        {
            InitializeComponent();
        }
        public string numara;

        //Data Source=DESKTOP-QBFPK40\SQLEXPRESS;Initial Catalog=yb_ogrencinot;Integrated Security=True

        SqlConnection baglanti=new SqlConnection("Data Source=DESKTOP-QBFPK40\\SQLEXPRESS;Initial Catalog=yb_ogrencinot;Integrated Security=True");


        private void OgrenciDetay_Load(object sender, EventArgs e)
        {
            lblno.Text = numara;
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select*from tablo where ogrnumara=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                lblad.Text = dr[2].ToString() + " " + dr[3].ToString();
                lbl1.Text = dr[4].ToString();
                lbl2.Text = dr[5].ToString();
                lbl3.Text = dr[6].ToString();
                lblort.Text = dr[7].ToString();
                if (dr[8].ToString() == "True")
                {
                    lbldurum.Text = "Geçti";
                }
                else
                {
                    lbldurum.Text = "Kaldı";
                }
            }


        }
    }
}
