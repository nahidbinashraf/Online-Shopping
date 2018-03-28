<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminlogin.aspx.cs" Inherits="admin_adminlogin" %>

<!DOCTYPE html>
<html lang="en">

<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Admin - Online Shop</title>
    <!-- Bootstrap core CSS-->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom fonts for this template-->
    <link href="assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <!-- Custom styles for this template-->
    <link href="assets/css/custom.css" rel="stylesheet">
</head>

<body class="bg-dark">
    <form runat="server" id="mainform">
        <div class="container">
            <div class="card card-login mx-auto mt-5">
                <div class="card-header">Login</div>

                <div class="card-body">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Email address</label>
                        <asp:TextBox ID="txt_email" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqr_email" runat="server" ErrorMessage="Enter a valid email" ControlToValidate="txt_email" Display="Dynamic" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Password</label>
                        <asp:TextBox ID="txt_password" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqr_pass" runat="server" ErrorMessage="Enter a valid valid password" ControlToValidate="txt_password" Display="Dynamic" ForeColor="#CC0000" ></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <div class="form-check">
                                <asp:CheckBox ID="chk_remeberme" runat="server" CssClass="form-check-input" Text="Remeber me" TextAlign="Right"/>
                            <br />
                        </div>
                    </div>
                    <%-- For login error panel --%>
                    <asp:Panel ID="panel_loginerror" runat="server" Visible="false">
                        <div class="card-header alert alert-warning text-center" role="alert">
                            <asp:Label ID="lbl_error" runat="server"  CssClass=" text-danger"></asp:Label>
                        </div>
                    </asp:Panel>
                    <asp:Button ID="btn_login" runat="server" Text="Login"  CssClass="btn btn-primary btn-block" OnClick="btn_login_Click"/>
                    <div class="text-center">
                        <a class="d-block small" href="forgot-password.html">Forgot Password?</a>
                    </div>

                </div>
            </div>
        </div>
        <!-- Bootstrap core JavaScript-->
        <script src="assets/js/jquery.min.js"></script>
        <script src="assets/js/bootstrap.bundle.min.js"></script>
    </form>
</body>
</html>

