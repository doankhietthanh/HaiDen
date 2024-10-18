<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Admin/MasterPage.Master" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="HaiDen.Admin.Info" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="bower_components/chosen/chosen.min.css" rel="stylesheet" />
    <link href="bower_components/bootstrap-sweetalert/sweet-alert.css" rel="stylesheet" />
    <link href="bower_components/bootstrap-datepicker/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <link href="bower_components/bootstrap-select/bootstrap-select.css" rel="stylesheet" />
    <link href="bower_components/noUiSlider.8.5.1/jquery.nouislider.min.css" rel="stylesheet" />

    <%-- new editor --%>
    <link href="http://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.2/summernote.css" rel="stylesheet">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="card">
        <div class="card-header">

            <h2>Contact Us <small></small></h2>

        </div>

        <table id="data-table-command" class="table table-striped table-vmiddle">
            <thead>
                <tr>
                    <th data-column-id="id" data-order="desc" data-type="numeric">ID</th>
                    <th data-column-id="alias" data-order="desc">Alias</th>
                    <th data-column-id="name" data-order="desc">Tiêu Đề </th>
                    <th data-column-id="des" data-order="desc">Nội Dung</th>

                    <th data-column-id="commands" data-formatter="commands" data-sortable="false">Action</th>
                </tr>
            </thead>
            <tbody class="list_contact">
                <tr>
                    <td></td>

                </tr>

            </tbody>
        </table>

    </div>

    <div class="modal fade" id="preventClick" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <form id="frm">
                    <div class="modal-header">
                        <h4 class="modal-title"></h4>
                        <button type="button" class="btn btn-link" data-dismiss="modal" style="position: absolute; right: 10px; top: 15px; color: #000;">X</button>
                    </div>
                    <div class="modal-body clearfix">

                        <input type="hidden" class="iid" value="0" />
                        <div class="col-sm-12">
                            <div class="form-group">
                                <label>Tiêu đề</label>
                                <div class="fg-line">
                                    <input type="text" class="form-control iname" required value="" placeholder="Tiêu đề...">
                                </div>
                            </div>
                           
                            <div class="form-group">
                                <br />
                                <h4>Nội Dung Thông tin</h4>
                                <br />
                                <div class="abc_bottom ides">
                                    <%-- new editor --%>
                                    <div id="editordes">Hello...</div>
                                </div>
                            </div>
                            
                        </div>


                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Đóng</button>
                        <button type="button" class="btn btn-primary btn-save">Lưu thay đổi</button>
                    </div>
                </form>
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

    <%-- new editor --%>
    <script src="http://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.2/summernote.js"></script>

    <!-- Data Table -->

    <script type="text/javascript">

          <!-- =========== Insert Images in editor =========================== -->

              $('#editordes').summernote({
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
                        sendFile(files[0], '#editordes');
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
        $(document).ready(function () {
            load_thongtin();
            $('.btn-save').on('click', function () {
                var isValid = $("#frm").valid();
                if (isValid) {
                    insert_update_thongtin();
                }
            });
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

        //===================LOAD LIST THÔNG TIN =========================

        function load_thongtin() {

            var Shoplist = [{}];
            var shoplistSt = escape(JSON.stringify(Shoplist));
            param = { "stpe": 7, "shoplistSt": shoplistSt };
            postAjax(param, load_thongtin_result, "html");
        }
        function load_thongtin_result(e) {
            if (e != "err") {
                if (reload_key == 1) {
                    $('#data-table-command').bootgrid("destroy"); reload_key = 0;

                }
                $('.list_contact').html(e);
                var grid = $("#data-table-command").bootgrid({
                    css: {
                        icon: 'zmdi icon',
                        iconColumns: 'zmdi-view-module',
                        iconDown: 'zmdi-expand-more',
                        iconRefresh: 'zmdi-refresh',
                        iconUp: 'zmdi-expand-less'
                    },
                    templates: {
                        header: "<div id=\"{{ctx.id}}\" class=\"{{css.header}}\"><div class=\"row\"><div class=\"col-sm-12 actionBar\"><p class=\"{{css.search}}\"></p><p class=\"{{css.actions}}\"></p></div></div></div>"
                    },
                    formatters: {
                        "commands": function (column, row) {
                            return "<button type=\"button\" class=\"btn btn-icon cmd-edit waves-effect waves-circle  btn-warning\" data-row-id=\"" + row.id + "\"><span class=\"zmdi zmdi-edit\"></span></button>";
                        },

                    }
                }).on("loaded.rs.jquery.bootgrid", function () {
                    grid.find(".cmd-edit").on("click", function (e) {
                        var id = $(this).data("row-id");
                        console.log(e)
                        console.log(id);
                        $('#preventClick').modal({ backdrop: 'static', keyboard: false });
                        $('.modal-title').html('Sửa thông tin Số: ' + id);
                        $('.btn-save').html('Lưu thay đổi');
                        //reset();
                        load_thongtin_id(id)
                    });
                    grid.find(".cmd-delete").on("click", function (e) {
                        var id = $(this).data("row-id");
                        delete_thongtin_id(id);

                    });
                });

                $('.btn-custom ').on('click', function () {
                    $('#preventClick').modal({ backdrop: 'static', keyboard: false });
                    $('.modal-title').html('Thêm ');
                    $('.btn-save').html('Thêm mới');
                    reset();
                });
            }
            else {

                $('.thongtin_list').html("no data");
            }

        }
        //===================INSERT UPDATE THÔNG TIN =====================
        function insert_update_thongtin() {

            var des = $('#editordes').summernote('code'),
                name = $('.iname').val(),
                id = $('.iid').val();

            var Shoplist = [{
                "id": id,
                "name": name,
                "des": des,

            }];

            var shoplistSt = escape(JSON.stringify(Shoplist));
            var param = { "stpe": 8, "shoplistSt": shoplistSt };
            postAjax(param, insert_update_thongtin_result, "html");
        }
        function insert_update_thongtin_result(e) {
            if (e != 'err') {
                reload_key = 1;
                reload();
                $('#preventClick').modal('hide');
                notify('Success!', '', '', '', '', 'success', '', '');
            }
            else { notify('danger', 'Fail!', 'Insert(update) fail!') }
        }

        //===================RELOAD THÔNG TIN ============================
        function reset() {
            var id = $('.iid').val('0');
            $('#editordes').summernote('code', '');
            $('#editordes_en').summernote('code', '');
            name = $('.iname').val('');
            name_en = $('.iname_en').val('');
            load_thongtin();
        }
        function reload() {
            reset();
            load_thongtin();
        }


        function load_thongtin_id(id) {

            var Shoplist = [{ "id": id }];
            var shoplistSt = escape(JSON.stringify(Shoplist));
            var param = { "stpe": 3, "shoplistSt": shoplistSt };
            postAjax_list(param, load_thongtin_id_result, "html");
        }
        function load_thongtin_id_result(e) {
            for (var i in e) {
                var dr = e[0];

                var id = $('.iid').val(dr.id),
                    name = $('.iname').val(dr.name),
                    name_en = $('.iname_en').val(dr.name_en);
                $('#editordes').summernote('code', dr.des),
                    $('#editordes_en').summernote('code', dr.des_en);
            }
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