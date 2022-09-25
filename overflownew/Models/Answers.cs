using StackOverFlow.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace StackOverFlow.Models
{
    public class Answers
    {
        public int answerID;
        public string answerBody;
        public int ansVoteCount;
        public bool ansStatus;
        public string ansPostDate;
        public int userID;
        public int questionID;
        public string questionTitle;
        Answers_DAL answers_DAL_Obj = new Answers_DAL();
        public Question GetQues(int id)
        {
            return answers_DAL_Obj.GetQuestions(id);
        }
        public List<Answers> GetAns(int id)
        {
            return answers_DAL_Obj.GetAnswers(id);
        }
        public Answers(Dictionary<string, object> childRow)
        {
            answerID = int.Parse(childRow["AnswerID"].ToString());
            answerBody = childRow["answerBody"].ToString();
            ansVoteCount = int.Parse(childRow["ansvoteCount"].ToString());
            ansStatus = Convert.ToBoolean(childRow["ansStatus"].ToString());
            ansPostDate = childRow["postDate"].ToString();
            userID = int.Parse(childRow["UserID"].ToString());
            questionID= int.Parse(childRow["QuestionID"].ToString());

        }
        public Answers()
        {
            
        }
        public Answers(string _answerBody )
        {
            answerBody = _answerBody;
        }
        public string AddAns(Answers answer, int uid, int qid)
        {
            //Movies_DAL movie_DAL_Obj = new Movies_DAL();
            return answers_DAL_Obj.AddAnswer(answer,uid,qid);
        }
    }

}