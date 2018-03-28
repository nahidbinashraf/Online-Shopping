<%@ Page Title="" Language="C#" MasterPageFile="~/Mainsite.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentplaceholder" runat="Server">
    <%-- For slider --%>
    <div id="carouselExampleIndicators" class="carousel slide my-4" data-ride="carousel">
        <ol class="carousel-indicators">
            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
        </ol>
        <div class="carousel-inner" role="listbox">
            <div class="carousel-item active">
                <img class="d-block img-fluid" src="http://placehold.it/900x350" alt="First slide">
            </div>
            <div class="carousel-item">
                <img class="d-block img-fluid" src="http://placehold.it/900x350" alt="Second slide">
            </div>
            <div class="carousel-item">
                <img class="d-block img-fluid" src="http://placehold.it/900x350" alt="Third slide">
            </div>
        </div>
        <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>
    <%-- for top 6  product show --%>
    <asp:Repeater ID="product_show" runat="server">
        <HeaderTemplate>
            <div class="row">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="col-lg-4 col-md-6 mb-4">
                <div class="card h-100">
                    <a href="productdetail.aspx?pid=<%#Eval("id") %>" class="">
                        <img class="card-img-top img-thumbnail" src="../admin/<%# Eval("product_image") %>" alt="" style="height:250px; object-fit:contain"></a>
                    <div class="card-body d-block">
                        <h4 class="card-title"><%# Eval("product_name") %> </h4>
                        <h5>TK. <%# Eval("product_price") %></h5>
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
    <%-- if no product available --%>
    <asp:Panel ID="pnl_noproducterror" runat="server" Visible="false">
    <div class="row">
        <div class="col-12">
            <div class="card-header alert alert-warning text-center" role="alert">
                 <asp:Label ID="lbl_error" runat="server" CssClass="text-danger"></asp:Label>
           </div>
        </div>
    </div>
    </asp:Panel>

</asp:Content>

