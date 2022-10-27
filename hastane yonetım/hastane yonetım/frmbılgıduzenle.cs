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
namespace hastane_yonetım
{
    public partial class frmbılgıduzenle : Form
    {
        public frmbılgıduzenle()
        {
            InitializeComponent();
        }
        public string tc;
        sqlbaglantısı bgl = new sqlbaglantısı();
        private void frmbılgıduzenle_Load(object sender, EventArgs e)
        {
            msktc.Text = tc;
            SqlCommand komut = new SqlCommand("select * from tbl_hastalar where hastatc=@p1", bgl.baglantı()); ;
            komut.Parameters.AddWithValue("@p1",msktc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                msktelefon.Text = dr[4].ToString();
                textBox2.Text = dr[5].ToString();
                cmbcınsıyet.Text = dr[6].ToString();
            }
            bgl.baglantı();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update tbl_hastalar set hastaad=@p1,hastasoyad=@p2,hastatelefon=@p3,hastasifre=@p4,hastacinsiyet=@p5 where hastatc=@p6", bgl.baglantı());
            komut2.Parameters.AddWithValue("@p1",txtad.Text);
            komut2.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut2.Parameters.AddWithValue("@p3", msktelefon.Text);
            komut2.Parameters.AddWithValue("@p4", textBox2.Text);
            komut2.Parameters.AddWithValue("@p5", cmbcınsıyet.Text);
            komut2.Parameters.AddWithValue("@p6", msktc.Text);
            komut2.ExecuteNonQuery();
            bgl.baglantı();
            MessageBox.Show("bılgı guncellendı");

        }
    }
}
