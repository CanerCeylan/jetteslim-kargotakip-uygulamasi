using kargotakip.Properties;
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
using Microsoft.SqlServer.Server;
using Guna.UI2.WinForms;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Net;
using System.Globalization;

namespace kargotakip
{
    public partial class Form3 : Form
    {
        public Form3()
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

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            guna2ImageButton2.Image = Resources.subesari;
            guna2ImageButton5.Image = Resources.subeyesileksi;
            guna2ImageButton3.Image = Resources.calisanyesil;
            guna2ImageButton4.Image = Resources.calisanyesileksi;

            guna2Panel3.BringToFront();
        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {
            guna2ImageButton2.Image = Resources.subeyesil;
            guna2ImageButton5.Image = Resources.subesarieksi;
            guna2ImageButton3.Image = Resources.calisanyesil;
            guna2ImageButton4.Image = Resources.calisanyesileksi;

            guna2Panel6.BringToFront();

        }

        private void guna2ImageButton3_Click_1(object sender, EventArgs e)
        {
            guna2ImageButton2.Image = Resources.subeyesil;
            guna2ImageButton5.Image = Resources.subeyesileksi;
            guna2ImageButton3.Image = Resources.calisansari;
            guna2ImageButton4.Image = Resources.calisanyesileksi;

            guna2Panel5.BringToFront();
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            guna2ImageButton2.Image = Resources.subeyesil;
            guna2ImageButton5.Image = Resources.subeyesileksi;
            guna2ImageButton3.Image = Resources.calisanyesil;
            guna2ImageButton4.Image = Resources.calisansarieksi;

            guna2Panel7.BringToFront();

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox2.SelectedIndex = -1;
            guna2ComboBox3.SelectedIndex = -1;

            guna2ComboBox2.Items.Clear();
            guna2ComboBox3.Items.Clear();

            guna2ComboBox2.Enabled = true;
            guna2ComboBox3.Enabled = false;

            guna2ComboBox1.BorderColor = ColorTranslator.FromHtml("#447270");

            SqlCommand komut = new SqlCommand("SELECT DISTINCT ilçe FROM Adres WHERE il=@p1 ORDER BY ilçe ASC", baglanti);
            komut.Parameters.AddWithValue("@p1", guna2ComboBox1.Text);

            SqlDataReader dr;

            baglanti.Open();

            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                guna2ComboBox2.Items.Add(dr["ilçe"]);
            }

            baglanti.Close();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT DISTINCT il FROM Adres ORDER BY il ASC", baglanti);

            SqlDataReader dr;

            baglanti.Open();

            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                guna2ComboBox1.Items.Add(dr["il"]);
                guna2ComboBox4.Items.Add(dr["il"]);
                guna2ComboBox9.Items.Add(dr["il"]);
                guna2ComboBox12.Items.Add(dr["il"]);
            }

            baglanti.Close();


            guna2Panel5.AutoScroll = false;
            guna2Panel5.HorizontalScroll.Maximum = 0;
            guna2Panel5.VerticalScroll.Visible = false;
            guna2Panel5.AutoScroll = true;

            //pozisyon doldurma
            guna2ComboBox7.Items.Add("Satış Görevlisi");
            guna2ComboBox7.Items.Add("Kurye");
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox3.SelectedIndex = -1;

            guna2ComboBox3.Items.Clear();

            guna2ComboBox3.Enabled = true;

            guna2ComboBox2.BorderColor = ColorTranslator.FromHtml("#447270");

            SqlCommand komut = new SqlCommand("SELECT Mahalle FROM Adres WHERE il=@p1 AND ilçe=@p2 ORDER BY Mahalle ASC", baglanti);
            komut.Parameters.AddWithValue("@p1", guna2ComboBox1.Text);
            komut.Parameters.AddWithValue("@p2", guna2ComboBox2.Text);

            SqlDataReader dr;

