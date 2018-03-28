<%@ Page Title="" Language="C#" MasterPageFile="~/Mainsite.master" AutoEventWireup="true" CodeFile="viewcart.aspx.cs" Inherits="viewcart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentplaceholder" runat="Server">
    <asp:Repeater ID="viewcart_details" runat="server">
        <ItemTemplate>
            <div class="card my-4">
                <div class="row card-body">
                    <div class="col-sm-1 d-none d-sm-block">
<%--                        <p class="text-danger" style="margin: 50px 0px 0px 19px"><%# Eval("product_id") %></p>--%>
                    </div>
                    <div class="col-sm-3 col-6">
                        <img src="../admin/<%# Eval("product_image") %>" class="img-thumbnail img-fluid" style="height: 150px; object-fit: contain">
                    </div>
                    <div class="col-5 d-block d-sm-none p-1">
                        <h4 class="card-title text-danger"><%# Eval("product_name") %></h4>
                        <p class="card-text">Quantity: <span class="text-danger"><%# Eval("product_quantity") %></span></p>
                        <p class="card-text">Price: <span class="text-danger"><%# Eval("product_price")%> TK</span></p>
                    </div>
                    <div class="col-sm-3 d-none d-sm-block m-1">
                        <h4 class="card-title text-danger"><%# Eval("product_name") %></h4>
                        <p class="card-text">Quantity: <span class="text-danger"><%# Eval("product_quantity") %></span></p>
                        <p class="card-text">Price: <span class="text-danger"><%# Eval("product_price")%> TK</span></p>
                    </div>
                </div>
                <a href="deletecart.aspx?dcart=<%#Eval("product_id")%>" class="btn btn-block" style="color:#008080"><%#Eval("product_id")%>Remove</a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Panel ID="pnl_noviewcarterror" runat="server" Visible="false">
        <br />
        <br />
        <div class="row">
            <div class="col-12">
                <div class="card-header alert alert-warning text-center" role="alert">
                    <asp:Label ID="lbl_error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

