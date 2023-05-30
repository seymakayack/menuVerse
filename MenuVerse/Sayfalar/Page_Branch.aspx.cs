using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace MenuVerse.Sayfalar
{
    public class YourDataModel
    {
        public string SahipAdi { get; set; }
        public string SahipSoyAdi { get; set; }
        public string Kullanici { get; set; }
        public string SubeAdi { get; set; }
        public string Sehir { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
    }
    public partial class Page_Branch : System.Web.UI.Page
    {
        public static void PopulateCityDropdownList(DropDownList ddl)
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
            string kullaniciAdi = Request.Cookies["kullaniciAdi"].Value;

            if (!IsPostBack)
            {
                using (SqlConnection baglantile = new SqlConnection(@"Data Source=DESKTOP-RO4JD3G\SQLEXPRESS;Initial Catalog=MenuVerse;Integrated Security=True"))
                {
                    string qu2 = "SELECT SubeAdi,Telefon,Sehir FROM tbl_SahipSube  WHERE Kullanici=@kullanici ";


                    using (SqlCommand kontrolKomut1 = new SqlCommand(qu2, baglantile))
                    {

                       
                        kontrolKomut1.Parameters.AddWithValue("@kullanici", kullaniciAdi);
                       

                        baglantile.Open();

                        SqlDataReader ok = kontrolKomut1.ExecuteReader();
                        DataList1.DataSource = ok;
                        DataList1.DataBind();

                        baglantile.Close();


                    }
                }
                PopulateCityDropdownList(DropDownList1);
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Bilgiler")
            {

                string subeAdi = e.CommandArgument.ToString();
                Response.Redirect("Page_BranchInformation.aspx?Sube=" + subeAdi);
            }
        }
        

        protected void BtnAra_Click1(object sender, EventArgs e)
        {
            string aramaMetni = TxtAra.Text.Trim();
            string kullaniciAdi = Request.Cookies["kullaniciAdi"].Value;
            // Veritabanı bağlantısını ve sorgu yapısını kullanarak verileri filtreleyin
            // Örneğin, SQL sorgusuyla veritabanından filtreleme yapabilirsiniz

            string query = "SELECT * FROM tbl_SahipSube WHERE Kullanici=@kullanici AND SubeAdi LIKE '%' + @aramaMetni + '%'";

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RO4JD3G\SQLEXPRESS;Initial Catalog=MenuVerse;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@kullanici", kullaniciAdi);
                command.Parameters.AddWithValue("@aramaMetni", aramaMetni);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Filtrelenen verileri bir liste veya DataTable'e aktarın
                List<YourDataModel> filtrelenenVeriler = new List<YourDataModel>();

                while (reader.Read())
                {
                    // Verileri okuyarak ve modele dönüştürerek listeye veya DataTable'e ekleyin
                    // Örneğin, verileri bir model sınıfına dönüştürerek ve listeye ekleyerek:

                    YourDataModel data = new YourDataModel();
                    data.SubeAdi = reader["SubeAdi"].ToString();
                    data.Sehir = reader["Sehir"].ToString();
                    data.Telefon = reader["Telefon"].ToString();
                    // Diğer verileri de ekleyin

                    filtrelenenVeriler.Add(data);
                }

                reader.Close();
                connection.Close();

                // DataList'in veri kaynağını güncelleyin
                DataList1.DataSource = filtrelenenVeriler;
                DataList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-RO4JD3G\SQLEXPRESS;Initial Catalog=MenuVerse;Integrated Security=True");
            string kullaniciAdi = Request.Cookies["kullaniciAdi"].Value;
            baglanti.Open();

            SqlCommand komut = new SqlCommand("insert into tbl_SahipSube(SahipAdi,SahipSoyAdi,Kullanici,SubeAdi,Telefon,Sehir,Adres) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
            komut.Parameters.AddWithValue("@p1", "deneme");
            komut.Parameters.AddWithValue("@p2", "deneme");
            komut.Parameters.AddWithValue("@p3", kullaniciAdi);
            komut.Parameters.AddWithValue("@p4", txtSubeAdi.Text);
            komut.Parameters.AddWithValue("@p5", txtTelefon.Text);
            komut.Parameters.AddWithValue("@p6", DropDownList1.Text);
            komut.Parameters.AddWithValue("@p7", txtAdres.Text);

            komut.ExecuteNonQuery();

            baglanti.Close();
            Response.Redirect("Page_Branch.aspx");
        }
    }
}