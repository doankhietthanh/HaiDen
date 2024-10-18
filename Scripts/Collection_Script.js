
function CollectionScript() {
    this.Variables = {
        element: '#listCollection',
        request: {}
    }
}

CollectionScript.prototype.init = function () {
    var $this = this;
    $this.loadData();
}
CollectionScript.prototype.initIndex = function () {
    var $this = this;
    $this.Variables.element = '.list-';
    $this.loadDataIndex();
}
CollectionScript.prototype.loadData = function () {
    var $this = this;
    var Request = escape(JSON.stringify(this.Variables.request));
    var param = { "stpe": 101, "Request": Request };
    postAjax(param, $this.bindData, "json", $this);
}
CollectionScript.prototype.bindData = function (result, $this) {
    var htm = '';
    if (result.Code == 0 && result.DataList.length > 0) {
        result.DataList.forEach(item => {
            var link = _variable.url + '/collection/' + _commons.locdau(item.CO_NAME);
            htm += '<li><a class="dropdown-item" href="' + link + '">' + item.CO_NAME + '</a></li>';
        });

    }

    $($this.Variables.element).html(htm);
}

CollectionScript.prototype.loadDataIndex = function () {
    var $this = this;
    var Request = escape(JSON.stringify(this.Variables.request));
    var param = { "stpe": 101, "Request": Request };
    postAjax(param, $this.bindDataIndex, "json", $this);
}
CollectionScript.prototype.bindDataIndex = function (result, $this) {
    
    var htm = '';
    if (result.Code == 0 && result.DataList.length > 0) {
        var idx = 0;
        result.DataList.forEach(item => {
            idx++;
            htm = $this.RenderElement(item, idx);
            $($this.Variables.element + idx).html(htm);
        });

    }


}
CollectionScript.prototype.RenderElement = function (item, index) {
    var htm = '';
    var img = _variable.urlImg + '/Collections/' + item.CO_IMG;
    var link = _variable.url + '/collection/' + _commons.locdau(item.CO_NAME);
    switch (index) {
        case 1:
            htm += '<div class="col-lg-5"><a href="' + link + '"><img src="' + img + _commons.extendImg(605, 900) + '" width="605" height="900"  /></a>'
                + '<div class="collection-time right bottom"><h2>' + item.CO_SEASON + '</h2></div></div>'
                + '<div class="ml-lg-auto col-lg-6"><aside><h2 class="title text-center"><a href="' + link + '">' + item.CO_NAME + '</a></h2>'
                + '<p class="text-justify">' + item.CO_DES + '</p></aside></div>';
            break;
        case 2:
            htm += '<div class="ml-lg-auto col col-lg-custom"><a href="' + link + '"><img src="' + img + _commons.extendImg(1165, 780) + '" width="1165" height="780"  /></a>'
                + '<div class="collection-time top left"><h2>' + item.CO_SEASON + '</h2></div>'
                + '<aside><h2 class="title"><a href="' + link + '">' + item.CO_NAME + '</a></h2><p class="text-justify">' + item.CO_DES + '</p></aside></div>';
            break;
        case 3:
            htm += '<div class=" col-lg-6"><aside class="ml-lg-auto col-lg-11"><h2 class="title text-right"><a href="' + link + '">' + item.CO_NAME + '</a></h2>'
                + '<p class="text-justify">' + item.CO_DES + '</p></aside></div>'
                + '<div class="ml-lg-auto col-lg-6"><a href="' + link + '"><img src="' + img + _commons.extendImg(720, 1080) + '" width="720" height="1080"  /></a>'
                + '<div class="collection-time top left"><h2>' + item.CO_SEASON + '</h2></div></div>';
            break;
        case 4:
            var img1 = _variable.urlImg + '/Collections/' + item.CO_IMG_1;
            htm += '<div class="col-lg-6"><a href="' + link + '"><img src="' + img + _commons.extendImg(660, 990) + '" width="660" height="990"  /></a></div>'
                + '<div class=" col-lg-6"><div class="row justify-content-md-center"><div class="col-auto img_collection_4"><a href="' + link + '"><img src="' + img1 + _commons.extendImg(435, 435) + '" width="435" height="435"  /></a></div>'
                + '<div class="collection-time center"><h2><a href="' + link + '">' + item.CO_SEASON + '</a></h2></div>'
                + '<aside class="col-lg-10"><h2 class="title text-center"><a href="' + link + '">' + item.CO_NAME + '</a></h2><p class="text-justify">' + item.CO_DES + '</p></aside></div></div>';
            break;
        case 5:
            htm += '<div class=" col-lg-4"><aside class="ml-lg-auto col-lg-11"><h2 class="title text-right"><a href="' + link + '">' + item.CO_NAME + '</a></h2>'
                + '<p class="text-justify">' + item.CO_DES + '</p></aside></div>'
                + '<div class="ml-lg-auto col-lg-8"><a href="' + link + '"><img src="' + img + _commons.extendImg(975, 735) + '" width="975" height="735"  /></a>'
                + '<div class="collection-time top left"><h2>' + item.CO_SEASON + '</h2></div></div>';
            break;
    }

    return htm;
}
$(document).ready(function () {
    var Collection_Script = new CollectionScript();
    Collection_Script.init();
});