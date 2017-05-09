<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="REGISTER_INOFORMATION.aspx.cs" Inherits="MID_PROJECT.REGISTER_INOFORMATION" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 303px">
    <form id="form1" runat="server">
    <div style="height: 340px">
    
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MENU_FOR_REGISTER.aspx">BACK</asp:HyperLink>
    
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="USERNAME"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="PASSWORD"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="ENTER NEW PASSWORD" ControlToValidate="TextBox2" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="UPDATE" />
    
    </div>
    </form>
</body>
</html>
