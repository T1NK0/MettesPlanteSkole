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
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LinkButton_Create_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"INSERT INTO category (category_name) VALUES (@name)";

            cmd.Parameters.AddWithValue("@name", TextBox_Create_Category.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("Category.aspx");
        }
        protected void Repeater_ret_slet_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Slet")
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = @"DELETE FROM category WHERE category_id = @category_id";
                cmd.Parameters.AddWithValue("@category_id", e.CommandArgument);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Response.Redirect("Category.aspx");
            }

            if (e.CommandName == "Ret")
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                SqlCommand cmd = new SqlCommand("SELECT * FROM category WHERE category_id = @category_id", conn);
                cmd.Parameters.AddWithValue("@category_id", e.CommandArgument);
                ViewState["category_id"] = e.CommandArgument;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    //skriver de hentede værdier til formular felterne
                    TextBox_Genrer_Ret.Text = reader["category_name"].ToString();
                }
                conn.Close();
                Panel_ret.Visible = true;
                Panel_Opret.Visible = false;
            }
        }
        protected void Button_Gem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"UPDATE category SET category_name = @name WHERE category_id = @category_id";
            cmd.Parameters.AddWithValue("@name", TextBox_Genrer_Ret.Text);
            cmd.Parameters.AddWithValue("@category_id", ViewState["category_id"]);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("Category.aspx");
        }
    }
}