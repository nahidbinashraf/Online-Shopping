using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        getproduct();
    }

    //method for retriving the product info 
    public void getproduct()
    {
        string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        using(SqlConnection con = new SqlConnection(s))
        {
            SqlCommand cmd = new SqlCommand("select top 6 * from product", con);
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                if (tb == null)
                {
                    pnl_noproducterror.Visible = true;
                    lbl_error.Text = "Cuurent now there is no product";
                }
                else
                {
                    ad.Fill(tb);
                    product_show.DataSource = tb;
                    product_show.DataBind();
                }
            }
            catch
            {
                pnl_noproducterror.Visible = true;
                lbl_error.Text = "Something went wrong";
            }

        }


    }
}