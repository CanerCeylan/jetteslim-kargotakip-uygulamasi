using Guna.UI2.WinForms;
using kargotakip.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kargotakip
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-9QEE2O0\SQLEXPRESS;Initial Catalog=DbKargoTakip;Integrated Security=True");

        public static bool TelefonFormatKontrol(string Telefon)
        {
            string RegexDesen = @"^(0(\d{10}))$";
            Match Eslesme = Regex.Match(Telefon, RegexDesen, RegexOptions.IgnoreCase);
            return Eslesme.Success;
        }

        public static bool EmailFormatKontrol(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string SqlDateFormatlama(string yil, string ay, string gun, string saat, string dakika)
        {
            //2007-05-08 12:35:00 formatında - smalldatetime
            string tempo = yil + "-" + ay + "-" + gun + " " + saat + ":" + dakika;

            return tempo;
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Form1 sayfa1 = new Form1();
            sayfa1.Show();
            this.Hide();
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            if (TelefonFormatKontrol(guna2TextBox5.Text) == true)
            {
                //doğru
                guna2TextBox5.BorderColor = ColorTranslator.FromHtml("#447270");
                label19.Visible = false;
            }
            else
            {
                //yanlış
                guna2TextBox5.BorderColor = Color.Red;
                label19.Visible = true;
            }
        }

        private void guna2TextBox13_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox13.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox7.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox6.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox6.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //guna2ComboBox4 -- il
            //guna2ComboBox5 -- ilçe
            //guna2ComboBox6 -- mahalle

            guna2ComboBox5.BorderColor = ColorTranslator.FromHtml("#447270");

            guna2ComboBox6.Enabled = true;

            guna2ComboBox6.Items.Clear();

            guna2ComboBox6.SelectedIndex = -1;

            SqlCommand komut = new SqlCommand("SELECT Mahalle FROM Adres WHERE il=@p1 AND ilçe=@p2 ORDER BY Mahalle ASC", baglanti);
            komut.Parameters.AddWithValue("@p1", guna2ComboBox4.Text);
            komut.Parameters.AddWithValue("@p2", guna2ComboBox5.Text);

            SqlDataReader dr;

            baglanti.Open();

            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                guna2ComboBox6.Items.Add(dr["Mahalle"]);
            }
            baglanti.Close();
        }

        private void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox4.BorderColor = ColorTranslator.FromHtml("#447270");

            guna2ComboBox5.Enabled = true;
            guna2ComboBox6.Enabled = false;

            guna2ComboBox5.Items.Clear();
            guna2ComboBox6.Items.Clear();

            guna2ComboBox5.SelectedIndex = -1;
            guna2ComboBox6.SelectedIndex = -1;

            SqlCommand komut = new SqlCommand("SELECT DISTINCT ilçe FROM Adres WHERE il=@p1 ORDER BY ilçe ASC", baglanti);
            komut.Parameters.AddWithValue("@p1", guna2ComboBox4.Text);

            SqlDataReader dr;

            baglanti.Open();

            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                guna2ComboBox5.Items.Add(dr["ilçe"]);
            }

            baglanti.Close();
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            guna2DateTimePicker1.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2TextBox11_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox11.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {
            if (EmailFormatKontrol(guna2TextBox10.Text) == true)
            {
                //doğru
                guna2TextBox10.BorderColor = ColorTranslator.FromHtml("#447270");
                label20.Visible = false;
            }
            else
            {
                //yanlış
                guna2TextBox10.BorderColor = Color.Red;
                label20.Visible = true;

            }
        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox9.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox8.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox8_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.username = string.Empty;
            Properties.Settings.Default.password = string.Empty;
            Properties.Settings.Default.Save();

            Form1 sayfa1 = new Form1();
            sayfa1.Show();
            this.Hide();
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            guna2Panel4.BringToFront();
            guna2ImageButton2.Image = Resources.giris1;
            guna2ImageButton5.Image = Resources.guncelle1;
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            guna2Panel5.BringToFront();
            guna2ImageButton2.Image = Resources.giris2;
            guna2ImageButton5.Image = Resources.guncelle1;
        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {
            guna2ImageButton5.Image = Resources.guncelle2;
            guna2ImageButton2.Image = Resources.giris1;
            guna2Panel3.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int count = 0;

            if (guna2TextBox8.Text == string.Empty)
            {
                guna2TextBox8.BorderColor = Color.Red;
                count++;
            }
            if (guna2TextBox9.Text == string.Empty)
            {
                guna2TextBox9.BorderColor = Color.Red;
                count++;
            }
            if (guna2TextBox11.Text == string.Empty)
            {
                guna2TextBox11.BorderColor = Color.Red;
                count++;
            }
            if (DateTime.Now.Year < guna2DateTimePicker1.Value.Year)
            {
                guna2DateTimePicker1.BorderColor = Color.Red;
                count++;
            }
            else if (DateTime.Now.Year == guna2DateTimePicker1.Value.Year)
            {
                if (DateTime.Now.Month < guna2DateTimePicker1.Value.Month)
                {
                    guna2DateTimePicker1.BorderColor = Color.Red;
                    count++;
                }
                else if (DateTime.Now.Month == guna2DateTimePicker1.Value.Month)
                {
                    if (DateTime.Now.Day <= guna2DateTimePicker1.Value.Day)
                    {
                        guna2DateTimePicker1.BorderColor = Color.Red;
                        count++;
                    }
                }
            }
            if (guna2ComboBox4.Text == string.Empty)
            {
                guna2ComboBox4.BorderColor = Color.Red;
                count++;
            }
            if (guna2ComboBox5.Text == string.Empty)
            {
                guna2ComboBox5.BorderColor = Color.Red;
                count++;
            }
            if (guna2ComboBox6.Text == string.Empty)
            {
                guna2ComboBox6.BorderColor = Color.Red;
                count++;
            }
            if (guna2TextBox12.Text == string.Empty)
            {
                guna2TextBox12.BorderColor = Color.Red;
                count++;
            }
            if (guna2TextBox4.Text == string.Empty)
            {
                guna2TextBox4.BorderColor = Color.Red;
                count++;
            }
            if (guna2TextBox2.Text == string.Empty)
            {
                guna2TextBox2.BorderColor = Color.Red;
                count++;
            }
            if (DateTime.Now.Year < guna2DateTimePicker2.Value.Year)
            {
                guna2DateTimePicker2.BorderColor = Color.Red;
                count++;
            }
            else if (DateTime.Now.Year == guna2DateTimePicker2.Value.Year)
            {
                if (DateTime.Now.Month < guna2DateTimePicker2.Value.Month)
                {
                    guna2DateTimePicker2.BorderColor = Color.Red;
                    count++;
                }
                else if (DateTime.Now.Month == guna2DateTimePicker2.Value.Month)
                {
                    if (DateTime.Now.Day <= guna2DateTimePicker2.Value.Day)
                    {
                        guna2DateTimePicker2.BorderColor = Color.Red;
                        count++;
                    }
                }
            }
            if (guna2ComboBox3.Text == string.Empty)
            {
                guna2ComboBox3.BorderColor = Color.Red;
                count++;
            }
            if (guna2ComboBox2.Text == string.Empty)
            {
                guna2ComboBox2.BorderColor = Color.Red;
                count++;
            }
            if (guna2ComboBox1.Text == string.Empty)
            {
                guna2ComboBox1.BorderColor = Color.Red;
                count++;
            }
            if (guna2ComboBox7.Text == string.Empty)
            {
                guna2ComboBox7.BorderColor = Color.Red;
                count++;
            }
            if (guna2TextBox18.Text == string.Empty)
            {
                guna2TextBox18.BorderColor = Color.Red;
                count++;
            }
            if (guna2TextBox19.Text == string.Empty)
            {
                guna2TextBox19.BorderColor = Color.Red;
                count++;
            }
            if (guna2TextBox17.Text == string.Empty)
            {
                guna2TextBox17.BorderColor = Color.Red;
                count++;
            }
            if (guna2TextBox21.Text == string.Empty)
            {
                guna2TextBox21.BorderColor = Color.Red;
                count++;
            }
            if (!TelefonFormatKontrol(guna2TextBox5.Text))
            {
                guna2TextBox5.BorderColor = Color.Red;
                label19.Visible = true;
                count++;
            }
            if (!EmailFormatKontrol(guna2TextBox10.Text))
            {
                guna2TextBox10.BorderColor = Color.Red;
                label20.Visible = true;
                count++;
            }
            if (guna2TextBox6.Text == string.Empty)
            {
                guna2TextBox6.BorderColor = Color.Red;
                count++;
            }
            if (guna2TextBox7.Text == string.Empty)
            {
                guna2TextBox7.BorderColor = Color.Red;
                count++;
            }
            if (guna2TextBox13.Text == string.Empty)
            {
                guna2TextBox13.BorderColor = Color.Red;
                count++;
            }
            if (!TelefonFormatKontrol(guna2TextBox16.Text))
            {
                guna2TextBox16.BorderColor = Color.Red;
                label37.Visible = true;
                count++;
            }
            if (!EmailFormatKontrol(guna2TextBox3.Text))
            {
                guna2TextBox3.BorderColor = Color.Red;
                label6.Visible = true;
                count++;
            }
            if (guna2TextBox15.Text == string.Empty)
            {
                guna2TextBox15.BorderColor = Color.Red;
                count++;
            }
            if (guna2TextBox14.Text == string.Empty)
            {
                guna2TextBox14.BorderColor = Color.Red;
                count++;
            }
            if (guna2TextBox1.Text == string.Empty)
            {
                guna2TextBox1.BorderColor = Color.Red;
                count++;
            }
            if (guna2ComboBox8.Text == string.Empty)
            {
                guna2ComboBox8.BorderColor = Color.Red;
                count++;
            }


            if (count == 0)
            {
                try
                {
                    //çalışan şubeId getiriliyor

                    int cSube = 0;

                    SqlCommand subeIdGetir = new SqlCommand("SELECT çalışanŞube FROM Çalışan WHERE çalışanEmail=@p", baglanti);
                    subeIdGetir.Parameters.AddWithValue("@p", Properties.Settings.Default.email);

                    SqlDataReader dr;

                    baglanti.Open();

                    dr = subeIdGetir.ExecuteReader();

                    while (dr.Read())
                    {
                        cSube = Convert.ToInt32(dr["çalışanŞube"]);
                        break;
                    }
                    baglanti.Close();

                    //takip no oluşturma
                    //StringUtils.leftPad("19", 5, "0");

                    string yil = DateTime.Now.Year.ToString();
                    string ay = DateTime.Now.Month.ToString();
                    string gun = DateTime.Now.Day.ToString();
                    string saat = DateTime.Now.Hour.ToString();
                    string dk = DateTime.Now.Minute.ToString();
                    string saniye = DateTime.Now.Second.ToString();

                    string tarih = SqlDateFormatlama(yil, ay, gun, saat, dk);

                    if (ay.Length == 1)
                    {
                        ay = "0" + ay;
                    }
                    if (gun.Length == 1)
                    {
                        gun = "0" + gun;
                    }
                    if (saat.Length == 1)
                    {
                        saat = "0" + saat;
                    }
                    if (dk.Length == 1)
                    {
                        dk = "0" + dk;
                    }
                    if (saniye.Length == 1)
                    {
                        saniye = "0" + saniye;
                    }

                    string takipNo = cSube.ToString() + yil + ay + gun + saat + dk + saniye;

                    //alıcı ve göndericiye mail gönderme
                    SmtpClient sc = new SmtpClient();

                    sc.Port = 587;
                    sc.Host = "smtp.outlook.com";
                    sc.EnableSsl = true;

                    string alıcı = guna2TextBox3.Text;
                    string gönderici = guna2TextBox10.Text;

                    string konu = "Kargonuz bize emanet!";

                    sc.Credentials = new NetworkCredential("jetteslim@outlook.com", "KargoTakipAdmin");
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("jetteslim@outlook.com", "jetteslim");

                    mail.To.Add(alıcı);
                    mail.To.Add(gönderici);

                    mail.Subject = konu;

                    string metin = "Merhaba! Bizi tercih ettiğiniz için teşekkürler! Kargonuz bize emanet ve en kısa sürede hedefine ulaşacaktır. Kargo bilgilerinizi iletmekten mutluluk duyarız... Kargo takip numaranız: " + takipNo + " İlgili kargo takip numarası ile, uygulamamız üzerinden kargonuzun durumunu öğrenebilirsiniz...";
                    AlternateView plainView = AlternateView.CreateAlternateViewFromString(metin, null, "text/plain");

                    string metinHTML = "<img src=cid:companylogo> <h3>Merhaba!</h3> <h4>Bizi tercih ettiğiniz için teşekkürler! Kargonuz bize emanet ve en kısa sürede hedefine ulaşacaktır. Kargo bilgilerinizi iletmekten mutluluk duyarız...</h4> <p>Kargo takip numaranız: " + takipNo + "</p> <p>İlgili kargo takip numarası ile, uygulamamız üzerinden kargonuzun durumunu öğrenebilirsiniz...</p>";
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(metinHTML, null, "text/html");

                    LinkedResource logo = new LinkedResource(@"C:\Users\caner\source\repos\kargotakip\kargotakip\Resources\Banner2.png");

                    logo.ContentId = "companylogo";

                    htmlView.LinkedResources.Add(logo);

                    mail.AlternateViews.Add(plainView);

                    mail.AlternateViews.Add(htmlView);


                    //

                    mail.IsBodyHtml = true;
                    //mail.Body = icerik;

                    sc.Send(mail);


                    /*
                    @kargoTakipNo
                    @göndericiAdı
                    @göndericiSoyadı
                    @göndericiTC
                    @göndericiDoğum
                    @göndericiTelefon
                    @göndericiEmail
                    @göndericiİl
                    @göndericiİlçe
                    @göndericiMahalle
                    @göndericiSokak
                    @göndericiBinaNo
                    @göndericiDaire
                    @alıcıAdı
                    @alıcıSoyadı
                    @alıcıTC
                    @alıcıDoğum
                    @alıcıTelefon
                    @alıcıEmail
                    @alıcıİl
                    @alıcıİlçe
                    @alıcıMahalle
                    @alıcıSokak
                    @alıcıBinaNo
                    @alıcıDaire
                    @çıkışŞubeId
                    @varışŞubeId
                    @şubedenTeslim
                    @alıcıÖdemeli
                    @ücret
                    @girişTarihi
                    @sonİşlemTarihi
                    @durum
                    @kuryeId
                    @geriKabul
                    @aktif 
                    */

                    //varış şube id ayıklama
                    int indeks = 0;

                    for (int i = 0; i < guna2ComboBox8.Text.Length; i++)
                    {
                        if (guna2ComboBox8.Text[i] == '>')
                        {
                            indeks = i;
                            break;
                        }
                    }
                    string gecici = (guna2ComboBox8.Text).Substring(0, indeks);
                    int varisSubeIdCombo = Convert.ToInt32(gecici);

                    //giriş
                    SqlCommand komut = new SqlCommand("INSERT INTO Gönderi VALUES (@kargoTakipNo, @göndericiAdı, @göndericiSoyadı, @göndericiTC, @göndericiDoğum, @göndericiTelefon, @göndericiEmail, @göndericiİl, @göndericiİlçe, @göndericiMahalle, @göndericiSokak, @göndericiBinaNo, @göndericiDaire, @alıcıAdı, @alıcıSoyadı, @alıcıTC, @alıcıDoğum, @alıcıTelefon, @alıcıEmail, @alıcıİl, @alıcıİlçe, @alıcıMahalle, @alıcıSokak, @alıcıBinaNo, @alıcıDaire, @çıkışŞubeId, @varışŞubeId, @şubedenTeslim, @alıcıÖdemeli, @ücret, @girişTarihi, @sonİşlemTarihi, @durum, @kuryeId, @geriKabul, @aktif)", baglanti);
                    komut.Parameters.AddWithValue("@kargoTakipNo", takipNo);
                    komut.Parameters.AddWithValue("@göndericiAdı", guna2TextBox8.Text);
                    komut.Parameters.AddWithValue("@göndericiSoyadı", guna2TextBox9.Text);
                    komut.Parameters.AddWithValue("@göndericiTC", guna2TextBox11.Text);
                    komut.Parameters.AddWithValue("@göndericiDoğum", guna2DateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@göndericiTelefon", guna2TextBox5.Text);
                    komut.Parameters.AddWithValue("@göndericiEmail", guna2TextBox10.Text);
                    komut.Parameters.AddWithValue("@göndericiİl", guna2ComboBox4.Text);
                    komut.Parameters.AddWithValue("@göndericiİlçe", guna2ComboBox5.Text);
                    komut.Parameters.AddWithValue("@göndericiMahalle", guna2ComboBox6.Text);
                    komut.Parameters.AddWithValue("@göndericiSokak", guna2TextBox6.Text);
                    komut.Parameters.AddWithValue("@göndericiBinaNo", guna2TextBox7.Text);
                    komut.Parameters.AddWithValue("@göndericiDaire", guna2TextBox13.Text);
                    komut.Parameters.AddWithValue("@alıcıAdı", guna2TextBox12.Text);
                    komut.Parameters.AddWithValue("@alıcıSoyadı", guna2TextBox4.Text);
                    komut.Parameters.AddWithValue("@alıcıTC", guna2TextBox2.Text);
                    komut.Parameters.AddWithValue("@alıcıDoğum", guna2DateTimePicker2.Text);
                    komut.Parameters.AddWithValue("@alıcıTelefon", guna2TextBox16.Text);
                    komut.Parameters.AddWithValue("@alıcıEmail", guna2TextBox3.Text);
                    komut.Parameters.AddWithValue("@alıcıİl", guna2ComboBox3.Text);
                    komut.Parameters.AddWithValue("@alıcıİlçe", guna2ComboBox2.Text);
                    komut.Parameters.AddWithValue("@alıcıMahalle", guna2ComboBox1.Text);
                    komut.Parameters.AddWithValue("@alıcıSokak", guna2TextBox15.Text);
                    komut.Parameters.AddWithValue("@alıcıBinaNo", guna2TextBox14.Text);
                    komut.Parameters.AddWithValue("@alıcıDaire", guna2TextBox1.Text);
                    komut.Parameters.AddWithValue("@çıkışŞubeId", cSube);
                    komut.Parameters.AddWithValue("@varışŞubeId", varisSubeIdCombo);
                    if (guna2CheckBox1.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@şubedenTeslim", 1);
                    }
                    else
                    {
                        komut.Parameters.AddWithValue("@şubedenTeslim", 0);
                    }
                    if (guna2CheckBox2.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@alıcıÖdemeli", 1);
                    }
                    else
                    {
                        komut.Parameters.AddWithValue("@alıcıÖdemeli", 0);
                    }
                    komut.Parameters.AddWithValue("@ücret", label47.Text);
                    komut.Parameters.AddWithValue("@girişTarihi", tarih);
                    komut.Parameters.AddWithValue("@sonİşlemTarihi", tarih);
                    komut.Parameters.AddWithValue("@durum", "Kargoya verildi");
                    komut.Parameters.AddWithValue("@kuryeId", DBNull.Value);
                    komut.Parameters.AddWithValue("@geriKabul", 0);
                    komut.Parameters.AddWithValue("@aktif", 1);

                    baglanti.Open();

                    komut.ExecuteNonQuery();

                    baglanti.Close();

                    //düzeltmeler ve messagebox

                    

                    guna2TextBox8.Text = string.Empty;
                    guna2TextBox9.Text = string.Empty;
                    guna2TextBox11.Text = string.Empty;
                    guna2ComboBox4.SelectedIndex = -1;
                    guna2ComboBox5.SelectedIndex = -1;
                    guna2ComboBox6.SelectedIndex = -1;
                    guna2TextBox12.Text = string.Empty;
                    guna2TextBox4.Text = string.Empty;
                    guna2TextBox2.Text = string.Empty;
                    guna2ComboBox3.SelectedIndex = -1;
                    guna2ComboBox2.SelectedIndex = -1;
                    guna2ComboBox1.SelectedIndex = -1;
                    guna2ComboBox7.SelectedIndex = -1;
                    guna2TextBox18.Text = string.Empty;
                    guna2TextBox19.Text = string.Empty;
                    guna2TextBox17.Text = string.Empty;
                    guna2TextBox21.Text = string.Empty;
                    guna2TextBox5.Text = string.Empty;
                    guna2TextBox10.Text = string.Empty;
                    guna2TextBox6.Text = string.Empty;
                    guna2TextBox7.Text = string.Empty;
                    guna2TextBox13.Text = string.Empty;
                    guna2TextBox16.Text = string.Empty;
                    guna2TextBox3.Text = string.Empty;
                    guna2TextBox15.Text = string.Empty;
                    guna2TextBox14.Text = string.Empty;
                    guna2TextBox1.Text = string.Empty;
                    guna2ComboBox8.SelectedIndex = -1;

                    guna2TextBox5.BorderColor = ColorTranslator.FromHtml("#447270");
                    label19.Visible = false;

                    guna2TextBox10.BorderColor = ColorTranslator.FromHtml("#447270");
                    label20.Visible = false;

                    guna2TextBox16.BorderColor = ColorTranslator.FromHtml("#447270");
                    label37.Visible = false;

                    guna2TextBox3.BorderColor = ColorTranslator.FromHtml("#447270");
                    label6.Visible = false;

                    label59.Visible = false;
                    guna2ComboBox8.BorderColor = ColorTranslator.FromHtml("#447270");

                    guna2CheckBox1.Checked = false;
                    guna2CheckBox2.Checked = false;


                    guna2ComboBox8.Enabled = false;
                    guna2ComboBox5.Enabled = false;
                    guna2ComboBox6.Enabled = false;
                    guna2ComboBox2.Enabled = false;
                    guna2ComboBox1.Enabled = false;


                    label52.Text = "0";
                    label51.Text = "0";
                    label50.Text = "0";
                    label49.Text = "0";
                    label48.Text = "0";
                    label47.Text = "0";

                    guna2MessageDialog1.Show();

                    Form4 sayfa4 = new Form4();
                    sayfa4.Show();
                    this.Hide();
                }
                catch (SmtpException ex)
                {
                    Console.WriteLine(ex.Message);
                    guna2MessageDialog4.Show();
                }
            }
            else
            {
                guna2MessageDialog2.Show();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT DISTINCT il FROM Adres ORDER BY il ASC", baglanti);

            SqlDataReader dr;

            baglanti.Open();

            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                guna2ComboBox4.Items.Add(dr["il"]);
                guna2ComboBox3.Items.Add(dr["il"]);
                guna2ComboBox7.Items.Add(dr["il"]);
            }

            baglanti.Close();

            //çalışan bilgi getirme

            //label63 - çalışan id - çalışanId ++
            //label65 - çalışan adı - çalışanAd ++ 
            //label66 - çalışan soyadı - çalışanSoyad ++
            //label61 - çalışan email - çalışanEmail ++
            //label62 - çalışan şube - şubeAdı ++
            //label67 - çalışan şubesi ili - il ++
            //label64 - çalışan pozisyon - pozisyon ++
            //label68 - çalışan şube id - çalışanŞube ++

            label61.Text = Properties.Settings.Default.email;

            SqlCommand calisanGetir = new SqlCommand("SELECT çalışanId, çalışanAd, çalışanSoyad, pozisyon, çalışanŞube FROM Çalışan WHERE çalışanEmail=@email", baglanti);
            calisanGetir.Parameters.AddWithValue("@email", Properties.Settings.Default.email);

            SqlDataReader cdr;

            baglanti.Open();

            cdr = calisanGetir.ExecuteReader();

            while (cdr.Read())
            {
                label63.Text = cdr["çalışanId"].ToString();
                label65.Text = cdr["çalışanAd"].ToString();
                label66.Text = cdr["çalışanSoyad"].ToString();
                label64.Text = cdr["pozisyon"].ToString();
                label68.Text = cdr["çalışanŞube"].ToString();
            }
            baglanti.Close();


            SqlCommand calisanSubeGetir = new SqlCommand("SELECT şubeAdı, il FROM Şube WHERE şubeId=@şubeNo", baglanti);
            calisanSubeGetir.Parameters.AddWithValue("@şubeNo", Convert.ToInt32(label68.Text));

            SqlDataReader sdr;

            baglanti.Open();

            sdr = calisanSubeGetir.ExecuteReader();

            while (sdr.Read())
            {
                label62.Text = sdr["şubeAdı"].ToString();
                label67.Text = sdr["il"].ToString();
            }
            baglanti.Close();

            //çalışan paneli rollere göre bölme
            //"Satış Görevlisi"
            //"Kurye"

            if (label64.Text == "Kurye")
            {
                guna2ImageButton2.Visible = false;
                guna2Panel5.SendToBack();
                guna2ImageButton5.Location = new Point(12, 129);
                guna2PictureBox1.Location = new Point(4, 203);
            }


            //kargo güncelleme

            //anasayfa

            //label63 - çalışan id - çalışanId ++
            //label65 - çalışan adı - çalışanAd ++ 
            //label66 - çalışan soyadı - çalışanSoyad ++
            //label61 - çalışan email - çalışanEmail ++
            //label62 - çalışan şube - şubeAdı ++
            //label67 - çalışan şubesi ili - il ++
            //label64 - çalışan pozisyon - pozisyon ++
            //label68 - çalışan şube id - çalışanŞube ++

            //"Satış Görevlisi"
            //"Kurye"

            if (label64.Text == "Kurye")
            {
                SqlCommand kuryeKargo = new SqlCommand("SELECT kargoTakipNo FROM Gönderi WHERE şubedenTeslim=0 AND kuryeId=@kurye AND aktif=1 AND durum='Dağıtıma çıktı'", baglanti);
                kuryeKargo.Parameters.AddWithValue("@kurye", Convert.ToInt32(label63.Text));

                SqlDataReader kdr;

                baglanti.Open();

                kdr = kuryeKargo.ExecuteReader();

                while (kdr.Read())
                {
                    guna2ComboBox9.Items.Add(kdr["kargoTakipNo"]);
                }

                baglanti.Close();
            }
            else
            {
                SqlCommand sube1KargoGetir = new SqlCommand("SELECT kargoTakipNo FROM Gönderi WHERE ((çıkışŞubeId=@şubeIdsi AND durum='Kargoya verildi') OR (varışŞubeId=@şubeIdsi AND (durum='Varış şubesine gönderildi' OR durum='Varış şubesine teslim edildi' OR durum='Teslim edilemedi - Dağıtım'))) AND aktif=1", baglanti);
                sube1KargoGetir.Parameters.AddWithValue("@şubeIdsi", Convert.ToInt32(label68.Text));

                SqlDataReader skg1dr;

                baglanti.Open();

                skg1dr = sube1KargoGetir.ExecuteReader();

                while (skg1dr.Read())
                {
                    guna2ComboBox9.Items.Add(skg1dr["kargoTakipNo"]);
                }
                baglanti.Close();

                SqlCommand sube2KargoGetir = new SqlCommand("SELECT kargoTakipNo, sonİşlemTarihi FROM Gönderi WHERE varışŞubeId=@şubeIdsi AND durum='Varış şubesinde bekliyor' AND aktif=1", baglanti);
                sube2KargoGetir.Parameters.AddWithValue("@şubeIdsi", Convert.ToInt32(label68.Text));

                SqlDataReader skg2dr;

                baglanti.Open();

                skg2dr = sube2KargoGetir.ExecuteReader();

                while (skg2dr.Read())
                {
                    guna2ComboBox9.Items.Add(skg2dr["kargoTakipNo"]);
                }
                baglanti.Close();
            }

            if (label64.Text == "Kurye")
            {
                label78.Text = "Kuryeye Ait Gönderi*";
            }
            else
            {
                label78.Text = "Şubenize Ait Gönderi*";
            }

            if (guna2ComboBox9.Items.Count == 0)
            {
                label123.Visible = true;
                label123.Text = "İşlem yapabileceğiniz kargo bulunamadı!";
            }
            else
            {
                label123.Visible = false;
            }
        }

        private void guna2TextBox16_TextChanged(object sender, EventArgs e)
        {
            if (TelefonFormatKontrol(guna2TextBox16.Text) == true)
            {
                //doğru
                guna2TextBox16.BorderColor = ColorTranslator.FromHtml("#447270");
                label37.Visible = false;
            }
            else
            {
                //yanlış
                guna2TextBox16.BorderColor = Color.Red;
                label37.Visible = true;
            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (EmailFormatKontrol(guna2TextBox3.Text) == true)
            {
                //doğru
                guna2TextBox3.BorderColor = ColorTranslator.FromHtml("#447270");
                label6.Visible = false;
            }
            else
            {
                //yanlış
                guna2TextBox3.BorderColor = Color.Red;
                label6.Visible = true;
            }
        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox3.BorderColor = ColorTranslator.FromHtml("#447270");

            guna2ComboBox2.Enabled = true;
            guna2ComboBox1.Enabled = false;

            guna2ComboBox2.Items.Clear();
            guna2ComboBox1.Items.Clear();

            guna2ComboBox2.SelectedIndex = -1;
            guna2ComboBox1.SelectedIndex = -1;

            SqlCommand komut = new SqlCommand("SELECT DISTINCT ilçe FROM Adres WHERE il=@p1 ORDER BY ilçe ASC", baglanti);
            komut.Parameters.AddWithValue("@p1", guna2ComboBox3.Text);

            SqlDataReader dr;

            baglanti.Open();

            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                guna2ComboBox2.Items.Add(dr["ilçe"]);
            }
            baglanti.Close();

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //guna2ComboBox3 -- il
            //guna2ComboBox2 -- ilçe
            //guna2ComboBox1 -- mahalle

            guna2ComboBox2.BorderColor = ColorTranslator.FromHtml("#447270");

            guna2ComboBox1.Enabled = true;

            guna2ComboBox1.Items.Clear();

            guna2ComboBox1.SelectedIndex = -1;

            SqlCommand komut = new SqlCommand("SELECT Mahalle FROM Adres WHERE il=@p1 AND ilçe=@p2 ORDER BY Mahalle ASC", baglanti);
            komut.Parameters.AddWithValue("@p1", guna2ComboBox3.Text);
            komut.Parameters.AddWithValue("@p2", guna2ComboBox2.Text);

            SqlDataReader dr;

            baglanti.Open();

            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                guna2ComboBox1.Items.Add(dr["Mahalle"]);
            }

            baglanti.Close();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox1.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2ComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox8.Enabled = true;
            guna2ComboBox8.Items.Clear();
            guna2ComboBox8.SelectedIndex = -1;

            guna2ComboBox7.BorderColor = ColorTranslator.FromHtml("#447270");

            SqlCommand subeGetir = new SqlCommand("SELECT şubeId, şubeAdı, telefon FROM Şube WHERE il=@p1 AND aktif=1", baglanti);
            subeGetir.Parameters.AddWithValue("@p1", guna2ComboBox7.Text);

            SqlDataReader dr1;

            baglanti.Open();

            dr1 = subeGetir.ExecuteReader();

            while (dr1.Read())
            {
                string subeBilgi = (dr1["şubeId"]).ToString() + ">" + dr1["şubeAdı"] + ">" + dr1["telefon"];
                guna2ComboBox8.Items.Add(subeBilgi);
            }

            baglanti.Close();

            //

            SqlCommand sehirSube = new SqlCommand("SELECT COUNT(*) FROM Şube WHERE il=@p1 AND aktif=1", baglanti);
            sehirSube.Parameters.AddWithValue("@p1", guna2ComboBox7.Text);

            SqlDataReader dr2;

            baglanti.Open();

            dr2 = sehirSube.ExecuteReader();

            while (dr2.Read())
            {
                if ((int)(dr2[0]) == 0)
                {
                    label59.Visible = true;
                    break;
                }
                else
                {
                    label59.Visible = false;
                    break;
                }
            }

            baglanti.Close();
        }

        private void guna2ImageButton6_Click(object sender, EventArgs e)
        {
            //guna2TextBox18 -- en
            //guna2TextBox19 -- boy
            //guna2TextBox17 -- yükseklik

            //guna2TextBox21 -- kargo ağırlığı

            if (guna2TextBox18.Text != string.Empty && guna2TextBox19.Text != string.Empty && guna2TextBox17.Text != string.Empty && guna2TextBox21.Text != string.Empty)
            {
                double desi = Convert.ToDouble(guna2TextBox18.Text) * Convert.ToDouble(guna2TextBox19.Text) * Convert.ToDouble(guna2TextBox17.Text);
                desi = desi / 3000;

                double agirlik = Convert.ToDouble(guna2TextBox21.Text);

                double esas = 0;

                if (agirlik == desi)
                {
                    esas = agirlik;
                }
                else if (agirlik < desi)
                {
                    esas = desi;
                }
                else
                {
                    esas = agirlik;
                }

                double stb = esas * 30;

                double kdv = stb / 5;

                double toplamUcret = stb + kdv;

                //

                label52.Text = Math.Round(agirlik, 2).ToString(); //ağırlık
                label51.Text = Math.Round(desi, 2).ToString(); //desi
                label50.Text = Math.Round(esas, 2).ToString(); //esas
                label49.Text = Math.Round(stb, 2).ToString(); //stb
                label48.Text = Math.Round(kdv, 2).ToString(); //kdv
                label47.Text = Math.Round(toplamUcret, 2).ToString(); //toplam
            }
            else
            {
                if (guna2TextBox18.Text == string.Empty)
                {
                    guna2TextBox18.BorderColor = Color.Red;
                }
                if (guna2TextBox19.Text == string.Empty)
                {
                    guna2TextBox19.BorderColor = Color.Red;
                }
                if (guna2TextBox17.Text == string.Empty)
                {
                    guna2TextBox17.BorderColor = Color.Red;
                }
                if (guna2TextBox21.Text == string.Empty)
                {
                    guna2TextBox21.BorderColor = Color.Red;
                }
                guna2MessageDialog6.Show();
            }

        }

        private void guna2TextBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((guna2TextBox18).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void guna2TextBox19_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox19.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2TextBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((guna2TextBox19).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void guna2TextBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((guna2TextBox17).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void guna2TextBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((guna2TextBox21).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void guna2TextBox12_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox12.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox4.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox2.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            guna2DateTimePicker2.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2TextBox18_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox18.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2TextBox17_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox17.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2TextBox21_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox21.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2TextBox15_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox15.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2TextBox14_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox14.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox1.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2ComboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox8.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ComboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

            guna2ComboBox9.BorderColor = ColorTranslator.FromHtml("#447270");
            guna2ComboBox10.Enabled = true;
            guna2ComboBox10.Items.Clear();
            guna2ComboBox10.SelectedIndex = -1;

            guna2ComboBox11.Enabled = false;
            guna2ComboBox11.Items.Clear();
            guna2ComboBox11.SelectedIndex = -1;


            SqlCommand komut = new SqlCommand("SELECT göndericiAdı, göndericiSoyadı, göndericiTC, göndericiTelefon, göndericiEmail, göndericiİl, göndericiİlçe, göndericiMahalle, göndericiSokak, göndericiBinaNo, göndericiDaire, alıcıAdı, alıcıSoyadı, alıcıTC, alıcıTelefon, alıcıEmail, alıcıİl, alıcıİlçe, alıcıMahalle, alıcıSokak, alıcıBinaNo, alıcıDaire, çıkışŞubeId, varışŞubeId, şubedenTeslim, alıcıÖdemeli, ücret, girişTarihi, sonİşlemTarihi, durum, kuryeId, geriKabul, aktif FROM Gönderi WHERE kargoTakipNo=@takip", baglanti);
            komut.Parameters.AddWithValue("@takip", guna2ComboBox9.Text);

            SqlDataReader dr;

            baglanti.Open();

            dr = komut.ExecuteReader();

            //şubedenTeslim, alıcıÖdemeli
            //girişTarihi, sonİşlemTarihi

            while (dr.Read())
            {
                switch (dr["durum"])
                {
                    case ("Kargoya verildi"):
                        guna2ComboBox10.Items.Add("Varış şubesine gönderildi");
                        break;
                    case ("Varış şubesine gönderildi"):
                        guna2ComboBox10.Items.Add("Varış şubesine teslim edildi");
                        break;
                    case ("Varış şubesine teslim edildi"):
                        if (Convert.ToBoolean(dr["şubedenTeslim"]) == true)
                        {
                            guna2ComboBox10.Items.Add("Varış şubesinde bekliyor");
                        }
                        else
                        {
                            guna2ComboBox10.Items.Add("Dağıtıma çıktı");
                        }
                        break;
                    case ("Dağıtıma çıktı"):
                        guna2ComboBox10.Items.Add("Teslim edilemedi - Dağıtım");
                        guna2ComboBox10.Items.Add("Teslim edildi");
                        break;
                    case ("Teslim edilemedi - Dağıtım"):
                        guna2ComboBox10.Items.Add("Varış şubesinde bekliyor");
                        break;
                    case ("Varış şubesinde bekliyor"):

                        DateTime dateNow = DateTime.Now;
                        DateTime dateTime = Convert.ToDateTime(dr["sonİşlemTarihi"]);

                        TimeSpan ts = dateNow - dateTime;

                        if (ts.Days >= 7)
                        {
                            guna2ComboBox10.Items.Add("Geri kabul edildi");
                            guna2ComboBox10.Items.Add("Teslim edildi");
                        }
                        else
                        {
                            guna2ComboBox10.Items.Add("Teslim edildi");
                        }
                        break;
                    default:
                        break;
                }
                //bilgi alanlarını doldurma
                label106.Text = guna2ComboBox9.Text; //takip no
                label108.Text = dr["durum"].ToString(); //durum
                if (!Convert.ToBoolean(dr["alıcıÖdemeli"]))
                {
                    label111.Text = dr["ücret"].ToString() + " - Gönderici Ödemeli"; //ücret
                }
                else
                {
                    label111.Text = dr["ücret"].ToString() + " - Alıcı Ödemeli";
                }
                label120.Text = dr["çıkışŞubeId"].ToString();
                label99.Text = dr["göndericiAdı"].ToString();
                label98.Text = dr["göndericiSoyadı"].ToString();
                label95.Text = dr["göndericiTC"].ToString();
                label97.Text = dr["göndericiTelefon"].ToString();
                label96.Text = dr["göndericiEmail"].ToString();
                //gönderici adres
                label94.Text = (dr["göndericiMahalle"].ToString()).Trim() + " " + dr["göndericiSokak"].ToString() + " No: " + dr["göndericiBinaNo"].ToString() + " Daire: " + dr["göndericiDaire"].ToString() + " " + (dr["göndericiİlçe"].ToString()).Trim() + "/" + (dr["göndericiİl"].ToString()).Trim();//gön. adres

                label115.Text = dr["girişTarihi"].ToString();
                label116.Text = dr["sonİşlemTarihi"].ToString();
                if (Convert.ToBoolean(dr["geriKabul"]))
                {
                    label117.Text = "Geri kabul edildi";
                }
                else
                {
                    label117.Text = "-";
                }

                label121.Text = dr["varışŞubeId"].ToString();
                label105.Text = dr["alıcıAdı"].ToString();
                label104.Text = dr["alıcıSoyadı"].ToString();
                label101.Text = dr["alıcıTC"].ToString();
                label103.Text = dr["alıcıTelefon"].ToString();
                label102.Text = dr["alıcıEmail"].ToString();
                //alıcı adres
                label100.Text = (dr["alıcıMahalle"].ToString()).Trim() + " " + dr["alıcıSokak"].ToString() + " No: " + dr["alıcıBinaNo"].ToString() + " Daire: " + dr["alıcıDaire"].ToString() + " " + (dr["alıcıİlçe"].ToString()).Trim() + "/" + (dr["alıcıİl"].ToString()).Trim();
            }
            baglanti.Close();

            string cikisSube = label120.Text;

            string varisSube = label121.Text;//

            SqlCommand subeIdToAd = new SqlCommand("SELECT şubeAdı, telefon, il FROM Şube WHERE şubeId=@p", baglanti);
            subeIdToAd.Parameters.AddWithValue("@p", Convert.ToInt32(cikisSube));

            SqlDataReader ck;

            baglanti.Open();

            ck = subeIdToAd.ExecuteReader();

            while (ck.Read())
            {
                label120.Text = label120.Text + " - " + ck["şubeAdı"] + "/" + ck["il"];
            }
            baglanti.Close();

            SqlCommand subeIdToAd2 = new SqlCommand("SELECT şubeAdı, telefon, il FROM Şube WHERE şubeId=@p", baglanti);
            subeIdToAd2.Parameters.AddWithValue("@p", varisSube);

            SqlDataReader vr;

            baglanti.Open();

            vr = subeIdToAd2.ExecuteReader();

            while (vr.Read())
            {
                label121.Text = label121.Text + " - " + vr["şubeAdı"] + "/" + vr["il"];
            }
            baglanti.Close();

        }

        private void guna2ComboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            //guna2ComboBox11 - kurye
            //guna2ComboBox9 - kargoId

            guna2ComboBox10.BorderColor = ColorTranslator.FromHtml("#447270");

            guna2ComboBox11.Items.Clear();
            guna2ComboBox11.SelectedIndex = -1;

            if (guna2ComboBox10.Text == "Dağıtıma çıktı")
            {
                guna2ComboBox11.Enabled = true;

                SqlCommand kuryeDoldur = new SqlCommand("SELECT çalışanId, çalışanAd, çalışanSoyad FROM Çalışan WHERE pozisyon='Kurye' AND çalışanŞube=@çalışanŞubesi AND çalışanAktif=1", baglanti);
                kuryeDoldur.Parameters.AddWithValue("@çalışanŞubesi", Convert.ToInt32(label68.Text));

                SqlDataReader dr;

                baglanti.Open();

                dr = kuryeDoldur.ExecuteReader();

                while (dr.Read())
                {
                    guna2ComboBox11.Items.Add(dr["çalışanId"].ToString() + ">" + dr["çalışanAd"] + " " + dr["çalışanSoyad"]);
                }
                baglanti.Close();
            }
            else
            {
                guna2ComboBox11.Enabled = false;
            }
        }

        private void guna2ComboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox11.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label60_Click(object sender, EventArgs e)
        {

        }

        private void label59_Click(object sender, EventArgs e)
        {

        }

        private void label58_Click(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label68_Click(object sender, EventArgs e)
        {

        }

        private void label67_Click(object sender, EventArgs e)
        {

        }

        private void label66_Click(object sender, EventArgs e)
        {

        }

        private void label65_Click(object sender, EventArgs e)
        {

        }

        private void label64_Click(object sender, EventArgs e)
        {

        }

        private void label63_Click(object sender, EventArgs e)
        {

        }

        private void label62_Click(object sender, EventArgs e)
        {

        }

        private void label61_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label69_Click(object sender, EventArgs e)
        {

        }

        private void label70_Click(object sender, EventArgs e)
        {

        }

        private void label71_Click(object sender, EventArgs e)
        {

        }

        private void label72_Click(object sender, EventArgs e)
        {

        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void label74_Click(object sender, EventArgs e)
        {

        }

        private void label75_Click(object sender, EventArgs e)
        {

        }

        private void label76_Click(object sender, EventArgs e)
        {

        }

        private void label99_Click(object sender, EventArgs e)
        {

        }

        private void label77_Click(object sender, EventArgs e)
        {

        }

        private void label78_Click(object sender, EventArgs e)
        {

        }

        private void label79_Click(object sender, EventArgs e)
        {

        }

        private void label80_Click(object sender, EventArgs e)
        {

        }

        private void label81_Click(object sender, EventArgs e)
        {

        }

        private void label82_Click(object sender, EventArgs e)
        {

        }

        private void label83_Click(object sender, EventArgs e)
        {

        }

        private void label84_Click(object sender, EventArgs e)
        {

        }

        private void label85_Click(object sender, EventArgs e)
        {

        }

        private void label86_Click(object sender, EventArgs e)
        {

        }

        private void label87_Click(object sender, EventArgs e)
        {

        }

        private void label88_Click(object sender, EventArgs e)
        {

        }

        private void label89_Click(object sender, EventArgs e)
        {

        }

        private void label90_Click(object sender, EventArgs e)
        {

        }

        private void label91_Click(object sender, EventArgs e)
        {

        }

        private void label92_Click(object sender, EventArgs e)
        {

        }

        private void label93_Click(object sender, EventArgs e)
        {

        }

        private void label94_Click(object sender, EventArgs e)
        {

        }

        private void label95_Click(object sender, EventArgs e)
        {

        }

        private void label96_Click(object sender, EventArgs e)
        {

        }

        private void label97_Click(object sender, EventArgs e)
        {

        }

        private void label98_Click(object sender, EventArgs e)
        {

        }

        private void label100_Click(object sender, EventArgs e)
        {

        }

        private void label101_Click(object sender, EventArgs e)
        {

        }

        private void label102_Click(object sender, EventArgs e)
        {

        }

        private void label103_Click(object sender, EventArgs e)
        {

        }

        private void label104_Click(object sender, EventArgs e)
        {

        }

        private void label105_Click(object sender, EventArgs e)
        {

        }

        private void label106_Click(object sender, EventArgs e)
        {

        }

        private void label107_Click(object sender, EventArgs e)
        {

        }

        private void label108_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int count = 0;

            if (guna2ComboBox9.Text == string.Empty) //takip no combobox
            {
                guna2ComboBox9.BorderColor = Color.Red;
                count++;
            }
            if (guna2ComboBox10.Text == string.Empty) //yeni durum
            {
                guna2ComboBox10.BorderColor = Color.Red;
                count++;
            }
            else if (guna2ComboBox10.Text == "Dağıtıma çıktı")
            {
                if (guna2ComboBox11.Text == string.Empty) //kurye
                {
                    guna2ComboBox11.BorderColor = Color.Red;
                    count++;
                }
            }

            if (count == 0)
            {
                try
                {
                    int kuryeID = 0;
                    bool nullCont = false;

                    string alici = string.Empty;
                    string gonderici = string.Empty;
                    string takipEt = guna2ComboBox9.Text;

                    SqlCommand kuryeIdGetir = new SqlCommand("SELECT kuryeId, alıcıEmail, göndericiEmail FROM Gönderi WHERE kargoTakipNo=@takip", baglanti);
                    kuryeIdGetir.Parameters.AddWithValue("@takip", guna2ComboBox9.Text);

                    SqlDataReader dr;

                    baglanti.Open();

                    dr = kuryeIdGetir.ExecuteReader();

                    while (dr.Read())
                    {
                        if (dr["kuryeId"] == DBNull.Value)
                        {
                            nullCont = true;
                        }
                        else
                        {
                            nullCont = false;
                            kuryeID = Convert.ToInt32(dr["kuryeId"]);
                        }

                        alici = dr["alıcıEmail"].ToString();
                        gonderici = dr["göndericiEmail"].ToString();
                    }
                    baglanti.Close();

                    baglanti.Open();
                    SqlCommand kargoGuncelle = new SqlCommand("UPDATE Gönderi SET durum=@durum, kuryeId=@kurye, geriKabul=@geriK, aktif=@aktif, sonİşlemTarihi=@sonİşlemTarihi WHERE kargoTakipNo=@takip", baglanti);
                    kargoGuncelle.Parameters.AddWithValue("@takip", guna2ComboBox9.Text);
                    kargoGuncelle.Parameters.AddWithValue("@durum", guna2ComboBox10.Text);

                    string tarihNow = SqlDateFormatlama(DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), DateTime.Now.Hour.ToString(), DateTime.Now.Minute.ToString());

                    kargoGuncelle.Parameters.AddWithValue("@sonİşlemTarihi", tarihNow);

                    if (guna2ComboBox10.Text == "Geri kabul edildi")
                    {
                        kargoGuncelle.Parameters.AddWithValue("@geriK", 1);
                        kargoGuncelle.Parameters.AddWithValue("@aktif", 0);
                        if (nullCont == false)
                        {
                            kargoGuncelle.Parameters.AddWithValue("@kurye", kuryeID);
                        }
                        else
                        {
                            kargoGuncelle.Parameters.AddWithValue("@kurye", DBNull.Value);
                        }
                    }
                    else if (guna2ComboBox10.Text == "Teslim edildi")
                    {
                        kargoGuncelle.Parameters.AddWithValue("@aktif", 0);
                        if (nullCont == false)
                        {
                            kargoGuncelle.Parameters.AddWithValue("@kurye", kuryeID);
                        }
                        else
                        {
                            kargoGuncelle.Parameters.AddWithValue("@kurye", DBNull.Value);
                        }
                        kargoGuncelle.Parameters.AddWithValue("@geriK", 0);
                    }
                    else if (guna2ComboBox10.Text == "Dağıtıma çıktı")
                    {
                        string gecici = guna2ComboBox11.Text.Substring(0, guna2ComboBox11.Text.IndexOf(">"));

                        kargoGuncelle.Parameters.AddWithValue("@kurye", Convert.ToInt32(gecici));
                        kargoGuncelle.Parameters.AddWithValue("@geriK", 0);
                        kargoGuncelle.Parameters.AddWithValue("@aktif", 1);
                    }
                    else
                    {
                        if (nullCont == false)
                        {
                            kargoGuncelle.Parameters.AddWithValue("@kurye", kuryeID);
                        }
                        else
                        {
                            kargoGuncelle.Parameters.AddWithValue("@kurye", DBNull.Value);
                        }
                        kargoGuncelle.Parameters.AddWithValue("@aktif", 1);
                        kargoGuncelle.Parameters.AddWithValue("@geriK", 0);

                    }

                    // mail

                    if (guna2ComboBox10.Text == "Dağıtıma çıktı")
                    {
                        SmtpClient sc = new SmtpClient();

                        sc.Port = 587;
                        sc.Host = "smtp.outlook.com";
                        sc.EnableSsl = true;

                        string kime = alici;
                        string konu = "Kargonuz Dağıtıma Çıktı";

                        sc.Credentials = new NetworkCredential("jetteslim@outlook.com", "KargoTakipAdmin");
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("jetteslim@outlook.com", "jetteslim");
                        mail.To.Add(kime);

                        mail.Subject = konu;

                        string metin = "Merhaba! Bizi tercih ettiğiniz için teşekkürler. Kargonuz dağıtıma çıktı! Kargo takip numaranız: " + takipEt;
                        AlternateView plainView = AlternateView.CreateAlternateViewFromString(metin, null, "text/plain");

                        string metinHTML = "<img src=cid:companylogo> <h3>Merhaba!</h3> <h4>Bizi tercih ettiğiniz için teşekkürler.</h4> <p>Kargonuz dağıtıma çıktı!</p> <p>Kargo takip numaranız: " + takipEt + "</p>";
                        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(metinHTML, null, "text/html");

                        LinkedResource logo = new LinkedResource(@"C:\Users\caner\source\repos\kargotakip\kargotakip\Resources\dagitim.png");
                        logo.ContentId = "companylogo";

                        htmlView.LinkedResources.Add(logo);

                        mail.AlternateViews.Add(plainView);

                        mail.AlternateViews.Add(htmlView);


                        //

                        mail.IsBodyHtml = true;

                        sc.Send(mail);
                    }
                    else if (guna2ComboBox10.Text == "Varış şubesinde bekliyor")
                    {
                        SmtpClient sc = new SmtpClient();

                        sc.Port = 587;
                        sc.Host = "smtp.outlook.com";
                        sc.EnableSsl = true;

                        string kime = alici;
                        string konu = "Kargonuz Varış Şubesinde Bekliyor";

                        sc.Credentials = new NetworkCredential("jetteslim@outlook.com", "KargoTakipAdmin");
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("jetteslim@outlook.com", "jetteslim");
                        mail.To.Add(kime);

                        mail.Subject = konu;

                        string metin = "Merhaba! Bizi tercih ettiğiniz için teşekkürler. Kargonuz varış şubesinde bekliyor. Kargo takip numaranız: " + takipEt;
                        AlternateView plainView = AlternateView.CreateAlternateViewFromString(metin, null, "text/plain");

                        string metinHTML = "<img src=cid:companylogo> <h3>Merhaba!</h3> <h4>Bizi tercih ettiğiniz için teşekkürler.</h4> <p>Kargonuz varış şubesinde bekliyor.</p> <p>Kargo takip numaranız: " + takipEt + "</p>";
                        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(metinHTML, null, "text/html");

                        LinkedResource logo = new LinkedResource(@"C:\Users\caner\source\repos\kargotakip\kargotakip\Resources\subemizde.png");

                        logo.ContentId = "companylogo";

                        htmlView.LinkedResources.Add(logo);

                        mail.AlternateViews.Add(plainView);

                        mail.AlternateViews.Add(htmlView);

                        mail.IsBodyHtml = true;

                        sc.Send(mail);
                    }
                    else if (guna2ComboBox10.Text == "Teslim edilemedi - Dağıtım")
                    {
                        SmtpClient sc = new SmtpClient();

                        sc.Port = 587;
                        sc.Host = "smtp.outlook.com";
                        sc.EnableSsl = true;

                        string kime = alici;
                        string konu = "Kargonuz Dağıtımda Teslim Edilemedi";

                        sc.Credentials = new NetworkCredential("jetteslim@outlook.com", "KargoTakipAdmin");
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("jetteslim@outlook.com", "jetteslim");
                        mail.To.Add(kime);

                        mail.Subject = konu;

                        string metin = "Merhaba! Bizi tercih ettiğiniz için teşekkürler! Kargonuz dağıtım esnasında teslim edilemedi. Dilerseniz 7 gün içerisinde varış şubesinden alabilirsiniz. Kargo takip numaranız: " + takipEt;
                        AlternateView plainView = AlternateView.CreateAlternateViewFromString(metin, null, "text/plain");

                        string metinHTML = "<img src=cid:companylogo> <h3>Merhaba!</h3> <h4>Bizi tercih ettiğiniz için teşekkürler!</h4> <p>Kargonuz dağıtım esnasında teslim edilemedi. Dilerseniz 7 gün içerisinde varış şubesinden alabilirsiniz.</p> <p>Kargo takip numaranız: " + takipEt + "</p>";
                        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(metinHTML, null, "text/html");

                        LinkedResource logo = new LinkedResource(@"C:\Users\caner\source\repos\kargotakip\kargotakip\Resources\teslim.png");

                        logo.ContentId = "companylogo";

                        htmlView.LinkedResources.Add(logo);

                        mail.AlternateViews.Add(plainView);

                        mail.AlternateViews.Add(htmlView);

                        mail.IsBodyHtml = true;

                        sc.Send(mail);
                    }

                    // bitiş

                    kargoGuncelle.ExecuteNonQuery();
                    baglanti.Close();

                    //düzeltmeler ve messagebox

                    //guna2ComboBox9 - takip no
                    //guna2ComboBox10 - durum
                    //guna2ComboBox11 - kurye

                    guna2MessageDialog3.Show();

                    Form4 sayfa4 = new Form4();
                    sayfa4.Show();
                    this.Hide();
                }
                catch (SmtpException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                guna2MessageDialog5.Show();
            }
        }

        private void label109_Click(object sender, EventArgs e)
        {

        }

        private void label110_Click(object sender, EventArgs e)
        {

        }

        private void label111_Click(object sender, EventArgs e)
        {

        }

        private void label112_Click(object sender, EventArgs e)
        {

        }

        private void label115_Click(object sender, EventArgs e)
        {

        }

        private void label116_Click(object sender, EventArgs e)
        {

        }

        private void label113_Click(object sender, EventArgs e)
        {

        }

        private void label117_Click(object sender, EventArgs e)
        {

        }

        private void label114_Click(object sender, EventArgs e)
        {

        }

        private void label118_Click(object sender, EventArgs e)
        {

        }

        private void label119_Click(object sender, EventArgs e)
        {

        }

        private void label120_Click(object sender, EventArgs e)
        {

        }

        private void label121_Click(object sender, EventArgs e)
        {

        }

        private void label122_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            Form4 yenile = new Form4();
            yenile.Show();
            this.Hide();
        }
    }
}
