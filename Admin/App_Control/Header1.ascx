<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header1.ascx.cs" Inherits="HaiDen.Admin.App_Control.Header1" %>
<ul class="pull-right h-menu">
    <li class="hm-search-trigger">
        <a href="" data-ma-action="search-open">
            <i class="hm-icon zmdi zmdi-search"></i>
        </a>
    </li>
    <li class="dropdown hidden-xs hidden-sm h-apps">

        <ul class="dropdown-menu pull-right">

            <%--  <li class="hidden-xs">
                <a data-action="fullscreen" href=""><i class="zmdi zmdi-fullscreen"></i>Toggle Fullscreen</a>
            </li>--%>
<%--            <li>
                <a data-action="clear-localstorage" href=""><i class="zmdi zmdi-delete"></i>Clear Local Storage</a>
            </li>
            <li>
                <a href=""><i class="zmdi zmdi-face"></i>Privacy Settings</a>
            </li>
            <li>
                <a href=""><i class="zmdi zmdi-settings"></i>Other Settings</a>
            </li>--%>


        </ul>
    </li>

    <li class="hm-alerts" data-user-alert="sua-messages" data-ma-action="sidebar-open" data-ma-target="user-alerts">
        <a href=""><i class="hm-icon zmdi zmdi-notifications"></i></a>
    </li>
    <li class="dropdown hm-profile">
        <a data-toggle="dropdown" href="" runat="server" id="ad_img">
            <img src="img/profile-pics/1.jpg" alt="">
        </a>

        <ul class="dropdown-menu pull-right dm-icon">
            <li class="hidden-xs">
                <a data-action="fullscreen" href=""><i class="zmdi zmdi-fullscreen"></i>Full Màn Hình </a>
            </li>
           <%-- <li>
                <a href=""><i class="zmdi zmdi-input-antenna"></i>Privacy Settings</a>
            </li>
            <li>
                <a href=""><i class="zmdi zmdi-settings"></i>Settings</a>
            </li>--%>
            <li>
                <asp:LinkButton ID="lbtn_thoat" OnClick="lbtn_thoat_Click" OnClientClick="return Logout()" runat="server"><i class="zmdi zmdi-time-restore"></i>Logout</asp:LinkButton>
            </li>
        </ul>
    </li>
</ul>
