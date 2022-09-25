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
    public class SignUp_DAL
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
        public string SignupUser(User userObj)
        {
            sqlCon.Open();

            SqlCommand sqlCmd_AddUsers = new SqlCommand("sp_AddUsers", sqlCon);
            sqlCmd_AddUsers.CommandType = CommandType.StoredProcedure;
            sqlCmd_AddUsers.Parameters.Add(new SqlParameter("@firstname", userObj.firstName));
            sqlCmd_AddUsers.Parameters.Add(new SqlParameter("@lastname", userObj.lastName));          
            sqlCmd_AddUsers.Parameters.Add(new SqlParameter("@age", userObj.age));
            sqlCmd_AddUsers.Parameters.Add(new SqlParameter("@username", userObj.username));
            sqlCmd_AddUsers.Parameters.Add(new SqlParameter("@email", userObj.email));
            sqlCmd_AddUsers.Parameters.Add(new SqlParameter("@password", userObj.password));

            int[] userExistance = checkUserExistance(userObj);

            if (userExistance[0] > 0)
            {
                return "Username already exists";/* + userExistance[0] + "int";*/
            }
            else if (userExistance[1] > 0)
            {
                return "Email already exists";/* + userExistance[1] + "int";*/
            }
            else
            {
                sqlCmd_AddUsers.ExecuteNonQuery();
                return "Signup Successful";/* + userExistance[0] + userExistance[1] + "N, E"*/
            }
        }

        public int[] checkUserExistance(User userObj)
        {
            //sqlCon.Open();

            SqlCommand sqlCmd_checkUsernameExistance = new SqlCommand("checkUsernameExistance", sqlCon);
            sqlCmd_checkUsernameExistance.CommandType = CommandType.StoredProcedure;
            sqlCmd_checkUsernameExistance.Parameters.Add(new SqlParameter("@username", userObj.username));

            SqlCommand sqlCmd_checkEmailExistance = new SqlCommand("checkEmailExistance", sqlCon);
            sqlCmd_checkEmailExistance.CommandType = CommandType.StoredProcedure;
            sqlCmd_checkEmailExistance.Parameters.Add(new SqlParameter("@email", userObj.email));

            int[] userExistance = { Convert.ToInt32(sqlCmd_checkUsernameExistance.ExecuteScalar()), Convert.ToInt32(sqlCmd_checkEmailExistance.ExecuteScalar()) };
            //sqlCon.Close();
            return userExistance;

        }
    }
    }