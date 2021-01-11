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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button_opret_bruger_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"INSERT INTO users (user_username, user_password, user_firstname, user_lastname, user_address, user_email) VALUES (@username, @password, @firstname, @lastname, @address, @email)";
            cmd.Parameters.AddWithValue("@username", TextBox_Username_Create.Text);
            cmd.Parameters.AddWithValue("@email", TextBox_Email_Create.Text);
            cmd.Parameters.AddWithValue("@password", TextBox_Password_Create1.Text);
            cmd.Parameters.AddWithValue("@firstname", TextBox_Firstname_Create.Text);
            cmd.Parameters.AddWithValue("@lastname", TextBox_Lastname_Create.Text);
            cmd.Parameters.AddWithValue("@address", TextBox_Address_Create.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Default.aspx");
        }
    }
}