
function UsersScript() {

    this.Variables = {
        element: '.BridesStories',
        request: {
            MODE: 'SIGNUP',
            U_ID: -1,
            U_NAME: "-1",
            U_MAIL: "-1",
            U_PASS: "-1",
            U_PHONE: "-1",
            NA_ID: -1,
            U_BUGET: -1,
            U_WEDDING_DATE: new Date(),
            U_AVATAR: "-1",
            U_STATUS: 1,
        }
    }
}
UsersScript.prototype.User = function () {

    var member = JSON.parse(localStorage.getItem('memberData'));
    if (member != null) {
        var userzone = $('#Content_Header_User_zone');
        userzone.find('img').attr('src', _variable.urlImg + 'Users/' + member.U_AVATAR + _commons.extendImg(40, 40));
        userzone.find('label').text(member.U_NAME);


        var userzonemobi = $('#Content_Header_User_zone_mobi');
        userzonemobi.find('img').attr('src', _variable.urlImg + 'Users/' + member.U_AVATAR + _commons.extendImg(40, 40));
        userzonemobi.find('label').text(member.U_NAME);

        $('.btnLogout').on('click', function () {
            _commons.eraseCookie('CookieUsersName');
            _commons.eraseCookie('SUsersName');
            localStorage.clear('memberData');
            window.location.href = _variable.url + '/index.html';
        })
    }
}
UsersScript.prototype.SignIn = function () {
    $this = this;
    $('#btnSignIn').on('click', function () {
        var iEmail = $('#iEmail').val(), iPass = $('#iPass').val();
        if (iEmail != '' && iPass != '') {
            $this.Variables.request.U_MAIL = iEmail;
            $this.Variables.request.U_PASS = iPass;

            var Request = escape(JSON.stringify($this.Variables.request));
            var param = { "stpe": 110, "Request": Request };
            postAjax(param, $this.SignInResult, "json", $this);
        } else {
            _alers.danger('You must enter a full information!');
            return false;
        }
    })
}
UsersScript.prototype.SignInResult = function (result, $this) {

    if (result.Code == 1) {
        _alers.success(result.result);
        var curUrl = localStorage.getItem('curUrl');
        localStorage.setItem('memberData', JSON.stringify(result.DataList[0]));
        curUrl = curUrl == null ? _variable.url + '/member' : curUrl;
        window.location.href = curUrl;

    } else {
        _alers.danger(result.result);
    }
}

UsersScript.prototype.init = function () {

    var $this = this;
    $this.Variables.request.MODE = 'SIGNUP';
    $('#btnSignUp').on('click', function () {
        $this.insetupdateData(null);
    })

}
UsersScript.prototype.initAuto = function (_this) {

    var $this = this;
    $this.Variables.request.MODE = 'SIGNUP';

    $this.insetupdateData(_this);


}
UsersScript.prototype.insetupdateData = function (_this) {
    var $this = this;

    var iName = $('#iName').val(), iEmail = $('#iEmail').val(), iPass = $('#iPass').val(), iRePass = $('#iRePass').val()
    iBugget = $('#iBugget').val(), iNational = $('#iNational').val(), iPhone = $('#iPhone').val(),
        iWeddingDate = $('#iWeddingDate').val(), ava = $('#imgName').val();

    if (iName != '' && iEmail != '' && iPass != '' && iRePass != '' && iBugget != '' && iNational != '-1' && iPhone != '' && iWeddingDate != '') {
        if (iPass == iRePass) {
            $this.Variables.request.U_NAME = iName;
            $this.Variables.request.U_MAIL = iEmail;
            $this.Variables.request.U_PASS = iPass;
            $this.Variables.request.U_PHONE = iPhone;
            $this.Variables.request.NA_ID = iNational;
            $this.Variables.request.U_BUGET = iBugget;
            $this.Variables.request.U_WEDDING_DATE = iWeddingDate;
            $this.Variables.request.U_AVATAR = ava;

            var Request = escape(JSON.stringify(this.Variables.request));
            var param = { "stpe": 109, "Request": Request };
            postAjax(param, $this.insetupdateResult, "json", $this);
            if (_this != null) {
                _this
                    .off('click')
                    .text('Abort')
                    .on('click', function () {
                        $this.remove();
                        data.abort();
                    });
                _this.data().submit().always(function () {
                    _this.remove();
                });
            }
        } else {
            _alers.danger('Passwords not matched!');
            return false;
        }
    } else {
        _alers.danger('You must enter a full information!');
        return false;
    }

}
UsersScript.prototype.insetupdateResult = function (result, $this) {

    if (result.Code == 0) {

        $('.page-content').hide();
        $('.thank_you').show();
        _alers.success(result.result);

        var iEmail = $('#iEmail').val(), iPass = $('#iPass').val();
        if (iEmail != '' && iPass != '') {
            $this.Variables.request.U_MAIL = iEmail;
            $this.Variables.request.U_PASS = iPass;

            var Request = escape(JSON.stringify($this.Variables.request));
            var param = { "stpe": 110, "Request": Request };
            postAjax(param, $this.SignInResult, "json", $this);
        } else {
            _alers.danger('You must enter a full information!');
            return false;
        }

    } else {
        _alers.danger(result.result);
    }
}

