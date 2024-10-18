<%@ Page Title="Order Process" Language="C#" MasterPageFile="~/Views/_layout.Master" AutoEventWireup="true" CodeBehind="OrderProcess.aspx.cs" Inherits="HaiDen.Views.OrderProcess" %>


<%@ Register Src="~/Views/Control/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Views/Control/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <uc1:Header runat="server" ID="Header" />
    <section class="container content-page signup-page profile">
        <div class="page-head">
            <div class="logo">
                <a href="<%= Page.ResolveClientUrl("~/index.html")%>">
                    <span id="lb-banner">Truong Thanh Hai</span>
                </a>
            </div>
            <h2>Order Process</h2>
        </div>
        <div class="page-content">
            <div class="row">
                <div class="col-lg-12 processDetail">
                </div>
            </div>

        </div>
    </section>
    <uc1:Footer runat="server" ID="Footer" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/Scripts/OrderProcess_Script.js")%>"></script>
    <script>
        $(document).ready(function () {
            var OrderProcess_Script = new OrderProcessScript();
            OrderProcess_Script.initDetail();
        });
    </script>
</asp:Content>
