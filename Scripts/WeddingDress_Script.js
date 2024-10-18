
function WeddingDressScript() {
    this.Variables = {
        element: '.listWeddingDress',
        request: {
            WD_ID: -1,
            CO_NAME: ''
        },
        elementImg: '.list-dess-img',
        requestImg: {
            WD_ID: -1
        },
        elementFav: '.listWeddingDress',
        elementFav: {}
    }
}

WeddingDressScript.prototype.init = function () {
    var $this = this;
    $this.Variables.request.CO_NAME = $('#Content_hdAlias').val();
    $this.Variables.request.WD_ID = -1;
    $this.loadData();
}
WeddingDressScript.prototype.initFav = function () {
    var $this = this;
    $this.loadDataFav();
}
WeddingDressScript.prototype.initDetail = function () {
    var $this = this;
    $this.Variables.request.CO_NAME = '-1';
    $this.Variables.request.WD_ID = $('#Content_hdAlias').val();
    $this.Variables.element = '';
    $this.loadDataDetail();
}
WeddingDressScript.prototype.initImg = function () {
    var $this = this;
    $this.Variables.request.WD_ID = $('#Content_hdAlias').val();
    $this.loadDataImg();
}

WeddingDressScript.prototype.loadData = function () {
    var $this = this;
    var Request = escape(JSON.stringify(this.Variables.request));
    var param = { "stpe": 106, "Request": Request };
    postAjax(param, $this.bindData, "json", $this);
}
WeddingDressScript.prototype.bindData = function (result, $this) {

    var htm = '', listCurrentCollection = [];
    if (result.Code == 0 && result.DataList.length > 0) {
        var index = 0, fist = 0;
        htm += '<div class="row">';
        result.DataList.forEach(item => {
            index++; fist++
            var img = _variable.urlImg + '/WeddingDress/' + item.IMG + _commons.extendImg(460, 675);
            var link = _variable.url + '/dress/' + _commons.locdau(item.WD_NAME) + '-' + item.WD_ID + '.html';
            var isActive = item.IS_FAV !== 0 ? 'active' : '';
            htm += '<div class="col-lg-4"><div class="collection-img">'
                + '<label class="favorite ' + isActive + '" title="Add to favourite" data-id="' + item.WD_ID + '"><i class="fa fa-heart"></i></label>'
                + '<a href="' + link + '"><img src="' + img + '" class="" width="460" height="675"  />'
                + '<label class="collection-title">' + item.WD_NAME + '</label></a></div></div>';
            //if (index == 3) {
            //    htm += '</div><div class="row">';
            //    index = 0;
            //}
            if (fist == 1) {
                var phead = $('.page-head');
                phead.find('h2').text(item.CO_NAME);
                phead.find('label').text(item.CO_SEASON);
                document.title = item.CO_NAME;
            }
            listCurrentCollection.push(item);
        });
        htm += '</div>';
        localStorage.setItem('listCurrentCollection', JSON.stringify(listCurrentCollection));
    }

    $($this.Variables.element).html(htm);
    $('.favorite').on('click', function () {
        var _this = this;
        $this.AddToFavourite($(this).data('id'), _this);
    })
}

WeddingDressScript.prototype.loadDataFav = function () {
    var $this = this;
    if (_commons.readCookie('CookieUsersName') != null || _commons.readCookie('SUsersName') != null) {
        var Request = escape(JSON.stringify(this.Variables.request));
        var param = { "stpe": 115, "Request": Request };
        postAjax(param, $this.bindDataFav, "json", $this);
    } else {
        _alers.danger('You must <a href="' + _variable.url + '/signin">Signin</a> or <a href="' + _variable.url + '/signup">Signup</a> first!');
    }
}
WeddingDressScript.prototype.bindDataFav = function (result, $this) {

    var htm = '', listCurrentCollection = [];
    if (result.Code == 0 && result.DataList.length > 0) {
        var index = 0, fist = 0;
        htm += '<div class="row">';
        result.DataList.forEach(item => {
            index++; fist++
            var img = _variable.urlImg + '/WeddingDress/' + item.IMG + _commons.extendImg(460, 675);
            var link = _variable.url + '/dress/' + _commons.locdau(item.WD_NAME) + '-' + item.WD_ID + '.html';

            htm += '<div class="col-lg-4"><div class="collection-img">'
                + '<a href="' + link + '"><img src="' + img + '" class="" width="460" height="675"  />'
                + '<label class="collection-title">' + item.WD_NAME + '</label></a></div></div>';
            if (index == 3) {
                htm += '</div><div class="row">';
                index = 0;
            }
            listCurrentCollection.push(item);
        });
        htm += '</div>';
        localStorage.setItem('listCurrentCollection', JSON.stringify(listCurrentCollection));
    }

    $($this.Variables.element).html(htm);
}

