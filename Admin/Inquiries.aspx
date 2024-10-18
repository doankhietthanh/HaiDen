<%@ Page Title="Inquiries " Language="C#" MasterPageFile="~/Admin/MasterPage.Master" AutoEventWireup="true" CodeBehind="Inquiries.aspx.cs" Inherits="HaiDen.Admin.Inquiries" %>

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
            <h2>Inquiries </h2>
        </div>
        <table id="data-table-command" class="table table-striped table-vmiddle">
            <thead>
                <tr>
                    <th data-column-id="id" data-order="desc" data-type="numeric">ID</th>
                    <th data-column-id="name" data-order="desc">Tên người đặt</th>
                    <th data-column-id="mail" data-order="desc">Mail</th>
                    <th data-column-id="phone" data-order="desc">Phone</th>
                    <th data-column-id="dress" data-order="desc">Tên Váy đặt</th>
                    <th data-column-id="pro" data-order="desc">Process</th>
                    <th data-column-id="commands" data-formatter="commands" data-sortable="false">Action</th>
                </tr>
            </thead>
            <tbody class="list_Inquiries">
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
                    <button type="button" class="btn btn-link" data-dismiss="modal" style="position: absolute; right: 10px; top: 15px; color: #000; font-size: 20px;">X</button>
                </div>
                <div class="modal-body clearfix">

                    <input type="hidden" class="iid" value="0" />
                    <div class="col-sm-6">
                        <form id="frm">
                            <div class="col-sm-12">
                                <h4>THÔNG TIN KHÁCH HÀNG </h4>

                                <div class="form-group ">
                                    <label>Tên Khách Hàng </label>
                                    <div class="fg-line">
                                        <input type="text" class="form-control iname" required maxlength="200" minlength="2" value="" placeholder="Tên Khách Hàng...">
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label>Ngày cưới</label>
                                    <div class="fg-line fg-line-c">
                                        <input type="text" class="form-control date-picker fg-input  t-white iwed_date" placeholder="Ngày cưới..." required value="" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label>Email</label>
                                    <div class="fg-line">
                                        <input type="email" class="form-control imail" required maxlength="200" minlength="2" value="" placeholder="Email">
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label>Phone</label>
                                    <div class="fg-line">
                                        <input type="number" class="form-control iphone" required maxlength="15" value="" placeholder="Phone Khách Hàng..">
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="fg-line">
                                        <label>Quốc gia</label>
                                        <div class="select-not fg-line-c">
                                            <select class="form-control t-white ination">
                                                <option value="-1">Chọn quốc gia...</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label>Ngân sách </label>
                                    <div class="fg-line">
                                        <input type="number" class="form-control ibuget" required value="" placeholder="Ngân sách ...">
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="fg-line">
                                        <label>Trạng Thái</label>
                                        <div class="select-not fg-line-c">
                                            <select class="form-control t-white istatus">
                                                <option value="-1">Trạng Thái..</option>
                                                <option value="0">Chưa xem </option>
                                                <option value="1">Đã xem </option>
                                                 <option value="2">Hoàn Thành </option>
                                            </select>
                                        </div>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <div class="fg-line">
                                        <label>Tên Người Dùng (User)</label>
                                        <div class="select-not fg-line-c">
                                            <select class="form-control t-white iuser" disabled="disabled">
                                                <option value="-1">Tên Người Dùng (User)...</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </form>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <div class="col-sm-12">
                                <h4>THÔNG TIN ORDER</h4>

                                <div class="form-group">
                                    <label>Ngày đặt</label>
                                    <div class="fg-line fg-line-c">
                                        <input type="text" class="form-control date-picker fg-input  t-white iorder_date" placeholder="Ngày đặt..." required value="" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label>Due Date </label>
                                    <div class="fg-line fg-line-c">
                                        <input type="text" class="form-control date-picker fg-input  t-white idue_date" placeholder="Due Date..." required value="" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="fg-line">
                                        <label>Tên váy</label>
                                        <div class="select-not fg-line-c">
                                            <select class="form-control t-white idress">
                                                <option value="-1">Tên váy...</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label>Tổng đơn hàng </label>
                                    <div class="fg-line">
                                        <input type="number" class="form-control iamout" required value="" placeholder="Tổng đơn hàng...">
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label>Toward purchase of</label>
                                    <div class="fg-line">
                                        <input type="number" class="form-control itoward" required value="" placeholder="Toward purchase of...">
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label>Deposit</label>
                                    <div class="fg-line">
                                        <input type="number" class="form-control ideposit" required value="" placeholder="Deposit...">
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="fg-line">
                                        <label>Order progress</label>
                                        <div class="select-not fg-line-c">
                                            <select class="form-control t-white iprocess">
                                                <option value="-1">Trạng Thái..</option>
                                                <option value="1">Place the order</option>
                                                <option value="2">Deposit</option>
                                                <option value="3">Production</option>
                                                <option value="4">Payment Completed</option>
                                                <option value="5">Shipping</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="fg-line">
                                        <label>Lời nhắn </label>
                                        <textarea class="form-control auto-size imes" placeholder="Lời nhắn..."> </textarea>
                                    </div>
                                </div>

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
    <script src="bower_components/bootstrap-datepicker/bootstrap-datetimepicker.min.js"></script>
    <script src="bower_components/bootstrap-select/bootstrap-select.js"></script>
    <script src="bower_components/noUiSlider.8.5.1/jquery.nouislider.all.min.js"></script>
    <script src="Scripts/ajaxupload.js"></script>
    <script src="Scripts/jquery.validate.js"></script>
    <!-- Data Table -->
    <script type="text/javascript">
        var reload_key = 0;
        var path = '../Assets/HinhAnh/Inquiries/';
        $(document).ready(function () {
            load_Inquiries();
            $('.btn-save').on('click', function () {
                var isValid = $("#frm").valid();
                if (isValid) {
                    insert_update_Inquiries();
                }
            });
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
        //===================LOAD LIST INQUIRIES =========================
        function load_Inquiries() {

            var Shoplist = [{}];
            var shoplistSt = escape(JSON.stringify(Shoplist));
            param = { "stpe": 41, "shoplistSt": shoplistSt };
            postAjax(param, load_Inquiries_result, "html");
        }
        function load_Inquiries_result(e) {
            if (e != "err") {
                if (reload_key == 1) {
                    $('#data-table-command').bootgrid("destroy"); reload_key = 0;

                }
                $('.list_Inquiries').html(e);
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
                            return "<button type=\"button\" class=\"btn btn-icon cmd-edit waves-effect waves-circle btn-warning\" data-row-id=\"" + row.id + "\"><span class=\"zmdi zmdi-edit\"></span></button>";

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
                        $('.modal-title').html('Sửa Inquiries Số: ' + id);
                        $('.btn-save').html('Lưu thay đổi');
                        reset();
                        load_Inquiries_id(id)
                    });
                    grid.find(".command-delete").on("click", function (e) {
                        var id = $(this).data("row-id");
                        delete_Inquiries_id(id);

                    });
                });

                $('.btn-custom ').on('click', function () {
                    $('#preventClick').modal({ backdrop: 'static', keyboard: false });
                    $('.modal-title').html('Thêm Inquiries');
                    $('.btn-save').html('Thêm mới');
                    reset();
                });
            }
            else {

                $('.list_Inquiries').html("no data");
            }
        }

        //=================== LOAD LIST NATIONALITY  =====================
        function load_list_nation() {

            var Shoplist = [{}];
            var shoplistSt = escape(JSON.stringify(Shoplist));
            var param = { "stpe": 40, "shoplistSt": shoplistSt };
            postAjax(param, load_list_nation_result, "html");
        }
        function load_list_nation_result(e) {
            if (e != 'err') {
                $('.ination').html('<option value="0" >Chọn quốc gia..</option>' + e);

                //}
            }
        }
        //=================== LOAD LIST WEDDING DRESS  =====================
        function load_list_dress() {

            var Shoplist = [{}];
            var shoplistSt = escape(JSON.stringify(Shoplist));
            var param = { "stpe": 42, "shoplistSt": shoplistSt };
            postAjax(param, load_list_dress_result, "html");
        }
        function load_list_dress_result(e) {
            if (e != 'err') {
                $('.idress').html('<option value="0" >Chọn váy cưới..</option>' + e);

                //}
            }
        }

        //=================== LOAD LIST USER  =====================
        function load_list_user() {

            var Shoplist = [{}];
            var shoplistSt = escape(JSON.stringify(Shoplist));
            var param = { "stpe": 43, "shoplistSt": shoplistSt };
            postAjax(param, load_list_user_result, "html");
        }
        function load_list_user_result(e) {
            if (e != 'err') {
                $('.iuser').html('<option value="0" >Chọn users..</option>' + e);

                //}
            }
        }

        //===================INSERT UPDATE INQUIRIES =====================
        function insert_update_Inquiries() {

            var id = $('.iid').val(),
                order_date = $('.iorder_date').val(),
                dress = $('.idress').val(),
                mes = $('.imes').val(),
                user = $('.iuser').val(),
                amout = $('.iamout').val(),
                toward = $('.itoward').val(),
                deposit = $('.ideposit').val(),
                due_date = $('.idue_date').val(),
                name = $('.iname').val(),
                mail = $('.imail').val(),
                phone = $('.iphone').val(),
                nation = $('.ination').val(),
                buget = $('.ibuget').val(),
                wed_date = $('.iwed_date').val(),
                status = $('.istatus').val(),
                process = $('.iprocess').val();

            var Shoplist = [{
                "id": id,
                "order_date": order_date,
                "dress": dress,
                "mes": mes,
                "user": user,
                "amout": amout,
                "toward": toward,
                "deposit": deposit,
                "due_date": due_date,
                "name": name,
                "mail": mail,
                "phone": phone,
                "nation": nation,
                "buget": buget,
                "wed_date": wed_date,
                "status": status,
                "process": process,

            }];

            var shoplistSt = escape(JSON.stringify(Shoplist));
            var param = { "stpe": 44, "shoplistSt": shoplistSt };
            postAjax(param, insert_update_Inquiries_result, "html");
        }
        function insert_update_Inquiries_result(e) {
            if (e != 'err') {
                reload_key = 1;
                reload();
                $('#preventClick').modal('hide');
                notify('Success!', '', '', '', '', 'success', '', '');
            }
            else { notify('danger', 'Fail!', 'Insert(update) fail!') }
        }
        //===================RELOAD INQUIRIES ============================
        function reset() {

            var id = $('.iid').val('0'),
                order_date = $('.iorder_date').val(''),
                dress = $('.idress').val(''),
                mes = $('.imes').val(''),
                user = $('.iuser').val(''),
                amout = $('.iamout').val(''),
                toward = $('.itoward').val(''),
                deposit = $('.ideposit').val(''),
                due_date = $('.idue_date').val(''),
                name = $('.iname').val(''),
                mail = $('.imail').val(''),
                phone = $('.iphone').val(''),
                nation = $('.ination').val(''),
                buget = $('.ibuget').val(''),
                wed_date = $('.iwed_date').val(''),
                status = $('.istatus').val(''),
                process = $('.iprocess').val('');
            $('.iid').val('0');
            load_list_nation();
            load_list_dress();
            load_list_user();

        }
        function reload() {
            reset();
            load_Inquiries();
        }
        //===================SHOW INQUIRIES ID============================

        function load_Inquiries_id(id) {

            var Shoplist = [{ "id": id }];
            var shoplistSt = escape(JSON.stringify(Shoplist));
            var param = { "stpe": 13, "shoplistSt": shoplistSt };
            postAjax_list(param, load_Inquiries_id_result, "html");
        }
        function load_Inquiries_id_result(e) {
            for (var i in e) {
                var dr = e[0];

                var id = $('.iid').val(dr.id),
                    order_date = $('.iorder_date').val(dr.order_date),
                    dress = $('.idress').val(dr.dress),
                    mes = $('.imes').val(dr.mes),
                    user = $('.iuser').val(dr.user),
                    amout = $('.iamout').val(dr.amout),
                    toward = $('.itoward').val(dr.toward),
                    deposit = $('.ideposit').val(dr.deposit),
                    due_date = $('.idue_date').val(dr.due_date),
                    name = $('.iname').val(dr.name),
                    mail = $('.imail').val(dr.mail),
                    phone = $('.iphone').val(dr.phone),
                    nation = $('.ination').val(dr.nation),
                    buget = $('.ibuget').val(dr.buget),
                    wed_date = $('.iwed_date').val(dr.wed_date),
                    status = $('.istatus').val(dr.status),
                    process = $('.iprocess').val(dr.process);
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
