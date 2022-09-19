using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverFlow.Models
{
    public class Questions
    {
        public int questionID;
        public string questionTitle;
        public string questionBody;
        public int quesVoteCount;
        public DateTime postDate;
        public List<Tags> tags=new List<Tags>();
        public List<Answers> answers = new List<Answers>();


        public Questions(int _questionId, string _questionTitle, string _questionBody, int _quesVoteCount, DateTime _postDate, List<Tags> _tags, List<Answers> _answers)
        {
            questionID = _questionId;
            questionTitle = _questionTitle;
            questionBody =_questionBody;
            quesVoteCount = _quesVoteCount;
            postDate = _postDate;
            tags = _tags;
            answers = _answers;
        }

        public Questions(Dictionary<string, object> childRow)
        {
            questionID = int.Parse(childRow["MovieID"].ToString());
            questionTitle = childRow["Name"].ToString();
            length = childRow["Length"].ToString();
            price = int.Parse(childRow["Price"].ToString());
            poster = childRow["Poster"].ToString();

            List<int> allGenreIDs = new List<int>();

            allGenreIDs = movies_DAL_Obj.getAllGenreIDs(int.Parse(childRow["MovieID"].ToString()));

            //int count = 0;
            foreach (var item in allGenreIDs)
            {
                Genres tempGenre = new Genres();
                tempGenre.ID = item;
                tempGenre.name = movies_DAL_Obj.getGenreName(item);

                genreList.Add(tempGenre);
                //count++;                
            }
        }
    }
}