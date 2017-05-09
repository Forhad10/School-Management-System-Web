<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADD_STUDENT.aspx.cs" Inherits="MID_PROJECT.ADD_STUDENT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 348px">
    <form id="form1" runat="server">
    <div>
        
        &nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <br />
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="ID REQUIRED" ControlToValidate="TextBox1" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        &nbsp;&nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="VALID ID REQUIRED" ControlToValidate="TextBox1" ForeColor="#CC0099" ValidationExpression="[0-9]([0-9])*"></asp:RegularExpressionValidator>
        <br />
        <br/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        FIRST NAME&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="FIRST NAME REQUIRED" ControlToValidate="TextBox2" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        &nbsp;&nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="VALID FIRST NAME REQUIRED" ControlToValidate="TextBox2" ForeColor="#CC0099" ValidationExpression="[A-Z]|[a-z]([A-Z]|[a-z])*"></asp:RegularExpressionValidator>
        <br />
        <br/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        LAST NAME&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="LAST NAME REQUIRED " ControlToValidate="TextBox3" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        &nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="VALID LAST NAME REQUIRED " ControlToValidate="TextBox3" ForeColor="#CC0099" ValidationExpression="[A-Z]|[a-z]([A-Z]|[a-z])*"></asp:RegularExpressionValidator>
        <br />
        <br/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        EMAIL&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="EMAIL REQUIRED" ControlToValidate="TextBox4" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        &nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="VALID EMAIL REQUIRED" ControlToValidate="TextBox4" ForeColor="#CC0099" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        <br/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        PHONE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="PHONE REQUIRED" ControlToValidate="TextBox5" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        &nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="VALID PHONE NUMBER REQUIRED" ControlToValidate="TextBox5" ForeColor="#CC0099" ValidationExpression="[0][1][5-9][1-9][1-9][1-9][1-9][1-9][1-9][1-9][1-9]"></asp:RegularExpressionValidator>
        <br />
        <br/>
        &nbsp;&nbsp;&nbsp;&nbsp;
        GENDER&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownList1" runat="server" Height="23px" Width="134px">
            <asp:ListItem Selected="True">MALE</asp:ListItem>
            <asp:ListItem>FEMALE</asp:ListItem>
        </asp:DropDownList>

        <br />

        <br/>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Button ID="Button2" runat="server" Text="BACK" OnClick="Button2_Click"  ValidationGroup="add" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="ADD" OnClick="Button1_Click"  />

        <br/>


    
    </div>
    </form>
</body>
</html>
