<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyQuestions.aspx.cs" Inherits="StackOverFlow.PL.MyQuestions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
   
   
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/js/bootstrap.min.js" integrity="sha384-7VPbUDkoPSGFnVtYi0QogXtr74QeVeeIs99Qfg5YCF+TidwNdjvaKZX19NZ/e6oz" crossorigin="anonymous"></script>
 
</head>
<body>
    <form id="form1" runat="server">
         <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <!--Main Navigation-->
        <header>
            <!-- Sidebar -->
            <nav id="sidebarMenu" class="collapse d-lg-block sidebar collapse bg-white">
                <div class="position-sticky">
                    <div class="list-group list-group-flush mx-3 mt-4">
                        <a href="#" class="list-group-item list-group-item-action py-2 ripple" aria-current="true">
                            <i class="fas fa-tachometer-alt fa-fw me-3"></i><span>Main dashboard</span>
                        </a>
                        <a href="#" class="list-group-item list-group-item-action py-2 ripple active">
                            <i class="fas fa-chart-area fa-fw me-3"></i><span>Questions</span>
                        </a>
                        <a href="#" class="list-group-item list-group-item-action py-2 ripple"><i
                            class="fas fa-lock fa-fw me-3"></i><span>Password</span></a>
                        <a href="#" class="list-group-item list-group-item-action py-2 ripple"><i
                            class="fas fa-chart-line fa-fw me-3"></i><span>Analytics</span></a>
                        <a href="#" class="list-group-item list-group-item-action py-2 ripple">
                            <i class="fas fa-chart-pie fa-fw me-3"></i><span>SEO</span>
                        </a>
                       
                    </div>
                </div>
            </nav>
            <!-- Sidebar -->

            <!-- Navbar -->
            <nav id="main-navbar" class="navbar navbar-expand-lg navbar-light bg-white fixed-top">
                <!-- Container wrapper -->
                <div class="container-fluid">
                    <!-- Toggle button -->
                    <button class="navbar-toggler" type="button" data-mdb-toggle="collapse" data-mdb-target="#sidebarMenu"
                        aria-controls="sidebarMenu" aria-expanded="false" aria-label="Toggle navigation">
                        <i class="fas fa-bars"></i>
                    </button>

                    <!-- Brand -->
                    <a class="navbar-brand" href="#">
                        <img src="logo-stackoverflow.png"  height="25" alt="SOF Logo"
                            loading="lazy"/>
                        
                    </a>
                    <!-- Search form -->
                    <div class="d-none d-md-flex input-group w-auto my-auto">
                          <input  type="text" id="searchField" class="form-control form-control-lg" placeholder="search..."/>
                         <div class="nav-item form-outline ms-2" id="searchBtnDiv">
                            <button id="btnSearch" class="btn btn-dark" type="button">Search</button>
                            </div>

                    <%--    <input autocomplete="off" type="search" class="form-control rounded"
                            placeholder='Search (ctrl + "/" to focus)' style="min-width: 225px;" />--%>
                    </div>

                    <!-- Right links -->
                    <ul class="navbar-nav ms-auto d-flex flex-row">
                        <!-- Notification dropdown -->
                        <!-- Icon -->
                        <li class="nav-item">
                            <a class="nav-link me-3 me-lg-0" href="#">
                                <i class="fas fa-fill-drip"></i>
                            </a>
                        </li>
                        <!-- Icon -->
                      <%--  <div><asp:Button ID="AskQuestion" class="btn btn-primary ms-2" runat="server" Text="Ask-Question" OnClick="AskQuestion_Click"/></div>
                      --%>  <%-- <div><asp:Button ID="Login" class="btn btn-info ms-2" runat="server" Text="Login" OnClick="Login_Click" /></div>
                        <div><asp:Button ID="Logout" class="btn btn-secondary ms-2" runat="server" Text="Sign-Up" OnClick="Signup_Click"/></div>--%>

                 <%--        <div><asp:Button ID="Signout" class="btn btn-info ms-2" runat="server" Text="Sign-Out" OnClick="Signout_Click"/></div>--%>
                </div>
                <!-- Container wrapper -->
            </nav>
            <!-- Navbar -->
        </header>
        <!--Main Navigation-->
        <%--  --%>
        <!--Main layout-->
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
            
        </main>
        <!--Main layout-->
        
    </form>
     <script src="scripts/MyQuestions.js"></script>
</body>
</html>
