<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SigninPage.aspx.cs" Inherits="StackOverFlow.PL.SigninPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/js/bootstrap.min.js" integrity="sha384-7VPbUDkoPSGFnVtYi0QogXtr74QeVeeIs99Qfg5YCF+TidwNdjvaKZX19NZ/e6oz" crossorigin="anonymous"></script>
   
    <script>
        function validation()
        {
            let email = document.getElementById('txtEmail').value;
            let pas = document.getElementById('txtEmail').value;
            if (email == "") {
                alert("Please fill Email");
                return false;
            }
 }
            </script>


    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
        <section class="h-100 gradient-form" style="background-color: #eee;">
            <div class="container py-5 h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col">
                        <div class="card rounded-3 text-black">
                            <div class="row g-0">
                                <div class="col">
                                    <div class="card-body p-md-5 mx-md-4">

                                        <div class="text-center">
                                            <img src="logo-stackoverflow.png"  style="width: 185px;" alt="logo"/>
                                        </div>
                                        <%--<form>--%>
                                        <p>Please login to your account</p>
                                        <div class="form-outline mb-4">
                                            <asp:TextBox runat="server" type="email" ID="txtEmail" class="form-control form-control-lg"
                                                placeholder="Enter a valid email address" ></asp:TextBox>
                                        </div>
                                        <h2 id="result"></h2>
                                        <div class="form-outline mb-4">
                                            <asp:TextBox runat="server" type="password" ID="txtPassword" class="form-control form-control-lg" placeholder="Enter password"  ></asp:TextBox>
                                            <div id="error-nwl"></div>
                                        </div>

                                        <div class="text-center pt-1 mb-5 pb-1">
                                            <asp:Button ID="btnLogin" runat="server" Text="Log in" type="button" class="btn btn-primary btn-block fa-lg gradient-custom-2 mb-3"
                                                Style="padding-left: 2.5rem; padding-right: 2.5rem;" OnClientClick="return validation();" OnClick="btnLogin_Click" />

                                            <asp:Label ID="lblloginStatus" runat="server" class="badge bg-secondary" Text="loginStatusLabel"></asp:Label>

                                        
                                        </div>

                                        <div class="d-flex align-items-center justify-content-center pb-4">
                                            <p class="mb-0 me-2">Don't have an account?</p>

                                            <asp:Button runat="server" type="button" class="btn btn-outline-danger" Text="Sign up"  OnClick="btnSignup_Click" />
                                        </div>

                                       
                                    </div>
                                </div>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

       
    </form>
</body>
</html>
