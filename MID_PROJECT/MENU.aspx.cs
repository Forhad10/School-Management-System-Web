using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MID_PROJECT
{
    public partial class MENU : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = Session["username"].ToString();
            Label3.Text = Session["TYPE"].ToString();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["TYPE"] = Label3.Text;

            Response.Redirect("~/STUDENT_LIST.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["TYPE"] = Label3.Text;
            Response.Redirect("~/ADMIN_LIST.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session.Remove("username");
            
            Session.Remove("TYPE");
            Response.Redirect("~/login.aspx");

        }
    }
}