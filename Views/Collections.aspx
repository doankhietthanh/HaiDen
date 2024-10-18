<%@ Page Title="" Language="C#" MasterPageFile="~/Views/_layout.Master" AutoEventWireup="true" CodeBehind="Collections.aspx.cs" Inherits="HaiDen.Views.Collections" %>

<%@ Register Src="~/Views/Control/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Views/Control/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>



<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <input type="hidden" runat="server" id="hdAlias" value="-1" />
    <uc1:Header runat="server" ID="Header" />
    <section class="container content-page pagelist">
        <div class="page-head">
            <div class="logo">
                <a href="<%= Page.ResolveClientUrl("~/index.html")%>">
                    <span id="lb-banner">Truong Thanh Hai</span>
                </a>
            </div>
            <h2></h2>
            <label></label>
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
            var WeddingDress_Script = new WeddingDressScript();
            WeddingDress_Script.init();
        });
    </script>
</asp:Content>