UsersScript.prototype.initProfile = function () {
    var $this = this;
    var member = JSON.parse(localStorage.getItem('memberData'));
    if (member != null) {
        var userzone = $('.profile');
        userzone.find('.avatar-control img').attr('src', _variable.urlImg + 'Users/' + member.U_AVATAR + _commons.extendImg(400, 400));
        userzone.find('.name').text(member.U_NAME);
        userzone.find('.phone').text(member.U_PHONE);
        userzone.find('.mail').text(member.U_MAIL);
        userzone.find('.nation').text(member.NA_NAME);

        var end = new Date(member.U_WEDDING_DATE);

        var _second = 1000;
        var _minute = _second * 60;
        var _hour = _minute * 60;
        var _day = _hour * 24;
        var now = new Date();
        var distance = end - now;
        var days
        if (distance < 0) {
            days = 0;
        } else {
            days = Math.floor(distance / _day);
        }
        userzone.find('.countdown').text(days);
    }

    $('#btnEditProfile').on('click', function () {
        $this.changeProfile();
    })
}
UsersScript.prototype.loadNational = function () {
    $('#iNational').html('').append('<option value="-1" selected disabled>Where Do You Live</option>');
    var $this = this;
    var Request = escape(JSON.stringify(this.Variables.request));
    var param = { "stpe": 116, "Request": Request };
    postAjax(param, $this.bindDataNational, "json", $this);
}
UsersScript.prototype.bindDataNational = function (result, $this) {
    if (result.Code == 0 && result.DataList.length > 0) {
        result.DataList.forEach(item => {
            $('#iNational').append('<option value="' + item.NA_ID + '">' + item.NA_NAME + '</option>');
        });

    }
}

UsersScript.prototype.changeAvatar = function (ava) {
    var $this = this;
    $this.Variables.request.MODE = 'UPDATE';
    var member = JSON.parse(localStorage.getItem('memberData'));
    if (member != null) {
        $this.Variables.request.U_ID = member.U_ID;
        $this.Variables.request.U_MAIL = member.U_MAIL;
        $this.Variables.request.U_WEDDING_DATE = member.U_WEDDING_DATE;
        $this.Variables.request.NA_ID = member.NA_ID;
        $this.Variables.request.U_AVATAR = ava;

        var Request = escape(JSON.stringify(this.Variables.request));
        var param = { "stpe": 109, "Request": Request };
        postAjax(param, $this.insetupdateResult, "json", $this);
    }
}
UsersScript.prototype.insetupdateResult = function (result, $this) {

    if (result.Code == 0) {
        _alers.success('Change avatar success');
        var member = JSON.parse(localStorage.getItem('memberData'));
        if (member != null) {
            member.U_AVATAR = $this.Variables.request.U_AVATAR;
            localStorage.setItem('memberData', JSON.stringify(member));
            $this.User();
            $this.initProfile();
        }
    } else {
        _alers.danger(result.result);
    }
}

