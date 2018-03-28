using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public partial class productdetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["pid"] != null)
        {
            int getpid = Convert.ToInt32(Request.QueryString["pid"]);
            getproductdetails(getpid);
        }
        else
        {
            Response.Redirect("index.aspx");
        }
    }

    string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
    //method for retriving the product info details
    public void getproductdetails(int id)
    {
        using (SqlConnection con = new SqlConnection(s))
        {
            SqlCommand cmd = new SqlCommand("select * from product where id=@pid", con);
            cmd.Parameters.AddWithValue("@pid", id);
            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    product_details.DataSource = rd;
                    product_details.DataBind();

                }
                else
                {
                    btn_addcart.Visible = false;
                    pnl_noproducterror.Visible = true;
                    lbl_error.Text = "There is no product details for this request";
                }
            }
            catch
            {
                btn_addcart.Visible = false;
                pnl_noproducterror.Visible = true;
                lbl_error.Text = "Something went wrong";
            }
        }
    }

    //for adding in cart 
    string producat_name, product_quantity, product_price, product_image; 
    protected void btn_addcart_Click(object sender, EventArgs e)
    {
        int getpid = Convert.ToInt32(Request.QueryString["pid"]);
        using (SqlConnection con = new SqlConnection(s))
        {
            SqlCommand cmd = new SqlCommand("select * from product where id=@pid", con);
            cmd.Parameters.AddWithValue("@pid", getpid);
            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    producat_name = rd["product_name"].ToString();
                    product_quantity = rd["product_quantity"].ToString();
                    product_price = rd["product_price"].ToString();
                    product_image = rd["product_image"].ToString();
                    // Check if the browser supports cookies
                    if (Request.Browser.Cookies)
                    {
                        if(Request.Cookies["addcart"] == null)
                        {
                            Response.Cookies["addcart"].Value = producat_name.ToString() +  "," + product_quantity.ToString() + "," + product_price.ToString() + "," + product_image.ToString();
                            Response.Cookies["addcart"].Expires = DateTime.Now.AddHours(5);
                           
                        }
                        else
                        {
                            Response.Cookies["addcart"].Value = Request.Cookies["addcart"].Value + "|" + producat_name.ToString() + "," + product_quantity.ToString() + "," + product_price.ToString() + "," + product_image.ToString();
                            Response.Cookies["addcart"].Expires = DateTime.Now.AddHours(5);
                        }
                    }
                    else
                    {
                        pnl_noproducterror.Visible = true;
                        lbl_error.Text = "Your browser don't support cookies.Fo this fail to add cart";
                    }
                }
                else
                {
                    pnl_noproducterror.Visible = true;
                    lbl_error.Text = "There is no product details for this request to add";
                }
            }
            catch
            {
                btn_addcart.Visible = false;
                pnl_noproducterror.Visible = true;
                lbl_error.Text = "Something went wrong";
            }
        }
    }
}