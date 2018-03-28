<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="addproduct.aspx.cs" Inherits="admin_addproduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentplaceholder" runat="Server">
    <!-- Heading-->
    <ol class="breadcrumb">
        <li class="breadcrumb-item">
            <a href="addproduct.aspx">Add Product</a>
        </li>
    </ol>
    <!-- product form goes here -->
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <asp:Panel ID="pnl_addproducterror" runat="server" Visible="false">
                    <div class="card-header alert alert-warning" role="alert">
                        <asp:Label ID="lbl_error" runat="server" CssClass=" text-danger" Text=""></asp:Label>
                    </div>
                </asp:Panel>
                <div class="card-body">
                    <label class="col-form-label ">Product Name</label>
                    <div class="form-inline">
                        <asp:TextBox ID="txt_productname" runat="server" CssClass="form-control col-md-5"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="require_pname" runat="server" ErrorMessage="Enter product name" ControlToValidate="txt_productname" ForeColor="red" Display="Dynamic" CssClass="m-1"></asp:RequiredFieldValidator>
                    </div>
                    <label class="col-form-label ">Product Discription</label>
                    <div class="form-inline">
                        <asp:TextBox ID="txt_productdiscription" runat="server" CssClass="form-control col-md-5" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="require_txt_pdiscription" runat="server" ErrorMessage="Enter option one" ControlToValidate="txt_productdiscription" ForeColor="red" Display="Dynamic" CssClass="m-1"></asp:RequiredFieldValidator>
                    </div>
                    <label class="col-form-label ">Product Qauntity</label>
                    <div class="form-inline">
                        <asp:TextBox ID="txt_productquantity" runat="server" CssClass="form-control col-md-5" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="req_pquantity" runat="server" ErrorMessage="Enter product quantity" ControlToValidate="txt_productquantity" ForeColor="red" Display="Dynamic" CssClass="m-1"></asp:RequiredFieldValidator>
                    </div>
                    <label class="col-form-label ">Product Price</label>
                    <div class="form-inline">
                        <asp:TextBox ID="txt_productprice" runat="server" CssClass="form-control col-md-5" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="req_pprice" runat="server" ErrorMessage="Enter option one" ControlToValidate="txt_productprice" ForeColor="red" Display="Dynamic" CssClass="m-1"></asp:RequiredFieldValidator>
                    </div>
                    <label class="col-form-label ">Upload Product Image</label>
                    <div class="form-inline">
                        <asp:FileUpload ID="upld_pimage" runat="server" CssClass="custom-file col-md-5 customfileupload" />
                        <asp:RequiredFieldValidator ID="req_image" runat="server" ErrorMessage="Please upload image" ControlToValidate="upld_pimage" ForeColor="red" Display="Dynamic" CssClass="m-1"></asp:RequiredFieldValidator>
                        <asp:Label ID="lbl_pimageerror" runat="server"  Visible="false" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Button ID="btn_addproduct" runat="server" Text="Add Product" CssClass="btn btn-dark offset-3" OnClick="btn_addproduct_Click" />
                </div>
            </div>
            <br />
        </div>
    </div>
</asp:Content>

