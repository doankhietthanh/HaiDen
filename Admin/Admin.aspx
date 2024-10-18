<%@ Page Title="Admins" Language="C#" MasterPageFile="~/Admin/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="HaiDen.Admin.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="bower_components/chosen/chosen.min.css" rel="stylesheet" />
    <link href="bower_components/bootstrap-sweetalert/sweet-alert.css" rel="stylesheet" />
    <link href="bower_components/bootstrap-datepicker/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <link href="bower_components/bootstrap-select/bootstrap-select.css" rel="stylesheet" />
    <link href="bower_components/noUiSlider.8.5.1/jquery.nouislider.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>Admins</h2>
        </div>
        <table id="data-table-command" class="table table-striped table-vmiddle">
            <thead>
                <tr>
                    <th data-column-id="id" data-order="desc" data-type="numeric">ID</th>
                    <th data-column-id="imagess" data-formatter="pix">Hình ảnh</th>
                    <th data-column-id="ten" data-order="desc">Tên</th>
                    <th data-column-id="mail" data-order="desc">Mail</th>
                    <th data-column-id="commands" data-formatter="commands" data-sortable="false">Action</th>
                </tr>
            </thead>
            <tbody class="list_admin">
                <tr>
                    <td></td>
                </tr>
            </tbody>
        </table>
    </div>

    <div class="modal fade" id="preventClick" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">

                <div class="modal-header">
                    <h4 class="modal-title"></h4>
                    <button type="button" class="btn btn-link" data-dismiss="modal" style="position: absolute; right: 10px; top: 15px; color: #000;">X</button>
                </div>
                <div class="modal-body clearfix">

                    <input type="hidden" class="iid" value="0" />
                    <div class="col-sm-6">
                        <form id="frm">
                            <div class="form-group">
                                <label>Email</label>
                                <div class="fg-line">
                                    <input type="email" class="form-control imail" required maxlength="200" minlength="2" value="" placeholder="Email">
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="fg-line">
                                    <label>Mật Khẩu</label>
                                    <input type="password" class="form-control imk" required value="" placeholder="Mật Khẩu">
                                </div>
                            </div>

                            <div class="form-group ">
                                <label>Tên Admin </label>
                                <div class="fg-line">
                                    <input type="text" class="form-control iname" required maxlength="200" minlength="2" value="" placeholder="Tên Admin...">
                                </div>
                            </div>
                        </form>
                    </div>


                    <div class="col-sm-6" style="text-align: center;">
                        <div class="form-group fg-float">
                            <a id="UploadButton_APP_LIST" class="btn btn-primary waves-effect">Hình Ảnh</a>
                        </div>
                        <img class="pimg_APP_LIST" src="img/demo/note.png.ashx?width=290&height=250&mode=crop" />
                        <input type="hidden" id="iimg_APP_LIST" value="-1" />
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Đóng</button>
                    <button type="button" class="btn btn-primary btn-save">Lưu thay đổi</button>
                </div>
            </div>

        </div>
    </div>
    <div class="modal fade" id="rightClick" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <h4 class="modal-title"></h4>
                    <button type="button" class="btn btn-danger" data-dismiss="modal" style="position: absolute; right: 10px; top: 15px; color: #000; font-size: 17px;">
                        Đóng
                    </button>
                </div>
                <div class="modal-body clearfix">
                    <table class="table right-tbl">
                        <thead>
                            <tr>
                                <th>Tên Trang</th>
                                <th>Quyền</th>
                            </tr>
                        </thead>
                        <tbody id="tbl_right_list">
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">

                    <button type="button" class="btn btn-danger" data-dismiss="modal">Đóng</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script src="bower_components/autosize/autosize.min.js"></script>
    <script src="bower_components/input-mask/input-mask.min.js"></script>
    <script src="bower_components/chosen/chosen.jquery.min.js"></script>
    <script src="bower_components/bootstrap-sweetalert/sweet-alert.min.js"></script>
    <script src="bower_components/bootstrap-datepicker/bootstrap-datetimepicker.min.js"></script>
    <script src="bower_components/bootstrap-select/bootstrap-select.js"></script>
    <script src="bower_components/noUiSlider.8.5.1/jquery.nouislider.all.min.js"></script>
    <script src="Scripts/ajaxupload.js"></script>
    <script src="Scripts/jquery.validate.js"></script>
    <!-- Data Table -->
    <script type="text/javascript">
        var reload_key = 0;
        var path = '../Assets/HinhAnh/Admins/';
        $(document).ready(function () {
            load_admin();
            $('.btn-save').on('click', function () {
                var isValid = $("#frm").valid();
                if (isValid) {
                    insert_update_admin();
                }
            });
            uploadimg('APP_LIST');

        });
        //===================NOTIFIY================================
        function notify(title, message, from, align, icon, type, animIn, animOut) {

            title = title == '' ? "success!" : title;
            message = message == '' ? "success!" : message;
            from = from == '' ? "bottom" : from;
            align = align == '' ? "right" : align;
            type = type == '' ? "inverse" : type;
            animIn = animIn == '' ? "animated fadeInRight" : animIn;
            animOut = animOut == '' ? "animated fadeOutRight" : animOut;

            $.growl({
                icon: icon,
                title: title,
                message: message,
                url: ''
            }, {
                    element: 'body',
                    type: type,
                    allow_dismiss: true,
                    placement: {
                        from: from,
                        align: align
                    },
                    offset: {
                        x: 30,
                        y: 30
                    },
                    spacing: 10,
                    z_index: 1031,
                    delay: 2500,
                    timer: 1000,
                    url_target: '_blank',
                    mouse_over: false,
                    animate: {
                        enter: animIn,
                        exit: animOut
                    },
                    icon_type: 'class',
                    template: '<div data-growl="container" class="alert" role="alert">' +
                    '<button type="button" class="close" data-growl="dismiss">' +
                    '<span aria-hidden="true">&times;</span>' +
                    '<span class="sr-only">Close</span>' +
                    '</button>' +
                    '<span data-growl="icon"></span>' +
                    '<span data-growl="title"></span>' +
                    '<span data-growl="message"></span>' +
                    '<a href="#" data-growl="url"></a>' +
                    '</div>'
                });
        };
        //===================LOAD LIST ADMIN=========================
        function load_admin() {

            var Shoplist = [{}];
            var shoplistSt = escape(JSON.stringify(Shoplist));
            param = { "stpe": 2, "shoplistSt": shoplistSt };
            postAjax(param, load_admin_result, "html");
        }
        function load_admin_result(e) {
            if (e != "err") {
                if (reload_key == 1) {
                    $('#data-table-command').bootgrid("destroy"); reload_key = 0;

                }
                $('.list_admin').html(e);
                var grid = $("#data-table-command").bootgrid({
                    css: {
                        icon: 'zmdi icon',
                        iconColumns: 'zmdi-view-module',
                        iconDown: 'zmdi-expand-more',
                        iconRefresh: 'zmdi-refresh',
                        iconUp: 'zmdi-expand-less'
                    },
                    templates: {
                        header: "<div id=\"{{ctx.id}}\" class=\"{{css.header}}\"><div class=\"row\"><div class=\"col-sm-12 actionBar\"><button class=\"btn btn-success waves-effect btn-custom\">Thêm Admin</button><p class=\"{{css.search}}\"></p><p class=\"{{css.actions}}\"></p></div></div></div>"
                    },
                    formatters: {
                        "commands": function (column, row) {
                            return "<button type=\"button\" class=\"btn btn-icon cmd-edit waves-effect waves-circle btn-warning\" data-row-id=\"" + row.id + "\"><span class=\"zmdi zmdi-edit\"></span></button>"
                                + "<button type=\"button\" class=\"btn btn-icon cmd-right waves-effect waves-circle btn-success \" data-row-ten=\"" + row.ten + "\" data-row-id=\"" + row.id + "\"><span class=\"zmdi zmdi-key\"></span></button>";
                        },
                        "pix": function (column, row) {
                            return "<img src=" + path + row.imagess + "\" />";
                        }
                    }
                }).on("loaded.rs.jquery.bootgrid", function () {
                    grid.find(".cmd-edit").on("click", function (e) {
                        var id = $(this).data("row-id");
                        console.log(e)
                        console.log(id);
                        $('#preventClick').modal({ backdrop: 'static', keyboard: false });
                        $('.modal-title').html('Sửa thông tin Admin số: ' + id);
                        $('.btn-save').html('Lưu thay đổi');
                        reset();
                        load_admin_id(id)
                    });

                    grid.find(".cmd-right").on("click", function (e) {

                        var id = $(this).data("row-id"), ten = $(this).data("row-ten");
                        load_page(id);
                        $('#rightClick').modal({ backdrop: 'static', keyboard: false });
                        $('.modal-title').html('Cấp quyền: ' + ten);
                    });

                    grid.find(".command-delete").on("click", function (e) {
                        var id = $(this).data("row-id");
                        delete_admin_id(id);

                    });
                });

                $('.btn-custom ').on('click', function () {
                    $('#preventClick').modal({ backdrop: 'static', keyboard: false });
                    $('.modal-title').html('Thêm Admin');
                    $('.btn-save').html('Thêm mới');
                    reset();
                });
            }
            else {

                $('.cate_list').html("no data");
            }
        }

        //=================== PAGE RIGHT===================================
        function load_page(id) {
            var Shoplist = [{ "id": id }];
            var shoplistSt = escape(JSON.stringify(Shoplist));
            var param = { "stpe": 63, "shoplistSt": shoplistSt };
            postAjax(param, load_page_right_result, "html");
        }
        function load_page_right_result(e) {
            if (e != 'err') {
                $('#tbl_right_list').html(e);
            } else {
                $('#tbl_right_list').html('');
            }
        }
        function update_right(id) {
            var right = $('.ssl_right_' + id + '').val();
            if (right != '-1') {
                var Shoplist = [{ "id": id, "right": right }];
                var shoplistSt = escape(JSON.stringify(Shoplist));
                var param = { "stpe": 64, "shoplistSt": shoplistSt };
                postAjax(param, update_right_result, "html");
            } else {
                alert('Bạn phải chọn quyền!');
            }
        }
        function update_right_result(e) {
            if (e != 'err') {
                notify('Success!', '', '', '', '', 'success', '', '');
            } else {
                notify('danger', 'Fail!', 'Insert(update) fail!')
            }
        }
        //===================INSERT UPDATE ADMIN=====================
        function insert_update_admin() {
            var mail = $('.imail').val(),
                pass = $('.imk').val(),
                name = $('.iname').val(),
                //right = $('.iright').val(),
                img = $('#iimg_APP_LIST').val(),
                id = $('.iid').val();
            var Shoplist = [{
                "id": id,
                "mail": mail,
                "pass": pass,
                "name": name,
                //"right": right,
                "iimg_APP_LIST": img,
            }];

            var shoplistSt = escape(JSON.stringify(Shoplist));
            var param = { "stpe": 3, "shoplistSt": shoplistSt };
            postAjax(param, insert_update_admin_result, "html");
        }
        function insert_update_admin_result(e) {
            if (e != 'err') {
                reload_key = 1;
                reload();
                $('#preventClick').modal('hide');
                notify('Success!', '', '', '', '', 'success', '', '');
            }
            else { notify('danger', 'Fail!', 'Insert(update) fail!') }
        }
        //===================RELOAD ADMIN ============================
        function reset() {
            var mail = $('.imail').val(''),
                matkhau = $('.imk').val(''),
                name = $('.iname').val(''),
                //quyen = $('.iright').val('-1');
                img = $('#iimg_APP_LIST').val('-1');
            $('.pimg_APP_LIST').attr('src', 'img/demo/note.png.ashx?width=290&height=250&mode=crop');

            id = $('.iid').val('0');
        }
        function reload() {
            reset();
            load_admin();
        }
        //===================SHOW ADMIN ID============================

        function load_admin_id(id) {

            var Shoplist = [{ "id": id }];
            var shoplistSt = escape(JSON.stringify(Shoplist));
            var param = { "stpe": 1, "shoplistSt": shoplistSt };
            postAjax_list(param, load_admin_id_result, "html");
        }
        function load_admin_id_result(e) {
            for (var i in e) {
                var dr = e[0];

                var mail = $('.imail').val(dr.mail),
                    matkhau = $('.imk').val('*****'),
                    name = $('.iname').val(dr.name);
                $('#iimg_APP_LIST').val(dr.img);
                $('.pimg_APP_LIST').attr('src', path + dr.img + '.ashx?width=290&height=250&mode=crop');

                id = $('.iid').val(dr.id);
            }
        }
        //==================UPLOAD IMG========================
        function uploadimg(ele) {

            new AjaxUpload('#UploadButton_' + ele + '', {
                action: 'App_upload_Img_' + ele + '.ashx?file=0&path=' + path,
                onComplete: function (file, response) {
                    $(".pimg_" + ele + "").attr('src', path + response + '.ashx?width=290&height=250&mode=crop');
                    var res = $("#iimg_" + ele + "").attr("value");
                    DeleteFile(res, ele);
                    $("#iimg_" + ele + "").val(response);
                },
                onSubmit: function (file, ext) {
                    if (!(ext && /^(gif|png|jpg)$/i.test(ext))) {
                        alert('Hình không đúng định dạng.');
                        return false;
                    }
                }
            });
        }
        //==================DELETE IMG=================
        function DeleteFile(file, ele) {
            $.ajax({
                url: "App_upload_Img_" + ele + ".ashx?file=" + file + "&path=" + path,
                type: "GET",
                cache: false,
                async: true,
                success: function (html) {
                }
            });
        }
            //==================================================================================================
    </script>
    <style>
        .btn-custom {
            padding: 9px 10px;
            margin-right: 20px;
        }
    </style>
</asp:Content>
