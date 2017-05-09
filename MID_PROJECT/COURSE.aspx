<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="COURSE.aspx.cs" Inherits="MID_PROJECT.COURSE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 310px">
    <form id="form1" runat="server">
    <div>
        <div>
            COURSE ID<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            COURSE NAME<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                  <br />
            TEACHER NAME <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            <br/>
            <asp:Button ID="Button1" runat="server" Text="ADD" OnClick="Button1_Click" />

        </div>
        <div>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="course_id" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="course_id" HeaderText="COURSE ID" />
                    <asp:BoundField DataField="course_name" HeaderText="COURSE NAME" />
                    <asp:BoundField DataField="teacher_name" HeaderText="TEACHER NAME" />
                    <asp:CommandField HeaderText="OPTION" ShowDeleteButton="True" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
            <br/>
            <asp:Button ID="Button4" runat="server" Text="BACK" />
            <asp:Button ID="Button2" runat="server" Text="CANCEL" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="CONFIRM" OnClick="Button3_Click" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        </div>

    
    </div>
    </form>
</body>
</html>
