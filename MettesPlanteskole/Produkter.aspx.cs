using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MettesPlanteskole
{
    public partial class Produkter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd2 = new SqlCommand("SELECT category_id, category_name FROM category"))
                    {
                        cmd2.CommandType = CommandType.Text;
                        cmd2.Connection = conn;
                        conn.Open();
                        DropDownList_Categorys.DataSource = cmd2.ExecuteReader();
                        DropDownList_Categorys.DataTextField = "category_name";
                        DropDownList_Categorys.DataValueField = "category_id";
                        DropDownList_Categorys.DataBind();
                        conn.Close();
                    }
                }
                DropDownList_Categorys.Items.Insert(0, new ListItem("--Vælg kategori--", "0"));
            }
        }

        protected void Button_Opret_Click(object sender, EventArgs e)
        {
            string pris = TextBox_Price.Text;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"INSERT INTO products(product_name, FK_category_id, product_price, product_storage, product_min_storage, product_max_storage, product_recomended_dirt, product_growthtime, product_image_1, product_image_2, product_image_3, product_description, product_number) VALUES (@name, @fk_category, @price, @storage, @min_storage, @max_storage, @recomended_dirt, @growthtime, @image1, @image2, @image3, @description, @number);";
            cmd.Parameters.AddWithValue("@name", TextBox_Name.Text);
            cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(pris));
            cmd.Parameters.AddWithValue("@storage", TextBox_Storage.Text);
            cmd.Parameters.AddWithValue("@min_storage", TextBox_Min_Storage.Text);
            cmd.Parameters.AddWithValue("@max_storage", TextBox_Max_Storage.Text);
            cmd.Parameters.AddWithValue("@recomended_dirt", TextBox_Dirt.Text);
            cmd.Parameters.AddWithValue("@growthtime", TextBox_Time.Text);
            cmd.Parameters.AddWithValue("@description", TextBox_Description.Text);
            cmd.Parameters.AddWithValue("@number", TextBox_Productnumber.Text);
            cmd.Parameters.AddWithValue("@fk_category", DropDownList_Categorys.SelectedValue);

            //database sti til billede
            string bill_sti = "intetbillede.jpg";

            //Hvis der er en fil i FilUploaden
            #region image1
            if (FileUpload_Img1.HasFile)
            {
                //NewGuid danner uniq navn for billeder
                bill_sti = Guid.NewGuid() + Path.GetExtension(FileUpload_Img1.FileName);
                // Opret
                String UploadeMappe = Server.MapPath("~/images/resizer/Original_Images/");
                String CroppedMappe = Server.MapPath("~/images/resizer/Croppede/");
                String Filnavn = DateTime.Now.ToFileTime() + FileUpload_Img1.FileName;
                bill_sti = Filnavn;

                //Gem det orginale Billede
                FileUpload_Img1.SaveAs(UploadeMappe + Filnavn);

                // Definer hvordan
                ImageResizer.ResizeSettings BilledeSkalering = new ImageResizer.ResizeSettings();
                //Lav nogle nye skalerings instillinger
                BilledeSkalering = new ImageResizer.ResizeSettings();
                BilledeSkalering.Width = 120;
                BilledeSkalering.Height = 90;
                BilledeSkalering.Mode = ImageResizer.FitMode.Crop;

                //Udfør selve skaleringen
                ImageResizer.ImageBuilder.Current.Build(UploadeMappe + Filnavn, CroppedMappe + Filnavn, BilledeSkalering);

            }
            // Tildel parameter-værdierne, fra input felterne.
            cmd.Parameters.AddWithValue("@image1", bill_sti);
            #endregion
            #region image2
            if (FileUpload_Img2.HasFile)
            {
                //NewGuid danner uniq navn for billeder
                bill_sti = Guid.NewGuid() + Path.GetExtension(FileUpload_Img2.FileName);
                // Opret
                String UploadeMappe = Server.MapPath("~/images/resizer/Original_Images/");
                String CroppedMappe = Server.MapPath("~/images/resizer/Croppede/");
                String Filnavn = DateTime.Now.ToFileTime() + FileUpload_Img2.FileName;
                bill_sti = Filnavn;

                //Gem det orginale Billede
                FileUpload_Img2.SaveAs(UploadeMappe + Filnavn);

                // Definer hvordan
                ImageResizer.ResizeSettings BilledeSkalering = new ImageResizer.ResizeSettings();
                //Lav nogle nye skalerings instillinger
                BilledeSkalering = new ImageResizer.ResizeSettings();
                BilledeSkalering.Width = 90;
                BilledeSkalering.Height = 120;
                BilledeSkalering.Mode = ImageResizer.FitMode.Crop;

                //Udfør selve skaleringen
                ImageResizer.ImageBuilder.Current.Build(UploadeMappe + Filnavn, CroppedMappe + Filnavn, BilledeSkalering);

            }
            // Tildel parameter-værdierne, fra input felterne.
            cmd.Parameters.AddWithValue("@image2", bill_sti);
            #endregion
            #region image3
            if (FileUpload_Img3.HasFile)
            {
                //NewGuid danner uniq navn for billeder
                bill_sti = Guid.NewGuid() + Path.GetExtension(FileUpload_Img3.FileName);
                // Opret
                String UploadeMappe = Server.MapPath("~/images/resizer/Original_Images/");
                String CroppedMappe = Server.MapPath("~/images/resizer/Croppede/");
                String Filnavn = DateTime.Now.ToFileTime() + FileUpload_Img3.FileName;
                bill_sti = Filnavn;

                //Gem det orginale Billede
                FileUpload_Img3.SaveAs(UploadeMappe + Filnavn);

                // Definer hvordan
                ImageResizer.ResizeSettings BilledeSkalering = new ImageResizer.ResizeSettings();
                //Lav nogle nye skalerings instillinger
                BilledeSkalering = new ImageResizer.ResizeSettings();
                BilledeSkalering.Width = 90;
                BilledeSkalering.Height = 120;
                BilledeSkalering.Mode = ImageResizer.FitMode.Crop;

                //Udfør selve skaleringen
                ImageResizer.ImageBuilder.Current.Build(UploadeMappe + Filnavn, CroppedMappe + Filnavn, BilledeSkalering);

            }
            // Tildel parameter-værdierne, fra input felterne.
            cmd.Parameters.AddWithValue("@image3", bill_sti);
            #endregion

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("Produkter.aspx");
        }
        protected void Repeater_Vis_Vare_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Slet")
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = @"DELETE FROM products WHERE product_id = @product_id";
                cmd.Parameters.AddWithValue("@product_id", e.CommandArgument);

                HiddenField img1 = e.Item.FindControl("HiddenField_img_slet1") as HiddenField;
                string product_image1 = img1.Value.ToString();
                File.Delete(Server.MapPath("~/images/resizer/Croppede/" + product_image1));
                File.Delete(Server.MapPath("~/images/resizer/Original_Images/" + product_image1));

                HiddenField img2 = e.Item.FindControl("HiddenField_img_slet2") as HiddenField;
                string product_image2 = img2.Value.ToString();
                File.Delete(Server.MapPath("~/images/resizer/Croppede/" + product_image2));
                File.Delete(Server.MapPath("~/images/resizer/Original_Images/" + product_image2));

                HiddenField img3 = e.Item.FindControl("HiddenField_img_slet3") as HiddenField;
                string product_image3 = img3.Value.ToString();
                File.Delete(Server.MapPath("~/images/resizer/Croppede/" + product_image3));
                File.Delete(Server.MapPath("~/images/resizer/Original_Images/" + product_image3));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Response.Redirect("Produkter.aspx");
            }

            if (e.CommandName == "Ret")
            {
                Button_Gem_Ret.Visible = true;
                Button_Opret.Visible = false;
                Image_Ret1.Visible = true;
                Image_Ret2.Visible = true;
                Image_Ret3.Visible = true;

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                SqlCommand cmd = new SqlCommand("SELECT * FROM products WHERE product_id = @product_id", conn);
                cmd.Parameters.AddWithValue("@product_id", e.CommandArgument);
                ViewState["product_id"] = e.CommandArgument;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    //skriver de hentede værdier til formular felterne
                    TextBox_Name.Text = reader["product_name"].ToString();
                    TextBox_Productnumber.Text = reader["product_number"].ToString();
                    TextBox_Price.Text = reader["product_price"].ToString();
                    TextBox_Storage.Text = reader["product_storage"].ToString();
                    TextBox_Min_Storage.Text = reader["product_min_storage"].ToString();
                    TextBox_Max_Storage.Text = reader["product_max_storage"].ToString();
                    TextBox_Dirt.Text = reader["product_recomended_dirt"].ToString();
                    TextBox_Time.Text = reader["product_growthtime"].ToString();
                    TextBox_Description.Text = reader["product_description"].ToString();
                    DropDownList_Categorys.Text = reader["FK_category_id"].ToString();
                    Image_Ret1.ImageUrl = "~/images/resizer/Croppede/" + reader["product_image_1"].ToString();
                    Image_Ret2.ImageUrl = "~/images/resizer/Croppede/" + reader["product_image_2"].ToString();
                    Image_Ret3.ImageUrl = "~/images/resizer/Croppede/" + reader["product_image_3"].ToString();
                    HiddenField_oldImage1.Value = reader["product_image_1"].ToString();
                    HiddenField_oldImage2.Value = reader["product_image_2"].ToString();
                    HiddenField_oldImage3.Value = reader["product_image_3"].ToString();
                }
                conn.Close();
            }
        }
        protected void Button_Gem_Ret_Click(object sender, EventArgs e)
        {
            string pris = TextBox_Price.Text;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"UPDATE products SET product_name = @name, FK_category_id = @fk_category, product_price = @price, product_storage = @storage, product_min_storage = @min_storage, product_max_storage = @max_storage, product_recomended_dirt = @dirt, product_growthtime = @growthtime, product_image_1 = @image1, product_image_2 = @image2, product_image_3 = @image3, product_description = @description, product_number = @number WHERE product_id = @product_id";

            cmd.Parameters.AddWithValue("@product_id", ViewState["product_id"]);
            cmd.Parameters.AddWithValue("@name", TextBox_Name.Text);
            cmd.Parameters.AddWithValue("@number", TextBox_Productnumber.Text);
            cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(pris));
            cmd.Parameters.AddWithValue("@storage", TextBox_Storage.Text);
            cmd.Parameters.AddWithValue("@min_storage", TextBox_Min_Storage.Text);
            cmd.Parameters.AddWithValue("@max_storage", TextBox_Max_Storage.Text);
            cmd.Parameters.AddWithValue("@dirt", TextBox_Dirt.Text);
            cmd.Parameters.AddWithValue("@growthtime", TextBox_Time.Text);
            cmd.Parameters.AddWithValue("@description", TextBox_Description.Text);
            cmd.Parameters.AddWithValue("@fk_category", DropDownList_Categorys.SelectedValue);


            #region Image 1
            string product_image1 = HiddenField_oldImage1.Value;
            if (FileUpload_Img1.HasFile)
            {
                //NewGuid danner uniq navn for billeder
                product_image1 = Guid.NewGuid() + Path.GetExtension(FileUpload_Img1.FileName);
                // Opret
                String UploadeMappe = Server.MapPath("~/images/resizer/Original_Images/");
                String CroppedMappe = Server.MapPath("~/images/resizer/Croppede/");
                String Filnavn = DateTime.Now.ToFileTime() + FileUpload_Img1.FileName;
                product_image1 = Filnavn;

                //Gem det orginale Billede
                FileUpload_Img1.SaveAs(UploadeMappe + Filnavn);

                // Definer hvordan
                ImageResizer.ResizeSettings BilledeSkalering = new ImageResizer.ResizeSettings();
                //Lav nogle nye skalerings instillinger
                BilledeSkalering = new ImageResizer.ResizeSettings();
                BilledeSkalering.Width = 120;
                BilledeSkalering.Height = 90;

                //Udfør selve skaleringen
                ImageResizer.ImageBuilder.Current.Build(UploadeMappe + Filnavn, CroppedMappe + Filnavn, BilledeSkalering);

                string old_img = HiddenField_oldImage1.Value;
                if (File.Exists(Server.MapPath("~/images/resizer/Croppede/") + old_img))
                {
                    File.Delete(Server.MapPath("~/images/resizer/Croppede/") + old_img);
                }
                if (File.Exists(Server.MapPath("~/images/resizer/Original_Images/") + old_img))
                {
                    File.Delete(Server.MapPath("~/images/resizer/Original_Images/") + old_img);
                }
            }
            cmd.Parameters.AddWithValue("@image1", product_image1);
            #endregion
            #region image 2
            string product_image2 = HiddenField_oldImage2.Value;
            if (FileUpload_Img2.HasFile)
            {
                //NewGuid danner uniq navn for billeder
                product_image2 = Guid.NewGuid() + Path.GetExtension(FileUpload_Img2.FileName);
                // Opret
                String UploadeMappe = Server.MapPath("~/images/resizer/Original_Images/");
                String CroppedMappe = Server.MapPath("~/images/resizer/Croppede/");
                String Filnavn = DateTime.Now.ToFileTime() + FileUpload_Img2.FileName;
                product_image2 = Filnavn;

                //Gem det orginale Billede
                FileUpload_Img2.SaveAs(UploadeMappe + Filnavn);

                // Definer hvordan
                ImageResizer.ResizeSettings BilledeSkalering = new ImageResizer.ResizeSettings();
                //Lav nogle nye skalerings instillinger
                BilledeSkalering = new ImageResizer.ResizeSettings();
                BilledeSkalering.Width = 120;
                BilledeSkalering.Height = 90;

                //Udfør selve skaleringen
                ImageResizer.ImageBuilder.Current.Build(UploadeMappe + Filnavn, CroppedMappe + Filnavn, BilledeSkalering);

                string old_img = HiddenField_oldImage2.Value;
                if (File.Exists(Server.MapPath("~/images/resizer/Croppede/") + old_img))
                {
                    File.Delete(Server.MapPath("~/images/resizer/Croppede/") + old_img);
                }
                if (File.Exists(Server.MapPath("~/images/resizer/Original_Images/") + old_img))
                {
                    File.Delete(Server.MapPath("~/images/resizer/Original_Images/") + old_img);
                }
            }
            cmd.Parameters.AddWithValue("@image2", product_image2);
            #endregion
            #region Image 3
            string product_image3 = HiddenField_oldImage3.Value;
            if (FileUpload_Img3.HasFile)
            {
                //NewGuid danner uniq navn for billeder
                product_image3 = Guid.NewGuid() + Path.GetExtension(FileUpload_Img3.FileName);
                // Opret
                String UploadeMappe = Server.MapPath("~/images/resizer/Original_Images/");
                String CroppedMappe = Server.MapPath("~/images/resizer/Croppede/");
                String Filnavn = DateTime.Now.ToFileTime() + FileUpload_Img3.FileName;
                product_image3 = Filnavn;

                //Gem det orginale Billede
                FileUpload_Img3.SaveAs(UploadeMappe + Filnavn);

                // Definer hvordan
                ImageResizer.ResizeSettings BilledeSkalering = new ImageResizer.ResizeSettings();
                //Lav nogle nye skalerings instillinger
                BilledeSkalering = new ImageResizer.ResizeSettings();
                BilledeSkalering.Width = 120;
                BilledeSkalering.Height = 90;

                //Udfør selve skaleringen
                ImageResizer.ImageBuilder.Current.Build(UploadeMappe + Filnavn, CroppedMappe + Filnavn, BilledeSkalering);

                string old_img = HiddenField_oldImage3.Value;
                if (File.Exists(Server.MapPath("~/images/resizer/Croppede/") + old_img))
                {
                    File.Delete(Server.MapPath("~/images/resizer/Croppede/") + old_img);
                }
                if (File.Exists(Server.MapPath("~/images/resizer/Original_Images/") + old_img))
                {
                    File.Delete(Server.MapPath("~/images/resizer/Original_Images/") + old_img);
                }
            }
            cmd.Parameters.AddWithValue("@image3", product_image3);
            #endregion
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Produkter.aspx");
        }
    }
}