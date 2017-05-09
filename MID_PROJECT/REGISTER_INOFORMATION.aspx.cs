using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MID_PROJECT
{
    public partial class REGISTER_INOFORMATION : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = Session["information"].ToString();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string sql = "update login set password='"+TextBox2.Text+"'  where username='"+TextBox1.Text+"'" ;
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "login");

            Response.Redirect("MENU_FOR_REGISTER.aspx");
        }
    }
}