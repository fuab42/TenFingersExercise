using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication14
{
    public partial class Form1 : Form
    {

        public static int x;
        int t = 0;
        int y = 0;
        int u = 0;
        public Form1()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer3.Start();
            textBox3.Text = "";
            textBox2.Text = "";
            t = 0;
            y = 0;
            u = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < textBox2.Text.Length; i++)
            {
                string statik = textBox2.Text;
                string kelimeler = textBox1.Text;

                if (textBox1.Text.Length < textBox2.Text.Length)
                {
                    timer2.Stop();
                    timer1.Stop();
                    timer3.Stop();
                    MessageBox.Show("Yazım Alanına Girilen Değer Sayısı, Verilen Yazının Değer Sayısından Fazla!" + "\n" + "Lütfen 'BAŞLA' Butonuna Tıklayarak Yeniden Deneyin");
                    textBox2.Text = "";
                }
                else if (kelimeler[i] == statik[i])
                {
                    textBox3.Text += textBox2.Text[i].ToString();
                    x = textBox2.Text.Length;
                    timer2.Start();
                    timer1.Stop();
                }
                else
                {
                    textBox3.Text += textBox2.Text[i].ToString().ToUpper();
                    x = textBox2.Text.Length;
                    timer2.Start();
                    timer1.Stop();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int a;
            a = textBox2.Text.Length;
            if (textBox1.Text.Length == textBox2.Text.Length && textBox3.Text.Length == textBox2.Text.Length)
            {
                int z = textBox3.Text.Length;
                int p = 0;
                int c = 0;
                string zar = textBox3.Text;

                for (int k = 0; k < textBox3.Text.Length; k++)
                {

                    if (char.IsUpper(zar[k]))
                    {
                        p++;
                        c = ((p * 100) / z);
                    }

                }
                timer2.Stop();
                timer1.Stop();
                timer3.Stop();
                DialogResult Soru;


                Soru = MessageBox.Show(label4.Text + " süresinde " + p + " hata ile" + "(%" + c + ")" + " bitirdiniz." + "\n" + "Veri Tabanına Kaydetmek İster misiniz?", "Uyarı",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Soru == DialogResult.Yes)
                {
                    if (radioButton1.Checked == true)
                    {

                        string SehirAdi;
                        SehirAdi = label4.Text + " süresinde " + p + " hata ile" + "(%" + c + ")" + " bitirdiniz.";
                        String BaglantiYolu = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Fuab/Desktop/onparmak.accdb";
                        OleDbConnection Baglanti = new OleDbConnection(BaglantiYolu);
                        Baglanti.Open();
                        string Sorgu = "INSERT INTO kayit(harf) VALUES ('" + SehirAdi + "')";
                        OleDbCommand Komut = new OleDbCommand(Sorgu, Baglanti);
                        Komut.ExecuteNonQuery();
                        Baglanti.Close();
                    }
                    else if (radioButton2.Checked == true)
                    {

                        string SehirAdi;
                        SehirAdi = label4.Text + " süresinde " + p + " hata ile" + "(%" + c + ")" + " bitirdiniz.";
                        String BaglantiYolu = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Fuab/Desktop/onparmak.accdb";
                        OleDbConnection Baglanti = new OleDbConnection(BaglantiYolu);
                        Baglanti.Open();
                        string Sorgu = "INSERT INTO kayit(kelime) VALUES ('" + SehirAdi + "')";
                        OleDbCommand Komut = new OleDbCommand(Sorgu, Baglanti);
                        Komut.ExecuteNonQuery();
                        Baglanti.Close();
                    }
                    else if (radioButton3.Checked == true)
                    {

                        string SehirAdi;
                        SehirAdi = label4.Text + " süresinde " + p + " hata ile" + "(%" + c + ")" + " bitirdiniz.";
                        String BaglantiYolu = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Fuab/Desktop/onparmak.accdb";
                        OleDbConnection Baglanti = new OleDbConnection(BaglantiYolu);
                        Baglanti.Open();
                        string Sorgu = "INSERT INTO kayit(cümle) VALUES ('" + SehirAdi + "')";
                        OleDbCommand Komut = new OleDbCommand(Sorgu, Baglanti);
                        Komut.ExecuteNonQuery();
                        Baglanti.Close();
                    }
                    else if (radioButton4.Checked == true)
                    {

                        string SehirAdi;
                        SehirAdi = label4.Text + " süresinde " + p + " hata ile" + "(%" + c + ")" + " bitirdiniz.";
                        String BaglantiYolu = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Fuab/Desktop/onparmak.accdb";
                        OleDbConnection Baglanti = new OleDbConnection(BaglantiYolu);
                        Baglanti.Open();
                        string Sorgu = "INSERT INTO kayit(parag) VALUES ('" + SehirAdi + "')";
                        OleDbCommand Komut = new OleDbCommand(Sorgu, Baglanti);
                        Komut.ExecuteNonQuery();
                        Baglanti.Close();
                    }
                    DialogResult Soru1;


                    Soru1 = MessageBox.Show("Yeni Yazı İster misiniz?", "Uyarı",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Soru1 == DialogResult.Yes)
                    {
                        button2_Click(button2, new EventArgs());
                    }


                }
                else
                {
                    DialogResult Soru2;
                    Soru2 = MessageBox.Show("Yeni Yazı İster misiniz?", "Uyarı",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Soru2 == DialogResult.Yes)
                    {
                        button2_Click(button2, new EventArgs());
                    }
                }              
            }
            if (textBox2.Text.Length > x)
            {
                textBox3.Text = "";
                timer1.Start();
                timer2.Stop();
            }
            else if (textBox2.Text.Length < x)
            {
                textBox3.Text = "";
                timer1.Start();
                timer2.Stop();

            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetterOrDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsNumber(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetterOrDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsNumber(e.KeyChar);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            t++;
            if (t == 60)
            {
                t = 0;
                y++;
            }


            if (y == 60)
            {
                y = 0;
                u++;
            }
            label4.Text = string.Format("{0:00}:{1:00}:{2:00}", u, y, t);
        }

        private void button2_Click(object sender, EventArgs e)
        {         
            if (radioButton1.Checked)
            {
                textBox1.Text = "";                                
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Fuab/Desktop/onparmak.accdb"); con.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT TOP 1 * FROM harf ORDER BY RND(ID)", con);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr["Alan1"].ToString();
                }
                cmd = null;
                dr = null;
                con.Close();
            }
            else if (radioButton2.Checked)
            {
                textBox1.Text = "";           
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Fuab/Desktop/onparmak.accdb"); con.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT TOP 1 * FROM kelime ORDER BY RND(Kimlik)", con);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox1.Text = dr["Alan1"].ToString();
                }
                cmd = null;
                dr = null;
                con.Close();
              
            }
            else if (radioButton3.Checked)
            {
                textBox1.Text = "";
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Fuab/Desktop/onparmak.accdb"); con.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT TOP 1 * FROM cumle ORDER BY RND(Kimlik)", con);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox1.Text = dr["Alan1"].ToString();
                }
                cmd = null;
                dr = null;
                con.Close();
            }
            else if (radioButton4.Checked)
            {
                textBox1.Text = "";              
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Fuab/Desktop/onparmak.accdb"); con.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT TOP 1 * FROM parag ORDER BY RND(Kimlik)", con);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox1.Text = dr["Alan1"].ToString();
                }
                cmd = null;
                dr = null;
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            button4.Visible = true;
            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Fuab/Desktop/onparmak.accdb"); 
            DataSet dtst = new DataSet();
            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From kayit", bag);

            adtr.Fill(dtst, "kayit");

            dataGridView1.DataSource = dtst.Tables["kayit"];

            adtr.Dispose();

            bag.Close();
            dataGridView1.Columns[0].HeaderText = "kimlik";

            dataGridView1.Columns[1].HeaderText = "harf";

            dataGridView1.Columns[2].HeaderText = "kelime";

            dataGridView1.Columns[3].HeaderText = "cümle";

            dataGridView1.Columns[4].HeaderText = "parag";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            button4.Visible = false;
        }

    }
}
