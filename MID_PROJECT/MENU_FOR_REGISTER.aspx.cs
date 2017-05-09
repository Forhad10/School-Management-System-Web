using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MID_PROJECT
{
    public partial class MENU_FOR_REGISTER : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = Session["username"].ToString();
            Session["information"] = Label2.Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/STUDENT_LIST.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Session.Remove("username");

            Session.Remove("TYPE");
            Response.Redirect("~/login.aspx");
        }
    }
}