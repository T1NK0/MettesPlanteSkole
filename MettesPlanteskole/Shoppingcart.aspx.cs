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
    public partial class Shoppingcart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                repeaterData();
            }
        }

        protected void Repeater_vare_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "PutIKurv")
            {
                Kurv minKurv = new Kurv();
                HiddenField pris = (HiddenField)e.Item.FindControl("HiddenField_pris");
                HiddenField navn = (HiddenField)e.Item.FindControl("HiddenField_navn");
                HiddenField produktid = (HiddenField)e.Item.FindControl("HiddenField_produktid");
                decimal pris_con = Convert.ToDecimal(pris.Value);
                int produkt_id = Convert.ToInt32(produktid.Value);
                minKurv.PutiKurv(e.CommandArgument.ToString(), 1, pris_con, navn.Value, produkt_id);
                Response.Redirect(Request.RawUrl);
            }
        }
        private void repeaterData()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"SELECT category.category_name, products.product_name,  products.product_number, products.product_price, products.product_storage, products.product_id FROM category INNER JOIN products ON category.category_id = products.FK_category_id WHERE category_id = @category_id";

            cmd.Parameters.AddWithValue("@category_id", Request.QueryString["category_id"].ToString());

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Repeater_vare.DataSource = reader;
            Repeater_vare.DataBind();
        }
    }
}