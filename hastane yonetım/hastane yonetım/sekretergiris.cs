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
    public partial class sekretergiris : Form
    {
        public sekretergiris()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgln = new sqlbaglantısı();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Select * From tbl_sekreterler where sekretertc=@p1 and sekretersifre=@p2", bgln.baglantı());
            komut2.Parameters.AddWithValue("@p1",msktc.Text);
            komut2.Parameters.AddWithValue("@p2",txtsıfre.Text);
            SqlDataReader dr = komut2.ExecuteReader();
            if(dr.Read())
            {
                sekreterdetay sd = new sekreterdetay();
                sd.tc = msktc.Text;
                sd.Show();
                this.Hide();
               
            }
            else
            {
                MessageBox.Show("tc sıfre yanlıs");
            }
            bgln.baglantı().Close();
        }
    }
}
