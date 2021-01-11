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
    public partial class MasterPage_Frontend : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Kurv nyKurv = new Kurv();
            GridView1.DataSource = Session["kurv"];
            GridView1.DataBind();
            Label_prisIalt.Text = nyKurv.prisIalt(0).ToString();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            if (!IsPostBack)
            {
                repeaterData();
            }
        }

        private void repeaterData()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"SELECT DISTINCT TOP(3) OrdreLinjer.FK_produkt_id, SUM(OrdreLinjer.antal) AS x, products.product_name, products.product_id 
                            FROM OrdreLinjer INNER JOIN products ON products.product_id = OrdreLinjer.FK_produkt_id 
                            GROUP BY OrdreLinjer.FK_produkt_id, products.product_name, products.product_id ORDER BY X DESC";

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Repeater_Top3Products.DataSource = reader;
            Repeater_Top3Products.DataBind();
        }

        protected void Button_login_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"SELECT * FROM users 
                            INNER JOIN roles
                            ON users.FK_role_id = role_id
                            WHERE @username = user_username
                            AND @password = user_password";

            cmd.Parameters.AddWithValue("@username", TextBox_Username.Text);
            cmd.Parameters.AddWithValue("@password", TextBox_Password.Text);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Session["user_id"] = reader["user_id"];
                Session["role_id"] = reader["role_id"];

                if (Convert.ToInt32(Session["role_id"]) == 1)
                {
                    Response.Redirect("AdminOverview.aspx");
                }

                if (Convert.ToInt32(Session["role_id"]) == 2)
                {
                    Response.Redirect("Default.aspx");
                }
                Response.Redirect("Default.aspx");
            }
            else
            {
                Label_Besked.Text = "Forkert kode eller brugernavn!";
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TableCell cell = GridView1.Rows[e.RowIndex].Cells[1];

            string x = cell.Text;
            //Response.Write(x);
            Kurv minKurv = new Kurv();
            minKurv.SletVare(x);
            Response.Redirect("default.aspx");
        }

        protected void Button_Vis_Kurven_Click(object sender, EventArgs e)
        {
            Response.Redirect("se_kurv.aspx");
        }

        protected void Button_Default_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void Button_Contact_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contact.aspx");
        }
    }
}