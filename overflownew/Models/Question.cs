using StackOverFlow.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackOverFlow.Models;

namespace StackOverFlow.Models
{
    public class Question
    {
        public int questionID;
        public string questionTitle;
        public string questionBody;
        public int quesVoteCount;
        public string postDate;
        public int userId;
        //public string email;
        public List<Tags> tagsList=new List<Tags>();
        public List<Answers> answers = new List<Answers>();
        Questions_DAL questions_DAL_Obj = new Questions_DAL();


        public Question(string _questionTitle, List<string> selectedTags, string _questionBody)
        {
            questionTitle = _questionTitle;
            int count = 0;
            foreach (var item in selectedTags)
            {
                Tags tempTag = new Tags();
                tempTag.tagName = item;
                tempTag.tagID = questions_DAL_Obj.GetTagID(item);
                tagsList.Add(tempTag);
                count++;
            }
            questionBody = _questionBody;
            //quesVoteCount = _quesVoteCount;
            //postDate = _postDate;

            
        }
        public Question(int _questionId, string _questionTitle, string _questionBody, int _quesVoteCount, string _postDate, List<Tags> _tags, List<Answers> _answers)
        {
            questionID = _questionId;
            questionTitle = _questionTitle;
            questionBody =_questionBody;
            quesVoteCount = _quesVoteCount;
            postDate = _postDate;
            tagsList = _tags;
            answers = _answers;
        }

      

        public Question(Dictionary<string, object> childRow)
        {
            questionID = int.Parse(childRow["QuestionID"].ToString());
            questionTitle = childRow["questionTitle"].ToString();
            questionBody = childRow["questionBody"].ToString();
            quesVoteCount = int.Parse(childRow["voteCount"].ToString());
            postDate = childRow["postdate"].ToString();

           
            List<int> allTagsIDs = new List<int>();

            allTagsIDs = questions_DAL_Obj.GetAllTagsIDs(int.Parse(childRow["QuestionID"].ToString()));

            //int count = 0;
            foreach (var item in allTagsIDs)
            {
                Tags tempTag = new Tags();
                tempTag.tagID = item;
                tempTag.tagName = questions_DAL_Obj.GetTagsName(item);

                tagsList.Add(tempTag);
                //count++;                
            }
            userId = int.Parse(childRow["UserID"].ToString());


        }

        public Question()
        {

        }
        public List<Question> GetAllQuest()
        {
            return questions_DAL_Obj.GetAllQuestions();
        }

        public List<Question> getSearchedQues(string searchField)
        {
            return questions_DAL_Obj.getSearchedQuestion(searchField);
        }
        public string AddQuest(Question question,int id)
        {
            //Movies_DAL movie_DAL_Obj = new Movies_DAL();
            return questions_DAL_Obj.AddQuestion(question,id);
        }
        public int GetQuestionID(Question id)
        {
            return questions_DAL_Obj.GetQuestionID(id);
        }
        public List<Question> GetAllmyQuest(int id)
        {
            return questions_DAL_Obj.GetMyQs(id);
        }
    }
}