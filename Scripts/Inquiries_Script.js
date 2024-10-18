function Inquiries() {
    this.Request = {
        WD_ID: '',
        IQ_MESSENGER: '',
        IQ_NAME: '',
        IQ_MAIL: '',
        IQ_PHONE: '',
        NA_ID: '',
        IQ_BUGET: '',
        IQ_WEDDING_DATE: '',
        U_ID: ''
    }
    this.UserInfo = JSON.parse(localStorage.getItem('memberData'));
}
Inquiries.prototype.init = function () {
    
    var $this = this;
    if ($this.UserInfo != null) {
        $('#InquireModal').addClass('guest');
    } else {
        $('#InquireModal').removeClass('guest');
    }
    $this.AddContact();
}
Inquiries.prototype.setRequest = function () {
    var $this = this;
    var iMess = $('#iMess').val();

    if ($this.UserInfo != null) {
        var item = $this.UserInfo;
        $this.Request.WD_ID = $('#Content_hdAlias').val();
        $this.Request.IQ_MESSENGER = iMess;
        $this.Request.IQ_NAME = item.U_NAME;
        $this.Request.IQ_MAIL = item.U_MAIL;
        $this.Request.IQ_PHONE = item.U_PHONE;
        $this.Request.NA_ID = item.NA_ID;
        $this.Request.IQ_BUGET = item.U_BUGET;
        $this.Request.IQ_WEDDING_DATE = item.U_WEDDING_DATE;
        $this.Request.U_ID = item.U_ID;
    } else {
        var iName = $('#iName').val(), iEmail = $('#iEmail').val(), iBugget = $('#iBugget').val(), iNational = $('#iNational').val(), iPhone = $('#iPhone').val(),
            iWeddingDate = $('#iWeddingDate').val();

        if (iName != '' && iEmail != '' && iBugget != '' && iNational != '' && iPhone != '' && iWeddingDate != '') {
            $this.Request.WD_ID = $('#Content_hdAlias').val();
            $this.Request.IQ_MESSENGER = iMess;
            $this.Request.IQ_NAME = iName;
            $this.Request.IQ_MAIL = iEmail;
            $this.Request.IQ_PHONE = iPhone;
            $this.Request.NA_ID = iNational;
            $this.Request.IQ_BUGET = iBugget;
            $this.Request.IQ_WEDDING_DATE = iWeddingDate;
            $this.Request.U_ID = -1;
        } else {
            alert('You must enter a full information!');
            return false;
        }
    }
    return true;
}
Inquiries.prototype.AddContact = function () {
    var $this = this;
    $('#btnInquiry').off('click').on('click', function () {
        
        if ($this.setRequest()) {
            var Request = escape(JSON.stringify($this.Request));
            var param = { "stpe": 108, "Request": Request };
            postAjax(param, $this.addContact_result, "json", null);
        }
    })
}
Inquiries.prototype.addContact_result = function (result, ele) {
    if (result.Code == 0) {
        _alers.success('Successfull!');
    }
    $('#iName').val(''); $('#iEmail').val(''); $('#iBugget').val(''); $('#iNational').val('1'); $('#iPhone').val(''); $('#iWeddingDate').val('');
    $('#iMess').val('');
    $('#InquireModal').modal('hide');
}

Inquiries.prototype.initLoad = function () {
    var $this = this;
    var member = JSON.parse(localStorage.getItem('memberData'));
    if (member != null) {
        $this.Request.U_ID = member.U_ID;
        $this.loadData();
    }
}
Inquiries.prototype.loadData = function () {
    var $this = this;
    var Request = escape(JSON.stringify(this.Request));
    var param = { "stpe": 111, "Request": Request };
    postAjax(param, $this.bindData, "json", $this);
}
Inquiries.prototype.bindData = function (result, $this) {
    
    if (result.Code == 0 && result.DataList.length > 0) {
        result.DataList.forEach(item => {
            var userzone = $('.profile');
            userzone.find('.dress').text(item.WD_NAME);
            userzone.find('.amout').text(item.IQ_TOTAL_AMOUT);
            userzone.find('.deposit').text(item.IQ_DEPOSIT);
            userzone.find('.toward').text(item.IQ_TOWARD);

            var date = new Date(item.IQ_DUE_DATE);
            userzone.find('.duedate').text((date.getMonth() + 1) + '/' + date.getDate() + '/' + date.getFullYear());

            var status = item.IQ_PROGRESS;
            var index = 0;
            $('.listProgress').find('li').removeClass('active');
            $('.listProgress').find('li').each(function () {
                index++;
                if (index <= parseInt(status)) {
                    $(this).addClass('active');
                }
            })
        });

    }
}