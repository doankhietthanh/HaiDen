
function BannerScript() {
    this.Variables = {
        element: '',
        request: {}
    }
}

BannerScript.prototype.init = function () {
    var $this = this;
    $this.loadData();
}
BannerScript.prototype.loadData = function () {
    var $this = this;
    var Request = escape(JSON.stringify(this.Variables.request));
    var param = { "stpe": 100, "Request": Request };
    postAjax(param, $this.bindData, "json", $this);
}
BannerScript.prototype.bindData = function (result, $this) {
    var htm = '';
    if (result.Code == 0 && result.DataList.length > 0) {
        result.DataList.forEach(item => {
            var img = _variable.urlImg + '/Banners/' + item.BN_IMG;
            $('.banner_img').attr('src', img + _commons.extendImg(1020, 765));
        });

    }

    $($this.Variables.element).html(htm);
}

$(document).ready(function () {
    var Banner_Script = new BannerScript();
    Banner_Script.init();
});