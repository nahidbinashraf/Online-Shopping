using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class viewcart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
            getcartdetails();
        
        
    }


    string cookievalue, pervalue;
    string[] getvalue = new string[5];
    
    //method for retriving the product from cart
    public void getcartdetails()
    {
        DataTable tb = new DataTable();
        tb.Columns.Add("product_id");
        tb.Columns.Add("product_name");
        tb.Columns.Add("product_quantity");
        tb.Columns.Add("product_price");
        tb.Columns.Add("product_image");
        if (Request.Cookies["addcart"] != null)
        {
            cookievalue = Request.Cookies["addcart"].Value.ToString();
            string[] allvaluesplit = cookievalue.Split('|');
            for (int i = 0; i < allvaluesplit.Length; i++)
            {
                pervalue = allvaluesplit[i].ToString();
                string[] pervaluesplit = pervalue.Split(',');
                for (int j = 0; j < pervaluesplit.Length; j++)
                {
                    getvalue[j] = pervaluesplit[j].ToString();
                }
                tb.Rows.Add(i.ToString(), getvalue[0].ToString(), getvalue[1].ToString(), getvalue[2].ToString(), getvalue[3].ToString());
            }
            viewcart_details.DataSource = tb;
            viewcart_details.DataBind();

        }

        else
        {
            pnl_noviewcarterror.Visible = true;
            lbl_error.Text = "Your cart is empty right now";
        }
    }
   
}