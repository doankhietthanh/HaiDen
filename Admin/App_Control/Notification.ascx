﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Notification.ascx.cs" Inherits="HaiDen.Admin.App_Control.Notification" %>


<aside id="s-user-alerts" class="sidebar">
   <%-- <ul class="tab-nav tn-justified tn-icon m-t-10" data-tab-color="teal">
        <li><a class="sua-messages" href="#sua-messages" data-toggle="tab"><i class="zmdi zmdi-email"></i></a></li>
        <li><a class="sua-notifications" href="#sua-notifications" data-toggle="tab"><i class="zmdi zmdi-notifications"></i></a></li>
        <li><a class="sua-tasks" href="#sua-tasks" data-toggle="tab"><i class="zmdi zmdi-view-list-alt"></i></a></li>
    </ul>--%>

    <%--<div class="tab-content">
        <div class="tab-pane fade" id="sua-messages">
            <ul class="sua-menu list-inline list-unstyled palette-Light-Blue bg">
                <li><a href=""><i class="zmdi zmdi-check-all"></i>Mark all</a></li>
                <li><a href=""><i class="zmdi zmdi-long-arrow-tab"></i>View all</a></li>
                <li><a href="" data-ma-action="sidebar-close"><i class="zmdi zmdi-close"></i>Close</a></li>
            </ul>

            <div class="list-group lg-alt c-overflow">
                <a href="" class="list-group-item media">
                    <div class="pull-left">
                        <img class="avatar-img" src="img/profile-pics/1.jpg" alt="">
                    </div>

                    <div class="media-body">
                        <div class="lgi-heading">David Villa Jacobs</div>
                        <small class="lgi-text">Sorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam mattis lobortis sapien non posuere</small>
                    </div>
                </a>

                <a href="" class="list-group-item media">
                    <div class="pull-left">
                        <img class="avatar-img" src="img/profile-pics/5.jpg" alt="">
                    </div>
                    <div class="media-body">
                        <div class="lgi-heading">Candice Barnes</div>
                        <small class="lgi-text">Quisque non tortor ultricies, posuere elit id, lacinia purus curabitur.</small>
                    </div>
                </a>

                <a href="" class="list-group-item media">
                    <div class="pull-left">
                        <img class="avatar-img" src="img/profile-pics/3.jpg" alt="">
                    </div>
                    <div class="media-body">
                        <div class="lgi-heading">Jeannette Lawson</div>
                        <small class="lgi-text">Donec congue tempus ligula, varius hendrerit mi hendrerit sit amet. Duis ac quam sit amet leo feugiat iaculis</small>
                    </div>
                </a>

                <a href="" class="list-group-item media">
                    <div class="pull-left">
                        <img class="avatar-img" src="img/profile-pics/4.jpg" alt="">
                    </div>
                    <div class="media-body">
                        <div class="lgi-heading">Darla Mckinney</div>
                        <small class="lgi-text">Duis tincidunt augue nec sem dignissim scelerisque. Vestibulum rhoncus sapien sed nulla aliquam lacinia</small>
                    </div>
                </a>

                <a href="" class="list-group-item media">
                    <div class="pull-left">
                        <img class="avatar-img" src="img/profile-pics/2.jpg" alt="">
                    </div>
                    <div class="media-body">
                        <div class="lgi-heading">Rudolph Perez</div>
                        <small class="lgi-text">Phasellus a ullamcorper lectus, sit amet viverra quam. In luctus tortor vel nulla pharetra bibendum</small>
                    </div>
                </a>
            </div>

            <a href="" class="btn btn-float btn-danger m-btn">
                <i class="zmdi zmdi-plus"></i>
            </a>
        </div>
        <div class="tab-pane fade" id="sua-notifications">
            <ul class="sua-menu list-inline list-unstyled palette-Orange bg">
                <li><a href=""><i class="zmdi zmdi-volume-off"></i>Mute</a></li>
                <li><a href=""><i class="zmdi zmdi-long-arrow-tab"></i>View all</a></li>
                <li><a href="" data-ma-action="sidebar-close"><i class="zmdi zmdi-close"></i>Close</a></li>
            </ul>

            <div class="list-group lg-alt c-overflow">
                <a href="" class="list-group-item media">
                    <div class="pull-left">
                        <img class="avatar-img" src="img/profile-pics/1.jpg" alt="">
                    </div>

                    <div class="media-body">
                        <div class="lgi-heading">David Villa Jacobs</div>
                        <small class="lgi-text">Sorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam mattis lobortis sapien non posuere</small>
                    </div>
                </a>

                <a href="" class="list-group-item media">
                    <div class="pull-left">
                        <img class="avatar-img" src="img/profile-pics/5.jpg" alt="">
                    </div>
                    <div class="media-body">
                        <div class="lgi-heading">Candice Barnes</div>
                        <small class="lgi-text">Quisque non tortor ultricies, posuere elit id, lacinia purus curabitur.</small>
                    </div>
                </a>

                <a href="" class="list-group-item media">
                    <div class="pull-left">
                        <img class="avatar-img" src="img/profile-pics/3.jpg" alt="">
                    </div>
                    <div class="media-body">
                        <div class="lgi-heading">Jeannette Lawson</div>
                        <small class="lgi-text">Donec congue tempus ligula, varius hendrerit mi hendrerit sit amet. Duis ac quam sit amet leo feugiat iaculis</small>
                    </div>
                </a>

                <a href="" class="list-group-item media">
                    <div class="pull-left">
                        <img class="avatar-img" src="img/profile-pics/4.jpg" alt="">
                    </div>
                    <div class="media-body">
                        <div class="lgi-heading">Darla Mckinney</div>
                        <small class="lgi-text">Duis tincidunt augue nec sem dignissim scelerisque. Vestibulum rhoncus sapien sed nulla aliquam lacinia</small>
                    </div>
                </a>

                <a href="" class="list-group-item media">
                    <div class="pull-left">
                        <img class="avatar-img" src="img/profile-pics/2.jpg" alt="">
                    </div>
                    <div class="media-body">
                        <div class="lgi-heading">Rudolph Perez</div>
                        <small class="lgi-text">Phasellus a ullamcorper lectus, sit amet viverra quam. In luctus tortor vel nulla pharetra bibendum</small>
                    </div>
                </a>
            </div>
        </div>
        <div class="tab-pane fade" id="sua-tasks">
            <ul class="sua-menu list-inline list-unstyled palette-Green-400 bg">
                <li><a href=""><i class="zmdi zmdi-time"></i>Archived</a></li>
                <li><a href=""><i class="zmdi zmdi-check-all"></i>Mark all</a></li>
                <li><a href="" data-ma-action="sidebar-close"><i class="zmdi zmdi-close"></i>Close</a></li>
            </ul>

            <div class="list-group lg-alt c-overflow">
                <div class="list-group-item">
                    <div class="lgi-heading m-b-5">HTML5 Validation Report</div>

                    <div class="progress">
                        <div class="progress-bar" role="progressbar" aria-valuenow="95" aria-valuemin="0" aria-valuemax="100" style="width: 95%">
                            <span class="sr-only">95% Complete (success)</span>
                        </div>
                    </div>
                </div>
                <div class="list-group-item">
                    <div class="lgi-heading m-b-5">Google Chrome Extension</div>

                    <div class="progress">
                        <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100" style="width: 80%">
                            <span class="sr-only">80% Complete (success)</span>
                        </div>
                    </div>
                </div>
                <div class="list-group-item">
                    <div class="lgi-heading m-b-5">Social Intranet Projects</div>

                    <div class="progress">
                        <div class="progress-bar progress-bar-info" role="progressbar" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100" style="width: 20%">
                            <span class="sr-only">20% Complete</span>
                        </div>
                    </div>
                </div>
                <div class="list-group-item">
                    <div class="lgi-heading m-b-5">Bootstrap Admin Template</div>

                    <div class="progress">
                        <div class="progress-bar progress-bar-warning" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: 60%">
                            <span class="sr-only">60% Complete (warning)</span>
                        </div>
                    </div>
                </div>
                <div class="list-group-item">
                    <div class="lgi-heading m-b-5">Youtube Client App</div>

                    <div class="progress">
                        <div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100" style="width: 80%">
                            <span class="sr-only">80% Complete (danger)</span>
                        </div>
                    </div>
                </div>
            </div>

            <a href="" class="btn btn-float btn-danger m-btn">
                <i class="zmdi zmdi-plus"></i>
            </a>
        </div>
    </div>--%>
</aside>