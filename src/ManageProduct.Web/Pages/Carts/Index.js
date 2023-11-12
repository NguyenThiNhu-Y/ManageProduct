var dataTable;
var l;
var getFilter;


$(function () {
    l = abp.localization.getResource('ManageProduct');
    

    getFilter = function () {
        return {
            filterText: $("input[name='Search']").val(),
        };
    };


    dataTable = $('#CartsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            //order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(manageProduct.carts.cart.getList),
            columnDefs: [
                {
                    title: l('IdProduct'),
                    data: "idProduct"
                },
                {
                    title: l('Name'),
                    data: "name"
                }

                
                
            ]
        })
    );


});

