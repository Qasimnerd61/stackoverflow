using StackOverFlow.Models;
using StackOverFlow.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StackOverFlow.DAL
{
    public class Answers_DAL
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
        public Question GetQuestions(int id)
        {
            sqlCon.Open();

            SqlCommand sqlCmd_getGenreID = new SqlCommand("getQuestonWRTqID", sqlCon);
            sqlCmd_getGenreID.CommandType = CommandType.StoredProcedure;
            sqlCmd_getGenreID.Parameters.Add(new SqlParameter("@questionid", id));
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd_getGenreID);
            DataTable table = new DataTable();
            adapter.Fill(table);
            List<Question> questions = new List<Question>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                     Question question = new Question(childRow);
                questions.Add(question);
            }
            Question quest = questions[0];
            
            return quest;
        }
        public List<Answers> GetAnswers(int id)
        {
            sqlCon.Open();

            SqlCommand sqlCmd_getAllAnswers = new SqlCommand("answersWRTqustion", sqlCon);
            sqlCmd_getAllAnswers.CommandType = CommandType.StoredProcedure;
            sqlCmd_getAllAnswers.Parameters.Add(new SqlParameter("@questionid", id));
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd_getAllAnswers);
            DataTable table = new DataTable();
            adapter.Fill(table);

            List<Answers> allQuestionsList = new List<Answers>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                allQuestionsList.Add(new Answers(childRow));
            }
            sqlCon.Close();
            return allQuestionsList;
        }
        public string AddAnswer(Answers answer,int uid,int qid)
        {
            sqlCon.Open();
            SqlCommand sqlCmd_addQuestion = new SqlCommand("AddAnswer", sqlCon);
            sqlCmd_addQuestion.CommandType = CommandType.StoredProcedure;
            sqlCmd_addQuestion.Parameters.Add(new SqlParameter("@answerbody", answer.answerBody));
            sqlCmd_addQuestion.Parameters.Add(new SqlParameter("@userid", uid));
            sqlCmd_addQuestion.Parameters.Add(new SqlParameter("@questionid", answer.questionID));
            sqlCmd_addQuestion.ExecuteNonQuery();

            //SqlCommand sqlCmd_checkQuestionExistance = new SqlCommand("checkQuestionExistance", sqlCon);
            //sqlCmd_checkQuestionExistance.CommandType = CommandType.StoredProcedure;
            //sqlCmd_checkQuestionExistance.Parameters.Add(new SqlParameter("@questiontitle", question.questionTitle));
            //int checkQuestionExistance = Convert.ToInt32(sqlCmd_checkQuestionExistance.ExecuteScalar());
            //if (checkQuestionExistance > 0)
            //{
            //    sqlCon.Close();
            //    string statusM = "<script>alert('Question Already Exists')</script>";
            //    return statusM;
            //}
            //else
            //{
            //sqlCmd_addQuestion.ExecuteNonQuery();
            //SqlCommand sqlCmd_getMovieID = new SqlCommand("getQuestionID", sqlCon);
            //sqlCmd_getMovieID.CommandType = CommandType.StoredProcedure;
            //sqlCmd_getMovieID.Parameters.Add(new SqlParameter("@questiontitle", question.questionTitle));

            //int getQuestionID = Convert.ToInt32(sqlCmd_getMovieID.ExecuteScalar());
            //SqlCommand sqlCmd_SaveMovieGenres = new SqlCommand("SaveQuestionTags", sqlCon);
            //sqlCmd_SaveMovieGenres.CommandType = CommandType.StoredProcedure;
            //sqlCmd_SaveMovieGenres.Parameters.Add(new SqlParameter("@questionid", getQuestionID));
            //for (int i = 0; i < question.tagsList.Count; i++)
            //{
            //    sqlCmd_SaveMovieGenres.Parameters.Add(new SqlParameter("@tagid", question.tagsList[i].tagID));
            //    sqlCmd_SaveMovieGenres.ExecuteNonQuery();
            //    sqlCmd_SaveMovieGenres.Parameters.RemoveAt("@tagid");
            //    //sqlCmd_addMovie.Parameters.Add(new SqlParameter)
            //}

            sqlCon.Close();
                return "Answer added succesfully";
            }
        }
    }
    
