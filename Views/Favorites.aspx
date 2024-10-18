<%@ Page Title="Favorites" Language="C#" MasterPageFile="~/Views/_layout.Master" AutoEventWireup="true" CodeBehind="Favorites.aspx.cs" Inherits="HaiDen.Views.Favorites" %>

<%@ Register Src="~/Views/Control/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>
<%@ Register Src="~/Views/Control/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <uc1:Header runat="server" ID="Header" />
    <input type="hidden" runat="server" id="hdAlias" value="-1" />
    <section class="container content-page signup-page profile">
        <div class="page-head">
            <div class="logo">
                <a href="<%= Page.ResolveClientUrl("~/index.html")%>">
                    <span id="lb-banner">Truong Thanh Hai</span>
                </a>
            </div>
            <h2>My Favorites</h2>
        </div>
        <div class="page-content listWeddingDress">
        </div>
    </section>
    <uc1:Footer runat="server" ID="Footer" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
        <script src="<%= Page.ResolveClientUrl("~/Scripts/WeddingDress_Script.js")%>"></script>
    <script>
        $(document).ready(function () {
            var WeddingDressFav_Script = new WeddingDressScript();
            WeddingDressFav_Script.initFav();
        });
    </script>
</asp:Content>
