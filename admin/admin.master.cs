using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.Cookies["admincookie"] != null || Session["adminemail"] != null)
        {
            link_loginout.Text = "Logout";
        }
        else
        {
            link_loginout.Text = "Login";
            Response.Redirect("adminlogin.aspx");
        }

    }

    protected void link_loginout_Click(object sender, EventArgs e)
    {
        if(link_loginout.Text == "Logout")
        {
            Response.Cookies["admincookie"].Expires = DateTime.Now.AddYears(-1);
            Session.Clear();
            Response.Redirect("adminlogin.aspx");
            
        }
    }
}
