<%@ Page Title="" Language="C#" MasterPageFile="~/Views/_layout.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="HaiDen.Views.index" %>

<%@ Register Src="~/Views/Control/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Views/Control/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>



<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <uc1:Header runat="server" ID="Header" />
    <section class="container banner">
        <div class="row justify-content-end">
            <div class="col-lg-8 col-md-9 col-sm-12 round_banner">
                <img class="banner_img" src="" width="1020" height="765"  />
            </div>
        </div>
        <div class="row">
            <div class="col-12 text-center">
                <%--<img class="banner_bottom" src="../Assets/img/resource/logo-banner.png" height="225"  />--%>
                <label id="lb-banner"> Truong Thanh Hai</label>
            </div>
        </div>
    </section>
    <section class="container site-content">
        <section class="listCollection">
            <div class="row align-items-center list-1">
            </div>
            <div class="row list-2">
            </div>
            <div class="row align-items-end list-3">
            </div>
            <div class="row align-items-end list-4">
            </div>
            <div class="row align-items-end list-5">
            </div>
        </section>
        <section class="OrderProcess">
            <h1 class="title text-center">Order Process</h1>
            <div class="row align-items-center">
                <div class="col-lg-7">
                    <a href="<%= Page.ResolveClientUrl("~/order-process")%>">
                        <img src="" width="845" height="565"  /></a>
                </div>
                <div class="mr-lg-auto col-lg-4">
                    <a href="<%= Page.ResolveClientUrl("~/order-process")%>">
                        <aside>
                            <p class="text-justify"></p>
                        </aside>
                    </a>
                </div>
            </div>
        </section>
        <section class="BridesStories">
            <h1 class="title text-center">Brides Stories</h1>
            <div class="row justify-content-lg-center">
                <div class="col-lg-auto contents">
                    <a href="<%= Page.ResolveClientUrl("~/brides-stories")%>">
                        <img src="" width="1325" height="725"  />
                    </a>
                </div>

            </div>
        </section>
        <section class="AboutUs">
            <h1 class="title text-center">About Us</h1>
            <div class="row section-content justify-content-lg-center contents">
            </div>
        </section>
        <section class="News">
            <h1 class="title text-center">News</h1>
            <div class="row section-content justify-content-lg-center">
                <div class="col-lg-7 item-large">
                </div>
                <div class="col-lg-5 item-child">
                    <ul>
                    </ul>

                </div>
            </div>
        </section>
    </section>
    <section class="Faq container-fluid">
        <div class="row justify-content-lg-center align-items-center content">
            <div class="col-auto">
                <a href="<%= Page.ResolveClientUrl("~/faq")%>">Faq</a>
            </div>
        </div>
    </section>
    <uc1:Footer runat="server" ID="Footer" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/Scripts/Banner_Script.js")%>"></script>
    <script>
        $(document).ready(function () {
            var CollectionIndex_Script = new CollectionScript();
            CollectionIndex_Script.initIndex();
        });
    </script>
    <script src="<%= Page.ResolveClientUrl("~/Scripts/OrderProcess_Script.js")%>"></script>
    <script src="<%= Page.ResolveClientUrl("~/Scripts/BrideStories_Script.js")%>"></script>
    <script src="<%= Page.ResolveClientUrl("~/Scripts/AboutUs_Script.js")%>"></script>
    <script src="<%= Page.ResolveClientUrl("~/Scripts/News_Script.js")%>"></script>
    <script>
        $(document).ready(function () {
            var News_Script = new NewsScript();
            News_Script.initIndex();
        });
        $(document).ready(function () {
            var BrideStoriesCate_Script = new BrideStoriesScript();
            BrideStoriesCate_Script.init();

            var AboutUsCate_Script = new AboutUsScript();
            AboutUsCate_Script.init();
        });

    </script>
</asp:Content>
