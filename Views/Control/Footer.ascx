<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="HaiDen.Views.Control.Footer" %>

<footer class="container-fluid">
    <div class="row align-items-end">

        <div class="col-lg-10 folows">
            <div class="row socials">
                <div class="col">
                    <label>Follow Us</label>
                    <ul>
                        <li><a class="fblink" href="#"><i class="fa fa-facebook"></i></a></li>
                        <li><a class="istarg" href="#"><i class="fa fa-instagram"></i></a></li>
                        <li><a class="printer" href="#"><i class="fa fa-pinterest-p"></i></a></li>
                    </ul>

                </div>

            </div>
            <div class="row contacts">
                <div class="col-lg-4">
                    <span><i class="fa fa-map-marker"></i></span>
                    <p class="adress">
                        19 Nhieu Tu, Ward 7, District Phu Nhuan
                            <br />
                        Ho Chi Minh City
                    </p>
                </div>
                <div class="col-lg-4">
                    <span><i class="fa fa-envelope"></i></span>
                    <p><a class="email" href="mailto:info@haidenbridal.com">info@haidenbridal.com</a></p>
                </div>
                <div class="col-lg-4">
                    <span><i class="fa fa-phone"></i></span>
                    <p><a class="phone" href="tel:+84 358 224340">+84 358 224340</a></p>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-6 rights">
                <p class="copyright">&copy; 2018 Truong Thanh Hai Bridal. All rights reserved.</p>
            </div>
            <div class="col-lg-6 terms">
                <p><a href="<%= Page.ResolveClientUrl("~/terms-conditions")%>">Terms & Conditions</a> | <a href="<%= Page.ResolveClientUrl("~/privacy-policy")%>">Privacy Policy</a></p>
            </div>
        </div>
    </div>

</footer>
