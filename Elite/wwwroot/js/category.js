var dataTable;

$(document).ready(
    function () {
        loadDataTable();
    }
);

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/category/GetAll",
            "type": "Get",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "30%" },
            { "data": "maxCap", "width": "20%" },
            { "data": "pricePerNight", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Category/Upsert/${data}" class='btn btn-warning text-dark' style='cursor: pointer; width: 100px;'>
                                    <i class="far fa-edit"></i> Edit
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Category/Delete/${data}") class='btn btn-danger text-white' style='cursor: pointer; width: 100px;'>
                                    <i class="far fa-trash-alt"></i> Delete
                                </a>
                            </div>

                            `;
                }, "width": "30%"
            },
        ],
        "language": {
            "emptyTable": "No records found."
        },
        "width": "100%"
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#DD6B55',
        confirmButtonText: 'Yes, delete it!',
        closeOnconfirm: true
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: 'Delete',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    })
}