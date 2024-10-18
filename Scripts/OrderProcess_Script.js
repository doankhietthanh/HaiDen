
function OrderProcessScript() {
    this.Variables = {
        element: '',
        request: { TYPE: 0 }
    }
}

OrderProcessScript.prototype.init = function () {
    var $this = this;
    $this.loadData();
}
OrderProcessScript.prototype.initDetail = function () {
    var $this = this;
    $this.Variables.request.TYPE = -1;
    $this.loadData();
}
OrderProcessScript.prototype.loadData = function () {
    var $this = this;
    var Request = escape(JSON.stringify(this.Variables.request));
    var param = { "stpe": 102, "Request": Request };
    postAjax(param, $this.bindData, "json", $this);
}
OrderProcessScript.prototype.bindData = function (result, $this) {
    var htm = '';
    if (result.Code == 0 && result.DataList != null) {
        var item = result.DataList;
        if ($this.Variables.request.TYPE != -1) {
            var img = _variable.urlImg + '/OrderProcess/' + item.OP_IMG;
            $('.OrderProcess').find('img').attr('src', img + _commons.extendImg(845, 565));
            $('.OrderProcess').find('p').html(item.OP_DES);
        } else {
            $('.processDetail').html(item.OP_DETAIL);
        }

    }

    $($this.Variables.element).html(htm);
}

$(document).ready(function () {
    var OrderProcess_Script = new OrderProcessScript();
    OrderProcess_Script.init();
});