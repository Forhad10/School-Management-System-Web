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
    public partial class ADMIN_LIST : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.LoadDataFromDatabase();

            }
        }



        private void LoadDataFromCache()
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            GridView1.DataSource = ds.Tables["login"];
            GridView1.DataBind();
        }

        private void LoadDataFromDatabase()
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string sql = "SELECT * FROM login";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "login");
            ds.Tables["login"].PrimaryKey = new DataColumn[] { ds.Tables["login"].Columns["username"] };
            Cache["DATASET"] = ds;
            Cache["ADAPTER"] = adapter;

            GridView1.DataSource = ds.Tables["login"];
            GridView1.DataBind();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string sql1 = "SELECT * FROM login";
            SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, conn);
            SqlCommandBuilder builder1 = new SqlCommandBuilder(adapter1);
            DataSet ds1 = new DataSet();

            adapter1.Fill(ds1, "login");

            DataRow dr = ds1.Tables["login"].NewRow();
            dr["username"] = TextBox1.Text;
            dr["password"] = TextBox2.Text;
            dr["TYPE"] = DropDownList1.SelectedItem.ToString();
           

            ds1.Tables["login"].Rows.Add(dr);



            adapter1.Update(ds1.Tables["login"]);
            Response.Redirect("~/ADMIN_LIST.aspx");
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            DataSet ds = (DataSet)Cache["DATASET"];
            DataRow dr = ds.Tables["login"].Rows.Find(e.Keys["username"]);
            
            
            dr["password"] = e.NewValues["password"];
            dr["TYPE"] = e.NewValues["TYPE"];
           
           


            Cache["DATASET"] = ds;
            GridView1.EditIndex = -1;
            this.LoadDataFromCache();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            this.LoadDataFromCache();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            DataRow dr = ds.Tables["login"].Rows.Find(e.Keys["username"]);
            dr.Delete();
            Cache["DATASET"] = ds;
            this.LoadDataFromCache();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.LoadDataFromCache();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            SqlDataAdapter adapter = (SqlDataAdapter)Cache["ADAPTER"];
            adapter.Update(ds.Tables["login"]);
            Label4.Text = " saved permanently";
        }

     

        protected void Button4_Click(object sender, EventArgs e)
        {

            DataSet ds = (DataSet)Cache["DATASET"];
            if (ds.HasChanges())
            {
                ds.RejectChanges();
                Label4.Text = "CANCEL  successfull";
                this.LoadDataFromCache();
            }
            else
            {
                Label4.Text = "Nothing to be CANCELED";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MENU.aspx");
        }
    }
}