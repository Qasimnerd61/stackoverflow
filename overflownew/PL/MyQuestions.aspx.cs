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
    public partial class MyQuestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["UserID"]);
            Label1.Text = id.ToString();
        }
     [WebMethod]
        public static List<Question> GetmyQuestion(int id)
        {
           
            Question question = new Question();
            return question.GetAllmyQuest(id);
        }
        //protected void My_Click(object sender, EventArgs e)
        //{
        //}
    }
}