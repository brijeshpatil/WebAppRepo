using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        pservice PS = new pservice();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                FillGRid();
            }
        }

        private void FillGRid()
        {
            GridView1.DataSource = PS.GEtAllUSers();
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PS.FirstName = txtFname.Text;
            PS.LastName = txtLname.Text;
            PS.InsertNewUser(PS);
            FillGRid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            FillGRid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            PS.UserID = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Value);
            PS.DeleteUser(PS);
            FillGRid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            FillGRid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            PS.UserID = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Value);
            PS.FirstName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1")).Text;
            PS.LastName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2")).Text;
            PS.UadateUser(PS);
            GridView1.EditIndex = -1;
            FillGRid();
        }
    }
}