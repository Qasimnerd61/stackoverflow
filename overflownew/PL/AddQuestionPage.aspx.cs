using StackOverFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StackOverFlow.PL
{
    public partial class AddQuestionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void addQuestion_Click(object sender, EventArgs e)
        {
            List<string> selectedGenres = new List<string>();

            for (int i = 0; i < genreCheckBoxList.Items.Count; i++)
            {
                if (genreCheckBoxList.Items[i].Selected)
                {
                    selectedGenres.Add(genreCheckBoxList.Items[i].Text);
                }
            }
            Question question = new Question(moviename.Value, selectedGenres, desc.Value);
            //addQuestionStatus.Visible = true;
            int id = Convert.ToInt32(Session["UserID"]);
            addQuestionStatus.Text = question.AddQuest(question,id);
            if(addQuestionStatus.Text== "Question added succesfully")
            {
                Response.Redirect("Questions.aspx");
            }
        }
    }
    }
