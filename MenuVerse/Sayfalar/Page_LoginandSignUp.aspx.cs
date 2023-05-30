using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace MenuVerse.Sayfalar
{
    public partial class Page_LoginandSignUp : System.Web.UI.Page
    {
        //Data Source=DESKTOP-RO4JD3G\SQLEXPRESS;Initial Catalog=MenuVerse;Integrated Security=True
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public bool KullaniciAdiVarmi(string kullaniciAdi)
        {
            bool exists = false;

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RO4JD3G\SQLEXPRESS;Initial Catalog=MenuVerse;Integrated Security=True"))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM tbl_Kullanicilar WHERE KullaniciAdi = @KullaniciAdi";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    exists = true;
                }
            }

            return exists;
        }
        public bool EmailVarmi(string email)
        {
            bool exists = false;

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RO4JD3G\SQLEXPRESS;Initial Catalog=MenuVerse;Integrated Security=True"))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM tbl_Kullanicilar WHERE Email = @email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", email);

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    exists = true;
                }
            }

            return exists;
        }
        public bool EmailKontrol(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private bool KullaniciGirisDogrula(string kullaniciAdi, string sifre)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RO4JD3G\SQLEXPRESS;Initial Catalog=MenuVerse;Integrated Security=True"))
            {
                connection.Open();

                // SQL sorgusu ile kullanıcı adı ve şifrenin doğruluğunu kontrol et
                string query = "SELECT COUNT(*) FROM tbl_Kullanicilar WHERE Kullaniciadi = @kullaniciAdi AND Sifre = @sifre";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                command.Parameters.AddWithValue("@sifre", sifre);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }
        private bool GirisVerilerBosMu()
        {
            string kullaniciAdi = Txt_KullaniciID.Text;
            string sifre = Txt_Sifre.Text;

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                return true; // Boş veri var
            }
            else
            {
                return false; // Veriler dolu
            }
        }
        private bool KayitOlVerilerBosMu()
        {
            string kullaniciAdi = Txt_OKullaniciID.Text;
            string sifre = Txt_OSifre.Text;
            string email = Txt_OEmail.Text;
            string sifret = Txt_OSifreT.Text;

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(sifret) )
            {
                return true; 
            }
            else
            {
                return false; // Veriler dolu
            }
        }
        private string KullaniciRolunuBul(string kullaniciAdi)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RO4JD3G\SQLEXPRESS;Initial Catalog=MenuVerse;Integrated Security=True"))
            {
                connection.Open();

                // SQL sorgusu ile kullanıcının rolünü bul
                string query = "SELECT Rol FROM tbl_Kullanicilar WHERE KullaniciAdi = @kullaniciAdi";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);

                string rol = (string)command.ExecuteScalar();

                return rol;
            }
        }
        protected void Btn_KayitOl_Click(object sender, EventArgs e)
        {
            try
            {
                string kullaniciAdi = Txt_OKullaniciID.Text;
                string email = Txt_OEmail.Text;
                string sifre = Txt_OSifre.Text;
                string rol = "owner";
                if (KayitOlVerilerBosMu())
                {
                    throw new Exception("Boş Bırakılan Yerleri Doldurun");
                }
                if (KullaniciAdiVarmi(kullaniciAdi))
                {
                    throw new Exception("Kullanıcı adı zaten mevcut!");
                }
                if(EmailVarmi(email))
                {
                    throw new Exception("Bu mail adresi ile kayıt gerçekleştirilmiştir. ");
                }
                if (!EmailKontrol(email))
                {
                    throw new Exception("Bu mail kullanıma uygun değildir.");
                }
                if(Txt_OSifre.Text!=Txt_OSifreT.Text)
                {
                    throw new Exception("Şifreleri tekrar giriniz.");
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RO4JD3G\SQLEXPRESS;Initial Catalog=MenuVerse;Integrated Security=True"))
                    {
                        conn.Open();

                        // Kullanıcıyı eklemek için SQL INSERT sorgusu kullanılır
                        string sql = "INSERT INTO tbl_Kullanicilar (KullaniciAdi, Email, Sifre, Rol) VALUES (@Kullaniciadi, @Email, @Sifre, @Rol)";
                        SqlCommand cmd = new SqlCommand(sql, conn);

                        // Parametreler atanır
                        cmd.Parameters.AddWithValue("@Kullaniciadi", kullaniciAdi);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Sifre", sifre);
                        cmd.Parameters.AddWithValue("@Rol", rol);

                        // Sorguyu çalıştır
                        cmd.ExecuteNonQuery();
                    }

                    // Kullanıcı başarıyla eklendiğinde mesaj gösterilebilir
                    string successMessage = "Kullanıcı başarıyla oluşturuldu!";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessPopup", $"<script>alert('{successMessage}');</script>");
                }
            }
            catch (Exception ex)
            {
                string script = $"<script>alert('{ex.Message}');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorPopup", script);
            }
        }
        protected void Btn_Giris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = Txt_KullaniciID.Text;
            string sifre = Txt_Sifre.Text;

            try
            {
                // Veritabanında kullanıcı adı ve şifre kontrolü yap
                if (GirisVerilerBosMu())
                {
                    throw new Exception("Boş Bırakılan Yerleri Doldurun");
                }
                if (KullaniciGirisDogrula(kullaniciAdi, sifre))
                {
                    string rol = KullaniciRolunuBul(kullaniciAdi);
                    if(rol == "admin")
                    {

                    }
                    else if(rol == "owner")
                    {
                        
                        HttpCookie cookie22 = new HttpCookie("kullaniciAdi", kullaniciAdi);
                        Response.Cookies.Add(cookie22);
                        Response.Redirect("Page_Branch.aspx");
                    }
                    else if(rol == "user")
                    {
                        Response.Redirect("AnaSayfa.aspx");
                    }
                    
                }
                else
                {
                    throw new Exception("Kullanıcı adı veya şifre hatalı!");
                }
            }
            catch (Exception ex)
            {
                string script = $"<script>alert('{ex.Message}');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorPopup", script);

            }
        }

    }
}