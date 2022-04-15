var categroryAppService;
var dataTable;
var l;
var getFilter;


$(function () {
    l = abp.localization.getResource('ManageProduct');
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Products/CreateModal',
    });
    var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Products/EditModal',
    });
    var detailModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Products/DetailModal',
    });

    getFilter = function () {
        return {
            filterText: $("input[name='Search']").val(),
        };
    };


    dataTable = $('#ProductsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(manageProduct.products.product.getList, getFilter),
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
                    title: l('CategoryParent'),
                    data: "categoryName",

                },
                {
                    title: l('Price'),
                    data: "price",

                },
                {
                    title: l('Image'),
                    data: { image: "image", id: "id" },
                    render: function (data) {
                        var img = `<img src="/ImageProducts/${data.image}" name="${data.id}" width="100px" height="100px" onerror="this.onerror=null;this.src='/ImageProducts/imageDefault.jpg'"/>`;
                        return img;
                    }
                },

                
                //{
                //    title: l('Status'),
                //    data: { status: "status", id: "id" },
                //    render: function (data) {

                //        var check = '';
                //        if (data.status == 1)
                //            check = "checked";
                //        var str = '<label class="switch">' +
                //            `<input type = "checkbox" id="${data.id}" ${check} onclick="ChangeStatus(this.id,${data.status})">` +
                //            '<span class="slider round"></span>' +
                //            '</label >';
                //        return str;

                //    }
                //},
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Detail'),
                                    action: function (data) {
                                        dataTable.ajax.reload();
                                        window.location = "https://localhost:44344/Products/DetailModal?Id=" + data.record.id;
                                        //detailModal.open({ id: data.record.id });                                      


                                        //location.reload();
                                    }
                                },
                                {
                                    text: l('Edit'),
                                    action: function (data) {
                                        //editModal.open({ id: data.record.id });
                                        window.location = "https://localhost:44344/Products/EditModal?Id=" + data.record.id;
                                        //dataTable.ajax.reload();
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    confirmMessage: function (data) {
                                        return l('Delete', data.record.name);
                                    },
                                    action: function (data) {
                                        manageProduct.products.product
                                            .delete(data.record.id)
                                            .then(function (data) {
                                                if (data) {
                                                    abp.notify.info(l('SuccessfullyDeleted'));
                                                    dataTable.ajax.reload();
                                                }

                                                else {
                                                    abp.message.error(l("NotifyDeleteAuthor"));
                                                }
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

    $('#NewProductButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });


    $("input[name='Search'").keyup(function () {
        dataTable.ajax.reload();
        console.log(getFilter);
    });

    function ChangeStatus(id, status) {
        debugger;
        if ($('#' + id).is(':checked')) {
            $("#" + id).prop("checked", false);
        }
        else {
            $("#" + id).prop("checked", true);
        }
        dataTable.ajax.reload();

        var mess = l('BlockTheCategory');
        if (status == 0) {
            mess = l('UnblockTheCategory');
        }

        abp.message.confirm(mess, l('Notify'))
            .then(function (confirmed) {

                if (confirmed) {
                    manageProduct.Products.category.changStatus(data.record.id);
                    abp.message.success(l('YourChangesHaveBeenSuccessfullySaved'), l('Congratulations'));
                    dataTable.ajax.reload();
                }


            });
    };


});

