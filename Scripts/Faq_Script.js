
function FaqsScript() {
    this.Variables = {
        element: '.pageContent',
        request: {}
    }
}

FaqsScript.prototype.init = function () {
    var $this = this;
    $this.loadData();
}
FaqsScript.prototype.loadData = function () {
    var $this = this;
    var Request = escape(JSON.stringify(this.Variables.request));
    var param = { "stpe": 113, "Request": Request };
    postAjax(param, $this.bindData, "json", $this);
}
FaqsScript.prototype.bindData = function (result, $this) {
    var htm = '';
    if (result.Code == 0 && result.DataList.length > 0) {
        result.DataList.forEach(item => {

            var FaqCate = item.Faq_Cate_Model;
            var Faq = item.Faq_Model;

            htm += '<div class="row"><div class="col-12 title">' + FaqCate.FC_NAME + '</div>';
            var stt = 0;
            Faq.forEach(item1 => {
                stt++;
                htm += '<div class="col-lg-5 ' + (stt % 2 == 0 ? 'ml-lg-auto' : '') + '"><div class="question">' + item1.F_QUESTION + '</div><div class="answer"><p>' + item1.F_ANSWER + '</p></div></div>';
            });

            htm += '</div>';
        });

    }

    $($this.Variables.element).html(htm);
}
