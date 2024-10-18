<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="HaiDen.Views.Control.Header" %>


<nav class="container navbar fixed-top navbar-expand-lg no-shadow top-menu">
    <div class="collapse navbar-collapse" id="navbarSupportedContent">

        <ul class="navbar-nav ml-auto">
            <li class="nav-item Uzone" runat="server" id="Guest_zone">
                <label class="nav-link waves-effect waves-light signin">
                    <i class="fa fa-user"></i><a href="<%= Page.ResolveClientUrl("~/signin")%>">SignIn </a><a>/</a> <a href="<%= Page.ResolveClientUrl("~/signup")%>">SignUp</a></label>
            </li>
            <li class="nav-item avatar dropdown Uzone" runat="server" id="User_zone">
                <a class="nav-link dropdown-toggle waves-effect waves-light" id="navbarDropdownMenuLink-4" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <img src="" class="rounded-circle z-depth-0" /><label></label>
                </a>
                <div class="dropdown-menu dropdown-menu-right dropdown-info" aria-labelledby="navbarDropdownMenuLink-4">
                    <a class="dropdown-item waves-effect waves-light" href="<%= Page.ResolveClientUrl("~/member")%>">My account</a>
                    <a class="dropdown-item waves-effect waves-light btnLogout" href="javascript:void(0)">Log out</a>
                </div>
            </li>
        </ul>
    </div>
</nav>

<section class=" menu">
    <div class="logo">
        <a href="<%= Page.ResolveClientUrl("~/index.html")%>">
            <img src="../Assets/img/resource/logo.png" /></a>
    </div>
    <nav class="navbar navbar-expand-md no-shadow">
        <div class=" navbar-collapse" id="navbarNavDropdown">
            <ul class="navbar-nav">
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="fa fa-navicon"></i>Menu
                    </a>
                    <ul class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                        <li><a class="dropdown-item dropdown-toggle" href="#">Collection</a>
                            <ul class="dropdown-menu" id="listCollection">
                            </ul>
                        </li>
                        <li><a class="dropdown-item" href="<%= Page.ResolveClientUrl("~/order-process")%>">Order Process</a></li>
                        <li><a class="dropdown-item" href="<%= Page.ResolveClientUrl("~/brides-stories")%>">Brides Stories</a></li>
                        <li><a class="dropdown-item" href="<%= Page.ResolveClientUrl("~/about-us")%>">About Us</a></li>
                        <li><a class="dropdown-item" href="<%= Page.ResolveClientUrl("~/news")%>">News</a></li>
                        <li><a class="dropdown-item" href="<%= Page.ResolveClientUrl("~/faq")%>">Faq</a></li>
                        <li><a class="dropdown-item" href="<%= Page.ResolveClientUrl("~/contact-us")%>">Contact Us</a></li>
                        <li class="nav-item Uzone_mobi" runat="server" id="Guest_zone_mobi">
                            <label class="nav-link waves-effect waves-light signin">
                                <i class="fa fa-user"></i><a href="<%= Page.ResolveClientUrl("~/signin")%>">SignIn </a><a>/</a> <a href="<%= Page.ResolveClientUrl("~/signup")%>">SignUp</a></label>
                        </li>
                        <li class="nav-item avatar dropdown Uzone_mobi" runat="server" id="User_zone_mobi">
                            <a class="nav-link dropdown-toggle waves-effect waves-light" id="navbarDropdownMenuLink-4-1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <img src="" class="rounded-circle z-depth-0" /><label></label>
                            </a>
                            <div class="dropdown-menu dropdown-menu-right dropdown-info" aria-labelledby="navbarDropdownMenuLink-4">
                                <a class="dropdown-item waves-effect waves-light" href="<%= Page.ResolveClientUrl("~/member")%>">My account</a>
                                <a class="dropdown-item waves-effect waves-light btnLogout" href="javascript:void(0)">Log out</a>
                            </div>
                        </li>
                        <li class="social-item">
                            <ul>
                                <li><a class="fblink" href="#"><i class="fa fa-facebook"></i></a></li>
                                <li><a class="istarg" href="#"><i class="fa fa-instagram"></i></a></li>
                                <li><a class="printer" href="#"><i class="fa fa-pinterest-p"></i></a></li>
                            </ul>
                        </li>
                    </ul>
                </li>
            </ul>
        </div>
    </nav>

</section>
