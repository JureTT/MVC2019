<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PozdravnaPoruka.aspx.cs" Inherits="WebFormsPrimjer.PozdravnaPoruka" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ovo je pozdravna poruka<br />
            <asp:Label ID="Label1" runat="server" Text="Ime:"></asp:Label><br />
            <asp:TextBox ID="txtIme" runat="server"></asp:TextBox><br />
            <asp:Button ID="Obradi" runat="server" Text="Obradi" BackColor="#00CC66" Height="57px" OnClick="Obradi_Click" Width="119px" /><br />
            <asp:Label ID="lblRezultat" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
