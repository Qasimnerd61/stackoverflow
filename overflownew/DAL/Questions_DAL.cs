using StackOverFlow.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StackOverFlow.DAL
{
    public class Questions_DAL
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
        public List<Question> GetAllQuestions()
        {
            sqlCon.Open();
            SqlCommand sqlCmd_getAllMovies = new SqlCommand("getAllQuestions", sqlCon);
            sqlCmd_getAllMovies.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd_getAllMovies);
            DataTable table = new DataTable();
            adapter.Fill(table);

            List<Question> allQuestionsList = new List<Question>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                allQuestionsList.Add(new Question(childRow));
            }
            sqlCon.Close();
           
            return allQuestionsList;
        }

        public List<int> GetAllTagsIDs(int questionID)
        {
            SqlCommand sqlCmd_getAllGenreIDs = new SqlCommand("getAllTagsIDs", sqlCon);
            sqlCmd_getAllGenreIDs.CommandType = CommandType.StoredProcedure;
            sqlCmd_getAllGenreIDs.Parameters.Add(new SqlParameter("@questionid", questionID));

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd_getAllGenreIDs);
            DataTable table = new DataTable();
            adapter.Fill(table);

            List<int> allTagsIDs = new List<int>();

            //Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                //childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    allTagsIDs.Add(int.Parse(row[col].ToString()));
                }

            }
            return allTagsIDs;
        }
        public string GetTagsName(int selectedTagID)
        {
            sqlCon.Open();

            SqlCommand sqlCmd_getGenreName = new SqlCommand("getTagName", sqlCon);
            sqlCmd_getGenreName.CommandType = CommandType.StoredProcedure;
            sqlCmd_getGenreName.Parameters.Add(new SqlParameter("@tagid", selectedTagID));
            string tagName = sqlCmd_getGenreName.ExecuteScalar().ToString();
            sqlCon.Close();
            return tagName;
        }

        public int GetTagID(string selectedTagName)
        {
            sqlCon.Open();

            SqlCommand sqlCmd_getGenreID = new SqlCommand("getTagID", sqlCon);
            sqlCmd_getGenreID.CommandType = CommandType.StoredProcedure;
            sqlCmd_getGenreID.Parameters.Add(new SqlParameter("@tagname", selectedTagName));

            int genreID = Convert.ToInt32(sqlCmd_getGenreID.ExecuteScalar());
            sqlCon.Close();
            return genreID;
        }

        public int GetQuestionID(Question question)
        {
            sqlCon.Open();
            SqlCommand sqlCmd_getMovieID = new SqlCommand("getQuestionID", sqlCon);
            sqlCmd_getMovieID.CommandType = CommandType.StoredProcedure;
            sqlCmd_getMovieID.Parameters.Add(new SqlParameter("@questiontitle", question.questionTitle));

            int getQuestionID = Convert.ToInt32(sqlCmd_getMovieID.ExecuteScalar());
            HttpContext.Current.Session["QuestionID"] = getQuestionID;
            sqlCon.Close();

            return getQuestionID;
        }
        public string AddQuestion(Question question,int id)
        {
            sqlCon.Open();
            //User loggeduser = new User(null);
            SqlCommand sqlCmd_addQuestion = new SqlCommand("AddQuestion", sqlCon);
            sqlCmd_addQuestion.CommandType = CommandType.StoredProcedure;
            sqlCmd_addQuestion.Parameters.Add(new SqlParameter("@questiontitle", question.questionTitle));
            sqlCmd_addQuestion.Parameters.Add(new SqlParameter("@questionbody", question.questionBody));
            sqlCmd_addQuestion.Parameters.Add(new SqlParameter("@userid", id));

            SqlCommand sqlCmd_checkQuestionExistance = new SqlCommand("checkQuestionExistance", sqlCon);
            sqlCmd_checkQuestionExistance.CommandType = CommandType.StoredProcedure;
            sqlCmd_checkQuestionExistance.Parameters.Add(new SqlParameter("@questiontitle", question.questionTitle));
            int checkQuestionExistance = Convert.ToInt32(sqlCmd_checkQuestionExistance.ExecuteScalar());
            if (checkQuestionExistance > 0)
            {
                sqlCon.Close();
                string statusM = "<script>alert('Question Already Exists')</script>";
                return statusM;
            }
            else
            {
                sqlCmd_addQuestion.ExecuteNonQuery();
                SqlCommand sqlCmd_getMovieID = new SqlCommand("getQuestionID", sqlCon);
                sqlCmd_getMovieID.CommandType = CommandType.StoredProcedure;
                sqlCmd_getMovieID.Parameters.Add(new SqlParameter("@questiontitle", question.questionTitle));
              
                int getQuestionID = Convert.ToInt32(sqlCmd_getMovieID.ExecuteScalar());
                HttpContext.Current.Session["QuestionID"] = getQuestionID;
                SqlCommand sqlCmd_SaveMovieGenres = new SqlCommand("SaveQuestionTags", sqlCon);
                sqlCmd_SaveMovieGenres.CommandType = CommandType.StoredProcedure;
                sqlCmd_SaveMovieGenres.Parameters.Add(new SqlParameter("@questionid", getQuestionID));
                for (int i = 0; i < question.tagsList.Count; i++)
                {
                    sqlCmd_SaveMovieGenres.Parameters.Add(new SqlParameter("@tagid", question.tagsList[i].tagID));
                    sqlCmd_SaveMovieGenres.ExecuteNonQuery();
                    sqlCmd_SaveMovieGenres.Parameters.RemoveAt("@tagid");
                    //sqlCmd_addMovie.Parameters.Add(new SqlParameter)
                }

                sqlCon.Close();
                return "Question added succesfully";
            }

        }
        public List<Question> getSearchedQuestion(string searchField)
        {
            //SqlConnection sqlCon = new SqlConnection(@"Server=CMDLHRLT670; Data Source=CMDLHRLT670;initial Catalog=OnlineMovieSystem; Integrated Security=true;");

            sqlCon.Open();

            SqlCommand sqlCmd_getSearchedMovies = new SqlCommand("getSearchedQuestion", sqlCon);
            sqlCmd_getSearchedMovies.CommandType = CommandType.StoredProcedure;
            sqlCmd_getSearchedMovies.Parameters.Add(new SqlParameter("@searchField", searchField));

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd_getSearchedMovies);
            DataTable table = new DataTable();
            adapter.Fill(table);

            List<Question> searchedMovieList = new List<Question>();
            //Movies
            //List<object> childRow;
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                searchedMovieList.Add(new Question(childRow));
            }
            sqlCon.Close();
            return searchedMovieList;
        }
        public List<Question> GetMyQs(int id)
        {
            sqlCon.Open();

            SqlCommand sqlCmd_getSearchedMovies = new SqlCommand("GetQuesttionsWRTUserID", sqlCon);
            sqlCmd_getSearchedMovies.CommandType = CommandType.StoredProcedure;
            sqlCmd_getSearchedMovies.Parameters.Add(new SqlParameter("@userid", id));

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd_getSearchedMovies);
            DataTable table = new DataTable();
            adapter.Fill(table);

            List<Question> searchedMovieList = new List<Question>();
            //Movies
            //List<object> childRow;
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                searchedMovieList.Add(new Question(childRow));
            }
            sqlCon.Close();
            return searchedMovieList;
        }
    }
}