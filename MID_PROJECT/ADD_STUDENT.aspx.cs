using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MID_PROJECT
{
    public partial class ADD_STUDENT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];

            DataRow dr = ds.Tables["student"].NewRow();
            dr["student_id"] = TextBox1.Text;
            dr["first_name"] = TextBox2.Text;
            dr["last_name"] = TextBox3.Text;
            dr["email"] = TextBox4.Text;
            dr["phone"] = TextBox5.Text;
            dr["gender"] = DropDownList1.SelectedItem.ToString();

            ds.Tables["student"].Rows.Add(dr);

            SqlDataAdapter adapter = (SqlDataAdapter)Cache["ADAPTER"];

            
            Response.Redirect("~/STUDENT_LIST.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/STUDENT_LIST.aspx");
        }
    }
}