UsersScript.prototype.changeProfile = function () {
    var $this = this;
    $('#MyProfile').on('shown.bs.modal', function (e) {
        $this.loadNational();
        var member = JSON.parse(localStorage.getItem('memberData'));
        if (member != null) {
            $('#iName').val(member.U_NAME);
            $('#iEmail').val(member.U_MAIL);
            $('#iBugget').val(member.U_BUGET);
            $('#iNational').val(member.NA_ID);
            $('#iPhone').val(member.U_PHONE);
            var date = new Date(member.U_WEDDING_DATE);
            $('#iWeddingDate').val((date.getMonth() + 1) + '/' + date.getDate() + '/' + date.getFullYear());

            $(this).find('input[type=text]').next().addClass('active');
            $('#btnChangePass').text('Change Passwords');
            $('#MyProfile').find('input[type=text]').parent().css('opacity', '1');
            $('#MyProfile').find('select').parent().css('opacity', '1');
            $('#MyProfile').find('input[type=password]').parent().css('opacity', '0.2');
            $('#MyProfile').find('input[type=password]').addClass('disabled').attr('disabled');

            $('#btnSaveProfile').on('click', function () {
                $this.Variables.request.MODE = 'UPDATE';
                $this.saveProfile();
            });
            $('#btnChangePass').off().on('click', function () {
                $(this).parent().parent().find('input[type=text]').parent().css('opacity', '0.2');
                $(this).parent().parent().find('select').parent().css('opacity', '0.2');
                $(this).parent().parent().find('input[type=password]').parent().css('opacity', '1');
                $(this).parent().parent().find('input[type=password]').removeAttr('disabled').removeClass('disabled').next().addClass('active');
                $(this).text('Update Passwords');
                $(this).off().on('click', function () {
                    $this.Variables.request.MODE = 'UPDATE';
                    $this.savePass();
                })
            });
        }
    })

}
UsersScript.prototype.saveProfile = function () {
    var $this = this;
    var member = JSON.parse(localStorage.getItem('memberData'));
    if (member != null) {
        var iName = $('#iName').val(), iEmail = $('#iEmail').val(), iPass = $('#iPass').val(), iRePass = $('#iRePass').val()
        iBugget = $('#iBugget').val(), iNational = $('#iNational').val(), iPhone = $('#iPhone').val(),
            iWeddingDate = $('#iWeddingDate').val(), ava = $('#imgName').val();

        if (iName != '' && iEmail != '' && iBugget != '' && iNational != '-1' && iPhone != '' && iWeddingDate != '') {
            if (iPass == iRePass) {
                $this.Variables.request.U_ID = member.U_ID;
                $this.Variables.request.U_NAME = iName;
                $this.Variables.request.U_MAIL = iEmail;
                $this.Variables.request.U_PASS = iPass == '' ? '-1' : iPass;
                $this.Variables.request.U_PHONE = iPhone;
                $this.Variables.request.NA_ID = iNational;
                $this.Variables.request.U_BUGET = iBugget;
                $this.Variables.request.U_WEDDING_DATE = iWeddingDate;
                $this.Variables.request.U_AVATAR = member.U_AVATAR;

                var Request = escape(JSON.stringify(this.Variables.request));
                var param = { "stpe": 109, "Request": Request };
                postAjax(param, $this.saveProfileResult, "json", $this);

            } else {
                _alers.danger('Passwords not matched!');
                return false;
            }
        } else {
            _alers.danger('You must enter a full information!');
            return false;
        }
    }
}
UsersScript.prototype.saveProfileResult = function (result, $this) {
    if (result.Code == 0) {
        _alers.success('Change profile success!');
        var member = JSON.parse(localStorage.getItem('memberData'));
        if (member != null) {
            member.U_NAME = $this.Variables.request.U_NAME;
            member.U_MAIL = $this.Variables.request.U_MAIL;
            member.U_PHONE = $this.Variables.request.U_PHONE;
            member.U_WEDDING_DATE = $this.Variables.request.U_WEDDING_DATE;
            localStorage.setItem('memberData', JSON.stringify(member));
            $this.User();
            $this.initProfile();
        }
        $('#MyProfile').modal('hide');

    } else {
        _alers.danger(result.result);
    }
}
UsersScript.prototype.savePass = function () {
    var $this = this;
    var member = JSON.parse(localStorage.getItem('memberData'));
    if (member != null) {
        var iPass = $('#iPass').val(), iRePass = $('#iRePass').val();

        if (iPass != '' && iRePass != '') {
            if (iPass == iRePass) {
                $this.Variables.request.U_ID = member.U_ID;
                $this.Variables.request.U_NAME = member.U_NAME;
                $this.Variables.request.U_MAIL = member.U_MAIL;
                $this.Variables.request.U_PASS = iPass == '' ? '-1' : iPass;
                $this.Variables.request.U_PHONE = member.U_PHONE;
                $this.Variables.request.NA_ID = member.NA_ID;
                $this.Variables.request.U_BUGET = member.U_BUGET;
                $this.Variables.request.U_WEDDING_DATE = member.U_WEDDING_DATE;
                $this.Variables.request.U_AVATAR = member.U_AVATAR;

                var Request = escape(JSON.stringify(this.Variables.request));
                var param = { "stpe": 109, "Request": Request };
                postAjax(param, $this.savePassResult, "json", $this);

            } else {
                _alers.danger('Passwords not matched!');
                return false;
            }
        } else {
            _alers.danger('You must enter a new passwords!');
            return false;
        }
    }
}
UsersScript.prototype.savePassResult = function (result, $this) {
    if (result.Code == 0) {
        _alers.success('Change passwords success!');
        $('#btnChangePass').text('Change Passwords');
        $('#MyProfile').find('input[type=text]').parent().css('opacity', '1');
        $('#MyProfile').find('select').parent().css('opacity', '1');
        $('#MyProfile').find('input[type=password]').parent().css('opacity', '0.2');
        $('#MyProfile').find('input[type=password]').addClass('disabled').attr('disabled');
        $('#MyProfile').modal('hide');

    } else {
        _alers.danger(result.result);
    }
}