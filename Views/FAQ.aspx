<%@ Page Title="FAQ" Language="C#" MasterPageFile="~/Views/_layout.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="HaiDen.Views.FAQ" %>


<%@ Register Src="~/Views/Control/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Views/Control/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <uc1:Header runat="server" ID="Header" />

    <input type="hidden" runat="server" id="hdAlias" value="-1" />
    <section class="container content-page signup-page faq">
        <div class="page-head">
            <h2>FAQ</h2>
        </div>
        <div class="pageContent">
        </div>
    </section>
    <uc1:Footer runat="server" ID="Footer" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/Scripts/Faq_Script.js")%>"></script>
    <script>
        $(document).ready(function () {
            var Faq_Script = new FaqsScript();
            Faq_Script.init();
        });
    </script>
</asp:Content>
