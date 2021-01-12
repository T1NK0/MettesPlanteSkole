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
    public partial class AdminOverview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS products_antal FROM products", conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Label_Different_Products.Text = reader["products_antal"].ToString();
            }
            conn.Close();

            conn.Open();
            cmd.CommandText = @"SELECT COUNT(*) AS category_antal FROM category";
            SqlDataReader reader2 = cmd.ExecuteReader();
            if (reader2.Read())
            {
                Label_Categorys.Text = reader2["category_antal"].ToString();
            }
            conn.Close();
        }

        protected void Button_Logud_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Forside.aspx");
        }
    }
}