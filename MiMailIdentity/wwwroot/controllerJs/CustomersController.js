R.Customer = {
    Init: function () {
        R.Customer.CurrentId = 0;
        R.Customer.Index = 1;
        R.Customer.Size = 10;
        R.Customer.RegisterEvent();
        R.Customer.DefaultCateId = parseInt(R.GetPath(3));
        R.Customer.date = '';
        R.Customer.Load(R.Customer.ParamSearch(''))
        setTimeout(function () {
            R.Customer.Pagination();
        }, 200)
    },
    RegisterEvent: function () {
        $('#CreateKhachHang').off('click').on('click', function () {
            R.Customer.CurrentId = 0;
            var url = "/Customers/AddModal";
            R.Customer.LoadModaSave(R.Customer.CurrentId, url);

        })
        $('.UDCustomer').off('click').on('click', function () {
            var id = $(this).data('id');
            R.Customer.CurrentId = id;
            var url = "/Customers/AddModal";
            R.Customer.LoadModaSave(R.Customer.CurrentId, url);
        })
        $('#Modal_Customer').off('submit').on('submit', function () {
            var Id = R.Customer.CurrentId;
            param = R.Customer.ParamModa(Id);
            R.Customer.Save(param)
            return false;
        })
        $('.ModaChiTiet').off('click').on('click', function () {
            var id = $(this).data('id');
            var url = "/Customers/OpenModalChiTiet";
            R.Customer.LoadModalChiTiet(id, url);
        })
        $('#FintCate').off('change').on('change', function () {
            R.Customer.DefaultCateId = parseInt($(this).val());
        })
        $('#search').off('click').on('click', function () {
            var date = $('#searchTime').val();
            R.Customer.date = date;
            var param = R.Customer.ParamSearch(R.Customer.date)
            R.Customer.Load(param);
            setTimeout(function () {
                R.Customer.Pagination();
            }, 100)
        })
    },
    //Cac ham xu ly
    Load: function (params) {
        var url = '/Customers/Filter';
        $.post(url, params, function (response) {
            $('#datatable').html('').html(response);
            R.Customer.RegisterEvent();
        })
    },
    Save: function (param) {
        var url = "/Customers/Save";
        $.post(url, param, function (response) {
            if (response.status) {
                $('#myModal2').modal('hide');
                R.Notify(null, response.mess, "success")
                R.Customer.Load(R.Customer.ParamSearch(''));
                setTimeout(function () {
                    R.Customer.Pagination();
                },200)
                R.Customer.RegisterEvent();
            }
            else if (response.status == false) {
                R.Notify(null, response.mess, "error")
                $('#myModal2').modal("hide");
                R.Customer.RegisterEvent();
            }
        })
    },
    LoadModaSave: function (Id, url) {
        var Param = {
            Id: Id
        }
        $.post(url, Param, function (res) {
            $('#Modal_Customer').find('.modal-content').html('').html(res);

            $('#myModal2').modal('show');
            var dpk = $('#Birth');
            R.DatePicker(dpk, true);
            R.Customer.RegisterEvent();
        })
    },
    LoadModalChiTiet: function (Id, url) {
        var Param = {
            Id: Id
        }
        $.post(url, Param, function (res) {
            $('#ModalChiTiet').find('.modal-content').html('').html(res);
            $('#ModalChiTiet').modal('show');
            R.Customer.RegisterEvent();
        })
    },
    ParamModa: function (Id) {
        var Name = $('#Name').val();
        var Phone = $('#Phone').val();
        var CMT = $('#CMT').val();
        var Nhom = $('#Nhom').val();
        var b = $('#Birth').val();
        var Birth = moment(b, "DD/MM/YYYY").format("YYYY-MM-DD");
        var Address = $('#Address').val();
        var Email = $('#Mail').val();
        var Node = $('#Node').val();
        var GioiTinh = $("#Modal_Customer input[type='radio']:checked").val();
        var param = {
            Id: Id,
            Name: Name,
            Phone: Phone,
            DateOfBirth: Birth,
            CustomerCateId: Nhom,
            Address: Address,
            Email: Email,
            Description: Node,
            CMT: CMT,
            Gender: GioiTinh
        }
        return param;
    },
    ParamSearch: function (date) {
        var stdate = null;
        var edate = null;
        if (date != '') {
            stdate = moment(date.split('-')[0], "DD/MM/YYYY").format("YYYY-MM-DD ")
            edate = moment(date.split('-')[1], "DD/MM/YYYY").format("YYYY-MM-DD ")
        }
        var params = {
            Name: $('#FintName').val(),
            CateId: R.Customer.DefaultCateId,
            StartDate: stdate,
            EndDate: edate,
            PageIndex: R.Customer.Index,
            PageSize: R.Customer.Size
        }
        return params;
    },
    Pagination: function () {
        var el = $('#datatable');
        var t = el.find('#_set_pagination');
        var total = t.data('total');
        var size = t.data('size');
        R.Pagination($('#pagination'), total, size, function (data, pagination) {
            var picking_page = pagination.pageNumber;
            R.Customer.Index = picking_page;
            R.Customer.Load(R.Customer.ParamSearch(R.Customer.date));
        });
    },
    LoadCoutMess: function () {

    }
}
R.Customer.Init();