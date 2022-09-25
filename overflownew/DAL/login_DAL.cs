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
    public class login_DAL
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);


        public string loginUser(User userObj)
        {

            sqlCon.Open();

            SqlCommand sqlCmd_loginUser = new SqlCommand("loginUser", sqlCon);
            sqlCmd_loginUser.CommandType = CommandType.StoredProcedure;
            sqlCmd_loginUser.Parameters.Add(new SqlParameter("@email", userObj.email));
            sqlCmd_loginUser.Parameters.Add(new SqlParameter("@password", userObj.password));

            int[] userExistance = checkUserExistance(userObj);

            if (userExistance[0] == 0)
            {
                sqlCon.Close();
                string status = "<script>alert('No Email Exists Sign up to register')</script>";
                return status;// +userExistance[1] + "int";

            }
            else
            {
                int passMatch = Convert.ToInt32(sqlCmd_loginUser.ExecuteScalar());

                if (passMatch == 1)
                {
                    sqlCon.Close();

                    return "Success";
                }
                else
                {
                    sqlCon.Close();
                    string statusP = "<script>alert('Wrong Password')</script>";
                    return statusP;
                }

            }
        }

        public int[] checkUserExistance(User userObj)
        {
           
            SqlCommand sqlCmd_checkEmailExistance = new SqlCommand("checkEmailExistance", sqlCon);
            sqlCmd_checkEmailExistance.CommandType = CommandType.StoredProcedure;
            sqlCmd_checkEmailExistance.Parameters.Add(new SqlParameter("@email", userObj.email));

            int[] userExistance = { Convert.ToInt32(Convert.ToInt32(sqlCmd_checkEmailExistance.ExecuteScalar())) };
            //sqlCon.Close();
            return userExistance;

        }

        public int GetUserId(User userobj)
        {
            sqlCon.Open();
            SqlCommand sqlCmd_getUserID = new SqlCommand("getUserID", sqlCon);
            sqlCmd_getUserID.CommandType = CommandType.StoredProcedure;
            sqlCmd_getUserID.Parameters.Add(new SqlParameter("@email", userobj.email));

            int userID = Convert.ToInt32(sqlCmd_getUserID.ExecuteScalar());
            HttpContext.Current.Session["UserID"] = userID;
            sqlCon.Close();
            return userID;
        }



        //public User getUserDetails(User userObj)
        //{

        //    sqlCon.Open();
        //    SqlCommand sqlCmd_getUserDetails = new SqlCommand("getUserDetails", sqlCon);
        //    sqlCmd_getUserDetails.CommandType = CommandType.StoredProcedure;
        //    sqlCmd_getUserDetails.Parameters.Add(new SqlParameter("@username", userObj.email));

        //    SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd_getUserDetails);
        //    DataTable table = new DataTable();
        //    adapter.Fill(table);

        //    Dictionary<string, object> childRow;
        //    User loggedUser = new User(null);
        //    foreach (DataRow row in table.Rows)
        //    {
        //        childRow = new Dictionary<string, object>();
        //        foreach (DataColumn col in table.Columns)
        //        {
        //            childRow.Add(col.ColumnName, row[col]);
        //        }
        //            loggedUser = new User(childRow);
                
        //        //loggedUser
        //    }
        //    sqlCon.Close();
        //    return loggedUser;
           





        //    //User loggedUser = new User();

        //    //Dictionary<string, object> childRow;
        //    //foreach (DataRow row in table.Rows)
        //    //{
        //    //    childRow = new Dictionary<string, object>();
        //    //    foreach (DataColumn col in table.Columns)
        //    //    {
        //    //        childRow.Add(col.ColumnName, row[col]);
        //    //    }
        //    //    if (int.Parse(childRow["UserTypeID"].ToString()) != 0)
        //    //    {
        //    //        loggedUser = new User(childRow);
        //    //    }
        //    //    else
        //    //    {
        //    //        loggedUser = new (childRow);
        //    //    }
        //    //    //loggedUser
        //    //}

        //    //sqlCon.Close();
        //    //return loggedUser;




        //    //User loggedUser = new User(childRow);
        //    //Dictionary<string, object> childRow;

        //    //User loggedUser = new User(childRow);


        //    //sqlCon.Close();
        //    //return loggedUser;

        //}


    }
}