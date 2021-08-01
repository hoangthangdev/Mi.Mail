R = {
    Init: function () {
    },
    Pagination: function (el, total, size, callback) {
        var arr = [];
        for (var i = 1; i <= total; i++) {
            arr.push(i);
        }

        el.pagination({
            dataSource: arr,
            pageSize: size,
            showPrevious: false,
            showNext: false,
            callback: callback
        })
    },
    Notify: function (el, text, type) {
        if (el == null) {
            $.notify(text, type);
        }
        if (el != null) {
            $.notify(el, text, type);
        }
    },
    Confirm: function (title, content, callback) {
        $.confirm({
            title: title,
            content: content,
            buttons: {
                confirm: callback,
                cancel: function () {
                    
                }
                
            }
        });
    },
    DatePicker: function (el, singleDatePicker) {
        el.daterangepicker({
            singleDatePicker: singleDatePicker,
            showDropdowns: true,
            autoUpdateInput: true,
            locale: {
                "format": "DD/MM/YYYY"
            }
        });
    },
    CurrentLoginId: function () {
        var c = $('#current_login_user').data('id');
        return c;
    },
    GetPath: function (indexer) {
        return window.location.pathname.split('/')[indexer];
    },
    CreateElementFromHtml: function (htmlString, configClass) {
        var t = document.createElement('tr');
        htm = "";
        htm += htmlString.trim();
        $(t).append(htm);
        return t;
    }
}

R.Init();

