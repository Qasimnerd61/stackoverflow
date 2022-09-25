using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using StackOverFlow.Models;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;

namespace StackOverFlow.PresentationLayer
{
    public partial class Questions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("QuestionsNull.aspx");
            }
        }

        [WebMethod]
        public  static List<Question> GetAllQuestion()
        {
            Question question = new Question();
            return question.GetAllQuest();
        }

        //protected void Login_Click(object sender, EventArgs e) 
        //{
        //    Response.Redirect("SigninPage.aspx");
        //}
        //protected void Signup_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("SignupPage.aspx");
        //}
        [WebMethod]
        public static List<Question> getSearchedQuestions(string searchField)
        {
            Question question = new Question();
            return question.getSearchedQues(searchField);
        }
        protected void AskQuestion_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddQuestionPage.aspx");
            //Session[]
        }
        protected void MyQuestions_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyQuestions.aspx");
        }


    }
}