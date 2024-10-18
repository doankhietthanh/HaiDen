
function NewsScript() {
    this.Variables = {
        element: '.News',
        request: { N_ID: -1 }
    }
}

NewsScript.prototype.init = function () {
    var $this = this;

    $this.Variables.request.N_ID = $('#Content_hdAlias').val();
    $this.loadData();
}
NewsScript.prototype.initIndex = function () {
    var $this = this;
    $this.Variables.element = '.News';
    $this.loadDataIndex();
}
NewsScript.prototype.loadData = function () {
    var $this = this;
    var Request = escape(JSON.stringify(this.Variables.request));
    var param = { "stpe": 105, "Request": Request };
    postAjax(param, $this.bindData, "json", $this);
}
NewsScript.prototype.bindData = function (result, $this) {
    var htm = '';
    if (result.Code == 0 && result.DataList.length > 0) {
        result.DataList.forEach(item => {
            $('.newsTitle').text(item.N_NAME);
            document.title = item.N_NAME;
            $('.newsDetail').html(item.N_DETAIL);
        });
    }

    $($this.Variables.element).html(htm);
}

NewsScript.prototype.loadDataIndex = function () {
    var $this = this;
    var Request = escape(JSON.stringify(this.Variables.request));
    var param = { "stpe": 105, "Request": Request };
    postAjax(param, $this.bindDataIndex, "json", $this);
}
NewsScript.prototype.bindDataIndex = function (result, $this) {

    var htm = '';
    if (result.Code == 0 && result.DataList.length > 0) {
        var idx = 0;
        result.DataList.forEach(item => {
            idx++;
            if (idx == 1) {
                $($this.Variables.element).find('.item-large').html($this.RenderElement(item, idx));
            } else if (idx < 5) {
                htm += $this.RenderElement(item, idx);
            }
        });
        $($this.Variables.element).find('.item-child').html('<ul>' + htm + '</ul>');
    } else {
        $('.News').hide();
    }


}
NewsScript.prototype.RenderElement = function (item, index) {
    var htm = '';
    var img = _variable.urlImg + '/News/' + item.N_IMG;
    var link = _variable.url + '/post/' + _commons.locdau(item.N_NAME) + '-' + item.N_ID + '.html';
    var date = new Date(Date.parse(item.N_DATE)).toLocaleDateString();
    switch (index) {
        case 1:
            htm += '<a href="' + link + '"><img src="' + img + _commons.extendImg(868, 578) + '" width="868" height="578"  /></a><aside>'
                + '<h2><a href="' + link + '">' + item.N_NAME + '</a><small>' + date + '</small></h2><p>' + item.N_DES + '</p></aside>';
            break;
        case 2: case 3: case 4:
            htm += '<li><a href="' + link + '"><img src="' + img + _commons.extendImg(176, 172) + '" width="176" height="172"  /></a><aside>'
                + '<h2><a href="' + link + '">' + item.N_NAME + '</a><small>' + date + '</small></h2><p>' + item.N_DES + '</p></aside></li>';
            break;

    }

    return htm;
}
$(document).ready(function () {

});
NewsScript.prototype.initList = function () {
    var $this = this;
    $this.Variables.element = '.list-item';
    $this.loadDataList();
}
NewsScript.prototype.loadDataList = function () {
    var $this = this;
    var Request = escape(JSON.stringify(this.Variables.request));
    var param = { "stpe": 105, "Request": Request };
    postAjax(param, $this.bindDataList, "json", $this);
}
NewsScript.prototype.bindDataList = function (result, $this) {
    var htm = '';
    if (result.Code == 0 && result.DataList.length > 0) {
        var stt = 0;
        result.DataList.forEach(item => {
            stt++;
            var img = _variable.urlImg + '/News/' + item.N_IMG;
            var link = _variable.url + '/post/' + _commons.locdau(item.N_NAME) + '-' + item.N_ID + '.html';
            var date = new Date(Date.parse(item.N_DATE)).toLocaleDateString();

            var odd = (stt % 2) == 0 ? 'ml-lg-auto' : '';

            htm += '<div class="col-lg-5 item ' + odd + '"><a href="' + link + '"><img src="' + img + _commons.extendImg(176, 172) + '" ></a>'
                + '<aside><h2><a href="' + link + '">' + item.N_NAME + '</a><small>' + date + '</small></h2>'
                + '<p>' + item.N_DES + '</p></aside></div>';
        });
    }

    $($this.Variables.element).html(htm);
}
