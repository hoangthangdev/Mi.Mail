R.BuildingItem = {
    Init: function () {
        R.BuildingItem.BuildCloning();
        R.BuildingItem.BuildDrop();
        R.BuildingItem.BuildSelectCate();
        R.BuildingItem.RegisterEvent();

    },
    RegisterEvent: function () {
        $('.block').off('click').on('click', function () {
            if (!$(this).hasClass('block-selected')) {
                var selected = $(this).parent().find('.block-selected');
                selected.each(function (el) {
                    $(this).removeClass('block-selected');
                    $(this).find('.close-choose-block').remove();
                })
                $(this).addClass('block-selected');
                $(this).find('.close-choose-block').css("display", "block");
                $('.toolbox').find('.item-picking').css('display', 'none');
                $('.toolbox').find('.item-picked-editor').css('display', 'block');
                R.BuildingItem.FillChildElement($(this));
            }
            else {
                var selected = $(this).parent().find('.block-selected');
                selected.each(function (el) {
                    $(this).removeClass('block-selected');
                    $(this).find('.close-choose-block').css("display", "none");
                })
            }
        })
        $('#ipImg').off('change').on('change', function () {
            var parent = $(this).closest(".loadAvatar")
            var file = $(this).prop('files')[0];
            R.BuildingItem.ReadUrl(file, parent);
        })
        $('.save-template-form').off('submit').on('submit', function () {
            var fileUpload = $(this).find("#ipImg").get(0);
            var file = fileUpload.files[0];
            var name = $('.name-template').val();
            var avatar = "";
            var cate = $('#IpCate').val();
            var body = $(this).find('.layoutBody').html();
            var params = {
                Id: 0,
                Name: name,
                Avatar: avatar,
                MailBody: body,
                Category: cate
            }
            R.BuildingItem.SaveTemplate(file, params);
            return false;
        })

        $(document).off('mouseup').on('mouseup', function (e) {
            var container = $(".block");

            // if the target of the click isn't the container nor a descendant of the container
            if (!container.is(e.target) && container.has(e.target).length === 0) {
                var selected = $(this).find('.block-selected');
                selected.each(function (el) {
                    $(this).removeClass('block-selected');
                    $(this).find('.close-choose-block').remove();
                    $('.toolbox').find('.item-picking').css('display', 'block');
                    $('.toolbox').find('.item-picked-editor').css('display', 'none');
                })
            }
        });
       
    },
    ReadUrl: function (input, el) {
        var reder = new FileReader();
        formdata = new FormData()
        reder.onload = function (e) {
            el.find('#imgAvatar').attr('src', e.target.result);
        }
        reder.readAsDataURL(input)
    },
    BuildSelectCate: function () {
        var url = "/Template/GetAllcateTemp";
        var arr = [];
        $.post(url, null, function (repos) {
            repos.forEach(function (it) {
                arr.push(it)
            })
            $('input[name="IpCate"]').amsifySuggestags({
                type: 'amsify',
                suggestions: arr,
            });
        })


    },
    BuildCloning: function () {

        $('.itemBuilderClone').sortable({
            group: {
                name: 'shared',
                pull: 'clone', // To clone: set pull to 'clone'
                put: false,
            },
            animation: 150,
            sort: false
        });
    },
    BuildDrop: function () {
        $('.table-body-drop-zone').sortable({
            group: {
                name: 'shared',
            },
            item: ">*",
            animation: 150,
            //setData: function (transfer, dragEl) {
            //    transfer.setData('1', dragEl.textContent);

            //},
            onAdd: function (event) {
                var dr = $(event.item);
                var n_index = event.newIndex;
                var r = $(event.from).find('button').data('body');
                var configClass = $(event.from).data('cname');
                var x = $.parseHTML(r);
                var aff = x[0];
                $(aff).addClass(configClass);
                console.log(aff);
                var element_to_append = $('.table-body-drop-zone').find('.block')[n_index];
                element_to_append.before(aff);
                dr.remove();
                R.BuildingItem.RegisterEvent();
            },
        })
    },
    FillChildElement: function (el) {
        if (CKEDITOR.instances.editck) CKEDITOR.instances.editck.destroy();
        var ck = CKEDITOR.replace('editck');
        var htm = el.find('td').html();
        CKEDITOR.instances['editck'].setData(htm);
        CKEDITOR.instances['editck'].on('change', function () {
            var fl = sessionStorage.getItem("ck-change-flag");
            if (fl != null) {
                if (fl = "yes") {
                    var changed = CKEDITOR.instances['editck'].getData();

                    el.css('width', '600px');
                    var paragramp = el.find('p');
                    paragramp.each(function (element) {
                        $(this).css('font-size', '14px');
                    })

                    el.html('').html(changed);
                }
            }
            R.BuildingItem.RegisterEvent();
        });
        //var ck = CKEDITOR.replace('editck');
        R.BuildingItem.RegisterEvent();
    },
    SaveTemplate: function (file, data) {
        console.log(file);
        console.log(data);
        //upload truoc
        if (file != null) {
            var url_upload = "/Uploads/CKEasyImage";
            var formData = new FormData();
            formData.append('file', file);
            var r = "";
            $.ajax({
                url: url_upload,
                type: "POST",
                data: formData,
                contentType: false,
                processData: false,
                success: function (result) {
                    console.log(result);
                    var url = "/Template/SaveTemplate";
                    data.Avatar = result;
                    console.log(data);
                    $.post(url, data, function (response) {
                        R.Notify(null, response, 'success');
                    }).fail(function (response) {
                        R.Notify(null, response, 'error');
                    })
                },
            });
        }
        else {
            var url = "/Template/SaveTemplate";
            data.Avatar = "";
            console.log(data);
            $.post(url, data, function (response) {
                R.Notify(null, response, 'success');
            }).fail(function (response) {
                R.Notify(null, response, 'error');
            })
        }
        return false;
    }
}
R.BuildingItem.Init();