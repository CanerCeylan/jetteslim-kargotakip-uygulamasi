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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-9QEE2O0\SQLEXPRESS;Initial Catalog=DbKargoTakip;Integrated Security=True");

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            switch (guna2TextBox1.Text.ToLower())
            {
                case "admin":
                    if (guna2TextBox2.Text == "kargotakipadmin")
                    {
                        if (guna2ToggleSwitch1.Checked == true)
                        {
                            Properties.Settings.Default.username = guna2TextBox1.Text.ToLower();
                            Properties.Settings.Default.password = guna2TextBox2.Text;
                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                            Properties.Settings.Default.username = string.Empty;
                            Properties.Settings.Default.password = string.Empty;
                            Properties.Settings.Default.Save();
                        }

                        Form3 sayfa3 = new Form3();
                        sayfa3.Show();
                        this.Hide();
                    }
                    else
                    {
                        guna2MessageDialog1.Show();
                        guna2TextBox1.BorderColor = Color.Red;
                        guna2TextBox2.BorderColor = Color.Red;
                    }
                    break;

                default:
                    bool kayitMevcut = true;
                    
                    SqlCommand calisanAra = new SqlCommand("SELECT COUNT(*) FROM Çalışan WHERE çalışanEmail=@p1 AND çalışanAktif=1", baglanti);
                    calisanAra.Parameters.AddWithValue("@p1", guna2TextBox1.Text.ToLower());

                    SqlDataReader dr;

                    baglanti.Open();

                    dr = calisanAra.ExecuteReader();

                    while (dr.Read())
                    {
                        if((int)(dr[0]) == 0)
                        {
                            kayitMevcut = false;
                            break;
                        }
                    }
                    baglanti.Close();
                    
                    if (kayitMevcut == true)
                    {
                        string parola = string.Empty;

                        SqlCommand parolaGetir = new SqlCommand("SELECT çalışanParola FROM Çalışan WHERE çalışanEmail=@p1", baglanti);
                        parolaGetir.Parameters.AddWithValue("@p1", guna2TextBox1.Text.ToLower());

                        SqlDataReader dr1;

                        baglanti.Open();

                        dr1 = parolaGetir.ExecuteReader();

                        while (dr1.Read())
                        {
                            parola = (dr1["çalışanParola"]).ToString();
                        }
                        baglanti.Close();

                        if (parola == guna2TextBox2.Text)
                        {
                            if (guna2ToggleSwitch1.Checked == true)
                            {
                                Properties.Settings.Default.username = guna2TextBox1.Text.ToLower();
                                Properties.Settings.Default.password = guna2TextBox2.Text;
                                Properties.Settings.Default.Save();
                            }
                            else
                            {
                                Properties.Settings.Default.username = string.Empty;
                                Properties.Settings.Default.password = string.Empty;
                                Properties.Settings.Default.Save();
                            }

                            Properties.Settings.Default.email = guna2TextBox1.Text.ToLower();
                            Properties.Settings.Default.Save();

                            Form sayfa4 = new Form4();
                            sayfa4.Show();
                            this.Hide();
                        }
                        else
                        {
                            guna2MessageDialog1.Show();
                            guna2TextBox1.BorderColor = Color.Red;
                            guna2TextBox2.BorderColor = Color.Red;
                        }
                    }
                    else
                    {
                        guna2MessageDialog1.Show();
                        guna2TextBox1.BorderColor = Color.Red;
                        guna2TextBox2.BorderColor = Color.Red;
                    }
                    break;
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Form1 sayfa1 = new Form1();
            sayfa1.Show();
            this.Hide();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            guna2TextBox1.Text = Properties.Settings.Default.username;
            guna2TextBox2.Text = Properties.Settings.Default.password;

            if (Properties.Settings.Default.username == string.Empty)
            {
                guna2ToggleSwitch1.Checked = false;
            }
            else
            {
                guna2ToggleSwitch1.Checked = true;
            }
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
