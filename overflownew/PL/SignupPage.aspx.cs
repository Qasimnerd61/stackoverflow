using StackOverFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StackOverFlow.PL
{
    public partial class SignupPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void signup_Click(object sender, EventArgs e)
        {
            //login_BL login_BL_Obj = new login_BL();
            User userObj = new User(firstname.Value, lastname.Value,int.Parse(age.Value), username.Value, email.Value, password.Value);
            lblsignupStatus.Visible = true;
            lblsignupStatus.Text = userObj.Signup(userObj);
            if (lblsignupStatus.Text == "Signup Successful")
            {
                Response.Redirect("SigninPage.aspx");
            }
        }
    }
}