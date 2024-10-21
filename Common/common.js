const protocol = "http://";

function postAjax(parameter, request, type, _this) {

    jQuery.ajax({
        // the URL for the request
        url: protocol + window.location.host + "/Common/HandlerRequest.ashx",
        // the data to send
        // (will be converted to a query string)
        data: parameter,
        // whether this is a POST or GET request
        type: "POST",
        // the type of data we expect back
        dataType: type || "json",
        async: false,
        // code to run if the request succeeds;
        // the response is passed to the function
        success: function (json) {
            request(json, _this);
        },
        beforeSend: function () {
            let load = '<div class="wrapper"><div class="cssload-loader"></div></div>';
            //if (control != null || control != undefined) {
            //jQuery(control).html(load);
            //}
        },
        // code to run if the request fails;
        // the raw request and status codes are
        // passed to the function
        error: function (xhr, status) {
            // code to run regardless of success or failure
            //if (control != null || control != undefined) {
            //jQuery(control).html('Error...!');
            //}

        },
        complete: function (xhr, status) {

        }

    });
};

jQuery(window).bind('load', function () {
    jQuery('img').each(function () {
        if ((typeof this.naturalWidth != "undefined" &&
            this.naturalWidth == 0)
            || this.readyState == 'uninitialized') {
            jQuery(this).attr('src', protocol + window.document.location.host + '/Common/thumbnail-default.png');
            jQuery(this).css({ 'border': '1px solid #f3f3f3' });
        }
    });
})
var _variable = {
    url: protocol + window.location.host,
    html: '',
    html1: '',
    PathImg: '/Assets/HinhAnh/',
    urlImg: protocol + window.location.host + '/Assets/HinhAnh/',
    Lang: 'vi',
    ListInfo: []
}
var _commons = {
    extendImg: function (w, h) {
        return '.ashx?width=' + w + '&height=' + h + '&mode=crop';
    },
    locdau: function (str) {

        var str;
        if (str != null) {
            str = str.toLowerCase();
            str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
            str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
            str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
            str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
            str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
            str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
            str = str.replace(/đ/g, "d");
            str = str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|jQuery|_/g, "-");
            /* tìm và thay thế các kí tự đặc biệt trong chuỗi sang kí tự - */
            str = str.replace(/-+-/g, "-"); //thay thế 2- thành 1-  
            str = str.replace(/^\-+|\-+jQuery/g, "");
            //cắt bỏ ký tự - ở đầu và cuối chuỗi 
            //eval(obj).value = str.toUpperCase();
        }
        return str;
    },
    numberWithCommas: function (x) {
        var parts = x.toString().split(".");
        parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        return parts.join(".")
    },
    getPathName: function (str, slice) {
        var pos = str.lastIndexOf(slice);
        if (pos == -1) {
            return pos;
        } else {
            return str.slice(pos + 1);
        }
    },
    getPathNameDetail: function (str, slice, slice1) {
        str = str.replace(slice1, '')
        var pos = str.lastIndexOf(slice);
        if (pos == -1) {
            return pos;
        } else {
            return str.slice(pos + 1);
        }
    },
    stringToDate: function (_date, _format, _delimiter, isLocal) {
        if (_date.length > 10) { _date = _date.substr(0, 10); }
        var formatLowerCase = _format.toLowerCase();
        var formatItems = formatLowerCase.split(_delimiter);
        var dateItems = _date.split(_delimiter);
        var monthIndex = formatItems.indexOf("mm");
        var dayIndex = formatItems.indexOf("dd");
        var yearIndex = formatItems.indexOf("yyyy");
        var month = parseInt(dateItems[monthIndex]);
        month -= 1;
        var formatedDate = isLocal ? new Date(dateItems[yearIndex], month, parseInt(dateItems[dayIndex]) + 1).toLocaleDateString() : new Date(dateItems[yearIndex], month, dateItems[dayIndex]);
        return formatedDate;
    },
    createGUID: function () {
        return 'SNDN-4xxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16).toUpperCase();
        });
    },
    createUserGUID: function () {
        return 'xxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x4);
            return v.toString(16).toUpperCase();
        });
    },
    createPassGUID: function () {
        return 'xxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x4);
            return v.toString(16).toUpperCase();
        });
    },
    setCurrentMenu: function (target) {
        //jQuery('.main-menu').find('li').find('a').removeClass('current');
        jQuery('.main-menu').find('li').each(function () {
            if (jQuery(this).data('id') == target) {
                jQuery(this).addClass('active');
            }
        });
    },
    createCookie: function (name, value, days) {
        var expires;

        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            expires = "; expires=" + date.toGMTString();
        } else {
            expires = "";
        }
        document.cookie = encodeURIComponent(name) + "=" + encodeURIComponent(value) + expires + "; path=/";
    },
    readCookie: function (name) {
        var nameEQ = encodeURIComponent(name) + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) === ' ')
                c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) === 0)
                return decodeURIComponent(c.substring(nameEQ.length, c.length));
        }
        return null;
    },
    eraseCookie: function (name) {
        this.createCookie(name, "", -1);
    },
    //////////////////////////////////////
    findInfo: function (key) {
        let list = _variable.ListInfo;

        if (list.length > 0) {
            let item = list.find(o => o.IF_ALIAS == key);
            if (item != undefined || item != null || item != "") {
                return item;
            } else { return "-"; }
        }

    },
    validateEmail(email) {
        var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(email);
    },
    alert: function (title, des, type) {
        $.Toast(title, des, type, {
            has_icon: true,
            has_close_btn: true,
            stack: true,
            fullscreen: false,
            position_class: "toast-top-right",
            timeout: 1000,
            sticky: false,
            has_progress: true,
            rtl: false,
        });
    },
    sweet: function (title, text, type, callback, model) {
        swal({
            title: title != '' ? title : 'Are you sure?',
            text: text != '' ? text : "You won't be able to revert this!",
            type: type != '' ? type : 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes',
            cancelButtonText: 'No'
        }).then((result) => {
            if (result.value) {
                callback(model);
            }
        })
    },
    sweetReturn: function (title, text, type) {
        swal({
            title: title != '' ? title : 'Are you sure?',
            text: text != '' ? text : "You won't be able to revert this!",
            type: type != '' ? type : 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes',
            cancelButtonText: 'No'
        }).then((result) => {
            if (result.value) {
                return result.value;
            }
        })
    }
}
var _cmElement = {
    hasClass: function (element, cls) {
        return (' ' + element[0].className + ' ').indexOf(' ' + cls + ' ') > -1;
    }
}

