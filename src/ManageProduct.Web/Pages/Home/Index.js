var dataTable;
var l;
$(function () {
    l = abp.localization.getResource('ManageProduct');


    


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
    //$("span[id='dec'").click(function () {
    //    var quanlity = document.getElementById("Quanlity").value;
    //    var id = document.getElementById("Id").value;
        
    //    manageProduct.carts.cart.updateQuanlity(id, quanlity);
    //});
    var proQty = $('.pro-qty-custorm');
    proQty.on('click', '.qtybtn', function () {
        var $button = $(this);
        var oldValue = $button.parent().find('input').val();
        if ($button.hasClass('inc')) {
            var newVal = parseFloat(oldValue) + 1;
        } else {
            // Don't allow decrementing below zero
            if (oldValue > 0) {
                var newVal = parseFloat(oldValue) - 1;
            } else {
                newVal = 0;
            }
        }
        $button.parent().find('input').val(newVal);

        var id = document.getElementById("Id").value;
        manageProduct.carts.cart.updateQuanlity(id, newVal);
    });
})