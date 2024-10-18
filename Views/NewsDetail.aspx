<%@ Page Title="News" Language="C#" MasterPageFile="~/Views/_layout.Master" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="HaiDen.Views.NewsDetail" %>


<%@ Register Src="~/Views/Control/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Views/Control/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <title runat="server" id="meta_title"></title>
    <meta name="twitter:title" runat="server" id="meta_title_tw" content="" />
    <meta name="keywords" runat="server" id="meta_keywords" content="" />
    <meta name="robots" content="index, follow" runat="server" id="meta_robots" />
    <meta content="" runat="server" id="meta_title_fb" itemprop="headline" property="og:title" />
    <meta name="description" content="" runat="server" id="meta_description" />
    <meta content="" runat="server" id="meta_description_fb" itemprop="description" property="og:description" />
    <meta name="twitter:description" runat="server" id="meta_description_tw" content="" />
    <meta property="og:image" runat="server" id="meta_img_fb" itemprop="thumbnailUrl" content="http://southlands.vn/Assets/img/logos/logo.png" />
    <meta name="twitter:image" runat="server" id="meta_img_tw" content="http://southlands.vn/Assets/img/logos/logo.png" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <uc1:Header runat="server" ID="Header" />

    <input type="hidden" runat="server" id="hdAlias" value="-1" />
    <section class="container content-page signup-page profile">
        <div class="page-head">
            <div class="logo">
                <a href="<%= Page.ResolveClientUrl("~/index.html")%>">
                    <img src="../Assets/img/resource/logo-banner.png" />
                </a>
            </div>
            <h2>News</h2>
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
    <script src="<%= Page.ResolveClientUrl("~/Scripts/News_Script.js")%>"></script>
    <script>
        $(document).ready(function () {
            var News_Script = new NewsScript();
            News_Script.init();
        });
    </script>
</asp:Content>
