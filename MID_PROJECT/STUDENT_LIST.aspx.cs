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
    public partial class TEACHER_LIST : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Label3.Text = Session["TYPE"].ToString();
            if (!IsPostBack)
            {
                if (Cache["DATASET"] == null)
                {
                    this.LoadDataFromDatabase();
                }
                
                else
                {
                    this.LoadDataFromCache();
                    
                }
            }
        }

        private void LoadDataFromCache()
        {
            DataSet ds = (DataSet)Cache["DATASET"];
           GridView1.DataSource = ds.Tables["student"];
           GridView1.DataBind();
        }

        private void LoadDataFromDatabase()
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string sql = "SELECT * FROM student";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "student");
            ds.Tables["student"].PrimaryKey = new DataColumn[] { ds.Tables["student"].Columns["student_id"] };
            Cache["DATASET"] = ds;
            Cache["ADAPTER"] = adapter;
            
            GridView1.DataSource = ds.Tables["student"];
            GridView1.DataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            this.LoadDataFromCache();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            DataRow dr = ds.Tables["student"].Rows.Find(e.Keys["student_id"]);

            dr["first_name"] = e.NewValues["first_name"];

            dr["last_name"] = e.NewValues["last_name"];
            dr["email"] = e.NewValues["email"];

            dr["phone"] = e.NewValues["phone"];
            dr["gender"] = e.NewValues["gender"];

            Cache["DATASET"] = ds;
            GridView1.EditIndex = -1;
            this.LoadDataFromCache();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            DataRow dr = ds.Tables["student"].Rows.Find(e.Keys["student_id"]);
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
            if (ds.HasChanges())
            {
                ds.RejectChanges();
                Label1.Text = "nothing is permanently save in database";
                this.LoadDataFromCache();
            }
            else
            {
                Label1.Text = "Nothing to be saved";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            SqlDataAdapter adapter = (SqlDataAdapter)Cache["ADAPTER"];
            adapter.Update(ds.Tables["student"]);
            Label1.Text = " saved permanently";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ADD_STUDENT.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Label3.Text == "ADMIN")
            {

                Response.Redirect("~/MENU.aspx");
            }


            else
            {
                Response.Redirect("~/MENU_FOR_REGISTER.aspx");
            }
        }

    }
}