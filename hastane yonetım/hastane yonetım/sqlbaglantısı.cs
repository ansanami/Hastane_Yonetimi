using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace hastane_yonetım
{
    class sqlbaglantısı
    {
        public SqlConnection baglantı()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-B899JMR;Initial Catalog=hastaneproje;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
