using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MettesPlanteskole
{
    public partial class Samlede_ordrer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Kurv nyKurv = new Kurv();
                GridView_VisVare.DataSource = Session["kurv"];
                GridView_VisVare.DataBind();
                Label_PrisIAlt.Text = nyKurv.prisIalt(0).ToString();
                Label_Moms.Text = nyKurv.moms(0).ToString();
            }
        }
        protected void GridView_VisVare_SelectedIndexChanged(object sender, EventArgs e)
        {
            string varenr = GridView_VisVare.SelectedRow.Cells[1].Text;
            TextBox TextBox1 = (TextBox)GridView_VisVare.SelectedRow.Cells[4].Controls[1];
            int antal = Convert.ToInt32(TextBox1.Text);

            Kurv minKurv = new Kurv();
            minKurv.RetVare(varenr, antal);
            Response.Redirect(Request.RawUrl);
        }
        protected void LinkButton_CheckUd_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Remove("kurv");
            Response.Redirect(Request.RawUrl);
        }
        protected void LinkButton_PDF_Click(object sender, EventArgs e)
        {

        }
    }
}