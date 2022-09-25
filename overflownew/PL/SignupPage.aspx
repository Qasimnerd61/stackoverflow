<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignupPage.aspx.cs" Inherits="StackOverFlow.PL.SignupPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/js/bootstrap.min.js" integrity="sha384-7VPbUDkoPSGFnVtYi0QogXtr74QeVeeIs99Qfg5YCF+TidwNdjvaKZX19NZ/e6oz" crossorigin="anonymous"></script>
   
     <script type="text/javascript">

         function validation() {
             var usern = document.getElementById('username').value;
             //var pwd = document.getElementById('password').value;

             var age = document.getElementById('age').value;
             var em = document.getElementById('email').value;
             
             var p1 = document.getElementById('password').value;
             var p2 = document.getElementById('confirmpassword').value;
             //var regName = /^[a-zA-Z]+ [a-zA-Z]+$/;
             var regName = /^[a-zA-Z]+$/;
             var fname = document.getElementById('firstname').value;
             if (fname.length < 5 || fname.length > 15) {
                 alert('First name length should be between 3 and 15');
                 return false;
             }
             if (!regName.test(fname)) {
                 alert('First name should be Only Characters.');
                 document.getElementById('firstname').focus();
                 return false;
             }
             var regName1 = /^[a-zA-Z]+$/;
             var lname = document.getElementById('lastname').value;
             if (lname.length < 3 || lname.length > 15) {
                 alert('Last name length should be between 3 and 15');
                 return false;
             }
             if (!regName1.test(lname)) {
                 alert('Last name should be Only Characters.');
                 document.getElementById('lastname').focus();
                 return false;
             }
             if (age < 10 || age > 150) {
                 document.getElementById('lblage').innerHTML = "**Age Limit is between 10 to 150";
                 return false;
             }
             else {
                 document.getElementById('lblage').innerHTML = "";
             }
             var ck_username = /^[A-Za-z0-9_]{5,20}$/;
             if (!ck_username.test(usern)) {
                 alert('Username is not correct');
                 document.getElementById('username').focus();
                 return false;
             }
             var ck_email = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/; 
             if (!ck_email.test(em)) {
                 alert('email is not correct');
                 document.getElementById('email').focus();
                 return false;
             }
             var paswd = /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{7,15}$/;
             if (!paswd.test(p1)) {
                 alert('Your password is not correct make sure your password between 7 to 15 characters which contain at least one numeric digit and a special character');
                 document.getElementById('password').focus();
                 return false;
             }
             if (p1 != p2)
             {
                 alert('Passwords donot match')
                 return false;
             }
             //} else {
             //    alert('Valid name given.');
             //    return true;
             //}
         }
              //if (fn == "") {
              //    document.getElementById('lblfn').innerHTML = "**Please fill the first name";
              //    return false;
              //}
              //if (fn.length<=5) {
              //    document.getElementById('lblfn').innerHTML = "**lentgh is not correct";
              //    return false;
              //}
              //else {
              //    document.getElementById('lblfn').innerHTML = "";
              
             
              //    if (!regName.test(fn)) {
              //        alert('Invalid name given.');
              //        return false;
              //    }
              ////} else {
              ////    alert('Valid name given.');
              //}

              
          //    }
          //    if (!isNaN(fn)) {
          //            document.getElementById('lblfn').innerHTML = "**Please enter only characters in first name";
          //            return false;
          //    }
          //    if (ln == "") {
          //        document.getElementById('lblln').innerHTML = "**Please fill the last name";
          //        return false;
          //    }
              
          //    if (age == "") {
          //        document.getElementById('lblage').innerHTML = "**Please fill the age";
          //        return false;
          //    }
          //    if (age <10||age>150) {
          //        document.getElementById('lblage').innerHTML = "**Age Limit is between 10 to 150";
          //        return false;
          //    }
          //    if (ln == "") {
          //        document.getElementById('lblln').innerHTML = "**Please fill the last name";
          //        return false;
          //    }
          //    if (p1 != p2) {
          //        alert("Passwords Do Not Match");
          //        return false;
          //    }
          //}
      </script>


    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <section class="vh-100" style="background-color: #eee;">
                <div class="container h-100">
                    <div class="row d-flex justify-content-center align-items-center h-100">
                        <div class="col-lg-12 col-xl-11">
                            <div class="card text-black" style="border-radius: 25px;">
                                <div class="card-body p-md-5">
                                    <div class="row justify-content-center">
                                        <div class="col-md-10 col-lg-6 ">

                                            <p class="text-center h1 fw-bold mb-5 mx-1 mx-md-4 mt-4">Sign up</p>

                                            <div class="mx-1 mx-md-4">
                                                
                                                
                                                <div class="d-flex flex-row align-items-center mb-4">
                                                    <i class="fas fa-user fa-lg me-3 fa-fw"></i>
                                                    <div class="form-outline flex-fill mb-0">
                                                        <input type="text" runat="server" id="firstname" class="form-control" />

                                                        <label class="form-label" for="form3Example1c">First Name</label>
                                                         <span class="text-danger form-label" id="lblfn"></span>
                                                    </div>
                                                </div>

                                                <div class="d-flex flex-row align-items-center mb-4">
                                                    <i class="fas fa-user fa-lg me-3 fa-fw"></i>
                                                    <div class="form-outline flex-fill mb-0">
                                                        <input type="text" runat="server" id="lastname" class="form-control" />
                                                        <label class="form-label" for="form3Example1c">Last Name</label>
                                                         <label class="text-danger form-label" id="lblln"></label>
                                                    </div>
                                                </div>

                                                <div class="d-flex flex-row align-items-end justify-content-spacebetween mb-4">
                                                    <i class="fas fa-user fa-lg me-3 fa-fw"></i>

                                                    <div class="form-outline flex-fill mb-0 ms-1">
                                                        <input type="number" min="0" max 1000 runat="server" id="age" class="form-control" />
                                                        <label class="form-label" for="form3Example1c">Age</label>
                                                         <label class="text-danger form-label" id="lblage"></label>
                                                    </div>
                                                               

                                                </div>




                                               <%-- <div class="d-flex flex-row align-items-center mb-4">
                                                    <i class="fas fa-user fa-lg me-3 fa-fw"></i>
                                                    <div class="form-outline flex-fill mb-0">
                                                        <input type="tel" runat="server" id="cellnum" class="form-control" />
                                                        <label class="form-label"  for="form3Example1c">Cell number</label>
                                                    </div>
                                                </div>--%>



                                                <div class="d-flex flex-row align-items-center mb-4">
                                                    <i class="fas fa-user fa-lg me-3 fa-fw"></i>
                                                    <div class="form-outline flex-fill mb-0">
                                                        <input type="text" runat="server" id="username" class="form-control" />
                                                        <label class="form-label" for="form3Example3c">Username</label>
                                                          <label class="text-danger form-label" id="lblusername"></label>

                                                    </div>
                                                </div>

                                                <div class="d-flex flex-row align-items-center mb-4">
                                                    <i class="fas fa-envelope fa-lg me-3 fa-fw"></i>
                                                    <div class="form-outline flex-fill mb-0">
                                                        <input type="email" runat="server" id="email" class="form-control" />
                                                        <label class="form-label" for="form3Example3c">Email</label>
                                                         <label class="text-danger form-label" id="lblemail"></label>
                                                    </div>
                                                </div>

                                                <div class="d-flex flex-row align-items-center mb-4">
                                                    <i class="fas fa-lock fa-lg me-3 fa-fw"></i>
                                                    <div class="form-outline flex-fill mb-0">
                                                        <input type="password" runat="server" id="password" class="form-control" />
                                                        <label class="form-label" for="form3Example4c">Password</label>
                                                         <label class="text-danger form-label" id="lblpw"></label>
                                                    </div>
                                                </div>

                                                <div class="d-flex flex-row align-items-center mb-4">
                                                    <i class="fas fa-key fa-lg me-3 fa-fw"></i>
                                                    <div class="form-outline flex-fill mb-0">
                                                        <input type="password" runat="server" id="confirmpassword" class="form-control" />
                                                        <label class="form-label" for="form3Example4cd">Confirm password</label>
                                                         <label class="text-danger form-label" id="lblcpw"></label>
                                                    </div>
                                                </div>

                                     
                                                <div class="d-flex flex-row justify-content-evenly align-items-center mx-4 mb-3 mb-lg-4">
                                                    
                                                    <asp:Button ID="signup" runat="server" Text="Sign up" type="button" class="btn btn-primary btn-lg" OnClick="signup_Click" OnClientClick="return validation()"/>
                                                    <asp:Label ID="lblsignupStatus" runat="server" class="badge bg-secondary" Text="signupStatusLabel"></asp:Label>
                                                </div>



                                            </div>

                                        </div>
                                        <div class="col-md-10 col-lg-6 col-xl-7 d-flex align-items-center order-1 order-lg-2">

                                            <%--<img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-registration/draw1.webp"
                                                class="img-fluid" alt="Sample image">--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>







        </div>
    </form>
</body>
</html>
