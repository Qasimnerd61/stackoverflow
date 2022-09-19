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
        public List<Questions> getAllQuestions()
        {
            sqlCon.Open();
            SqlCommand sqlCmd_getAllMovies = new SqlCommand("getAllQuestions", sqlCon);
            sqlCmd_getAllMovies.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd_getAllMovies);
            DataTable table = new DataTable();
            adapter.Fill(table);

            List<Questions> allQuestionsList = new List<Questions>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                allQuestionsList.Add(new Questions(childRow));
            }
            sqlCon.Close();
            return allQuestionsList;
        }

        public List<int> getAllTagsIDs(int questionID)
        {
            SqlCommand sqlCmd_getAllGenreIDs = new SqlCommand("getAllTagsIDs", sqlCon);
            sqlCmd_getAllGenreIDs.CommandType = CommandType.StoredProcedure;
            sqlCmd_getAllGenreIDs.Parameters.Add(new SqlParameter("@movieid", questionID));

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
        public string getTagsName(int selectedTagID)
        {
            sqlCon.Open();

            SqlCommand sqlCmd_getGenreName = new SqlCommand("getTagName", sqlCon);
            sqlCmd_getGenreName.CommandType = CommandType.StoredProcedure;
            sqlCmd_getGenreName.Parameters.Add(new SqlParameter("@tagid", selectedTagID));
            string tagName = sqlCmd_getGenreName.ExecuteScalar().ToString();
            sqlCon.Close();
            return tagName;
        }

        public int getTagID(string selectedTagName)
        {
            sqlCon.Open();

            SqlCommand sqlCmd_getGenreID = new SqlCommand("getTagID", sqlCon);
            sqlCmd_getGenreID.CommandType = CommandType.StoredProcedure;
            sqlCmd_getGenreID.Parameters.Add(new SqlParameter("@tagname", selectedTagName));

            int genreID = Convert.ToInt32(sqlCmd_getGenreID.ExecuteScalar());
            sqlCon.Close();
            return genreID;
        }
    }
}