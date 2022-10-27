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
    public partial class hastakayıt : Form
    {
        public hastakayıt()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgln = new sqlbaglantısı();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_hastalar(hastaad,hastasoyad,hastatc,hastatelefon,hastasifre,hastacinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6)",bgln.baglantı());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", msktc.Text);
            komut.Parameters.AddWithValue("@p4", msktelefon.Text);
            komut.Parameters.AddWithValue("@p5", textBox2.Text);
            komut.Parameters.AddWithValue("@p6", cmbcınsıyet.Text);
            komut.ExecuteNonQuery();
            bgln.baglantı().Close();
            MessageBox.Show("kaydınız gerceklestı sıfrenız :" + textBox2.Text, "bilgi", MessageBoxButtons.OK);
        }
    }
}
