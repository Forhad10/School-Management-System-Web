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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string sql = "Select * from login where username='" + TextBox1.Text + "' and password ='" + TextBox2.Text + "' and TYPE ='" + DropDownList1.SelectedItem.ToString() + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataTable ds = new DataTable();

            adapter.Fill(ds);

           

            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0][2].ToString() == "ADMIN")
                {
                    Session["username"] = TextBox1.Text;
                    Session["TYPE"] = DropDownList1.SelectedItem.ToString();
                    Response.Redirect("MENU.aspx");
                }

                if (ds.Rows[0][2].ToString() == "REGISTER")
                {
                    Session["username"] = TextBox1.Text;
                    Session["TYPE"] = DropDownList1.SelectedItem.ToString();
                    Response.Redirect("MENU_FOR_REGISTER.aspx");
                }
               
            }

            else
            {

                Response.Redirect("login.aspx");

            }
            
           
           
        }
    }
}