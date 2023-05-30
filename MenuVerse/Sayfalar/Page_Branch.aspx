<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page_Branch.aspx.cs" Inherits="MenuVerse.Sayfalar.Page_Branch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
	    body {
            margin: 0;
            padding: 0;
            background-image: url('/Resim/12.png');
            
        }
        #sidebar {
            width: 300px;
            height: 100vh;
            background-color: yellow;
            float: left;
		margin-right: -4px;
            margin-bottom: -4px;
        }

        #content {
            margin-left: 300px;
            height: 100vh;
            
            background-size: cover;
        }

        #sidebar a {
            display: block;
            padding: 10px;
            color: black;
            text-decoration: none;
        }

        #sidebar a:hover {
            background-color: lightgray;
            color: white;
        }
        .auto-style1 {
            height: 882px;
            width: 1377px;
        }
        .auto-style2 {
            margin-left: 5px;
        }
        @media only screen and (max-width: 768px) {
            #sidebar {
                width: 100%;
                height: auto;
                float: none;
                margin-right: 0;
                margin-bottom: 0;
            }

            #content {
                margin-left: 0;
                height: auto;
            }
        }
        .auto-style10 {
            width: 100%;
        }
        .auto-style11 {
            height: 65px;
            text-align: center;
        }
        .auto-style15 {
            height: 37px;
            text-align: center;
        }
        .auto-style16 {
            height: 42px;
            text-align: center;
        }
        .auto-style17 {
            height: 37px;
            text-align: center;
            width: 106px;
        }
        .auto-style18 {
            height: 42px;
            text-align: center;
            width: 106px;
        }
        .auto-style10 {
        width: 200px;
        table-layout: fixed;
    }
    .auto-style10 td {
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
    }
        .auto-style19 {
            height: 120px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="sidebar">
            <a href="#">Hesabım</a>
            <a href="#">Çıkış</a>
        </div>
        <div id="content" class="auto-style1">
            <!-- İçerik buraya gelecektir -->
            <asp:TextBox ID="TxtAra" runat="server" Height="36px" Width="1214px" placeholder ="Şube Arayınız"></asp:TextBox>
            <asp:Button ID="BtnAra" runat="server" Text="Ara" Height="40px" OnClick="BtnAra_Click1" Width="138px" />
           
            <asp:Panel ID="Panel1" runat="server" CssClass="auto-style2" Height="718px" Width="1373px">
             
                <asp:DataList ID="DataList1" runat="server" CellSpacing="25" OnItemCommand="DataList1_ItemCommand" RepeatColumns="6" RepeatDirection="Horizontal" Width="1206px">
                    <ItemTemplate>
                        <table class="auto-style10">
                            <tr>
                                <td class="auto-style11" colspan="2">
                                    <asp:Label ID="Label3" runat="server" Font-Size="XX-Large" Text='<%# Eval("SubeAdi") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">
                                    <asp:Label ID="Label1" runat="server" Font-Size="Large" Text='<%# Eval("Sehir") %>'></asp:Label>
                                </td>
                                <td class="auto-style15">
                                    <asp:Label ID="Label2" runat="server" Font-Size="Large" Text='<%# Eval("Telefon") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style18">
                                    <asp:Button ID="BtnBilgiler" runat="server" CommandArgument='<%# Eval("SubeAdi") %>' CommandName="Bilgiler" Height="35px" Text="Bilgiler" Width="92px" />
                                </td>
                                <td class="auto-style16">
                                    <asp:Button ID="BtnSil" runat="server" Height="36px" Text="Sil" Width="90px" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>

            </asp:Panel>
        <div class="auto-style19">
    <div style="display: flex; flex-direction: row; align-items: center; margin-bottom: 10px;">
        <asp:Label ID="lblSubeAdi" runat="server" Text="Şube Adı:" style="margin-right: 10px;"></asp:Label>
        <asp:TextBox ID="txtSubeAdi" runat="server" style="width: 200px; height: 30px;"></asp:TextBox>

        <asp:Label ID="lblTelefon" runat="server" Text="Telefon:" style="margin-left: 10px; margin-right: 10px;"></asp:Label>
        <asp:TextBox ID="txtTelefon" runat="server" style="width: 200px; height: 30px;"  oninput="validatePhoneNumber(this)"></asp:TextBox>

        <asp:Label ID="lblSehir" runat="server" Text="Şehir:" style="margin-left: 10px; margin-right: 10px;"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" style="width: 200px; height: 30px;"></asp:DropDownList>

        <asp:Label ID="lblAdres" runat="server" Text="Adres:" style="margin-left: 10px; margin-right: 10px;"></asp:Label>
        <asp:TextBox ID="txtAdres" runat="server" TextMode="MultiLine" Rows="3" style="width: 200px;"></asp:TextBox>

        <asp:Button ID="Button1" runat="server" Text="Ekle" style="margin-left: 20px; margin-right: 20px;" Height="36px" Width="127px" OnClick="Button1_Click" />
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
