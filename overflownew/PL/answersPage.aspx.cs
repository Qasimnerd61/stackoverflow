using StackOverFlow.DAL;
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
    
    public partial class answersPage : System.Web.UI.Page
    {
        Answers_DAL answer = new Answers_DAL();
        static int question_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["questionID"] != null && Request.QueryString["questionID"] != string.Empty)
            {
                question_id = Convert.ToInt32(Request.QueryString["questionID"]);
                Label1.Text = question_id.ToString();

            }
            
        }
        [WebMethod]
        public static Question GetQuestion(string id)
        {
            
            Answers question = new Answers();
           
            return question.GetQues(int.Parse(id));
        }
        [WebMethod]
        public static List<Answers> GetAnswers1(string id)
        {
            Answers question = new Answers();

            return question.GetAns(int.Parse(id));
        }
        protected void AddAnswer_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAnswers.aspx");
        }


    }
}