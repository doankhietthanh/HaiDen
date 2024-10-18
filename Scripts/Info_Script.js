
function InfoScript() {
    this.Variables = {
        element: '.AboutUs',
        request: { IF_ALIAS: '-1' }
    }
}

InfoScript.prototype.init = function () {
    var $this = this;
    $this.loadData();
}
InfoScript.prototype.initPrivacy = function () {
    var $this = this;
    $this.Variables.request.IF_ALIAS = 'privacy';
    $this.loadDataPrivacy();
}
InfoScript.prototype.initTerm = function () {
    var $this = this;
    $this.Variables.request.IF_ALIAS = 'term';
    $this.loadDataTerm();
}
InfoScript.prototype.loadData = function () {
    var $this = this;
    var Request = escape(JSON.stringify(this.Variables.request));
    var param = { "stpe": 117, "Request": Request };
    postAjax(param, $this.bindData, "json", $this);
}
InfoScript.prototype.bindData = function (result, $this) {
    var htm = '';
    if (result.Code == 0 && result.DataList.length > 0) {
        _variable.ListInfo = result.DataList;

        jQuery('.fblink').attr('href', _commons.findInfo('fb')['IF_NAME']);
        jQuery('.istarg').attr('href', _commons.findInfo('ist')['IF_NAME']);
        jQuery('.printer').attr('href', _commons.findInfo('pr')['IF_NAME']);

        jQuery('.adress').html(_commons.findInfo('add')['IF_NAME']);
        jQuery('.email').attr('href', 'mailto:' + _commons.findInfo('email')['IF_NAME']).text(_commons.findInfo('email')['IF_NAME']);
        jQuery('.phone').attr('href', 'tel:' + _commons.findInfo('phone')['IF_NAME']).text(_commons.findInfo('phone')['IF_NAME']);
        jQuery('.copyright').html(_commons.findInfo('copyright')['IF_NAME']);
    }
}

InfoScript.prototype.loadDataPrivacy = function () {
    var $this = this;
    var Request = escape(JSON.stringify(this.Variables.request));
    var param = { "stpe": 117, "Request": Request };
    postAjax(param, $this.bindDataPrivacy, "json", $this);
}
InfoScript.prototype.bindDataPrivacy = function (result, $this) {
    var htm = '';
    if (result.Code == 0 && result.DataList.length > 0) {
        _variable.ListInfo = result.DataList;

        jQuery('#detail').html(_commons.findInfo('privacy')['IF_DES']);

    }
}

InfoScript.prototype.loadDataTerm = function () {
    var $this = this;
    var Request = escape(JSON.stringify(this.Variables.request));
    var param = { "stpe": 117, "Request": Request };
    postAjax(param, $this.bindDataTerm, "json", $this);
}
InfoScript.prototype.bindDataTerm = function (result, $this) {
    var htm = '';
    if (result.Code == 0 && result.DataList.length > 0) {
        _variable.ListInfo = result.DataList;

        jQuery('#detail').html(_commons.findInfo('term')['IF_DES']);

    }
}

