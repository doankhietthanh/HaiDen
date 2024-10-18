<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Views/_layout.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="HaiDen.Views.Member" %>

<%@ Register Src="~/Views/Control/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Views/Control/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <link href="../Assets/plugins/UploadImages/jquery.fileupload.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <uc1:Header runat="server" ID="Header" />
    <section class="container content-page signup-page profile">
        <div class="page-head">
            <div class="logo">
                <a href="<%= Page.ResolveClientUrl("~/index.html")%>">
                    <span id="lb-banner">Truong Thanh Hai</span>
                </a>
            </div>
            <h2>Profile</h2>
        </div>
        <div class="page-content">
            <div class="row">
                <div class="col-lg-4 left-side">
                    <div class="avatar-control">
                        <div>
                            <span class=" fileinput-button">
                                <i class="glyphicon glyphicon-plus"></i>
                                <span>Change avatar</span>
                                <input id="fileupload" type="file" name="files[]" multiple />
                            </span>
                            <div id="progress" class="progress">
                                <div class="progress-bar progress-bar-success"></div>
                            </div>
                            <div id="files" class="files">
                                <img src="" width="400" height="400"  />
                            </div>
                        </div>

                        <div class="count-down">
                            <div class="count-detail">
                                <label>Countdown</label>
                                <label class="countdown">0</label>
                                <label>Day</label>
                            </div>
                        </div>
                        <%--<input type="button" class="btn-uploadAvatar" value="Your profile photo" />--%>
                    </div>
                </div>
                <div class="col-lg-8 right-size">
                    <div class="row info">
                        <div class="col-lg-8 info-data">
                            <ul>
                                <li>
                                    <div>
                                        <label class="name">Name</label>
                                        <small class="nation">-</small>
                                    </div>

                                </li>
                                <li>
                                    <i class="fa fa-mobile"></i>
                                    <label class="phone">000000</label>
                                </li>
                                <li>
                                    <i class="fa fa-envelope"></i>
                                    <label class="mail">text@xxx.xx</label>
                                </li>
                            </ul>
                        </div>
                        <div class="col-lg-4 info-action">
                            <a href="<%= Page.ResolveClientUrl("~/favorite")%>" class="link2favouite">
                                <label>My Favouite</label>
                                <i class="fa fa-heart-o"></i>
                            </a>
                            <a href="javascript:void(0)" data-toggle="modal" data-target="#MyProfile" id="btnEditProfile" class="link2favouite">
                                <label>My Profile</label>
                                <i class="fa fa-pencil-square-o"></i>
                            </a>
                            

                        </div>
                    </div>
                    <div class="row order">
                        <div class="col-12 order-detail">
                            <h5>My Order</h5>
                            <div class="row detail">
                                <div class="col-12">
                                    <label>Dress: </label>
                                    <label class="dress">-</label>
                                </div>
                                <div class="col-lg-6 col-sm-12">
                                    <label>Total amout: </label>
                                    <label class="amout">$0</label>
                                </div>
                                <div class="col-lg-6 col-sm-12">
                                    <label>Deposit: </label>
                                    <label class="deposit">$0</label>
                                </div>
                                <div class="col-lg-6 col-sm-12">
                                    <label>Toward purchase of: </label>
                                    <label class="toward">$0</label>
                                </div>
                                <div class="col-lg-6 col-sm-12">
                                    <label>Due date: </label>
                                    <label class="duedate">0</label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row progres">
                        <h5>Order Progress</h5>
                        <ul class="listProgress">
                            <li class="active">
                                <label>Place the order</label>
                            </li>
                            <li class="active">
                                <label>Deposit</label>
                            </li>
                            <li class="active">
                                <label>Production</label>
                            </li>
                            <li>
                                <label>Payment Completed</label>
                            </li>
                            <li>
                                <label>Shipping</label>
                            </li>
                        </ul>
                    </div>
                </div>

            </div>

        </div>
    </section>
    <uc1:Footer runat="server" ID="Footer" />

    <div class="modal fade" id="MyProfile" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle">Change Profile</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row justify-content-md-center" id="Inquiry_Info">
                        <div class="col-lg-6 left">
                            <div class="md-form form-lg">
                                <input type="text" id="iName" class="form-control form-control-lg">
                                <label for="iName">Name</label>
                            </div>
                            <div class="md-form form-lg">
                                <input type="text" id="iEmail" class="form-control form-control-lg">
                                <label for="iEmail">E-mail Address</label>
                            </div>
                            <div class="md-form form-lg">
                                <input type="password" id="iPass" disabled class="form-control form-control-lg disabled">
                                <label for="iPass">Your Password</label>
                            </div>
                            <div class="md-form form-lg">
                                <input type="password" id="iRePass" disabled class="form-control form-control-lg disabled">
                                <label for="iRePass">Confirm Password</label>
                            </div>
                        </div>
                        <div class="col-lg-6 right">
                            <div class="md-form form-lg">
                                <select class="mdb-select form-control form-control-lg" id="iNational">
                                </select>
                            </div>
                            <div class="md-form form-lg">
                                <input type="text" id="iBugget" class="form-control form-control-lg">
                                <label for="iBugget">Wedding Dress Bugget</label>
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

                </div>
                <div class="modal-footer">
                    <button type="button" id="btnSaveProfile">Save Profile</button>
                    <button type="button" id="btnChangePass">Change Passwords</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    <script src="../Assets/plugins/UploadImages/vendor/jquery.ui.widget.js"></script>
    <!-- The Load Image plugin is included for the preview images and image resizing functionality -->
    <script src="https://blueimp.github.io/JavaScript-Load-Image/js/load-image.all.min.js"></script>
    <!-- The Canvas to Blob plugin is included for image resizing functionality -->
    <script src="https://blueimp.github.io/JavaScript-Canvas-to-Blob/js/canvas-to-blob.min.js"></script>
    <script src="../Assets/plugins/UploadImages/jquery.fileupload.js"></script>
    <script src="../Assets/plugins/UploadImages/jquery.fileupload-process.js"></script>
    <script src="../Assets/plugins/UploadImages/jquery.fileupload-image.js"></script>
    <script src="../Assets/plugins/UploadImages/jquery.fileupload-validate.js"></script>
    <script src="<%= Page.ResolveClientUrl("~/Scripts/Inquiries_Script.js")%>"></script>
    <script>
        $(document).ready(function () {
            var Users_Script = new UsersScript();
            Users_Script.initProfile();

            var Inquiries_Script = new Inquiries();
            Inquiries_Script.initLoad();
        });
        $(function () {
            'use strict';
            // Change this to the location of your server-side upload handler:
            var url = _variable.url + '/uploadimg/-1';
            $('#fileupload').fileupload({
                url: url,
                dataType: 'json',
                autoUpload: true,
                acceptFileTypes: /(\.|\/)(gif|jpe?g|png)$/i,
                maxFileSize: 999000,
                // Enable image resizing, except for Android and Opera,
                // which actually support image resizing, but fail to
                // send Blob objects via XHR requests:
                disableImageResize: /Android(?!.*Chrome)|Opera/
                    .test(window.navigator.userAgent),
                previewMaxWidth: 400,
                previewMaxHeight: 400,
                previewCrop: true
            }).on('fileuploadadd', function (e, data) {
                var imgPreview = document.getElementById('files');
                imgPreview.innerHTML = '';
                data.context = $('<div/>').appendTo(imgPreview);
                $.each(data.files, function (index, file) {
                    var node = $('<p/>')
                        .append($('<span/>').text(file.name));
                    node.appendTo(data.context);

                });

                // del old img
                var member = JSON.parse(localStorage.getItem('memberData'));
                if (member != null) {
                    $.ajax({
                        url: _variable.url + '/Common/upload_img.ashx?name=' + member.U_AVATAR + '',
                        type: "POST",
                        cache: false,
                        async: true,
                        success: function (html) {
                            data.submit();
                        }
                    });
                } else {
                    data.submit();
                }


            }).on('fileuploadprocessalways', function (e, data) {
                var index = data.index,
                    file = data.files[index],
                    node = $(data.context.children()[index]);
                if (file.preview) {
                    node
                        .prepend('<br>')
                        .prepend(file.preview);
                }
                if (file.error) {
                    node
                        .append('<br>')
                        .append($('<span class="text-danger"/>').text(file.error));
                }
                if (index + 1 === data.files.length) {
                    data.context.find('button')
                        .text('Upload')
                        .prop('disabled', !!data.files.error);
                }
            }).on('fileuploadprogressall', function (e, data) {
                var progress = parseInt(data.loaded / data.total * 100, 10);
                $('#progress .progress-bar').css(
                    'width',
                    progress + '%'
                );
            }).on('fileuploaddone', function (e, data) {
                var Users_Script = new UsersScript();
                Users_Script.changeAvatar(data.result[0].name);
                //$.each(data.result.files, function (index, file) {
                //    if (file.url) {
                //        var link = $('<a>')
                //            .attr('target', '_blank')
                //            .prop('href', file.url);
                //        $(data.context.children()[index])
                //            .wrap(link);
                //    } else if (file.error) {
                //        var error = $('<span class="text-danger"/>').text(file.error);
                //        $(data.context.children()[index])
                //            .append('<br>')
                //            .append(error);
                //    }
                //});
            }).on('fileuploadfail', function (e, data) {
                debugger
                $.each(data.files, function (index) {
                    var error = $('<span class="text-danger"/>').text('File upload failed.');
                    $(data.context.children()[index])
                        .append('<br>')
                        .append(error);
                });
            }).prop('disabled', !$.support.fileInput)
                .parent().addClass($.support.fileInput ? undefined : 'disabled');
        });
    </script>
</asp:Content>
