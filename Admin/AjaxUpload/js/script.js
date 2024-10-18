$(function () {
    load_images();
    function load_images() {

        var Shoplist = [{}];
        var shoplistSt = escape(JSON.stringify(Shoplist));
        param = { "stpe": 35, "shoplistSt": shoplistSt };
        postAjax(param, load_images_result, "html");
    }
    function load_images_result(e) {
        if (e != "err") {
            $('#listImages').html(e);
            if ($('.lightbox')[0]) {
                $('.lightbox').lightGallery({
                    enableTouch: true
                });
            }
            $('.itemImg').on('click', function (e) {
                delete_img($(this).data('id'), $(this).data('file'));
                return false;
                e.preventDefault();
            });
        }
        else {
            $('.cate_list').html("no data");
        }

    }
    function delete_img(id,file) {
        $.ajax({
            url: "AjaxUpload/Ajax_Upload.ashx?mode=Delete&path=../../Assets/HinhAnh/Gallery/&file=" + file,
            type: "GET",
            cache: false,
            async: true,
            success: function (html) {
                var Shoplist = [{ id: id }];
                var shoplistSt = escape(JSON.stringify(Shoplist));
                param = { "stpe": 36, "shoplistSt": shoplistSt };
                postAjax(param, delete_img_result, "html");
            }
        });
        
    }
    function delete_img_result(result) {
        if (result != 'err') {
            load_images();
        }
    }
    var ul = $('#upload ul');

    $('#drop a').click(function () {
        // Simulate a click on the file input button
        // to show the file browser dialog
        $(this).parent().find('input').click();
    });

    // Initialize the jQuery File Upload plugin
    $('#upload').fileupload({

        // This element will accept file drag/drop uploading
        dropZone: $('#drop'),

        // This function is called when a file is added to the queue;
        // either via the browse button, or via drag/drop:
        add: function (e, data) {

            var tpl = $('<li class="working"><input type="text" value="0" data-width="48" data-height="48"' +
                ' data-fgColor="#0788a5" data-readOnly="1" data-bgColor="#3e4043" /><p></p><span></span></li>');

            // Append the file name and file size
            tpl.find('p').text(data.files[0].name)
                .append('<i>' + formatFileSize(data.files[0].size) + '</i>');

            // Add the HTML to the UL element
            data.context = tpl.appendTo(ul);

            // Initialize the knob plugin
            tpl.find('input').knob();

            // Listen for clicks on the cancel icon
            tpl.find('span').click(function () {

                if (tpl.hasClass('working')) {
                    jqXHR.abort();
                }

                tpl.fadeOut(function () {
                    tpl.remove();
                });

            });

            // Automatically upload the file once it is added to the queue
            $.each(data.files, function (index, file) {
                console.log('Added file: ' + file.name);
            });
            data.url = 'AjaxUpload/Ajax_Upload.ashx?mode=Upload&path=../../Assets/HinhAnh/Gallery/';
            var jqXHR = data.submit();
        },

        progress: function (e, data) {

            // Calculate the completion percentage of the upload
            var progress = parseInt(data.loaded / data.total * 100, 10);

            // Update the hidden input field and trigger a change
            // so that the jQuery knob plugin knows to update the dial
            data.context.find('input').val(progress).change();

            if (progress == 100) {
                data.context.removeClass('working');
            }
        },
        success: function (e, data) {
            load_images();
            ul.html('');
            $('#preventClick').modal('hide');
        },
        fail: function (e, data) {
            // Something has gone wrong!
            data.context.addClass('error');
        }

    });


    // Prevent the default action when a file is dropped on the window
    $(document).on('drop dragover', function (e) {
        e.preventDefault();
    });

    // Helper function that formats the file sizes
    function formatFileSize(bytes) {
        if (typeof bytes !== 'number') {
            return '';
        }

        if (bytes >= 1000000000) {
            return (bytes / 1000000000).toFixed(2) + ' GB';
        }

        if (bytes >= 1000000) {
            return (bytes / 1000000).toFixed(2) + ' MB';
        }

        return (bytes / 1000).toFixed(2) + ' KB';
    }

});