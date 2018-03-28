using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class deletecart : System.Web.UI.Page
{
    //for adding in cart again
    string producat_name, product_quantity, product_price, product_image;
    string cookievalue, pervalue;
    string[] getvalue = new string[5];
    int id;
    int count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Convert.ToInt32(Request.QueryString["dcart"].ToString());
        DataTable tb = new DataTable();
        tb.Rows.Clear();
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
        }
        tb.Rows.RemoveAt(id);
        Response.Cookies["addcart"].Expires = DateTime.Now.AddDays(-10);
        Response.Cookies["addcart"].Expires = DateTime.Now.AddDays(-30);
        foreach (DataRow rd in tb.Rows)
        {
            producat_name = rd["product_name"].ToString();
            product_quantity = rd["product_quantity"].ToString();
            product_price = rd["product_price"].ToString();
            product_image = rd["product_image"].ToString();
            count = count + 1;
            if (count == 1)
            {
                Response.Cookies["addcart"].Value = producat_name.ToString() + "," + product_quantity.ToString() + "," + product_price.ToString() + "," + product_image.ToString();
                Response.Cookies["addcart"].Expires = DateTime.Now.AddHours(5);
            }
            else
            {
                Response.Cookies["addcart"].Value = Request.Cookies["addcart"].Value + "|" + producat_name.ToString() + "," + product_quantity.ToString() + "," + product_price.ToString() + "," + product_image.ToString();
                Response.Cookies["addcart"].Expires = DateTime.Now.AddHours(5);
            }
            
        }
        Response.Redirect("viewcart.aspx");
    }
}