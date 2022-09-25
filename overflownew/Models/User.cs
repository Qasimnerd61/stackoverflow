using StackOverFlow.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverFlow.Models
{
    public class User
    {
        public int userID;
        public string firstName;
        public string lastName;
        public int age;
        public string username;
        public string email;
        public string password;
        login_DAL login_DALObj = new login_DAL();
        SignUp_DAL signup_DALObj = new SignUp_DAL();


        public User(string _firstname, string _lastname, int _age, string _username, string _email, string _password)
        {
            //used when customer signs up
            firstName = _firstname;
            lastName = _lastname;
            age = _age;
            username = _username;
            email = _email;
            password = _password;
        }

        public User(Dictionary<string, object> childRow)
        {
            //used when customer logs in
            firstName = childRow["firstname"].ToString();
            lastName = childRow["lastname"].ToString();
            age = int.Parse(childRow["age"].ToString());
            username = childRow["username"].ToString();
            email = childRow["email"].ToString();
            password = childRow["password"].ToString();
         
        }
        public string login(User user)
        {
            return login_DALObj.loginUser(user);
        }
        public string Signup(User user)
        {
            return signup_DALObj.SignupUser(user);
        }
        //public User getUserDetails(User user)
        //{
        //    return login_DALObj.getUserDetails(user);
        //}
        public int GetUserID(User user)
        {
            return login_DALObj.GetUserId(user);
        }
    }
   
}