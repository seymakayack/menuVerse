<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page_BranchInformation.aspx.cs" Inherits="MenuVerse.Sayfalar.Page_BranchInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/Stil/page1c.css">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 720px;
        }

        /* Yeni stil tanımları */
        #content {
            height: 100%;
            display: flex;
            flex-direction: column;
        }

        #div1 {
            height: 150px;
            width: 100%;
        }

        #div2 {
            height: 500px;
            width: 100%;
            display: flex;
        }

        #div2 > div {
            flex: 1;
        }
        .auto-style2 {
            width: 732px;
            height: 299px;
        }
        .auto-style3 {
            width: 733px;
            height: 195px;
            text-align: left;
        }
        .auto-style4 {
            height: 93px;
        }
        .auto-style5 {
            height: 468px;
            width: 87%;
        }
        .auto-style6 {
            height: 132px;
        }
        .auto-style7 {
            height: 103px;
            width: 452px;
        }
        .auto-style8 {
            width: 100%;
        }
        .auto-style16 {
            height: 28px;
        }
        .auto-style17 {
            height: 28px;
            width: 40px;
        }
        .auto-style18 {
            width: 40px;
        }
        .auto-style26 {
            width: 179px;
        }
        .auto-style27 {
            height: 25px;
            width: 40px;
        }
        .auto-style28 {
            height: 25px;
        }
    </style>
    
</head>
<body style="height: 787px">
    <form id="form1" runat="server">
        <div id="menu">
            <ul>
                <li>
                    <a href="#" class="active">Hesap</a>
                </li>
                <li>
                    <a href="#">Çıkış</a>
                </li>
            </ul>
        </div>
        <div id="content" class="auto-style1">
            <div id="div1" class="auto-style4">
                <br />
                <asp:Label ID="Label2" runat="server" Text="Bilgiler" Font-Size="XX-Large"></asp:Label>
                <br />
                <br />
                    <div style="display: flex; flex-direction: row; align-items: center; margin-bottom: 10px;">
                    <asp:Label ID="lblSubeAdi" runat="server" Text="Şube Adı:" style="margin-right: 10px;"></asp:Label>
                    <asp:TextBox ID="txtSubeAdi" runat="server" style="width: 200px; height: 30px;"></asp:TextBox>

                    <asp:Label ID="lblTelefon" runat="server" Text="Telefon:" style="margin-left: 10px; margin-right: 10px;"></asp:Label>
                    <asp:TextBox ID="txtTelefon" runat="server" style="width: 200px; height: 30px;"  oninput="validatePhoneNumber(this)"></asp:TextBox>

                    <asp:Label ID="lblSehir" runat="server" Text="Şehir:" style="margin-left: 10px; margin-right: 10px;"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" style="width: 200px; height: 30px;"></asp:DropDownList>

                    <asp:Label ID="lblAdres" runat="server" Text="Adres:" style="margin-left: 10px; margin-right: 10px;"></asp:Label>
                    <asp:TextBox ID="txtAdres" runat="server" TextMode="MultiLine" Rows="3" style="width: 200px;"></asp:TextBox>

                    <asp:Button ID="Button2" runat="server" Text="Güncelle" style="margin-left: 20px; margin-right: 20px;" Height="36px" Width="127px" OnClick="Button2_Click" />
                </div>
            </div>
            <div id="div2" class="auto-style5">
                <div class="auto-style2" >
                    <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="Kategoriler"></asp:Label>
                    <asp:Panel ID="Panel1" runat="server" Height="268px">
                    </asp:Panel>
                </div>
                <div class="auto-style3">
                    <asp:Label ID="Label3" runat="server" Font-Size="X-Large" Text="Önerilen Kategoriler"></asp:Label>
                  
                    <asp:Panel ID="Panel2" runat="server" Height="161px">
                    </asp:Panel>               
                </div>
            </div>
            <div class="auto-style6" >
                <asp:Label ID="Label4" runat="server" Text="Kategori Ekle" Font-Size="Large"></asp:Label>

                <div class="auto-style7">
                    <table class="auto-style8">
                        <tr>
                            <td class="auto-style26" rowspan="3">
                                <asp:Image ID="Image1" runat="server" Height="70px" Width="175px" />
                            </td>
                            <td class="auto-style17"></td>
                            <td class="auto-style16">
                                <asp:Label ID="Label5" runat="server" Text="Kategori Adı"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style27"></td>
                            <td class="auto-style28">
                                <asp:TextBox ID="TxtKategori" runat="server" Width="215px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style18"></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:FileUpload ID="FileUpload1" runat="server" Width="218px" />
                            </td>
                            <td>
                                <asp:Button ID="Button4" runat="server" Text="Kategori Yükle" Width="219px" OnClick="Button4_Click" />
                            </td>
                        </tr>
                    </table>
                </div>

            </div>
        </div>
    </form>
</body>
    <script>
        function validatePhoneNumber(input) {
            var value = input.value;
            value = value.replace(/\D/g, ''); // Sadece rakamları tut
            value = value.slice(0, 15); // Maksimum 15 hane

            input.value = value;
        }
    </script>
</html>
