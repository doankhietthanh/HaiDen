<%@ Page Title="Brides Stories Cate " Language="C#" MasterPageFile="~/Admin/MasterPage.Master" AutoEventWireup="true" CodeBehind="Bride_stories_cate.aspx.cs" Inherits="HaiDen.Admin.Bride_stories_cate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link href="bower_components/chosen/chosen.min.css" rel="stylesheet" />
    <link href="bower_components/bootstrap-sweetalert/sweet-alert.css" rel="stylesheet" />
    <link href="bower_components/bootstrap-datepicker/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <link href="bower_components/bootstrap-select/bootstrap-select.css" rel="stylesheet" />
    <link href="bower_components/noUiSlider.8.5.1/jquery.nouislider.min.css" rel="stylesheet" />
    <link href="Styles/Style.css" rel="stylesheet" />
    <%-- new editor --%>
    <%-- #1 --%>
    <link href="Styles/summernote.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>Brides Stories Cate </h2>
        </div>
        <table id="data-table-command" class="table table-striped table-vmiddle">
            <thead>
                <tr>
                    <th data-column-id="id" data-order="desc" data-type="numeric">ID</th>
                    <th data-column-id="imagess" data-formatter="pix">Hình ảnh</th>
                    <th data-column-id="des" data-order="desc">Mô tả </th>
                    <th data-column-id="commands" data-formatter="commands" data-sortable="false">Action</th>
                </tr>
            </thead>
            <tbody class="list_bride_cate">
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
                                <div class="fg-line">
                                    <label>Mô Tả</label>
                                    <textarea class="form-control auto-size ides" placeholder="Nhập mô tả ..."> </textarea>
                                </div>
                            </div>

                             <label class="note">Kích thước hình: 1325px x 725px (cứ nhân theo tỷ lệ này lên là được)</label>

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
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <script src="bower_components/autosize/autosize.min.js"></script>
    <script src="bower_components/input-mask/input-mask.min.js"></script>
    <script src="bower_components/chosen/chosen.jquery.min.js"></script>
    <script src="bower_components/bootstrap-sweetalert/sweet-alert.min.js"></script>
    <script src="bower_components/bootstrap-datepicker/bootstrap-datetimepicker.js"></script>
    <script src="bower_components/bootstrap-select/bootstrap-select.js"></script>
    <script src="bower_components/noUiSlider.8.5.1/jquery.nouislider.all.min.js"></script>
    <script src="Scripts/ajaxupload.js"></script>
    <script src="scripts/jquery.validate.js"></script>

    <%-- new editor --%>
    <script src="Scripts/summernote.js"></script>
    <script src="Scripts/summernote-image-attributes.js"></script>

    <!-- Data Table -->
    <script type="text/javascript">

        var path = '../Assets/HinhAnh/BrideStories/';
        var reload_key = 0;
        $(document).ready(function () {
            //$('#datepk').datetimepicker({
            //    language: 'en',
            //    pick12HourFormat: true
            //});
            load_bride_cate();
            $('.btn-save').on('click', function () {
                var isValid = $("#frm").valid();
                if (isValid) {
                    insert_update_bride_cate();
                }
            });
            uploadimg('APP_LIST');

        });
        // #5
        function sendFile(file, controlElement) {
            data = new FormData();
            data.append("file", file);
            $.ajax({
                data: data,
                type: 'POST',
                xhr: function () {
                    var myXhr = $.ajaxSettings.xhr();
                    if (myXhr.upload) myXhr.upload.addEventListener('progress', progressHandlingFunction, false);
                    return myXhr;
                },
                url: 'App_upload_Img_APP_LIST.ashx?file=0&path=' + path,
                cache: false,
                contentType: false,
                processData: false,
                success: function (file, response) {
                    //editor.insertImage(welEditable, url);
                    $(controlElement).summernote('editor.insertImage', path + file);
                }
            });
        }
        // update progress bar

        function progressHandlingFunction(e) {
            if (e.lengthComputable) {
                $('progress').attr({ value: e.loaded, max: e.total });
                // reset progress on complete
                if (e.loaded == e.total) {
                    $('progress').attr('value', '0.0');
                }
            }
        }

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

        //===================LOAD LIST BRIDE STORIES CATE =========================

        function load_bride_cate() {

            var Shoplist = [{}];
            var shoplistSt = escape(JSON.stringify(Shoplist));
            param = { "stpe": 31, "shoplistSt": shoplistSt };
            postAjax(param, load_bride_cate_result, "html");
        }

        function load_bride_cate_result(e) {
            if (e != "err") {
                if (reload_key == 1) {
                    $('#data-table-command').bootgrid("destroy"); reload_key = 0;
                }
                $('.list_bride_cate').html(e);
                var grid = $("#data-table-command").bootgrid({
                    css: {
                        icon: 'zmdi icon',
                        iconColumns: 'zmdi-view-module',
                        iconDown: 'zmdi-expand-more',
                        iconRefresh: 'zmdi-refresh',
                        iconUp: 'zmdi-expand-less'
                    },
                    templates: {
                        header: "<div id=\"{{ctx.id}}\" class=\"{{css.header}}\"><div class=\"row\"><div class=\"col-sm-12 actionBar\"><button class=\"btn btn-success waves-effect btn-custom\">Thêm Mới</button><p class=\"{{css.search}}\"></p><p class=\"{{css.actions}}\"></p></div></div></div>"
                    },
                    formatters: {
                        "commands": function (column, row) {
                            return "<button type=\"button\" class=\"btn btn-icon cmd-edit waves-effect waves-circle btn-warning\" data-row-id=\"" + row.id + "\"><span class=\"zmdi zmdi-edit\"></span></button>" +
                                "<button type=\"button\" class=\"btn btn-icon cmd-delete waves-effect waves-circle btn-danger\" data-row-id=\"" + row.id + "\"><span class=\"zmdi zmdi-delete\"></span></button>";
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
                        $('.modal-title').html('Sửa Bride Cate Sô: ' + id);
                        $('.btn-save').html('Lưu thay đổi');
                        reset();
                        load_bride_cate_id(id)
                    });
                    grid.find(".cmd-delete").on("click", function (e) {
                        var id = $(this).data("row-id");
                        delete_bride_cate_id(id);

                    });
                });
                $('.btn-custom ').on('click', function () {
                    $('#preventClick').modal({ backdrop: 'static', keyboard: false });
                    $('.modal-title').html('Thêm mới');
                    $('.btn-save').html('Thêm mới');
                    reset();
                });
            }
            else {

                $('.cate_list').html("no data");
            }
        }

        //===================INSERT UPDATE  BRIDE STORIES CATE  =====================
        function insert_update_bride_cate() {
            var des = $('.ides').val(),
                img = $('#iimg_APP_LIST').val(),
                id = $('.iid').val();


            var Shoplist = [{

                "id": id,
                "des": des,
                "iimg_APP_LIST": img,
            }];

            var shoplistSt = escape(JSON.stringify(Shoplist));
            var param = { "stpe": 32, "shoplistSt": shoplistSt };
            postAjax(param, insert_update_bride_cate_result, "html");
        }
        function insert_update_bride_cate_result(e) {
            if (e != 'err') {
                reload_key = 1;
                reload();
                $('#preventClick').modal('hide');
                notify('Success!', '', '', '', '', 'success', '', '');
            }
            else { notify('danger', 'Fail!', 'Insert(update) fail!') }
        }

        //===================RELOAD BRIDE STORIES CATE  ============================
        function reset() {
            var 
                des = $('.ides').val(''),
                img = $('#iimg_APP_LIST').val('-1');
            $('.iid').val('0');
            $('.pimg_APP_LIST').attr('src', 'img/demo/note.png.ashx?width=290&height=250&mode=crop');


        }
        function reload() {
            reset();
            load_bride_cate();
        }
        //===================DELETE BRIDE STORIES CATE  ============================
        function delete_bride_cate_id(id) {
            swal({
                title: "Bạn muốn xóa?",
                text: "Dữ liệu sẽ không thể phục hồi sau khi xóa!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Xóa",
                cancelButtonText: "Không",
                closeOnConfirm: false,
                closeOnCancel: false
            }, function (isConfirm) {
                if (isConfirm) {
                    var Shoplist = [{ "id": id }];
                    var shoplistSt = escape(JSON.stringify(Shoplist));
                    var param = { "stpe": 33, "shoplistSt": shoplistSt };
                    postAjax(param, delete_banner_result, "html");

                    function delete_banner_result(e) {
                        if (e == 'ok') {
                            swal("Đã xóa", "success");
                            reload_key = 1;
                            reload();
                            $('#preventClick').modal('hide');
                            notify('Success!', '', '', '', '', 'success', '', '');
                        } else { swal("Lỗi!", "Không thể xóa dữ liệu. Dữ liệu này có thể đang được sử dụng. Vui lòng xóa dữ liệu liên quan trước khi xóa.", "error"); }
                    }
                } else {
                    swal("Chưa xóa", "Dữ liệu an toàn", "error");
                }
            });
        };
        //===================SHOW BRIDE STORIES CATE ID============================

        function load_bride_cate_id(id) {

            var Shoplist = [{ "id": id }];
            var shoplistSt = escape(JSON.stringify(Shoplist));
            var param = { "stpe": 10, "shoplistSt": shoplistSt };
            postAjax_list(param, load_bride_cate_id_result, "html");
        }
        function load_bride_cate_id_result(e) {

            for (var i in e) {
                var dr = e[0];
                var                   
                    des = $('.ides').val(dr.des),
                    id = $('.iid').val(dr.id);

                $('#iimg_APP_LIST').val(dr.img),
                    $('.pimg_APP_LIST').attr('src', path + dr.img + '.ashx?width=290&height=250&mode=crop');
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
            //ath = path + $('.ialias').val() + '/';
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
