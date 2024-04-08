<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab7.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lissette Lindao - Lab 8</title>
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Bitter:ital,wght@0,100..900;1,100..900&family=Manrope:wght@200..800&display=swap" rel="stylesheet"/>
    <link href="App_Themes/styles.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link rel="stylesheet" href="Content/font-awesome.css"/>
</head>
<body>
    <nav class="navbar navbar-top navbar-expand-lg navbar-dark">
        <div class="container d-flex justify-content-between">
            <!-- Logo -->
            <a class="navbar-brand" href="AddStudent.aspx">COLLEGE APP</a>
            <!-- Botón de hamburguesa para dispositivos móviles -->
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <!-- Menu -->
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item active">
                        <a href="AddStudent.aspx" class="nav-link"> Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="RegisterCourse.aspx">Register courses</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <div class="container">
        <div class="row title d-flex align-items-center justify-content-between">
            <div class="col-md-10">
                <h1 class="title"><i class="fa fa-users" aria-hidden="true"></i> Students</h1>
            </div>

    
            <div class="col-md-2">
            </div>    
        </div>

        <form id="form1" runat="server" class="row">
            <div class="add-students">
                <div class="student form-group shadow">
                    <div class="mb-4" >
                        <label for="StudentName">Student Name:</label><br />
                        <asp:TextBox ID="StudentName" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="StudentName_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="StudentName"
                            ErrorMessage="Student name is required."
                            CssClass="text-danger mb-2"
                            Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </div>

                    <div class="mb-4">
                        <label for="StudentType">Student type:</label>
                        <asp:DropDownList ID="StudentType" runat="server" CssClass="form-control">                    
                            <asp:ListItem Text="Select ..." Value="Selection"></asp:ListItem>
                            <asp:ListItem Text="Full Time" Value="FullTime"></asp:ListItem>
                            <asp:ListItem Text="Part Time" Value="PartTime"></asp:ListItem>
                            <asp:ListItem Text="Coop" Value="Coop"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="StudentType"
                            ClientValidationFunction="validateStudentType" ErrorMessage="Please select an option."
                            CssClass="text-danger mb-2" Display="Dynamic">
                        </asp:CustomValidator>
                        <script>
                            function validateStudentType(source, args) {
                                var selectedValue = document.getElementById('<%= StudentType.ClientID %>').value;
                                if (selectedValue === "Selection") {
                                    args.IsValid = false;
                                } else {
                                    args.IsValid = true;
                                }
                            }
                        </script>
                    </div>

                    <asp:Button ID="AddStudentButn" runat="server" Text="Add" OnClick="AddStudentButn_Click"
                        CssClass="btn btn-primary"/>
                </div>
                <div class="student-list shadow">
                    <div id="header" runat="server" class="studentList">
                        <div class="student-list1">ID</div>
                        <div class="student-list">Student</div>
                    </div>
                    <div id="studentList" runat="server" >
                    </div>
                </div>
            
            </div>
        </form>
    </div>
    
           
<!-- Scripts for mobile navigation -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
 

</body>
</html>