$('input.datepicker').datepicker({
});

var _alers = {
    danger: function (msg) {
        $(".Alert").remove();

        var element = document.createElement('div');
        element.classList.add('Alert');
        element.style.cssText = 'position: fixed;top: 0px;left: 0px;width: 100%;height: 35px;text-align: center;color: #fff;z-index:  9999;background: #ca0e00;line-height: 30px;';
        element.innerHTML = msg;
        var closebtn = document.createElement('a');
        closebtn.style.cssText = 'position: absolute;top: 7px;right: 7px;width: 20px;height: 20px;color: #fff;line-height: 18px;';
        closebtn.innerHTML = 'x';
        closebtn.onclick = function () {
            $(this).parent().hide();
        };

        element.appendChild(closebtn);

        document.body.appendChild(element);
    },
    success: function (msg) {
        $(".Alert").remove();
        var element = document.createElement('div');
        element.classList.add('Alert');
        element.style.cssText = 'position: fixed;top: 0px;left: 0px;width: 100%;height: 35px;text-align: center;color: #fff;z-index:  9999;background: #4CAF50;line-height: 30px;';
        element.innerHTML = msg;
        var closebtn = document.createElement('a');
        closebtn.style.cssText = 'position: absolute;top: 7px;right: 7px;width: 20px;height: 20px;color: #fff;line-height: 18px;';
        closebtn.innerHTML = 'x';
        closebtn.onclick = function () {
            $(this).parent().hide();
        };

        element.appendChild(closebtn);

        document.body.appendChild(element);
    }
}