WeddingDressScript.prototype.AddToFavourite = function (id, _this) {
    var $this = this;
    $this.Variables.request.WD_ID = id;

    if (_commons.readCookie('CookieUsersName') != null || _commons.readCookie('SUsersName') != null) {
        var Request = escape(JSON.stringify(this.Variables.request));
        var param = { "stpe": 114, "Request": Request };
        postAjax(param, $this.AddToFavouriteResult, "json", _this);
    } else {
        _alers.danger('You must <a href="' + _variable.url + '/signin">Signin</a> or <a href="' + _variable.url + '/signup">Signup</a> first!');
    }

}
WeddingDressScript.prototype.AddToFavouriteResult = function (result, $this) {
    if (result.Code == 0) {
        _alers.success(result.result);
        $($this).addClass('active');
    } else if (result.Code == 2) {
        _alers.danger(result.error + ' <a href="' + _variable.url + '/favorite">Go to favourite</a>');
    } else {
        _alers.danger(result.error);
    }
}

WeddingDressScript.prototype.loadDataDetail = function () {
    var $this = this;
    var Request = escape(JSON.stringify(this.Variables.request));
    var param = { "stpe": 106, "Request": Request };
    postAjax(param, $this.bindDataDetail, "json", $this);
}
WeddingDressScript.prototype.bindDataDetail = function (result, $this) {

    var htm = '', listCurrentCollection = [];
    var co_name = '-1';
    if (result.Code == 0 && result.DataList.length > 0) {
        var dressContent = $('.detail-dress-content');


        result.DataList.forEach(item => {

            var img = _variable.urlImg + '/WeddingDress/' + item.IMG;
            var link = _variable.url + '/dress/' + _commons.locdau(item.WD_NAME) + '-' + item.WD_ID + '.html';

            $('.detail-dess-img').find('a').attr('href', img);
            $('.detail-dess-img').find('img').attr('src', img + _commons.extendImg(690, 1035));
            $('.add_to_fav').data('id', item.WD_ID);
            item.IS_FAV !== 0 && $('.add_to_fav').addClass('active');

            dressContent.find('h2').text(item.WD_NAME);
            dressContent.find('.price').text(item.WD_PRICE);
            dressContent.find('.dress-detail').html(item.WD_DES);
            document.title = item.WD_NAME;
            co_name = item.CO_NAME;

        });

        var listCollection = JSON.parse(localStorage.getItem('listCurrentCollection'));
        if (listCollection != null) {
            var currentCollectionItem = listCollection.filter(x => { return x.WD_ID == $this.Variables.request.WD_ID; });
            dressContent.find('h1').text(currentCollectionItem[0].CO_NAME);
            dressContent.find('.season-box').text(currentCollectionItem[0].CO_SEASON);
        } else {
            $this.loadListCurrentCollection(_commons.locdau(co_name));
        }

        $('.favorite').on('click', function () {
            var _this = this;
            $this.AddToFavourite($(this).data('id'), _this);
        })
        $this.initControl();

    }
}
WeddingDressScript.prototype.initControl = function () {
    var $this = this;
    var Cnext = $('.control-right');
    var Cprev = $('.control-left');
    var Cclose = $('.control-close');
    var listCollection = JSON.parse(localStorage.getItem('listCurrentCollection'));
    var currentId = $('#Content_hdAlias').val();

    var screen = window.outerHeight;
    Cnext.css({ 'top': (screen / 2 - 63) });
    Cprev.css({ 'top': (screen / 2 - 63) });
    var nextId, prevId;
    var currentIndex = listCollection.findIndex(x => x.WD_ID == currentId);
    var nextPos = (parseInt(currentIndex) + 1) + 1 <= listCollection.length ? parseInt(currentIndex) + 1 : null;
    var prevPos = currentIndex > 0 ? parseInt(currentIndex) - 1 : null;
    nextId = nextPos != null ? listCollection[nextPos].WD_ID : 0;
    prevId = prevPos != null ? listCollection[prevPos].WD_ID : 0;

    if (nextId != 0) {
        Cnext.on('click', function () {
            window.location.href = _variable.url + '/dress/' + _commons.locdau(listCollection[nextPos].WD_NAME) + '-' + nextId + '.html';
        });
    } else {
        Cnext.hide();
    }
    if (prevId != 0) {
        Cprev.on('click', function () {
            window.location.href = _variable.url + '/dress/' + _commons.locdau(listCollection[prevPos].WD_NAME) + '-' + prevId + '.html';
        });
    } else {
        Cprev.hide();
    }

    var curCollection = listCollection.filter(x => x.WD_ID == currentId)[0].CO_NAME;
    Cclose.on('click', function () {
        window.location.href = _variable.url + '/collection/' + _commons.locdau(curCollection);
    });
    $('.collection-current').on('click', function () {
        window.location.href = _variable.url + '/collection/' + _commons.locdau(curCollection);
    });
}
WeddingDressScript.prototype.loadListCurrentCollection = function (co_name) {

    var $this = this;
    $this.Variables.request.CO_NAME = co_name;
    $this.Variables.request.WD_ID = -1;

    var Request = escape(JSON.stringify(this.Variables.request));
    var param = { "stpe": 106, "Request": Request };
    postAjax(param, $this.bindListCurrentCollection, "json", $this);
}
WeddingDressScript.prototype.bindListCurrentCollection = function (result, $this) {
    if (result.Code == 0 && result.DataList.length > 0) {
        localStorage.setItem('listCurrentCollection', JSON.stringify(result.DataList));
        var dressContent = $('.detail-dress-content');
        var currentCollectionItem = result.DataList.filter(x => { return x.WD_ID == $('#Content_hdAlias').val(); });
        dressContent.find('h1').text(currentCollectionItem[0].CO_NAME);
        dressContent.find('.season-box').text(currentCollectionItem[0].CO_SEASON);
    }
}


WeddingDressScript.prototype.loadDataImg = function () {
    var $this = this;
    var Request = escape(JSON.stringify(this.Variables.request));
    var param = { "stpe": 107, "Request": Request };
    postAjax(param, $this.bindDataImg, "json", $this);
}
WeddingDressScript.prototype.bindDataImg = function (result, $this) {
    var htm = '';
    if (result.Code == 0 && result.DataList.length > 0) {
        var index = 0;
        result.DataList.forEach(item => {
            index++;
            var img = _variable.urlImg + '/WeddingDress/' + item.WDI_FILE;
            htm += '<li data-orginal="' + img + '" class="' + (index == 1 ? 'active' : '') + '"><img src="' + img + _commons.extendImg(120, 175) + '" width="120" height="175"  /></li>';
        });
    }

    $($this.Variables.elementImg).find('ul').html(htm);
    $($this.Variables.elementImg).find('li').each(function () {
        $(this).on('click', function () {
            var curImg = $(this).data('orginal');
            $('.detail-dess-img').find('a').attr('href', curImg);
            $('.detail-dess-img').find('img').attr('src', curImg + _commons.extendImg(690, 1035));
            $($this.Variables.elementImg).find('li').removeClass('active');
            $(this).addClass('active');
        });
    });
}