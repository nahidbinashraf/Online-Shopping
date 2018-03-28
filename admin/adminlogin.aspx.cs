using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class admin_adminlogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // check wheter cookies or session is enabled if then redirect to index page 
        if (!IsPostBack)
        {
            if(Request.Cookies["admincookie"] != null)
            {
                Response.Redirect("index.aspx");
            }
            else if(Session["adminemail"] != null)
            {
                Response.Redirect("index.aspx");
            }          
        }
    }

    // btn login click for login check 
    protected void btn_login_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spAdminlogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", txt_email.Text);
                cmd.Parameters.AddWithValue("@password", txt_password.Text);
                try
                {
                    con.Open();
                    int i = (int)cmd.ExecuteScalar();
                    if (i == 1)
                    {
                        if (chk_remeberme.Checked)
                        {
                            HttpCookie admin = new HttpCookie ("admincookie"); //creating cookie name
                            admin["email"] = txt_email.Text; // set cookie emailname as email.text
                            admin.Expires.AddYears(3);
                            Response.Cookies.Add(admin); //response in browser
                            Response.Redirect("index.aspx");
                        }
                        else
                        {
                            Session["adminemail"] = txt_email.Text;
                            Response.Redirect("index.aspx");
                        }
                    }
                    else
                    {
                        panel_loginerror.Visible = true;
                        lbl_error.Text = "Use correct email and password";
                        txt_email.Focus();
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        else
        {
            panel_loginerror.Visible = true;
            lbl_error.Text = "Fill email and password to login";
            txt_email.Focus();
        }


    }
}