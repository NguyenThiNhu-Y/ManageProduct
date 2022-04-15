var dataTable;
var l;
var getFilter;


$(function () {
    l = abp.localization.getResource('ManageProduct');
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Banners/CreateModal',
    });
    var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Banners/EditModal',
    });
    var detailModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Banners/DetailModal',
    });
    var deleteModal = new abp.ModalManager(abp.appPath + 'Banners/EditModal');
    var listBook = new abp.ModalManager(abp.appPath + 'Banners/ListBook');

    getFilter = function () {
        return {
            filterText: $("input[name='Search']").val(),
        };
    };


    dataTable = $('#BannersTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(manageProduct.banners.banner.getList, getFilter),
            columnDefs: [
                {
                    title: l('STT'),
                    data: "stt"
                },
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Image'),
                    data: { image: "image", id: "id" },
                    render: function (data) {
                        var img = `<img src="/ImageBanners/${data.image}" name="${data.id}" width="200px" height="100px" onerror="this.onerror=null;this.src='/ImageBanners/imageDefault.jpg'"/>`;
                        return img;
                    }
                },
                {
                    title: l('SetBanner'),
                    data: { setBanner: "setBanner", id: "id" },
                    render: function (data) {

                        var check = '';
                        if (data.setBanner)
                            check = "checked";
                        var str = '<label class="switch">' +
                            `<input type = "checkbox" id="${data.id}" ${check} onclick="ChangeStatus(this.id)">` +
                            '<span class="slider round"></span>' +
                            '</label >';
                        return str;

                    }
                },
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Detail'),
                                    action: function (data) {
                                        dataTable.ajax.reload();
                                        window.location = "https://localhost:44344/Banners/DetailModal?Id=" + data.record.id;
                                        //detailModal.open({ id: data.record.id });                                      


                                        //location.reload();
                                    }
                                },
                                {
                                    text: l('Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    confirmMessage: function (data) {
                                        return l('Delete', data.record.name);
                                    },
                                    action: function (data) {
                                        manageProduct.banners.banner
                                            .delete(data.record.id)
                                            .then(function (data) {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                                //if (data) {
                                                    
                                                //}

                                                //else {
                                                //    abp.message.error(l("NotifyDeleteAuthor"));
                                                //}
                                            });
                                    }
                                }
                                
                            ]
                    }
                }
            ]
        })
    );



    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    editModal.onResult(function () {
        dataTable.ajax.reload();
    });
    $('#NewBannerButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });


    $("input[name='Search'").keyup(function () {
        dataTable.ajax.reload();
        console.log(getFilter);
    });

  
});

function ChangeStatus(id) {
    if ($('#' + id).is(':checked')) {
        $("#" + id).prop("checked", false);
    }
    else {
        $("#" + id).prop("checked", true);
    }
    dataTable.ajax.reload();

    var mess = l('BlockTheCategory');
    
    abp.message.confirm(mess, l('Notify'))
        .then(function (confirmed) {

            if (confirmed) {
                manageProduct.banners.banner.changAllSetBanner(id);
                abp.message.success(l('YourChangesHaveBeenSuccessfullySaved'), l('Congratulations'));
                dataTable.ajax.reload();
            }


        });
    dataTable.ajax.reload();
};