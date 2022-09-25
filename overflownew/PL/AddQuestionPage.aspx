<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddQuestionPage.aspx.cs" Inherits="StackOverFlow.PL.AddQuestionPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/js/bootstrap.min.js" integrity="sha384-7VPbUDkoPSGFnVtYi0QogXtr74QeVeeIs99Qfg5YCF+TidwNdjvaKZX19NZ/e6oz" crossorigin="anonymous"></script>
   <script type="text/javascript">

       function ValidateCheckBoxList(sender, args) {
           var checkBoxList = document.getElementById("<%=genreCheckBoxList.ClientID %>");
           var checkboxes = checkBoxList.getElementsByTagName("input");
           var isValid = false;
           for (var i = 0; i < checkboxes.length; i++) {
               if (checkboxes[i].checked) {
                   isValid = true;
                   break;
               }
           }
           args.IsValid = isValid;
       }


       function validationq() {
           let qn = document.getElementById('moviename').value;
           let qb = document.getElementById('desc').value;
           let tl = document.getElementById('genreCheckBoxList').value; 
           if (qn == "")
           {
               alert("Question Title Can't be Emplty");
               return false;
           }
           if (qb == "") {
               alert("Question Body Can't be Emplty");
               return false;
           }
           if (tl == "") {
               alert("Tag List Can't be Emplty");
               return false;
           }


       }
   </script>
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
                                                    <i class="fas fa-user fa-lg me-3 fa-fw"></i>
                                                    <div class="form-outline flex-fill mb-0">
                                                         <h4 class="form-label" for="form3Example1c">Question Title</h4>
                                                        <input type="text" runat="server" id="moviename" class="form-control" />
                                                       
                                                    </div>
                                                </div>
                                                 <div class="d-flex flex-row align-items-center mb-4">
                                                    <i class="fas fa-envelope fa-lg me-3 fa-fw"></i>
                                                    <h4 class="form-label" >Question Body</h4>
                    
                                                     <input type="text" runat="server" id="desc" class="form-control" />
                                        
                                                </div>
                                                <div class="d-flex flex-column align-items-start justify-content-spacebetween mb-4 ms-3">
                                                    <i class="fas fa-user fa-lg me-3 fa-fw"></i>

                                                    <h4 class="form-label" for="form3Example1c">Select Tags</h4>

                                                    <asp:CheckBoxList ID="genreCheckBoxList" AutoPostBack="True" CellPadding="4" CellSpacing="4" RepeatColumns="10" TextAlign="Right"  runat="server" >
                                                        <asp:ListItem>SQL</asp:ListItem>
                                                        <asp:ListItem>inner-Join</asp:ListItem>
                                                        <asp:ListItem>sql-server</asp:ListItem>
                                                        <asp:ListItem>c#</asp:ListItem>
                                                        <asp:ListItem>asp.net</asp:ListItem>
                                                         <asp:ListItem>javascript</asp:ListItem>
                                                        <asp:ListItem>eventlistener</asp:ListItem>
                                                        <asp:ListItem>python</asp:ListItem>                                                     
                                                        <asp:ListItem>angular</asp:ListItem>
                                                        <asp:ListItem>react</asp:ListItem>
                                                        <asp:ListItem>jquery</asp:ListItem>
                                                         <asp:ListItem>java</asp:ListItem> 
                                                         <asp:ListItem>css</asp:ListItem> 
                                                         <asp:ListItem>json</asp:ListItem> 
                                                         <asp:ListItem>regex</asp:ListItem>
                                                        <asp:ListItem>swift</asp:ListItem>
                                                        <asp:ListItem>ruby</asp:ListItem>     
                                                    </asp:CheckBoxList>
                                                    <asp:CustomValidator ID="CustomValidator1" ErrorMessage="Please select at least one item."
    ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList" runat="server" />
                                                </div>

                                                <div class="d-flex flex-row justify-content-evenly align-items-center mx-4 mb-3 mb-lg-4">

                                                    <asp:Button ID="addMovie" runat="server" Text="Add Movie" type="button" class="btn btn-dark btn-lg" OnClientClick="return validationq()" OnClick="addQuestion_Click" />
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
