<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="answersPage.aspx.cs" Inherits="StackOverFlow.PL.answersPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/js/bootstrap.min.js" integrity="sha384-7VPbUDkoPSGFnVtYi0QogXtr74QeVeeIs99Qfg5YCF+TidwNdjvaKZX19NZ/e6oz" crossorigin="anonymous"></script>
  
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Hello Answers
            <ul class="navbar-nav ms-auto d-flex flex-row">
                        <!-- Notification dropdown -->
                        <!-- Icon -->
                        <li class="nav-item">
                            <a class="nav-link me-3 me-lg-0" href="#">
                                <i class="fas fa-fill-drip"></i>
                            </a>
                        </li>
                        <!-- Icon -->
                        <div><asp:Button ID="AskQuestion" class="btn btn-primary ms-2" runat="server" Text="Add Answer" OnClick="AddAnswer_Click"/></div>
                      
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        </div>
        <main style="margin-top: 58px;">
            <h2 id="questCount" class="container pt-4">Displaying: </h2>
            <div id="allMoviesDiv" class="container pt-4">
                
                <%--    <div class="list-group w-100">
                        <div class="d-flex w-100 justify-content-between">
                            <h5 class="mb-1">Question 3</h5>
                        </div>
                        <p class="mb-1">
                            Short & concise version of the answer.
                        </p>
                         <div class="d-flex w-100 justify-content-between">
                            <button class="btn btn-sm btn-info">Tag</button>
                        </div>
                        <div class="d-flex w-100 justify-content-between">
                            <button class="btn btn-sm btn-info">Tag</button>
                        </div>
                    </div>--%>

                </div>
             <div id="allAnswersDiv" class="container pt-4">
                
                <%--    <div class="list-group w-100">
                        <div class="d-flex w-100 justify-content-between">
                            <h5 class="mb-1">Question 3</h5>
                        </div>
                        <p class="mb-1">
                            Short & concise version of the answer.
                        </p>
                         <div class="d-flex w-100 justify-content-between">
                            <button class="btn btn-sm btn-info">Tag</button>
                        </div>
                        <div class="d-flex w-100 justify-content-between">
                            <button class="btn btn-sm btn-info">Tag</button>
                        </div>
                    </div>--%>

                </div>
            
        </main>
    </form>
    <script src="scripts/AnswersPage.js"></script>
</body>
</html>
