<%@ Page Title="Terms & Conditions" Language="C#" MasterPageFile="~/Views/_layout.Master" AutoEventWireup="true" CodeBehind="TermsConditions.aspx.cs" Inherits="HaiDen.Views.TermsConditions" %>

<%@ Register Src="~/Views/Control/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Views/Control/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <uc1:Header runat="server" ID="Header" />

    <input type="hidden" runat="server" id="hdAlias" value="-1" />
    <section class="container content-page signup-page profile">
        <div class="page-head">
            <h2>Terms & Conditions</h2>
        </div>
        <div class="page-content">
            <div class="row">
                <div class="col-12">
                    <div class="detail text-justify" id="detail">
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
            var InfoPrivacy_Script = new InfoScript();
            InfoPrivacy_Script.initTerm();
        });
    </script>
</asp:Content>