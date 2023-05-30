using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace MenuVerse.Sayfalar
{
    public partial class Page_BranchInformation : System.Web.UI.Page
    {
        protected void BilgileriGoster()
        {
            string sube = Request.QueryString["Sube"];
            string kullaniciAdi = Request.Cookies["kullaniciAdi"].Value;

            using (SqlConnection baglantile = new SqlConnection(@"Data Source=DESKTOP-RO4JD3G\SQLEXPRESS;Initial Catalog=MenuVerse;Integrated Security=True"))
            {
                baglantile.Open();
                string qu2 = "SELECT Telefon,Sehir,Adres FROM tbl_SahipSube  WHERE Kullanici=@kullanici AND SubeAdi=@sube ";

                using (SqlCommand kontrolKomut1 = new SqlCommand(qu2, baglantile))
                {

                    kontrolKomut1.Parameters.AddWithValue("@sube", sube);
                    kontrolKomut1.Parameters.AddWithValue("@kullanici", kullaniciAdi);

                    using (SqlDataReader reader1 = kontrolKomut1.ExecuteReader())
                    {
                        if (reader1.Read())
                        {
                            // İlgili kontrol değerlerine verileri atama
                            txtSubeAdi.Text = sube;
                            txtTelefon.Text = reader1["Telefon"].ToString();
                            DropDownList1.Text = reader1["Sehir"].ToString();
                            txtAdres.Text = reader1["Adres"].ToString();
                        }
                    }
                }
                baglantile.Close();
            }
        }
        public void PopulateCityDropdownList(DropDownList ddl)
        {
            // Veritabanı bağlantı dizesini belirtin

            // SqlConnection nesnesini oluşturun
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RO4JD3G\SQLEXPRESS;Initial Catalog=MenuVerse;Integrated Security=True"))
            {
                // SQL sorgusu için SqlCommand nesnesini oluşturun
                string query = "SELECT SehirAdi FROM tbl_AdminSehirler";
                SqlCommand cmd = new SqlCommand(query, con);

                // SqlDataAdapter nesnesini kullanarak verileri alın
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // DropDownList kontrolünü doldurun
                ddl.DataSource = dt;
                ddl.DataTextField = "SehirAdi";
                ddl.DataValueField = "SehirAdi";
                ddl.DataBind();

                // İlk sıraya varsayılan bir seçenek ekleyin
                ddl.Items.Insert(0, new ListItem("Seçiniz", ""));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateCityDropdownList(DropDownList1);
                BilgileriGoster();              
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sube = Request.QueryString["Sube"];
            string kullaniciAdi = Request.Cookies["kullaniciAdi"].Value;
            string qu3 = "UPDATE tbl_SahipSube SET SahipAdi=@ad,SahipSoyAdi=@soyad,Telefon=@telefon, Sehir=@sehir, Adres=@adres WHERE Kullanici=@kullanici AND SubeAdi=@sube";
            using (SqlConnection baglantile = new SqlConnection(@"Data Source=DESKTOP-RO4JD3G\SQLEXPRESS;Initial Catalog=MenuVerse;Integrated Security=True"))
            {
                baglantile.Open();

                using (SqlCommand güncelleKomut = new SqlCommand(qu3, baglantile))
                {
                    güncelleKomut.Parameters.AddWithValue("@ad", "deneme");
                    güncelleKomut.Parameters.AddWithValue("@soyad", "deneme");
                    güncelleKomut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                    güncelleKomut.Parameters.AddWithValue("@sehir", DropDownList1.Text);
                    güncelleKomut.Parameters.AddWithValue("@adres", txtAdres.Text);
                    güncelleKomut.Parameters.AddWithValue("@kullanici", kullaniciAdi);
                    güncelleKomut.Parameters.AddWithValue("@sube", sube);

                    güncelleKomut.ExecuteNonQuery();
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try { 
            using (SqlConnection baglantile = new SqlConnection(@"Data Source=DESKTOP-RO4JD3G\SQLEXPRESS;Initial Catalog=MenuVerse;Integrated Security=True"))
            {
                string sube = Request.QueryString["Sube"];
                string kullaniciAdi = Request.Cookies["kullaniciAdi"].Value;
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("Resim/KategoriResimleri/" + filename));
                baglantile.Open();
                SqlCommand cmd = new SqlCommand("Insert  into tbl_SahipSubeKategoriveYemek(Kullanici,SubeAdi,KategoriID,KategoriResim,YemekAdi,YemekAciklama,YemekFiyat) values (@kullanici,@sube,@kategori,@resim,NULL,NULL,NULL)",baglantile);
                cmd.Parameters.AddWithValue("@kullanici",kullaniciAdi);
                cmd.Parameters.AddWithValue("@sube", sube);
                cmd.Parameters.AddWithValue("@kategori", TxtKategori.Text);
                cmd.Parameters.AddWithValue("@resim", filename);
                cmd.ExecuteNonQuery();
                baglantile.Close();
            }

            }
            catch(Exception ex)
            {
                string script = $"<script>alert('{ex.Message}');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorPopup", script);
            }

        }
    }
}