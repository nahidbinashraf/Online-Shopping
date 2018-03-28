using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class admin_addproduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //for adding the product
    protected void btn_addproduct_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            if (upld_pimage.HasFile)
            {
                //get file extension
                string extnsion = Path.GetExtension(upld_pimage.FileName);
                if(extnsion.ToLower() != ".jpg" && extnsion.ToLower() != ".png")
                {
                    lbl_pimageerror.Visible = true;
                    lbl_pimageerror.Text = "Select a jpg or png image";
                }
                else
                {
                    int fileSize = upld_pimage.PostedFile.ContentLength;
                    if (fileSize > 2097152)
                    {
                        lbl_pimageerror.Visible = true;
                        lbl_pimageerror.Text = "Image size cannot be greater than 2 MB";
                    }
                    else
                    {
                        string prandomget, prandomuse;
                        prandomget = Path.GetRandomFileName();
                        upld_pimage.SaveAs(Server.MapPath("image/" + prandomget + upld_pimage.FileName.ToString()));
                        prandomuse = "image/" + prandomget+ upld_pimage.FileName.ToString();
                        // for database
                        string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                        using (SqlConnection con =  new SqlConnection(s))
                        {
                            SqlCommand cmd = new SqlCommand("spAddproduct", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@pname", txt_productname.Text);
                            cmd.Parameters.AddWithValue("@pdiscription", txt_productdiscription.Text);
                            cmd.Parameters.AddWithValue("@pquantity", txt_productquantity.Text);
                            cmd.Parameters.AddWithValue("@pprice", txt_productprice.Text);
                            cmd.Parameters.AddWithValue("@pimage", prandomuse.ToString());
                            try
                            {
                                con.Open();
                                int i = cmd.ExecuteNonQuery();
                                if (i < 0)
                                {
                                    pnl_addproducterror.Visible = true;
                                    lbl_error.Text = "Product has been not added ";
                                    txt_productname.Text = string.Empty;
                                    txt_productdiscription.Text = string.Empty;
                                    txt_productprice.Text = string.Empty;
                                    txt_productquantity.Text = string.Empty;
                                }
                                else
                                {
                                    pnl_addproducterror.Visible = true;
                                    lbl_error.Text = "Product Added succesfully";
                                    txt_productname.Text = string.Empty;
                                    txt_productdiscription.Text = string.Empty;
                                    txt_productprice.Text = string.Empty;
                                    txt_productquantity.Text = string.Empty;
                                }
                            }
                            catch(Exception ex)
                            {

                            }
                        }
                    }

                }
            }
            else
            {
                lbl_pimageerror.Visible = true;
                lbl_pimageerror.Text = "Please select an image";
            }
        }
        else
        {
            pnl_addproducterror.Visible = true;
            lbl_error.Text = "Please enter all the requiremnts";
            pnl_addproducterror.Focus();
        }
    }
}