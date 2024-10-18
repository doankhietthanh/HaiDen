<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menus.ascx.cs" Inherits="HaiDen.Admin.App_Control.Menus" %>

<aside id="s-main-menu" class="sidebar">
    <div class="smm-header">
        <i class="zmdi zmdi-long-arrow-left" data-ma-action="sidebar-close"></i>
    </div>

    <ul class="smm-alerts">
    </ul>

    <ul class="main-menu">

        <%-- <li class="active"><a href="Index.aspx"><i class="zmdi zmdi-home"></i>Admin Home Page </a></li>

        <li runat="server" id="collection"><a href="Collections.aspx"><i class="zmdi zmdi-labels zmdi-hc-fw"></i>Collections</a> </li>
        <li runat="server" id="dress"><a href="Wedding_Dress.aspx"><i class="zmdi zmdi-female zmdi-hc-fw"></i>Collection details</a></li>
        <li runat="server" id="inquries"><a href="Inquiries.aspx"><i class="zmdi zmdi-shopping-basket zmdi-hc-fw"></i>Inquiries </a></li>
        <li runat="server" id="storiescate"><a href="Bride_stories_cate.aspx"><i class="zmdi zmdi-layers zmdi-hc-fw"></i>Bride Stories Category </a></li>
        <li runat="server" id="stories"><a href="Bride_stories.aspx"><i class="zmdi zmdi-library zmdi-hc-fw"></i>Bride Stories </a></li>
        <li runat="server" id="new"><a href="News.aspx"><i class="zmdi zmdi-edit zmdi-hc-fw"></i>News</a></li>
        <li runat="server" id="banner"><a href="Banner.aspx"><i class="zmdi zmdi-image-alt zmdi-hc-fw"></i>Head Image </a></li>
        <li runat="server" id="faqcate"><a href="FAQ_Cate.aspx"><i class="zmdi zmdi-help-outline zmdi-hc-fw"></i>FAQ Category </a></li>
        <li runat="server" id="faq"><a href="FAQS.aspx"><i class="zmdi zmdi-pin-help zmdi-hc-fw"></i>FAQ</a> </li>
        <li runat="server" id="oprogress"><a href="OrderProcess.aspx"><i class="zmdi zmdi-flag zmdi-hc-fw"></i>Order Progress </a></li>
        <li runat="server" id="info"><a href="Info.aspx"><i class="zmdi zmdi-help zmdi-hc-fw "></i>Contact us</a></li>
        <li runat="server" id="user"><a href="Users.aspx"><i class="zmdi zmdi-account-circle zmdi-hc-fw"></i>Users </a></li>
        <li runat="server" id="admin"><a href="Admin.aspx"><i class="zmdi zmdi-account zmdi-hc-fw"></i>Admin</a> </li>--%>

        <li runat="server" class="sub-menu">
            <a href="#" data-ma-action="submenu-toggle"><i class="zmdi zmdi-home"></i>Home </a>
            <ul>
                <li><a href="Banner.aspx"><i class="zmdi zmdi-image-alt zmdi-hc-fw"></i>Head Image </a></li>
                <li><a href="Collections.aspx"><i class="zmdi zmdi-labels zmdi-hc-fw"></i>Collections</a></li>

                <li><a href="Bride_stories_cate.aspx"><i class="zmdi zmdi-layers zmdi-hc-fw"></i>Bride Stories Home </a></li>
                <li><a href="Info.aspx"><i class="zmdi zmdi-help zmdi-hc-fw "></i>Contact us</a></li>

            </ul>
        </li>
        <li runat="server" class="sub-menu">
            <a href="#" data-ma-action="submenu-toggle"><i class="zmdi zmdi-help-outline zmdi-hc-fw"></i>FAQ </a>
            <ul>
                <li><a href="FAQ_Cate.aspx"><i class="zmdi zmdi-help-outline zmdi-hc-fw"></i>FAQ Category </a></li>
                <li><a href="FAQS.aspx"><i class="zmdi zmdi-pin-help zmdi-hc-fw"></i>FAQ</a> </li>

            </ul>
        </li>
        <li runat="server" id="dress"><a href="Wedding_Dress.aspx"><i class="zmdi zmdi-female zmdi-hc-fw"></i>Collection details</a></li>
        <li runat="server" id="inquries"><a href="Inquiries.aspx"><i class="zmdi zmdi-shopping-basket zmdi-hc-fw"></i>Inquiries Detail </a></li>
        <li runat="server" id="stories"><a href="Bride_stories.aspx"><i class="zmdi zmdi-library zmdi-hc-fw"></i>Bride Stories Detail </a></li>
        <li runat="server" id="new"><a href="News.aspx"><i class="zmdi zmdi-edit zmdi-hc-fw"></i>News</a></li>
        <li runat="server" id="process"><a href="OrderProcess.aspx"><i class="zmdi zmdi-flag zmdi-hc-fw"></i>Order Process </a></li>
        <li runat="server" id="about"><a href="About_Us.aspx"><i class="zmdi zmdi-info zmdi-hc-fw"></i>About Us</a></li>
        <li runat="server" id="user"><a href="Users.aspx"><i class="zmdi zmdi-account-circle zmdi-hc-fw"></i>Users </a></li>
        <li runat="server" id="admin"><a href="Admin.aspx"><i class="zmdi zmdi-account zmdi-hc-fw"></i>Admin</a> </li>

    </ul>
</aside>
