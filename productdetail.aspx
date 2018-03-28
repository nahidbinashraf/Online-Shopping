<%@ Page Title="" Language="C#" MasterPageFile="~/Mainsite.master" AutoEventWireup="true" CodeFile="productdetail.aspx.cs" Inherits="productdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentplaceholder" runat="Server">
    <asp:Repeater ID="product_details" runat="server">
        <ItemTemplate>
            <div class="card my-4">
                <div class="row card-body">
                    <div class="col-md-4">
                        <img src="../admin/<%# Eval("product_image") %>" class="img-fluid img-thumbnail" style="max-height:500px; object-fit:contain">
                    </div>
                    <div class="col-md-8">
                        <div class="card-block p-1">
                            <h4 class="card-title text-danger"><%# Eval("product_name") %></h4>                            
                            <p class="card-text">Quantity: <span class="text-danger"><%# Eval("product_quantity") %></span></p>
                            <p class="card-text">Price: <span class="text-danger"><%# Eval("product_price")%> TK</span></p>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <h4 class="card-title text-danger">Porduct Discription</h4>
                    <p class="card-text"> <%# Eval("product_discription") %></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="card-footer">
        <asp:Button ID="btn_addcart" class="btn btn-lg btn-danger  float-md-right" runat="server" Text="Add to Cart" OnClick="btn_addcart_Click" />
    </div>
    <asp:Panel ID="pnl_noproducterror" runat="server" Visible="false">
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

