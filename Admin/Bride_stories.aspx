<%@ Page Title="Bridal Stories" Language="C#" MasterPageFile="~/Admin/MasterPage.Master" AutoEventWireup="true" CodeBehind="Bride_stories.aspx.cs" Inherits="HaiDen.Admin.Bride_stories1" %>

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
            <h2>Bridal Stories</h2>
        </div>
        <table id="data-table-command" class="table table-striped table-vmiddle">
            <thead>
                <tr>
                    <th data-column-id="id" data-order="desc" data-type="numeric">ID</th>
                    <th data-column-id="ten" data-order="desc">Tên Cô Dâu</th>
                    <th data-column-id="imagess" data-formatter="pix">Hình ảnh</th>
                    <th data-column-id="date" data-order="desc">Ngày </th>
                    <th data-column-id="commands" data-formatter="commands" data-sortable="false">Action</th>
                </tr>
            </thead>
            <tbody class="list_stories">
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
                                <label>Tên Cô Dâu</label>
                                <div class="fg-line">
                                    <input type="text" class="form-control iname" required placeholder="Tên cô dâu">
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="fg-line">
                                    <label>Mô Tả</label>
                                    <input type="text" class="form-control ides" placeholder="Mô Tả">
                                </div>
                            </div>
                            <div class="form-group ">
                                <label>Ngày</label>
                                <div class="fg-line">
                                    <input type="text" data-format="MM/dd/yyyy" id="datepk" class="form-control date-picker fg-input  t-white idate" placeholder="Ngày" required value="" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="fg-line">
                                    <label>Chọn danh mục</label>
                                    <div class="select-not fg-line-c">
                                        <select class="form-control t-white icate">
                                            <option value="-1">Chọn danh mục ..</option>
                                        </select>
                                    </div>
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

                    <div class="col-sm-12">
                        <div class="form-group">
                            <br />
                            <h4>Nội Dung Câu Chuyện</h4>
                            <br />
                            <div class="abc_bottom ides">
                                <%-- new editor --%>
                                <div id="editorDetail">Viết câu chuyện...</div>
                            </div>
                        </div>

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
    
        <!-- =========== Insert Images in editor =========================== -->

        $('#editorDetail').summernote({
            height: 300,                 // set editor height
            minHeight: null,             // set minimum height of editor
            maxHeight: null,             // set maximum height of editor
            focus: true,                 // set focus to editable area after initializing summernote
            // #4
            toolbar: [
                ['style', ['style']],
                ['font', ['bold', 'underline', 'clear']],
                ['fontname', ['fontname']],
                ['fontsize', ['fontsize', 'color']],
                ['para', ['ul', 'ol', 'paragraph', 'hr']],
                ['table', ['table']],
                ['height', ['height']],
                ['insert', ['link', 'picture']],
                ['view', ['fullscreen', 'codeview', 'help']]
            ],
            callbacks: {
                onImageUpload: function (files) {
                    sendFile(files[0], '#editorDetail');
                }
            },

            popover: {
                image: [
                    ['custom', ['imageAttributes']],
                    ['imagesize', ['imageSize100', 'imageSize50', 'imageSize25']],
                    ['float', ['floatLeft', 'floatRight', 'floatNone']],
                    ['remove', ['removeMedia']]
                ],
            },
            imageAttributes: {
                icon: '<i class="note-icon-pencil"/>',
                removeEmpty: false, // true = remove attributes | false = leave empty if present
                disableUpload: false // true = don't display Upload Options | Display Upload Options
            }
            //-----------
        });


        var reload_key = 0;
        var path = '../Assets/HinhAnh/BrideStories/';
        $(document).ready(function () {

            load_stories();
            $('.btn-save').on('click', function () {
                var isValid = $("#frm").valid();
                if (isValid) {
                    insert_update_stories();
                }

            });
            uploadimg('APP_LIST');

        });


        // =========== Insert Images in editor ===========================

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


        //===================LOAD LIST CATE  =====================
        function load_list_cate() {

            var Shoplist = [{}];
            var shoplistSt = escape(JSON.stringify(Shoplist));
            var param = { "stpe": 34, "shoplistSt": shoplistSt };
            postAjax(param, load_list_cate_result, "html");
        }
        function load_list_cate_result(e) {
            if (e != 'err') {
                $('.icate').html('<option value="0" >Chọn danh mục..</option>' + e);

                //}
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

        //===================LOAD LIST STORIES=========================

        function load_stories() {

            var Shoplist = [{}];
            var shoplistSt = escape(JSON.stringify(Shoplist));
            param = { "stpe": 9, "shoplistSt": shoplistSt };
            postAjax(param, load_stories_result, "html");
        }

        function load_stories_result(e) {
            if (e != "err") {
                if (reload_key == 1) {
                    $('#data-table-command').bootgrid("destroy"); reload_key = 0;
                }
                $('.list_stories').html(e);
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
                        $('.modal-title').html('Sửa stories số: ' + id);
                        $('.btn-save').html('Lưu thay đổi');
                        reset();
                        load_stories_id(id)
                    });
                    grid.find(".cmd-delete").on("click", function (e) {
                        var id = $(this).data("row-id");
                        delete_stories_id(id);

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

        //===================INSERT UPDATE STORIES=====================
        function insert_update_stories() {

            var name = $('.iname').val(),
                des = $('.ides').val(),
                date = $('.idate').val(),
                img = $('#iimg_APP_LIST').val(),
                id = $('.iid').val(),
                cate = $('.icate').val(),
                detail = $('#editorDetail').summernote('code');


            var Shoplist = [{

                "id": id,
                "name": name,
                "des": des,
                "detail": detail,
                "date": date,
                "cate": cate,
                "iimg_APP_LIST": img,
            }];

            var shoplistSt = escape(JSON.stringify(Shoplist));
            var param = { "stpe": 10, "shoplistSt": shoplistSt };
            postAjax(param, insert_update_stories_result, "html");
        }
        function insert_update_stories_result(e) {
            if (e != 'err') {
                reload_key = 1;
                reload();
                $('#preventClick').modal('hide');
                notify('Success!', '', '', '', '', 'success', '', '');
            }
            else { notify('danger', 'Fail!', 'Insert(update) fail!') }
        }

        //===================RELOAD STORIES ============================
        function reset() {
            var name = $('.iname').val(''),
                des = $('.ides').val(''),
                date = $('.idate').val(''),
                img = $('#iimg_APP_LIST').val('-1');
            $('.iid').val('0');
            $('.pimg_APP_LIST').attr('src', 'img/demo/note.png.ashx?width=290&height=250&mode=crop');

            $('#editorDetail').summernote('code', '');

            load_list_cate();
        }
        function reload() {
            reset();
            load_stories();
        }
        //===================DELETE STORIES ============================
        function delete_stories_id(id) {

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
                    var param = { "stpe": 11, "shoplistSt": shoplistSt };
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
        //===================SHOW STORIES ID============================

        function load_stories_id(id) {

            var Shoplist = [{ "id": id }];
            var shoplistSt = escape(JSON.stringify(Shoplist));
            var param = { "stpe": 4, "shoplistSt": shoplistSt };
            postAjax_list(param, load_stories_id_result, "html");
        }
        function load_stories_id_result(e) {

            for (var i in e) {
                var dr = e[0];
                var
                    name = $('.iname').val(dr.name),
                    des = $('.ides').val(dr.des),
                    date = $('.idate').val(dr.date),
                    id = $('.iid').val(dr.id),
                    cate = $('.icate').val(dr.cate);

                $('#editorDetail').summernote('code', dr.detail);
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
