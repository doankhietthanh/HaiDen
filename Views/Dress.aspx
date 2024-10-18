<%@ Page Title="" Language="C#" MasterPageFile="~/Views/_layout.Master" AutoEventWireup="true" CodeBehind="Dress.aspx.cs" Inherits="HaiDen.Views.Dress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <script type='text/javascript' src='//platform-api.sharethis.com/js/sharethis.js#property=5babd2df57034700119528e3&product=unknown' async='async'></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <input type="hidden" runat="server" id="hdAlias" value="-1" />
    <div class="container dress-page">
        <div class="row align-items-center justify-content-md-center">
            <div class="col-lg-3 list-dess-img">
                <ul>
                    <li class="active">
                        <img src="" width="120" height="175" /></li>
                    <li>
                        <img src="" width="120" height="175" /></li>
                    <li>
                        <img src="" width="120" height="175" /></li>
                    <li>
                        <img src="" width="120" height="175" /></li>
                    <li>
                        <img src="" width="120" height="175" /></li>
                    <li>
                        <img src="" width="120" height="175" /></li>
                </ul>
            </div>
            <div class="col-lg-6 detail-dess-img">
                <a href="#" target="_blank">
                    <img src="" width="690" height="1035" /></a>

            </div>
            <div class="col-lg-3 detail-dress-content">
                <span class="logo"><a href="<%= Page.ResolveClientUrl("~/index.html")%>">
                    <img src="../Assets/img/resource/logo.png" /></a></span>
                <h1 class="collection-current"></h1>
                <span class="season-box"></span>
                <h2></h2>
                <span class="price">-</span>
                <div class="dress-detail"></div>
                <button data-toggle="modal" data-target="#InquireModal">Inquire</button>
                <button class="favorite add_to_fav" title="Add to favourite" data-id=""><i class="fa fa-heart"></i></button>
                <div class="social">
                    <div class="sharethis-inline-share-buttons"></div>

                    <%--<ul>
                        <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                        <li><a href="#"><i class="fa fa-instagram"></i></a></li>
                        <li><a href="#"><i class="fa fa-pinterest-p"></i></a></li>
                        <li><a href="#"><i class="fa fa-heart"></i></a></li>
                    </ul>--%>
                </div>
            </div>
        </div>

        <div class="control control-left">
            <img src="../Assets/img/back.png" />
        </div>
        <div class="control control-right">
            <img src="../Assets/img/next.png" />
        </div>
        <div class="control control-close">
            <img src="../Assets/img/close_btn.png" />
        </div>

    </div>
    <div class="modal fade" id="InquireModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle">Inquire</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row justify-content-md-center guest" id="Inquiry_Info">
                        <div class="col-lg-6 col-sm-12">
                            <div class="md-form form-lg">
                                <input type="text" id="iName" class="form-control form-control-lg">
                                <label for="iName">Name</label>
                            </div>
                            <div class="md-form form-lg">
                                <input type="text" id="iEmail" class="form-control form-control-lg">
                                <label for="iEmail">E-mail Address</label>
                            </div>
                            <div class="md-form form-lg">
                                <input type="text" id="iBugget" class="form-control form-control-lg">
                                <label for="iBugget">Wedding Dress Bugget</label>
                            </div>
                        </div>
                        <div class="col-lg-6 col-sm-12">
                            <div class="md-form form-lg">
                                <select class="mdb-select form-control form-control-lg" id="iNational">
                                    <option value="-1" selected>Where Do You Live</option>
                                    <option value="1">Vietnam</option>
                                    <option value="2">USA</option>
                                </select>
                            </div>
                            <div class="md-form form-lg">
                                <input type="text" id="iPhone" class="form-control form-control-lg">
                                <label for="iPhone">Telephone</label>
                            </div>
                            <div class="md-form form-lg">
                                <input type="text" id="iWeddingDate" class="form-control form-control-lg datepicker">
                                <label for="iWeddingDate">Your Wedding Date</label>
                            </div>
                        </div>
                    </div>
                    <div class="row justify-content-md-center">
                        <div class="col-lg-6 col-sm-12 imessClass">
                            <label for="iMess">Message</label>
                            <textarea id="iMess">

                            </textarea>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btnInquiry">Submit</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/Scripts/WeddingDress_Script.js")%>"></script>
    <script src="<%= Page.ResolveClientUrl("~/Scripts/Inquiries_Script.js")%>"></script>
    <script>
        $(document).ready(function () {
            var WeddingDress_Script = new WeddingDressScript();
            WeddingDress_Script.initDetail();
            WeddingDress_Script.initImg();

            var Inquiries_Script = new Inquiries();
            Inquiries_Script.init();
        });
    </script>
</asp:Content>
