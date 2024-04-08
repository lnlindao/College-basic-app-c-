<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab7.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lissette Lindao - Lab 8</title>
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Bitter:ital,wght@0,100..900;1,100..900&family=Manrope:wght@200..800&display=swap" rel="stylesheet"/>
    <link href="App_Themes/styles.css" rel="stylesheet" />
    <link rel="stylesheet" href="Content/font-awesome.css"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
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
                        <a href="AddStudent.aspx" class="nav-link">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="RegisterCourse.aspx">Register courses</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>


    <div class="container">
        <div class="title">
            <h1 class="title"><i class="fa fa-address-card-o" aria-hidden="true"></i> Registration</h1>
        </div>
        <form id="form1" runat="server">
            <div class="row box">
                <div class="col-md-2">Student: </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="StudentDropdown" runat="server" CssClass="form-control" 
                        AutoPostBack="True" OnSelectedIndexChanged="Student_SelectedIndexChanged">
                    </asp:DropDownList>             
                </div>
             
                <div id="studentRegisteredCoursesDiv" role="alert" runat="server" visible="false">
                </div>
            </div>

            <div class="row mt-3 bg-white box" id="courses" runat="server">
                <h5 class="subtitles">Following courses are currently available for registration</h5>
                <div class="col-md-12 alert alert-danger" role="alert" id="errorDiv" runat="server" visible="false">
                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" ></asp:Label>
                </div>

                <div class="col-md-12">
                    <asp:CheckBoxList ID="chkCourses" runat="server"></asp:CheckBoxList>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="save" runat="server" Text="Save" class="btn btn-primary mt-3" OnClick="save_Click"/>
                </div>
            </div>
        
            <div id="registeredCoursesDiv"  runat="server"></div>
        </form>
    </div>

    


</body>
</html>
