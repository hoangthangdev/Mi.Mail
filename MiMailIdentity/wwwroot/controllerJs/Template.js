R.Template = {
    Init: function () {
        R.Template.CateName = $('.danh-muc-template.active').data('name');
        R.Template.Index = 1;
        R.Template.RegisterEvent();
        R.Template.Pagination();
        R.BuildingItem.BuildSelectCate();
    },
    RegisterEvent: function () {
        $('.danh-muc-template').off('click').on('click', function () {
            var index = 1;
            var cateName = $(this).data('name');
            R.Template.CateName = cateName;
            R.Template.LoadTemp(R.Template.ParamLoad(cateName, index), function () { R.Template.Pagination(); })
        });
        $('#IpTextSearch').off('input').on('input', function () {
            R.Template.LoadTemp(R.Template.ParamLoad(R.Template.CateName, R.Template.Index), function () { R.Template.Pagination(); })

        })
        $('#upFile').off('input').on('input', function (e) {
            var parent = $(this).closest('#FormUpFile');
            var file = e.target.files[0];
            R.Template.ReadFileText(file, parent);
            $.post("/Template/PhotoImgByHtml", { html: "trong" }, function (r) {

            })
        })
    },
    LoadTemp: function (param,callBack) {
        var url = "/Template/ListTempPlate";
        $.post(url, param, function (repo) {
            $('.binding-item').html('').html(repo)
            R.Template.RegisterEvent();
            callBack();
        })

    },
    Pagination: function () {
        var el = $('.binding-item');
        var t = el.find('#_set_pagination');
        var total = t.data('total');
        var size = 1;
        R.Pagination($('#pagination'), total, size, function (data, pagination) {
            var picking_page = pagination.pageNumber;
            R.Template.Index = picking_page;
            var param = R.Template.ParamLoad(R.Template.CateName, picking_page);
            R.Template.LoadTemp(param, null)
        });
    },
    ParamLoad: function (cateName,index) {
        var search = $('#IpTextSearch').val();
        var param = {
            cateName: cateName,
            search: search,
            Index: index
        }
        return param;
    },

    ReadFileText: function (ip, el) {
        form = new FileReader();
        form.onload = function (event) {
            console.log(event.target.result);
            el.find('#fileMail').html(event.target.result);
        }
        form.readAsText(ip, "UTF-8");
    },
}
R.Template.Init();