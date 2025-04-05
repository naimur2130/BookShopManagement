var dataTable;
$(document).ready(function () { loadDataTable(); });
function loadDataTable() {
    dataTable = $('#datatbl').DataTable({
        "ajax": { url: '/BookShopAdmin/Product/GetAll', dataSrc: "data" },
        "columns": [
            { data: 'productName', "width": "13%" },
            { data: 'productISBN', "width": "8%" },
            { data: 'productAuthor', "width": "16%" },
            { data: 'price', "width": "5%" },
            { data: 'category.categoryName', "width": "13%" },
            {
                data: 'productId',
                "render": function (data) {
                    return `<div class="W-75 btn-group" role="group">
                    <a href="/BookShopAdmin/Product/UpsertProduct?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>
                     <a onClick=Delete('/BookShopAdmin/Product/DeleteIT/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
                },
                "width": "15%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    });
}