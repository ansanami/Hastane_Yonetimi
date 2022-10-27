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
    public partial class frmhastadetay : Form
    {
        public frmhastadetay()
        {
            InitializeComponent();
        }
        public string tc,adsoyad;
        private void label3_Click(object sender, EventArgs e)
        {

        }
        sqlbaglantısı bgl = new sqlbaglantısı();

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            SqlCommand komut3 = new SqlCommand("select doktorad,doktorsoyad from tbl_doktorlar where doktorbrans=@p1", bgl.baglantı()) ;
            komut3.Parameters.AddWithValue("@p1",cmbbrans.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbdoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            bgl.baglantı().Close();

           

        }

        private void cmbdoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Selecet * From tbl_randevu where randevubrans='"+ cmbbrans.Text + "'",bgl.baglantı());
            
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void lnkbilgidüzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmbılgıduzenle fr = new frmbılgıduzenle();
            fr.tc = label3.Text;
            fr.Show();
            
        }

        private void frmhastadetay_Load(object sender, EventArgs e)
        {

            label3.Text = tc;
            SqlCommand komut = new SqlCommand("select hastaad,hastasoyad from tbl_hastalar where hastatc=@p1",bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", label3.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label4.Text = dr[0] +" "+ dr[1];
            }
            bgl.baglantı().Close();

            ////////////////////////////////////randevu gecmısı
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select *from tbl_randevu where hastatc="+tc,bgl.baglantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //////////////////////////////////// bransları cekme
            SqlCommand komut2 = new SqlCommand("select bransad from tbl_Branslar",bgl.baglantı());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0]);
               
            }
            bgl.baglantı().Close();

        }

    }
}
