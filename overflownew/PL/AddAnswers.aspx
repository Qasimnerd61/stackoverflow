<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAnswers.aspx.cs" Inherits="StackOverFlow.PL.AddAnswers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                                        <div >
                                            <p class="text-left h1 fw-bold mb-5 mx-1 mx-md-4 mt-4">Please Add a Question</p>
                                            <div class="mx-1 mx-md-4">
                                                
                                                 <div class="d-flex flex-row align-items-center mb-4">
                                                    <i class="fas fa-envelope fa-lg me-3 fa-fw"></i>
                                                    <h4 class="form-label" >Answer Body</h4>
                    
                                                     <input type="text" runat="server" id="desc" class="form-control" />
                                        
                                                </div>
                                               

                                                <div class="d-flex flex-row justify-content-evenly align-items-center mx-4 mb-3 mb-lg-4">

                                                    <asp:Button ID="addMovie" runat="server" Text="Add Answer" type="button" class="btn btn-dark btn-lg" OnClientClick="return validationq()" OnClick="AddAnswer_Click" />
                                                    <asp:Label ID="addQuestionStatus" runat="server" class="badge bg-secondary" Text="addQuestionStatusLabel"></asp:Label>
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
