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
    public partial class sekreterdetay : Form
    {
        public sekreterdetay()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        public string tc;
        sqlbaglantısı bgl = new sqlbaglantısı();
        private void sekreterdetay_Load(object sender, EventArgs e)
        {
            labeltc.Text = tc;

            SqlCommand cmd = new SqlCommand("select bransad from tbl_branslar",bgl.baglantı());
            SqlDataReader dr3 = cmd.ExecuteReader();
            while (dr3.Read())
            {
                cmbbrans.Items.Add(dr3[0]);
            }
            bgl.baglantı().Close();

            /////////////////
            
            
            
            
            ///
            SqlCommand komut = new SqlCommand("select sekreteradsoyad from tbl_sekreterler where sekretertc=@p1", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1",labeltc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                labeladsoyad.Text = dr[0].ToString();
            }
            bgl.baglantı().Close();


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select bransad from tbl_branslar ",bgl.baglantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglantı().Close();

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select (doktorad + ' ' + doktorsoyad) as 'doktorlar' ,doktorbrans from tbl_doktorlar",bgl.baglantı());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2; 
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into tbl_randevu (randevutarih,randevusaat,randevubrans,randevudoktor) values (@r1,@r2,@r3,@r4)",bgl.baglantı());
            komutkaydet.Parameters.AddWithValue("@r1",msktarih.Text);
            komutkaydet.Parameters.AddWithValue("@r2", msksaat.Text);
            komutkaydet.Parameters.AddWithValue("@r3", cmbbrans.Text);
            komutkaydet.Parameters.AddWithValue("@r4", cmbdoktor.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("randevu olusturuldu");
        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();
            SqlCommand cmd4= new SqlCommand("select doktorad,doktorsoyad from tbl_doktorlar where doktorbrans=@p1",bgl.baglantı());
            cmd4.Parameters.AddWithValue("@p1",cmbbrans.Text);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                cmbdoktor.Items.Add(dr4[0] + " " + dr4[1]);
            }
        }
    }
}
