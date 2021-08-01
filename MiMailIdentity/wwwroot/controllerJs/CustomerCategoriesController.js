R.CustomerCategories = {
    Init: function () {
        R.CustomerCategories.RegisterEvent();
        R.CustomerCategories.CurrentId = 0;
        R.CustomerCategories.Index = 1;
        R.CustomerCategories.Size = 10;
        R.CustomerCategories.Pagination();

    },
    RegisterEvent: function () {
        //Khai bao su kien tu ban phim
        //document.addEventListener("keydown", R.CustomerCategories.AnNutEnter, false);


        //Khai bao tu DOM

        $('.btn-create').off('click').on('click', function () {
            R.CustomerCategories.BuildHtmlAddEdit(0);
        });
        $('._cate_edit').off('click').on('click', function () {
            var id = $(this).data('id');
            R.CustomerCategories.BuildHtmlAddEdit(id);
        })
        $('._cate_delete').off('click').on('click', function () {
            var id = $(this).data('id');
            R.CustomerCategories.Delete(id);
        })
        $('._btn_save_cate').off('click').on('click', function () {
            var id = R.CustomerCategories.CurrentId;
            R.CustomerCategories.Save(id);
        });
    },
    Load: function (callback) {
        var url = '/CustomerCategories/Load';
        var params = {
            pageIndex: R.CustomerCategories.Index,
            pageSize: R.CustomerCategories.Size
        }
        $.post(url, params, function (response) {
            $('#datatable').html('').html(response);
            R.CustomerCategories.RegisterEvent();
        }).done(callback)
    },
    Save: function (id) {
        var url = '/CustomerCategories/Save';
        var params = {
            Id : id,
            Name: $('#_cate_name').val(),
            Status: parseInt($("._item_status").val())
        }
        console.log(params);
        $.post(url, params, function (response) {
            R.Notify(null, response, "success")
            $('#modal-create').modal('hide');
            R.CustomerCategories.ClearSaveText();
            R.CustomerCategories.Load(function () {
                console.log("load lai nay")
            });
            R.CustomerCategories.RegisterEvent();
        }).fail(function (error) {
            R.Notify(null, "Error cho nay", "error");
        })
    },
    Delete: function (id) {
        var title = "Xóa nhóm khách hàng"
        var content = "Bạn có muốn xóa nhóm KH không?<br/> Hãy đảm bảo xóa hết KH trong nhóm"
        R.Confirm(title, content, function () {
            var url = "/CustomerCategories/Delete";
            var params = {
                id : id
            }
            $.post(url, params, function (response) {
                R.Notify(null, response, "success");
                R.CustomerCategories.Load(function () {
                    console.log("load lai nay")
                });
                
                R.CustomerCategories.RegisterEvent();
            }).fail(function (response) {
                R.Notify(null, response, "error");
                R.CustomerCategories.RegisterEvent();
            })
        })
    },
    ClearSaveText: function () {
        $('#_cate_name').val('');
        R.CustomerCategories.RegisterEvent();
    },
    Pagination: function () { 
        //_set_pagination
        var t = $('#_set_pagination');
        var total = t.data('total');
        var size = t.data('size');
        console.log(total, size);
        var element = $('#pagination');
        R.Pagination($('#pagination'), total, size, function (data, pagination) {
            //alert(pagination.pageNumber);
            var picking_page = pagination.pageNumber;
            R.CustomerCategories.Index = picking_page;
            R.CustomerCategories.Load(function () {
                console.log("load lai nay")
            });
        });
    },
    BuildHtmlAddEdit: function (id) {
        var url = "/CustomerCategories/GetAddEditModal";
        var params = {
            id : id
        }
        $.post(url, params, function (response) {
            $('#modal-create').find('.modal-content').html('').html(response);
            $('#modal-create').modal('show');
            R.CustomerCategories.CurrentId = id;
            R.CustomerCategories.RegisterEvent();
        })
    }   
}
R.CustomerCategories.Init();


