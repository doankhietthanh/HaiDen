<%@ Page Title="Brides Stories" Language="C#" MasterPageFile="~/Views/_layout.Master" AutoEventWireup="true" CodeBehind="BridesStoriesDetail.aspx.cs" Inherits="HaiDen.Views.BridesStoriesDetail" %>



<%@ Register Src="~/Views/Control/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Views/Control/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <uc1:Header runat="server" ID="Header" />

    <input type="hidden" runat="server" id="hdAlias" value="-1" />
    <section class="container content-page signup-page profile bridal-story">
        <div class="page-head">
            <div class="logo">
                <a href="<%= Page.ResolveClientUrl("~/index.html")%>">
                    <span id="lb-banner">Truong Thanh Hai</span>
                </a>
            </div>
            <h2>Brides Stories</h2>
        </div>
        <div class="page-content">
            <div class="row">
                <div class="col-12">
                    <h3 class="newsTitle"></h3>
                </div>
                <div class="col-lg-9 newsDetail text-justify" style="margin: 0 auto">
                </div>
            </div>

        </div>
    </section>
    <uc1:Footer runat="server" ID="Footer" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/Scripts/BrideStories_Script.js")%>"></script>
    <script>
        $(document).ready(function () {
            var BrideStories_Script = new BrideStoriesScript();
            BrideStories_Script.initdata();
        });
    </script>
</asp:Content>
