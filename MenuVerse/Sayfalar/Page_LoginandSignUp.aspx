<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page_LoginandSignUp.aspx.cs" Inherits="MenuVerse.Sayfalar.Page_LoginandSignUp" %>

<!DOCTYPE html>
<html lang="tr">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="stylesheet" href="/Stil/Page_LoginandSignUp.css">
    <title>MenuVerse</title>
</head>
<body>
    <form runat="server">
        <section>
            <div class="container">
                <!-- Giriş Yap Formu -->
                <div class="user singinBx">
                    <div class="imgBx"><img src="/Resim/11.jpg" alt="Giriş Yap Resmi"></div>
                    <div class="formBx">
                        <h2>Giriş Yap</h2>
                        <asp:TextBox ID="Txt_KullaniciID" runat="server" placeholder="Kullanıcı Adı"></asp:TextBox>
                        <asp:TextBox ID="Txt_Sifre" runat="server" placeholder="Şifre" TextMode="Password"></asp:TextBox>
                        <asp:Button ID="Btn_Giris" runat="server" Text="Giriş Yap" OnClick="Btn_Giris_Click" />
                        <p class="signup"><a href="#" onclick="toggleForm();">Hesabınız Yoksa Hemen Kayıt Olun</a></p>
                    </div>
                </div>

                <!-- Kayıt Ol Formu -->
                <div class="user singupBx">
                    <div class="formBx">
                        <h2>Kayıt Ol</h2>
                        <asp:TextBox ID="Txt_OKullaniciID" runat="server" placeholder="Kullanıcı Adı Giriniz"></asp:TextBox>
                        <asp:TextBox ID="Txt_OEmail" runat="server" placeholder="E-mail Giriniz"></asp:TextBox>
                        <asp:TextBox ID="Txt_OSifre" runat="server" placeholder="Şifre Giriniz" TextMode="Password"></asp:TextBox>
                        <asp:TextBox ID="Txt_OSifreT" runat="server" placeholder="Tekrar Şifre Giriniz" TextMode="Password"></asp:TextBox>
                        <asp:Button ID="Btn_KayitOl" runat="server" Text="Kayıt Ol" OnClick="Btn_KayitOl_Click" />
                        <p class="signup"><a href="#" onclick="toggleForm();">Hesabın Varsa Hemen Giriş Yap</a></p>
                    </div>
                    <div class="imgBx"><img src="/Resim/11.jpg" alt="Kayıt Ol Resmi"></div>
                </div>
            </div>
        </section>
    </form>
    <script type="text/javascript">
        function toggleForm() {
            var container = document.querySelector('.container');
            container.classList.toggle('active');
        }
    </script>
</body>
</html>
