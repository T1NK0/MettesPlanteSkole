using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MettesPlanteskole
{
    public partial class MasterPage_Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = @"SELECT users.*, roles.* FROM users INNER JOIN roles ON user.FK_role_id = roles.role_id WHERE user_id = @user_id";

                cmd.Parameters.AddWithValue("@user_id", Convert.ToInt32(Session["user_id"]));
            }

            if (Convert.ToInt32(Session["role_id"]) != 1)
            {
                Response.Redirect("Default.aspx");
            }
        }
        protected void LinkButton_Logud_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Default.aspx");
        }
    }
}