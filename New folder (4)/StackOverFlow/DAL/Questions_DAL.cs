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
}