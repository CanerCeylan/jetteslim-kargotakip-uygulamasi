using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kargotakip
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-9QEE2O0\SQLEXPRESS;Initial Catalog=DbKargoTakip;Integrated Security=True");

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Form1 sayfa1 = new Form1();
            sayfa1.Show();
            this.Hide();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2RadialGauge1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            //guna2TextBox1 - kargo takip no
            //label2 - takip no - tip
            //label3 - gönderici
            //label17 - veriliş
            //label4 - çıkış şubesi
            //label5 - alıcı
            //label6 - son güncelleme
            //label7 - teslim şubesi

            //label1 - durum
            //guna2RadialGauge1 - ibre


            /*Kargoya verildi
             *Varış şubesine gönderildi
             *Varış şubesine teslim edildi
             *Varış şubesinde bekliyor
             *Dağıtıma çıktı
             *Teslim edilemedi - Dağıtım
             *Teslim edildi
             *Geri kabul edildi
             */
            bool mevcut = true;

            SqlCommand say = new SqlCommand("SELECT COUNT(*) FROM Gönderi WHERE kargoTakipNo=@takip", baglanti);
            say.Parameters.AddWithValue("@takip", guna2TextBox1.Text);

            SqlDataReader dr;

            baglanti.Open();

            dr = say.ExecuteReader();

            while (dr.Read())
            {
                if ((int)(dr[0]) == 0)
                {
                    //yanlış
                    guna2MessageDialog5.Show();
                    mevcut = false;
                    break;
                }
                else
                {
                    //doğru
                    guna2MessageDialog1.Show();
                    mevcut = true;
                    break;
                }
            }
            baglanti.Close();

            //içerik doldurma
            if (mevcut == true)
            {
                //var
                int varisId = 0;
                int cikisId = 0;

                SqlCommand kargoGetir = new SqlCommand("SELECT * FROM Gönderi WHERE kargoTakipNo=@takip", baglanti);
                kargoGetir.Parameters.AddWithValue("@takip", guna2TextBox1.Text.Trim());

                SqlDataReader getirDr;

                baglanti.Open();

                getirDr = kargoGetir.ExecuteReader();

                while (getirDr.Read())
                {
                    string şubedenTeslim = string.Empty;
                    if (Convert.ToBoolean(getirDr["şubedenTeslim"]) == true) //şubedenTeslim
                    {
                        şubedenTeslim = "Şubeden teslim";
                    }
                    else
                    {
                        şubedenTeslim = "Adrese teslim";
                    }
                    string alıcıÖdemeli = string.Empty;
                    if (Convert.ToBoolean(getirDr["alıcıÖdemeli"]) == true) //alıcıÖdemeli
                    {
                        alıcıÖdemeli = "Alıcı ödemeli";
                    }
                    else
                    {
                        alıcıÖdemeli = "Gönderici ödemeli";
                    }

                    label2.Text = guna2TextBox1.Text.Trim() + " - " + şubedenTeslim + "/" + alıcıÖdemeli;

                    label3.Text = getirDr["göndericiAdı"].ToString().Trim() + " " + getirDr["göndericiSoyadı"].ToString().Trim();
                    label17.Text = getirDr["girişTarihi"].ToString();

                    cikisId = Convert.ToInt32(getirDr["çıkışŞubeId"]);
                    label4.Text = getirDr["çıkışŞubeId"].ToString(); //aşağıda devam ediliyor

                    label5.Text = getirDr["alıcıAdı"].ToString().Trim() + " " + getirDr["alıcıSoyadı"].ToString().Trim();
                    label6.Text = getirDr["sonİşlemTarihi"].ToString();

                    varisId = Convert.ToInt32(getirDr["varışŞubeId"]);
                    label7.Text = getirDr["varışŞubeId"].ToString(); //aşağıda devam ediliyor

                    label1.Text = getirDr["durum"].ToString();
                }
                baglanti.Close();


                //varisId //cikisId
                SqlCommand subeGetir1 = new SqlCommand("SELECT * FROM Şube WHERE şubeId=@şubeV OR şubeId=@şubeC", baglanti);
                subeGetir1.Parameters.AddWithValue("@şubeV", varisId);
                subeGetir1.Parameters.AddWithValue("@şubeC", cikisId);

                SqlDataReader subedr1;

                baglanti.Open();

                subedr1 = subeGetir1.ExecuteReader();

                while (subedr1.Read())
                {
                    if (Convert.ToInt32(subedr1["şubeId"]) == varisId)
                    {
                        label7.Text = subedr1["şubeAdı"].ToString().Trim() + "/" + subedr1["il"].ToString().Trim();
                    }
                    else
                    {
                        label4.Text = subedr1["şubeAdı"].ToString().Trim() + "/" + subedr1["il"].ToString().Trim();
                    }
                }
                baglanti.Close();

                /*
                 * guna2RadialGauge1
                 */

                switch (label1.Text)
                {
                    case "Kargoya verildi":
                        label1.ForeColor = ColorTranslator.FromHtml("#447270");
                        guna2RadialGauge1.Value = 0;

                        break;
                    case "Varış şubesine gönderildi":
                        label1.ForeColor = ColorTranslator.FromHtml("#447270");
                        guna2RadialGauge1.Value = 25;

                        break;
                    case "Varış şubesine teslim edildi":
                        label1.ForeColor = ColorTranslator.FromHtml("#447270");
                        guna2RadialGauge1.Value = 50;

                        break;
                    case "Varış şubesinde bekliyor":
                        label1.ForeColor = ColorTranslator.FromHtml("#447270");
                        guna2RadialGauge1.Value = 50;

                        break;
                    case "Dağıtıma çıktı":
                        label1.ForeColor = ColorTranslator.FromHtml("#447270");
                        guna2RadialGauge1.Value = 75;

                        break;
                    case "Teslim edilemedi - Dağıtım":
                        label1.ForeColor = Color.Red;
                        guna2RadialGauge1.Value = 75;

                        break;
                    case "Teslim edildi":
                        label1.ForeColor = ColorTranslator.FromHtml("#447270");
                        guna2RadialGauge1.Value = 100;

                        break;
                    case "Geri kabul edildi":
                        label1.ForeColor = Color.Red;
                        guna2RadialGauge1.Value = 100;

                        break;
                    default:
                        break;
                }
            }
            else
            {
                //yok
                Form5 sayfa5 = new Form5();
                sayfa5.Show();
                this.Hide();
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
