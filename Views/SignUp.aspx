<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Views/_layout.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="HaiDen.Views.SignUp" %>

<%@ Register Src="~/Views/Control/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Views/Control/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <link href="../Assets/plugins/UploadImages/jquery.fileupload.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <uc1:Header runat="server" ID="Header" />
    <input type="hidden" id="imgName" value="" />
    <section class="container content-page signup-page">
        <div class="page-head">
            <div class="logo">
                <a href="#">
                    <img src="../Assets/img/resource/logo.png"  />
                </a>
            </div>
            <h1>Sign Up</h1>
        </div>
        <div class="page-content">
            <div class="row">
                <div class="col-lg-4">
                    <div class="avatar-control">

                        <div id="progress" class="progress">
                            <div class="progress-bar progress-bar-success"></div>
                        </div>
                        <div id="files" class="files">
                            <img src="" width="400" height="400"  />
                        </div>

                        <span class=" fileinput-button">
                            <i class="glyphicon glyphicon-plus"></i>
                            <span>Your profile photo</span>
                            <input id="fileupload" type="file" name="files[]" multiple />
                        </span>
                    </div>
                </div>
                <div class="col-lg-4 left">
                    <div class="md-form form-lg">
                        <input type="text" id="iName" class="form-control form-control-lg">
                        <label for="iName">Name</label>
                    </div>
                    <div class="md-form form-lg">
                        <input type="text" id="iEmail" class="form-control form-control-lg">
                        <label for="iEmail">E-mail Address</label>
                    </div>
                    <div class="md-form form-lg">
                        <input type="password" id="iPass" class="form-control form-control-lg">
                        <label for="iPass">Your Password</label>
                    </div>
                    <div class="md-form form-lg">
                        <input type="password" id="iRePass" class="form-control form-control-lg">
                        <label for="iRePass">Confirm Password</label>
                    </div>
                </div>
                <div class="col-lg-4 right">
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
            <div class=" row align-items-center justify-content-md-center form-action">
                <div class="col-12 text-center">
                    <div id="button_zone">
                        <button type="button" id="btnSignUp">Create Account</button>
                    </div>

                    <span>By singing up, you agree to our <a href="<%= Page.ResolveClientUrl("~/terms-conditions")%>">Terms of Use</a> & <a href="<%= Page.ResolveClientUrl("~/privacy-policy")%>">Privacy Policy.</a></span>
                </div>
            </div>

        </div>
        <div class="thank_you">
            <h3>Thank you have logged in account at Haiden bridal</h3>
            <a href="<%= Page.ResolveClientUrl("~/signin")%>">go to login</a>
        </div>
    </section>
    <uc1:Footer runat="server" ID="Footer" />
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
            Users_Script.loadNational();
            Users_Script.init();
        });
        $(function () {
            'use strict';
            // Change this to the location of your server-side upload handler:
            var url = window.location.hostname === 'blueimp.github.io' ?
                '//jquery-file-upload.appspot.com/' : _variable.url + '/uploadimg/-1',
                uploadButton = $('<button/>')
                    //.addClass('btn btn-primary')
                    .prop('disabled', true)
                    .text('Processing...')
                    .on('click', function () {
                        var $this = $(this),
                            data = $this.data();

                        var Users_Script = new UsersScript();
                        Users_Script.initAuto($this);
                        //data.submit().always(function () {
                        //    $this.remove();
                        //});
                    });
            $('#fileupload').fileupload({
                url: url,
                dataType: 'json',
                autoUpload: false,
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
                    if (!index) {
                        //node
                        //    .append('<br>')
                        //    .append(uploadButton.clone(true).data(data));
                        $('#button_zone').html(uploadButton.clone(true).data(data));
                    }
                    node.appendTo(data.context);
                });
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
                    $('#button_zone').find('button')
                        .text('Create Account')
                        .prop('disabled', !!data.files.error);
                    //data.context.find('button')
                    //    .text('Upload')
                    //    .prop('disabled', !!data.files.error);
                    $('#imgName').val(data.files[0].name);
                }
            }).on('fileuploadprogressall', function (e, data) {
                var progress = parseInt(data.loaded / data.total * 100, 10);
                $('#progress .progress-bar').css(
                    'width',
                    progress + '%'
                );
            }).on('fileuploaddone', function (e, data) {

                $.each(data.result.files, function (index, file) {
                    //debugger
                    if (file.url) {
                        var link = $('<a>')
                            .attr('target', '_blank')
                            .prop('href', file.url);
                        $(data.context.children()[index])
                            .wrap(link);
                    } else if (file.error) {
                        var error = $('<span class="text-danger"/>').text(file.error);
                        $(data.context.children()[index])
                            .append('<br>')
                            .append(error);
                    }
                });
                window.location.href = _variable.url + '/signin';
            }).on('fileuploadfail', function (e, data) {
                //debugger
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
