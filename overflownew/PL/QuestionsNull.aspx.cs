using StackOverFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StackOverFlow.PL
{
    public partial class QuestionsNull : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserID"] == null)
            //{
            //    Response.Redirect("SigninPage.aspx");
            //}

            
        }

        

    [WebMethod]
        public static List<Question> GetAllQuestion()
        {
            Question question = new Question();
            return question.GetAllQuest();
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("SigninPage.aspx");
        }
        protected void Signup_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignupPage.aspx");
        }
        //protected void AskQuestion_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("AddQuestionPage.aspx");
        //}


    }
}