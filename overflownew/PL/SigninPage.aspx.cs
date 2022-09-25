using StackOverFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StackOverFlow.PL
{
    public partial class SigninPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User userObj = new User(null, null, 0, null, txtEmail.Text, txtPassword.Text);
            //To sign up admin, simply make admin object (instead of customer object) and call signup method of user class
            lblloginStatus.Text = userObj.login(userObj);
            lblloginStatus.Visible = true;

            if (lblloginStatus.Text == "Success")
            {
                Session["UserID"] = userObj.GetUserID(userObj);
                //Session["LoggedUser"] = userObj.getUserDetails(userObj);
                //lblloginStatus.Text = customerObj.login(customerObj) + Session["UserID"];
                Response.Redirect("Questions.aspx");
            }

        }
        protected void btnSignup_Click(object sender, EventArgs e)
        {
            //login_BL login_BL_Obj = new login_BL();
            Response.Redirect("SignupPage.aspx");

        }
    }
}