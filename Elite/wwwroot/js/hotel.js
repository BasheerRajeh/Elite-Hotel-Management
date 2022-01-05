var dataTable;

$(document).ready(
    function () {
        loadDataTable();
    }
);

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/hotel/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "40%" },
            { "data": "city", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/hotel/Upsert/${data}" class='btn btn-warning text-dark' style='cursor: pointer; width: 100px;'>
                                    <i class="far fa-edit"></i> Edit
                                </a>
                                &nbsp;
                                <a onclick=Delete("/hotel/Delete/${data}") class='btn btn-danger text-white' style='cursor: pointer; width: 100px;'>
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