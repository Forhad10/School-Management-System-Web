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
    public partial class COURSE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.LoadDataFromDatabase();

            }

            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string sql = "SELECT * FROM teacher";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "teacher");

            DropDownList1.DataSource = ds.Tables["teacher"];
            DropDownList1.DataTextField = "teacher_name";
            DropDownList1.DataValueField = "teacher_name";
            DropDownList1.DataBind();
        }

        private void LoadDataFromCache()
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            GridView1.DataSource = ds.Tables["course"];
            GridView1.DataBind();
        }

        private void LoadDataFromDatabase()
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string sql = "SELECT * FROM course";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "course");
            ds.Tables["course"].PrimaryKey = new DataColumn[] { ds.Tables["course"].Columns["course_id"] };
            Cache["DATASET"] = ds;
            Cache["ADAPTER"] = adapter;

            GridView1.DataSource = ds.Tables["course"];
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string sql1 = "SELECT * FROM course";
            SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, conn);
            SqlCommandBuilder builder1 = new SqlCommandBuilder(adapter1);
            DataSet ds1 = new DataSet();

            adapter1.Fill(ds1, "course");

            DataRow dr = ds1.Tables["course"].NewRow();
            dr["course_id"] = TextBox1.Text;
            dr["course_name"] = TextBox2.Text;
            dr["teacher_name"] = DropDownList1.SelectedItem.ToString();


            ds1.Tables["course"].Rows.Add(dr);



            adapter1.Update(ds1.Tables["course"]);
            Response.Redirect("~/COURSE.aspx");
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            DataRow dr = ds.Tables["course"].Rows.Find(e.Keys["course_id"]);


            dr["course_name"] = e.NewValues["course_name"];
            dr["teacher_name"] = e.NewValues["teacher_name"];




            Cache["DATASET"] = ds;
            GridView1.EditIndex = -1;
            this.LoadDataFromCache();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            DataRow dr = ds.Tables["course"].Rows.Find(e.Keys["course_id"]);
            dr.Delete();
            Cache["DATASET"] = ds;
            this.LoadDataFromCache();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            this.LoadDataFromCache();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.LoadDataFromCache();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            SqlDataAdapter adapter = (SqlDataAdapter)Cache["ADAPTER"];
            adapter.Update(ds.Tables["course"]);
            Label1.Text = " saved permanently";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            if (ds.HasChanges())
            {
                ds.RejectChanges();
                Label1.Text = "CANCEL  successfull";
                this.LoadDataFromCache();
            }
            else
            {
                Label1.Text = "Nothing to be CANCELED";
            }
        }
    }
}