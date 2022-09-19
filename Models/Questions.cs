using StackOverFlow.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackOverFlow.Models;

namespace StackOverFlow.Models
{
    public class Questions
    {
        public int questionID;
        public string questionTitle;
        public string questionBody;
        public int quesVoteCount;
        public DateTime postDate;
        public List<Tags> tagsList=new List<Tags>();
        public List<Answers> answers = new List<Answers>();
        Questions_DAL questions_DAL_Obj = new Questions_DAL();

        public Questions(int _questionId, string _questionTitle, string _questionBody, int _quesVoteCount, DateTime _postDate, List<Tags> _tags, List<Answers> _answers)
        {
            questionID = _questionId;
            questionTitle = _questionTitle;
            questionBody =_questionBody;
            quesVoteCount = _quesVoteCount;
            postDate = _postDate;
            tagsList = _tags;
            answers = _answers;
        }

        public Questions(string _name, string _questionBody, int _quesVoteCount, DateTime _postDate, List<string> selectedTags)
        {
            questionTitle = _name;
            questionBody = _questionBody;
            quesVoteCount = _quesVoteCount;
            postDate = _postDate;

            int count = 0;
            foreach (var item in selectedTags)
            {
                Tags tempTag = new Tags();
                tempTag.tagName = item;
                tempTag.tagID = questions_DAL_Obj.getTagID(item);
                tagsList.Add(tempTag);
                count++;
            }
        }

        public Questions(Dictionary<string, object> childRow)
        {
            questionID = int.Parse(childRow["QuestionID"].ToString());
            questionTitle = childRow["questionTitle"].ToString();
            questionBody = childRow["questionBody"].ToString();
            quesVoteCount = int.Parse(childRow["voteCount"].ToString());
            postDate = Convert.ToDateTime(childRow["postdate"].ToString());
           
            List<int> allTagsIDs = new List<int>();

            allTagsIDs = questions_DAL_Obj.getAllTagsIDs(int.Parse(childRow["QuestionID"].ToString()));

            //int count = 0;
            foreach (var item in allTagsIDs)
            {
                Tags tempTag = new Tags();
                tempTag.tagID = item;
                tempTag.tagName = questions_DAL_Obj.getTagsName(item);

                tagsList.Add(tempTag);
                //count++;                
            }
        }

        public Questions()
        {

        }
        public List<Questions> getAllQuestions()
        {
            return questions_DAL_Obj.getAllQuestions();
        }
    }
}