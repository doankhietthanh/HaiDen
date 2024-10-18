<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="HaiDen.Admin.LogIn" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
            <link rel="shortcut icon" href="img/favicon.png" type="image/x-icon" />

        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
        <title>HaiDen Bridal Login </title>
        <!-- Vendor CSS -->
        <link href="bower_components/animate.css/animate.min.css" rel="stylesheet"/>
        <link href="bower_components/material-design-iconic-font/material-design-iconic-font.min.css" rel="stylesheet"/>   
        <link href="bower_components/google-material-color/palette.css" rel="stylesheet"/>
        
        <!-- CSS -->
        <link href="Styles/app.min.1.css" rel="stylesheet"/>
        <link href="Styles/app.min.2.css" rel="stylesheet"/>

    <link href="Styles/color/blue.css" rel="stylesheet" />
    <link href="Styles/Style.css" rel="stylesheet" />
</head>
<body>
   <div class="login" data-lbg="teal" style="background-image: url(img/aZlqiAT.jpg); background-size: cover; height: auto; background-repeat: no-repeat;" >
            <!-- Login -->

            <div class="l-block toggled" id="l-login">
                <div class="lb-header palette-Teal bg">
                    <i class="zmdi zmdi-account-circle"></i>
                    Xin chào ! vui lòng điền thông tin đăng nhập
                </div>
                <div class="lb-body">
                    <div class="form-group fg-float">
                        <div class="fg-line">
                            <input type="text" class="input-sm form-control fg-input imail "/>
                            <label class="fg-label">Email</label>
                        </div>
                    </div>
                    <div class="form-group fg-float">
                        <div class="fg-line">
                            <input type="password" class="input-sm form-control fg-input ipass"/>
                            <label class="fg-label">Mật Khẩu</label>
                        </div>
                    </div>
                    <button ="javascript:void(0);" class="btn palette-Teal bg" onclick="dangnhap();">Đăng Nhập</button>
                    <div class="m-t-20">
<%--                        <a data-block="#l-forget-password" data-bg="purple" href="" class="palette-Teal text">Quên Mật Khẩu</a>--%>
                    </div>
                </div>
            </div>
            <!-- Register -->
            <div class="l-block" id="l-register">
                <div class="lb-header palette-Blue bg">
                    <i class="zmdi zmdi-account-circle"></i>
                    Tạo Mới Tài Khoản
                </div>
                <div class="lb-body">
                    <div class="form-group fg-float">
                        <div class="fg-line">
                            <input type="text" class="input-sm form-control fg-input"/>
                            <label class="fg-label">Tên</label>
                        </div>
                    </div>
                    <div class="form-group fg-float">
                        <div class="fg-line">
                            <input type="text" class="input-sm form-control fg-input"/>
                            <label class="fg-label">Email</label>
                        </div>
                    </div>
                    <div class="form-group fg-float">
                        <div class="fg-line">
                            <input type="password" class="input-sm form-control fg-input"/>
                            <label class="fg-label">Mất Khẩu</label>
                        </div>
                    </div>
                    <div class="checkbox m-b-30">
                        <label>
                            <input type="checkbox" value=""/>
                            <i class="input-helper"></i>
                            Chấp nhận điều khoản
                        </label>
                    </div>
                    <button class="btn palette-Blue bg">Tạo tài khoản</button>
                    <div class="m-t-30">
                        <a data-block="#l-login" data-bg="teal" class="palette-Blue text d-block m-b-5" href="">Đã có tài khoản</a>
                        <a data-block="#l-forget-password" data-bg="purple" href="" class="palette-Blue text">Quên mật khẩu?</a>
                    </div>
                </div>
            </div>
            <!-- Forgot Password -->
            <div class="l-block" id="l-forget-password">
                <div class="lb-header palette-Purple bg">
                    <i class="zmdi zmdi-account-circle"></i>
                    Quên mật khẩu?
                </div>

                <div class="lb-body">
                    <p class="m-b-30">Vui lòng điền địa chỉ email của bạn !</p>

                    <div class="form-group fg-float">
                        <div class="fg-line">
                            <input type="text" class="input-sm form-control fg-input"/>
                            <label class="fg-label">Email</label>
                        </div>
                    </div>

                    <button class="btn palette-Purple bg">Lấy mật khẩu</button>

                    <div class="m-t-30">
                        <a data-block="#l-login" data-bg="teal" class="palette-Purple text d-block m-b-5" href="">Đã có tài khoản</a>
<%--                        <a data-block="#l-register" data-bg="blue" href="" class="palette-Purple text">Tạo tài khoản</a>--%>
                    </div>
                </div>
            </div>
        </div>
        <!-- Older IE warning message -->
       
        <![endif]-->
        <!-- Javascript Libraries -->
        <script src="bower_components/jquery/jquery.min.js"></script>
        <script src="bower_components/bootstrap/bootstrap.min.js"></script>
        <script src="bower_components/Waves/waves.min.js"></script>

        <!-- Placeholder for IE9 -->
        <!--[if IE 9 ]>
        <script src="vendors/bower_components/jquery-placeholder/jquery.placeholder.min.js"></script>
        <![endif]-->
        <script src="Scripts/functions.js"></script>

     <!-- HÀM ĐĂNG NHẬP-->
    
       <script type="text/javascript">
           $(document).ready(function () {
               $('body').keypress(function (e) {
                   var key = e.which;
                   if (key == 13)  // the enter key code
                   {
                       dangnhap();
                       return false;
                   }
               });
           });
           function dangnhap() {
               var imail = $('.imail').val(), ipass = $('.ipass').val(), ckc = '0';
               if (imail == "" || ipass == "") { alert('Please enter email and pass!!!'); } else {
                   var Shoplist = [{ "imail": imail, "ipass": ipass, "ckc": ckc }];
                   var shoplistSt = escape(JSON.stringify(Shoplist));
                   param = { "stpe": 1, "shoplistSt": shoplistSt };
                   postAjax(param, bt_login_result, "html");
               }
           }
           function bt_login_result(result) {

               switch (result) {
                   case '1':
                       // window.location.replace('dsfs.aspx');
                       //$(window).attr("location", "/Index.aspx");
                       $(document).ready(function () {
                           window.location.replace('/Admin/index.aspx');
                       });
                       break;
                   case '2':
                       $(document).ready(function () {
                           window.location.replace('/Admin/index.aspx');
                       });
                       break;
                   case '3':
                       $(document).ready(function () {
                           window.location.replace('/Admin/index.aspx');
                       });
                       break;
                   case '4':
                       $(document).ready(function () {
                           alert('Tài khoản bị khóa!');
                       });
                       break;
                   default:
                       alert('Error! Login fail!!!');
                       break;

               }
           }
        </script>
</body>
</html>