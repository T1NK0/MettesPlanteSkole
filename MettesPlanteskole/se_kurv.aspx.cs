using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MettesPlanteskole
{
    public partial class se_kurv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Kurv nyKurv = new Kurv();
                GridView1.DataSource = Session["kurv"];
                GridView1.DataBind();
                Label_PrisIAlt.Text = nyKurv.prisIalt(0).ToString();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string varenr = GridView1.SelectedRow.Cells[1].Text;
            TextBox TextBox1 = (TextBox)GridView1.SelectedRow.Cells[4].Controls[1];
            int antal = Convert.ToInt32(TextBox1.Text);

            Kurv minKurv = new Kurv();
            minKurv.RetVare(varenr, antal);
            Response.Redirect(Request.RawUrl);
        }
        protected void LinkButton_Bestil_Click(object sender, EventArgs e)
        {
            Kurv test = new Kurv();
            int Kundeid = 3;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"INSERT INTO Ordrer (ordre_dato, ordre_status, FK_kunde_id) VALUES (GETDATE(), 1, @kundeid);
        SELECT SCOPE_IDENTITY()";
            cmd.Parameters.Add("@kundeid", SqlDbType.Int).Value = Kundeid;
            conn.Open();
            object OrdreId = cmd.ExecuteScalar();
            conn.Close();

            cmd.CommandText = @"INSERT INTO OrdreLinjer (FK_ordre_id, FK_produkt_id, antal, pris) VALUES (@ordreid, @produktid, @antal, @pris)";
            cmd.Parameters.Add("@ordreid", SqlDbType.Int).Value = OrdreId;
            cmd.Parameters.Add("@produktid", SqlDbType.VarChar);
            cmd.Parameters.Add("@antal", SqlDbType.Int);
            cmd.Parameters.Add("@pris", SqlDbType.Decimal);
            conn.Open();

            foreach (DataRow varenIKurven in test.get_kurv().Rows)
            {
                cmd.Parameters["@produktid"].Value = varenIKurven["produktid"];
                cmd.Parameters["@antal"].Value = varenIKurven["antal"];
                cmd.Parameters["@pris"].Value = varenIKurven["pris"];
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            Response.Redirect("Samlede_ordrer.aspx");
        }
    }
}