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
    public partial class ProductInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

            cmd.CommandText = "SELECT category.*, products.* FROM category INNER JOIN products ON category.category_id = products.FK_category_id WHERE product_id = @product_id";

            cmd.Parameters.AddWithValue("@product_id", Request.QueryString["product_id"].ToString());

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Repeater_VisVare.DataSource = reader;
            Repeater_VisVare.DataBind();
        }

        protected void Repeater_VisVare_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToBasket")
            {
                Kurv minKurv = new Kurv();
                HiddenField pris = (HiddenField)e.Item.FindControl("HiddenField_Pris");
                HiddenField navn = (HiddenField)e.Item.FindControl("HiddenField_Name");
                HiddenField productid = (HiddenField)e.Item.FindControl("HiddenField_Id");
                decimal pris_con = Convert.ToDecimal(pris.Value);
                int product_id = Convert.ToInt32(productid.Value);

                minKurv.PutiKurv(e.CommandArgument.ToString(), 1, pris_con, navn.Value, product_id);
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}