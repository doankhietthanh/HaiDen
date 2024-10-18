<%@ Page Title="Sign In" Language="C#" MasterPageFile="~/Views/_layout.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="HaiDen.Views.SignIn" %>

<%@ Register Src="~/Views/Control/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Views/Control/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <uc1:Header runat="server" ID="Header" />
    <section class="container content-page signin-page">
        <div class="row align-items-center justify-content-md-center">
            <div class="col-lg-8 signin-content">
                <div class="page-head">
                    <div class="logo">
                        <a href="#">
                            <img src="../Assets/img/resource/logo.png"  />
                        </a>
                    </div>

                </div>
                <div class="page-content text-center">
                    <div class="row">
                        <div class="col-lg-5 left">
                            <h1>Sign In</h1>
                            <div class="md-form form-lg">
                                <input type="text" id="iEmail" class="form-control form-control-lg">
                                <label for="iEmail">E-mail Address</label>
                            </div>
                            <div class="md-form form-lg">
                                <input type="password" id="iPass" class="form-control form-control-lg">
                                <label for="iPass">Your Password</label>
                            </div>
                            <div class="btn-act">
                                <button type="button" class="btn-signin" id="btnSignIn">Sign In</button>
                            </div>
                        </div>
                        <div class="col-lg-7 right ">
                            <h1>Don't have an account</h1>
                            <p>Having a TRUONG THANH HAI Bridal account will give you access to:</p>
                            <ul class="clearfix">
                                <li>Save items in your wishlist</li>
                                <li>Persionalized recommentdations</li>
                                <li>Order delivery updates and return management</li>
                            </ul>
                            <div class="btn-act">
                                <a href="<%= Page.ResolveClientUrl("~/signup")%>" class="createAcc">Create an account</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
    <uc1:Footer runat="server" ID="Footer" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    
    <script>
        $(document).ready(function () {
            var Users_Script = new UsersScript();
            Users_Script.SignIn();
        });
    </script>
</asp:Content>
