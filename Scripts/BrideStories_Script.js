
function BrideStoriesScript() {
    this.Variables = {
        element: '.BridesStories',
        request: { BS_ID: -1 }
    }
}

BrideStoriesScript.prototype.init = function () {
    var $this = this;
    $this.loadData();
}
BrideStoriesScript.prototype.loadData = function () {
    var $this = this;
    var Request = escape(JSON.stringify(this.Variables.request));
    var param = { "stpe": 103, "Request": Request };
    postAjax(param, $this.bindData, "json", $this);
}
BrideStoriesScript.prototype.bindData = function (result, $this) {

    if (result.Code == 0 && result.DataList.length > 0) {
        result.DataList.forEach(item => {
            if (item.IS_DATA || item.IS_DATA == 'true') {
                var img = _variable.urlImg + '/BrideStories/' + item.BSC_IMG;
                $($this.Variables.element).find('img').attr('src', img + _commons.extendImg(1325, 725));
            }
            else {
                $('.BridesStories').hide();
            }
        });

    }
}

BrideStoriesScript.prototype.initdata = function () {
    var $this = this;
    $this.Variables.request.BS_ID = $('#Content_hdAlias').val();
    $this.Variables.request.element = '.list-item';
    $this.loadDataBridal();
}
BrideStoriesScript.prototype.loadDataBridal = function () {
    var $this = this;
    var Request = escape(JSON.stringify(this.Variables.request));
    var param = { "stpe": 112, "Request": Request };
    postAjax(param, $this.bindDataBridal, "json", $this);
}
BrideStoriesScript.prototype.bindDataBridal = function (result, $this) {
    
    var htm = '';
    if (result.Code == 0 && result.DataList.length > 0) {
        var stt = 0;
        if ($this.Variables.request.BS_ID == -1) { // list
            result.DataList.forEach(item => {
                stt++;
                var img = _variable.urlImg + '/BrideStories/' + item.BS_IMG;
                var link = _variable.url + '/story/' + _commons.locdau(item.BS_NAME) + '-' + item.BS_ID + '.html';
                var date = new Date(Date.parse(item.BS_DATE)).toLocaleDateString();

                var odd = (stt % 2) == 0 ? 'ml-lg-auto' : '';

                htm += '<div class="col-lg-5 item ' + odd + '"><a href="' + link + '"><img src="' + img + _commons.extendImg(176, 172) + '" ></a>'
                    + '<aside><h2><a href="' + link + '">' + item.BS_NAME + '</a><small>' + date + '</small></h2>'
                    + '<p>' + item.BS_DES + '</p></aside></div>';
            });
            $($this.Variables.request.element).html(htm);
        } else {
            result.DataList.forEach(item => {
                result.DataList.forEach(item => {
                    $('.newsTitle').text(item.BS_NAME);
                    document.title = item.BS_NAME;
                    $('.newsDetail').html(item.BS_DETAIL);
                });
            });
        }

    }
}