            baglanti.Open();

            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                guna2ComboBox3.Items.Add(dr["Mahalle"]);
            }

            baglanti.Close();
        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox3.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (TelefonFormatKontrol(guna2TextBox2.Text) == false)
            {
                label17.Visible = true;
                guna2TextBox2.BorderColor = Color.Red;
            }
            else
            {
                label17.Visible = false;
                guna2TextBox2.BorderColor = ColorTranslator.FromHtml("#447270");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int count = 0;

            if (TelefonFormatKontrol(guna2TextBox2.Text) == false)
            {
                label17.Visible = true;
                guna2TextBox2.BorderColor = Color.Red;
                count++;
            }
            if (guna2TextBox1.Text == string.Empty)
            {
                guna2TextBox1.BorderColor = Color.Red;
                count++;
            }
            if (guna2ComboBox1.Text == string.Empty)
            {
                guna2ComboBox1.BorderColor = Color.Red;
                count++;
            }
            if (guna2ComboBox2.Text == string.Empty)
            {
                guna2ComboBox2.BorderColor = Color.Red;
                count++;
            }
            if (guna2ComboBox3.Text == string.Empty)
            {
                guna2ComboBox3.BorderColor = Color.Red;
                count++;
            }
            if (guna2TextBox3.Text == string.Empty)
            {
                guna2TextBox3.BorderColor = Color.Red;
                count++;
            }
            if (guna2TextBox4.Text == string.Empty)
            {
                guna2TextBox4.BorderColor = Color.Red;
                count++;
            }

            if (count == 0)
            {
                bool kayitMevcutDegil = true;

                SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM Şube WHERE aktif=1 AND il=@p1 AND ilçe=@p2 AND telefon=@p3", baglanti);
                komut.Parameters.AddWithValue("@p1", guna2ComboBox1.Text);
                komut.Parameters.AddWithValue("@p2", guna2ComboBox2.Text);
                komut.Parameters.AddWithValue("@p3", guna2TextBox2.Text);

                SqlDataReader dr;

                baglanti.Open();

                dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    if ((int)(dr[0]) > 0)
                    {
                        kayitMevcutDegil = false;
                        break;
                    }
                }

                baglanti.Close();

                if (kayitMevcutDegil)
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO Şube (şubeAdı, telefon, il, ilçe, mahalle, sokak, binaNo, aktif) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, 1)", baglanti);
                    ekle.Parameters.AddWithValue("@p1", guna2TextBox1.Text);
                    ekle.Parameters.AddWithValue("@p2", guna2TextBox2.Text);
                    ekle.Parameters.AddWithValue("@p3", guna2ComboBox1.Text);
                    ekle.Parameters.AddWithValue("@p4", guna2ComboBox2.Text);
                    ekle.Parameters.AddWithValue("@p5", guna2ComboBox3.Text);
                    ekle.Parameters.AddWithValue("@p6", guna2TextBox3.Text);
                    ekle.Parameters.AddWithValue("@p7", guna2TextBox4.Text);

                    baglanti.Open();

                    ekle.ExecuteNonQuery();

                    baglanti.Close();



                    guna2TextBox1.Text = String.Empty;
                    guna2TextBox2.Text = String.Empty;
                    guna2ComboBox1.SelectedIndex = -1;
                    guna2ComboBox2.SelectedIndex = -1;
                    guna2ComboBox3.SelectedIndex = -1;
                    guna2TextBox3.Text = String.Empty;
                    guna2TextBox4.Text = String.Empty;

                    guna2ComboBox2.Enabled = false;
                    guna2ComboBox3.Enabled = false;

                    label17.Visible = false;
                    guna2TextBox2.BorderColor = ColorTranslator.FromHtml("#447270");

                    guna2MessageDialog3.Show();

                    Form3 sayfa3 = new Form3();
                    sayfa3.Show();
                    this.Hide();
                }
                else
                {
                    guna2MessageDialog1.Show();
                }

            }
            else
            {
                guna2MessageDialog2.Show();
            }

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox1.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox3.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox4.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            guna2Panel4.BringToFront();

            guna2ImageButton2.Image = Resources.subeyesil;
            guna2ImageButton5.Image = Resources.subeyesileksi;
            guna2ImageButton3.Image = Resources.calisanyesil;
            guna2ImageButton4.Image = Resources.calisanyesileksi;

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox8_Click(object sender, EventArgs e)
        {
        }

        private void guna2PictureBox8_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.username = string.Empty;
            Properties.Settings.Default.password = string.Empty;
            Properties.Settings.Default.Save();

            Form1 sayfa1 = new Form1();
            sayfa1.Show();
            this.Hide();
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            if (TelefonFormatKontrol(guna2TextBox5.Text) == false)
            {
                label19.Visible = true;
                guna2TextBox5.BorderColor = Color.Red;
            }
            else
            {
                label19.Visible = false;
                guna2TextBox5.BorderColor = ColorTranslator.FromHtml("#447270");
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox9.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2PictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox13_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox13.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
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

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox6.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2ImageButton6_Click(object sender, EventArgs e)
        {
            guna2TextBox12.BorderColor = ColorTranslator.FromHtml("#447270");
            label37.Visible = false;

            Random Rnd = new Random();

            string yeniParola = string.Empty;
            string karakterDizisi = "0123456789qwertyuıopğüasdfghjklşizxcvbnmöçQWERTYUIOPĞÜASDFGHJKLŞİZXCVBNMÖÇ.,:;/*-+-?#$%£!?-_";

            for (int i = 0; i < 10; i++)
            {
                int RandomSayi = Rnd.Next(92);
                yeniParola = yeniParola + karakterDizisi[RandomSayi];
            }

            guna2TextBox12.Text = yeniParola;
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            guna2DateTimePicker1.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2TextBox12_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox12.BorderColor = ColorTranslator.FromHtml("#447270");
            label37.Visible = false;

        }

        private void guna2TextBox11_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox11.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {
            if (EmailFormatKontrol(guna2TextBox10.Text) == false)
            {
                guna2TextBox10.BorderColor = Color.Red;
                label20.Visible = true;
            }
            else
            {
                guna2TextBox10.BorderColor = ColorTranslator.FromHtml("#447270");
                label20.Visible = false;
            }
        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox8.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox7.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (label41.Visible == true || guna2ComboBox8.Text == string.Empty)
            {
                guna2ComboBox8.BorderColor = Color.Red;
                count++;
            }
            if (TelefonFormatKontrol(guna2TextBox5.Text) == false)
            {
                label19.Visible = true;
                guna2TextBox5.BorderColor = Color.Red;
                count++;
            }
            if (EmailFormatKontrol(guna2TextBox10.Text) == false)
            {
                guna2TextBox10.BorderColor = Color.Red;
                label20.Visible = true;
                count++;
            }
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
                label37.Visible = true;
                guna2TextBox12.BorderColor = Color.Red;
                count++;
            }
            if (guna2ComboBox7.Text == string.Empty)
            {
                guna2ComboBox7.BorderColor = Color.Red;
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

            if (count == 0)
            {
                bool kayitMevcutDegil = true;

                SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM Çalışan WHERE çalışanAktif=1 AND (TCNo=@p1 OR çalışanEmail=@p2)", baglanti);
                komut.Parameters.AddWithValue("@p1", guna2TextBox11.Text);
                komut.Parameters.AddWithValue("@p2", guna2TextBox10.Text);

                SqlDataReader dr;

                baglanti.Open();

                dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    if ((int)(dr[0]) > 0)
                    {
                        kayitMevcutDegil = false;
                        break;
                    }
                }
                baglanti.Close();

                if (kayitMevcutDegil)
                {
                    try
                    {
                        //çalışana sisteme giriş bilgileri gönderiliyor

                        SmtpClient sc = new SmtpClient();

                        sc.Port = 587;
                        sc.Host = "smtp.outlook.com";
                        sc.EnableSsl = true;

                        string kime = guna2TextBox10.Text;
                        string konu = "Çalışan Sistem Girişi";
                        //string icerik = "Merhaba,\nBizimle çalışmaya başladığın için mutluyuz.\nAramıza hoşgeldin!\n\nSistem giriş bilgilerini aşağıda bulabilirsin.\n\n Sisteme Giriş Bilgileriniz\nÇalışan email adresi: " + guna2TextBox10.Text + "\nÇalışan parolası: " + guna2TextBox12.Text;

                        sc.Credentials = new NetworkCredential("jetteslim@outlook.com", "KargoTakipAdmin");
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("jetteslim@outlook.com", "jetteslim");
                        mail.To.Add(kime);

                        //mail.Attachments.Add(new Attachment(@"C:\Users\caner\source\repos\kargotakip\kargotakip\Resources\Banner.png"));

                        mail.Subject = konu;


                        //

                        string metin = "Merhaba! Bizimle çalışmaya başladığın için mutluyuz. Aramıza hoşgeldin! Sana sisteme giriş bilgilerini gönderdik. Çalışan email adresi: " + guna2TextBox10.Text + "Çalışan parola: " + guna2TextBox12.Text;
                        AlternateView plainView = AlternateView.CreateAlternateViewFromString(metin, null, "text/plain");

                        string metinHTML = "<img src=cid:companylogo> <h3>jetteslim'e HOŞGELDİN!</h3> <h4>Merhaba! Bizimle çalışmaya başladığın için mutluyuz. Aramıza hoşgeldin! Sana, sisteme giriş bilgilerini gönderdik.</h4> <p>Çalışan email adresi: " + guna2TextBox10.Text + "</p> <p>Çalışan parola: " + guna2TextBox12.Text + "</p>";
                        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(metinHTML, null, "text/html");

                        LinkedResource logo = new LinkedResource(@"C:\Users\caner\source\repos\kargotakip\kargotakip\Resources\Banner.png");



                        logo.ContentId = "companylogo";

                        htmlView.LinkedResources.Add(logo);

                        mail.AlternateViews.Add(plainView);

                        mail.AlternateViews.Add(htmlView);


                        //

                        mail.IsBodyHtml = true;
                        //mail.Body = icerik;

                        sc.Send(mail);


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
                        int subeId = Convert.ToInt32(gecici);

                        SqlCommand calisanEkle = new SqlCommand("INSERT INTO Çalışan (çalışanAd, çalışanSoyad, çalışanTelefon, çalışanEmail, TCNo, çalışanParola, doğumTarihi, pozisyon, çalışanİl, çalışanİlçe, çalışanMahalle, çalışanSokak, çalışanBinaNo, çalışanDaire, çalışanAktif, çalışanŞube) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @sube)", baglanti);
                        calisanEkle.Parameters.AddWithValue("@p1", guna2TextBox8.Text);
                        calisanEkle.Parameters.AddWithValue("@p2", guna2TextBox9.Text);
                        calisanEkle.Parameters.AddWithValue("@p3", guna2TextBox5.Text);
                        calisanEkle.Parameters.AddWithValue("@p4", guna2TextBox10.Text.ToLower());
                        calisanEkle.Parameters.AddWithValue("@p5", guna2TextBox11.Text);
                        calisanEkle.Parameters.AddWithValue("@p6", guna2TextBox12.Text);
                        calisanEkle.Parameters.AddWithValue("@p7", guna2DateTimePicker1.Text);
                        calisanEkle.Parameters.AddWithValue("@p8", guna2ComboBox7.Text);
                        calisanEkle.Parameters.AddWithValue("@p9", guna2ComboBox4.Text);
                        calisanEkle.Parameters.AddWithValue("@p10", guna2ComboBox5.Text);
                        calisanEkle.Parameters.AddWithValue("@p11", guna2ComboBox6.Text);
                        calisanEkle.Parameters.AddWithValue("@p12", guna2TextBox6.Text);
                        calisanEkle.Parameters.AddWithValue("@p13", guna2TextBox7.Text);
                        calisanEkle.Parameters.AddWithValue("@p14", guna2TextBox13.Text);
                        calisanEkle.Parameters.AddWithValue("@p15", 1);
                        calisanEkle.Parameters.AddWithValue("@sube", subeId);

                        baglanti.Open();

                        calisanEkle.ExecuteNonQuery();

                        baglanti.Close();




                        //messagebox ve düzeltmeler



                        guna2ComboBox8.SelectedIndex = -1;

                        guna2TextBox8.Text = string.Empty;
                        guna2TextBox9.Text = string.Empty;
                        guna2TextBox5.Text = string.Empty;
                        guna2TextBox10.Text = string.Empty;
                        guna2TextBox11.Text = string.Empty;
                        guna2TextBox12.Text = string.Empty;
                        guna2ComboBox7.SelectedIndex = -1;
                        guna2ComboBox4.SelectedIndex = -1;
                        guna2ComboBox5.SelectedIndex = -1;
                        guna2ComboBox6.SelectedIndex = -1;
                        guna2TextBox6.Text = string.Empty;
                        guna2TextBox7.Text = string.Empty;
                        guna2TextBox13.Text = string.Empty;

                        guna2ComboBox8.Enabled = false;

                        guna2ComboBox5.Enabled = false;
                        guna2ComboBox6.Enabled = false;

                        guna2TextBox5.BorderColor = ColorTranslator.FromHtml("#447270");
                        label19.Visible = false;
                        guna2TextBox10.BorderColor = ColorTranslator.FromHtml("#447270");
                        label20.Visible = false;

                        label41.Visible = false;

                        guna2MessageDialog6.Show();

                        Form3 sayfa3 = new Form3();
                        sayfa3.Show();
                        this.Hide();
                    }
                    catch (SmtpException ex)
                    {
                        guna2MessageDialog7.Show();
                        Console.WriteLine(ex.Message);
                        guna2TextBox10.BorderColor = Color.Red;
                        label20.Visible = true;
                    }

                }
                else
                {
                    guna2MessageDialog5.Show();
                }
            }
            else
            {
                guna2MessageDialog4.Show();
            }
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox7.BorderColor = ColorTranslator.FromHtml("#447270");
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


            guna2ComboBox6.Enabled = true;

            guna2ComboBox5.BorderColor = ColorTranslator.FromHtml("#447270");

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

            guna2ComboBox5.Enabled = true;
            guna2ComboBox6.Enabled = false;

            guna2ComboBox4.BorderColor = ColorTranslator.FromHtml("#447270");

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

            //Şube doldurma - Şehire göre getirir
            //çalışanŞube
            //guna2ComboBox8
            //label41

            guna2ComboBox8.Enabled = true;
            guna2ComboBox8.Items.Clear();
            guna2ComboBox8.SelectedIndex = -1;

            SqlCommand subeGetir = new SqlCommand("SELECT şubeId, şubeAdı, telefon FROM Şube WHERE il=@p1 AND aktif=1", baglanti);
            subeGetir.Parameters.AddWithValue("@p1", guna2ComboBox4.Text);

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
            sehirSube.Parameters.AddWithValue("@p1", guna2ComboBox4.Text);

            SqlDataReader dr2;

            baglanti.Open();

            dr2 = sehirSube.ExecuteReader();

            while (dr2.Read())
            {
                if ((int)(dr2[0]) == 0)
                {
                    label41.Visible = true;
                    break;
                }
                else
                {
                    label41.Visible = false;
                    break;
                }
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

        private void guna2ComboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox8.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2Panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2ImageButton7_Click(object sender, EventArgs e)
        {
            Form3 yenile = new Form3();
            yenile.Show();
            this.Hide();
        }

        private void guna2ComboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

            guna2ComboBox9.BorderColor = ColorTranslator.FromHtml("#447270");

            guna2ComboBox10.Enabled = true; // şube
            guna2ComboBox10.Items.Clear();
            guna2ComboBox10.SelectedIndex = -1;


            SqlCommand subeDoldur = new SqlCommand("SELECT * FROM Şube WHERE il=@il AND aktif=@aktif", baglanti);
            subeDoldur.Parameters.AddWithValue("@il", guna2ComboBox9.Text);
            subeDoldur.Parameters.AddWithValue("@aktif", 1);

            SqlDataReader dr;

            baglanti.Open();

            dr = subeDoldur.ExecuteReader();

            while (dr.Read())
            {
                string subeBilgi = (dr["şubeId"]).ToString() + ">" + dr["şubeAdı"] + ">" + dr["telefon"];

                guna2ComboBox10.Items.Add(subeBilgi);
            }
            baglanti.Close();



            if (guna2ComboBox10.Items.Count == 0)
            {
                label46.Visible = true;
            }
            else
            {
                label46.Visible = false;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            //guna2ComboBox9 - il
            //label46 - şube bulunamadı
            //guna2ComboBox10 - şube

            int count = 0;

            if (guna2ComboBox9.Text == string.Empty)
            {
                guna2ComboBox9.BorderColor = Color.Red;
                count++;
            }
            if (guna2ComboBox10.Text == string.Empty)
            {
                guna2ComboBox10.BorderColor = Color.Red;
                count++;
            }

            if (count == 0)
            {
                //doğru
                int indeks = guna2ComboBox10.Text.IndexOf(">");
                string subeId = guna2ComboBox10.Text.Substring(0, indeks);

                baglanti.Open();
                SqlCommand subeSil = new SqlCommand("UPDATE Şube SET aktif=0 WHERE şubeId=@şubeId", baglanti);
                subeSil.Parameters.AddWithValue("@şubeId", Convert.ToInt32(subeId));

                subeSil.ExecuteNonQuery();
                baglanti.Close();


                guna2MessageDialog8.Show();


                Form3 sayfa3 = new Form3();
                sayfa3.Show();
                this.Hide();

            }
            else
            {
                //yanlış
                guna2MessageDialog9.Show();
            }
        }

        private void guna2ComboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox10.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2ComboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {

            guna2ComboBox12.BorderColor = ColorTranslator.FromHtml("#447270");

            guna2ComboBox11.Enabled = true;
            guna2ComboBox11.Items.Clear();
            guna2ComboBox11.SelectedIndex = -1;

            guna2ComboBox13.Enabled = false;
            guna2ComboBox13.Items.Clear();
            guna2ComboBox13.SelectedIndex = -1;

            SqlCommand calisanSube = new SqlCommand("SELECT * FROM Şube WHERE il=@il", baglanti);
            calisanSube.Parameters.AddWithValue("@il", guna2ComboBox12.Text);

            SqlDataReader dr;

            baglanti.Open();

            dr = calisanSube.ExecuteReader();

            while (dr.Read())
            {
                if (Convert.ToBoolean(dr["aktif"]) == true)
                {
                    string subeBilgi = (dr["şubeId"]).ToString() + ">" + dr["şubeAdı"] + ">" + dr["telefon"] + ">" + "AKTİF";
                    guna2ComboBox11.Items.Add(subeBilgi);
                }
                else
                {
                    string subeBilgi = (dr["şubeId"]).ToString() + ">" + dr["şubeAdı"] + ">" + dr["telefon"] + ">" + "İNAKTİF";
                    guna2ComboBox11.Items.Add(subeBilgi);
                }
            }

            baglanti.Close();

            if (guna2ComboBox11.Items.Count == 0)
            {
                label49.Visible = true;
            }
            else
            {
                label49.Visible = false;
            }
        }

        private void guna2ComboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {

            guna2ComboBox11.BorderColor = ColorTranslator.FromHtml("#447270");

            guna2ComboBox13.Enabled = true;
            guna2ComboBox13.Items.Clear();
            guna2ComboBox13.SelectedIndex = -1;

            int indeks = guna2ComboBox11.Text.IndexOf(">");
            string subeId = guna2ComboBox11.Text.Substring(0, indeks);

            SqlCommand calisanGetir = new SqlCommand("SELECT * FROM Çalışan WHERE çalışanŞube=@çalışanŞube AND çalışanAktif=1", baglanti);
            calisanGetir.Parameters.AddWithValue("@çalışanŞube", Convert.ToInt32(subeId));

            SqlDataReader dr;

            baglanti.Open();

            dr = calisanGetir.ExecuteReader();

            while (dr.Read())
            {
                string calisanBilgi = (dr["çalışanId"]).ToString() + ">" + dr["çalışanAd"] + " " + dr["çalışanSoyad"];
                guna2ComboBox13.Items.Add(calisanBilgi);
            }
            baglanti.Close();

            if (guna2ComboBox13.Items.Count == 0)
            {
                label53.Visible = true;
            }
            else
            {
                label53.Visible = false;
            }
        }

        private void guna2ComboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox13.BorderColor = ColorTranslator.FromHtml("#447270");
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            //guna2ComboBox12 - il
            //guna2ComboBox11 - şube
            //guna2ComboBox13 - çalışan

            int count = 0;

            if (guna2ComboBox12.Text == string.Empty)
            {
                guna2ComboBox12.BorderColor = Color.Red;
                count++;
            }
            if (guna2ComboBox11.Text == string.Empty)
            {
                guna2ComboBox11.BorderColor = Color.Red;
                count++;
            }
            if (guna2ComboBox13.Text == string.Empty)
            {
                guna2ComboBox13.BorderColor = Color.Red;
                count++;
            }

            if (count == 0)
            {
                baglanti.Open();

                SqlCommand calisanSil = new SqlCommand("UPDATE Çalışan SET çalışanAktif=0 WHERE çalışanId=@çalışanId", baglanti);

                int indeks = guna2ComboBox13.Text.IndexOf(">");
                string calisanId = guna2ComboBox13.Text.Substring(0, indeks);

                calisanSil.Parameters.AddWithValue("@çalışanId", Convert.ToInt32(calisanId));

                calisanSil.ExecuteNonQuery();
                baglanti.Close();


                guna2MessageDialog10.Show(); // doğru

                Form3 sayfa3 = new Form3();
                sayfa3.Show();
                this.Hide();
            }
            else
            {
                guna2MessageDialog11.Show(); // yanlış
            }
        }
    }
}
