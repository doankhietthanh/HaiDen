
function AboutUsScript() {
    this.Variables = {
        element: '.AboutUs',
        request: { TYPE: 0 }
    }
}

AboutUsScript.prototype.init = function () {
    var $this = this;
    $this.loadData();
}
AboutUsScript.prototype.initDetail = function () {
    var $this = this;
    $this.Variables.request.TYPE = -1;
    $this.Variables.element = '';
    $this.loadData();
}
AboutUsScript.prototype.loadData = function () {
    var $this = this;
    var Request = escape(JSON.stringify(this.Variables.request));
    var param = { "stpe": 104, "Request": Request };
    postAjax(param, $this.bindData, "json", $this);
}
AboutUsScript.prototype.bindData = function (result, $this) {
    var htm = '';
    if (result.Code == 0 && result.DataList.length > 0) {
        if ($this.Variables.request.TYPE == 0) {
            var stt = 0;
            result.DataList.forEach(item => {
                stt++;
                var img = _variable.urlImg + '/AboutUs/' + item.AU_IMG + _commons.extendImg(545, 545);
                htm += '<div class="m' + (stt == 1 ? 'r' : 'l') + '-lg-auto col-lg-auto"><a href="' + _variable.url + '/about-us"><img src="' + img + '" width="545" height="545"  /><h4>' + item.AU_NAME + '</h4></a></div>';
            });
            $($this.Variables.element).find('.section-content').html(htm);
        } else {
            var stt = 0;
            result.DataList.forEach(item => {
                stt++;
                var itemObj = $('.aboutus');
                var img = _variable.urlImg + '/AboutUs/' + item.AU_IMG;
                if (stt == 1) {
                    itemObj.find('.item1 .name').text(item.AU_NAME);
                    itemObj.find('.item1 .title').text(item.AU_TITLE);
                    itemObj.find('.item1 .detail').html(item.AU_DETAIL);
                    itemObj.find('.item1 img').attr('src', img + _commons.extendImg(645, 850));
                }
                if (stt == 2) {
                    itemObj.find('.item2').find('.name').text(item.AU_NAME);
                    itemObj.find('.item2 .title').text(item.AU_TITLE);
                    itemObj.find('.item2 .detail').html(item.AU_DETAIL);
                    itemObj.find('.item2 img').attr('src', img + _commons.extendImg(800, 595));
                }
            });
        }

    }
}

