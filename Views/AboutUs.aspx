<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Views/_layout.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="HaiDen.Views.AboutUs" %>



<%@ Register Src="~/Views/Control/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Views/Control/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <uc1:Header runat="server" ID="Header" />

    <input type="hidden" runat="server" id="hdAlias" value="-1" />
    <section class="container content-page signup-page aboutus">
        <div class="page-head">
            <h2>About Us</h2>
        </div>
        <div class="pageContent">
            <div class="row item1">
                <div class="col-lg-5">
                    <img src="" width="645" style="background: #ddd;" />
                </div>
                <div class="col-lg-6 ml-lg-auto">
                    <div class="head">
                        <span class="ab">About</span>
                        <span class="name">HaiDen Truong</span>
                        <span class="title">Designer</span>
                    </div>
                    <div class="detail">
                    </div>
                </div>
            </div>
            <div class="row item2">

                <div class="col-lg-5 ">
                    <div class="head">
                        <span class="ab">About</span>
                        <span class="name">HaiDen Truong</span>
                        <span class="title">Designer</span>
                    </div>
                    <div class="detail">
                    </div>
                </div>
                <div class="col-lg-6 ml-lg-auto">
                    <img src="" width="800" style="background: #ddd;" />
                </div>
            </div>
        </div>
    </section>
    <uc1:Footer runat="server" ID="Footer" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/Scripts/AboutUs_Script.js")%>"></script>
    <script>
        $(document).ready(function () {
            var AboutUsCate_Script = new AboutUsScript();
            AboutUsCate_Script.initDetail();
        });
    </script>
</asp:Content>
