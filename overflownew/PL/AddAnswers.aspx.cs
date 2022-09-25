using StackOverFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StackOverFlow.PL
{
    public partial class AddAnswers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Question question = new Question();
            Session["QuestionID"] = question.GetQuestionID(question);

        }
        protected void AddAnswer_Click(object sender, EventArgs e)
        {
            
            Answers answers = new Answers(desc.Value);
            //addQuestionStatus.Visible = true;
            int uid = Convert.ToInt32(Session["UserID"]);
            int qid= Convert.ToInt32(Session["QuestionID"]);
            addQuestionStatus.Text = answers.AddAns(answers,uid,qid);

            if (addQuestionStatus.Text == "Answer added succesfully")
            {
                Response.Redirect("Questions.aspx");
            }
        }
    }
}