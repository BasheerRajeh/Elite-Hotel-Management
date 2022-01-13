var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $("#tblData").DataTable({
        ajax: {
            url: "/category/GetAll",
            type: "Get",
            datatype: "json",
        },
        columns: [
            { data: "name", "width": "30%" },
            { data: "maxCap", "width": "20%" },
            { data: "pricePerNight", "width": "20%" },
            {
                data: "id",
                render: function (data) {
                    return `
                            <div  class="col-12 text-center">

                                <a href="/Category/Upsert/${data}" class='btn btn-sm btn-warning text-dark' style='cursor: pointer; width: 80px;'>
                                    <i class="far fa-edit"></i> Edit
                                </a>

                                &nbsp;

                                <a id="btnInfo" onclick=Info("/Category/Details/${data}") data-bs-toggle="modal"
                                            data-bs-target="#exampleModalScrollable" class='btn btn-sm btn-info text-dark' style='cursor: pointer; width: 80px;'>
                                    <i class="fas fa-info-circle"></i> Details
                                </a>

                                &nbsp;
                                <a id="details" onclick=Delete("/Category/Delete/${data}+"fds"") class='btn btn-sm btn-danger text-white' style='cursor: pointer; width: 80px;'>
                                    <i class="far fa-trash-alt"></i> Delete
                                </a>
                            </div>

                            `;
                }, "width": "30%",
            },
        ],
        language: {
            emptyTable: "No records found.",
        },
        "width": "100%"
    });
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnconfirm: true,
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "Delete",
                url: url,
                success: function (data) {
                    if (data.success) {
                        Toastify({
                            text: "Deleted sucsessfully",
                            duration: 3000,
                            background: '#4BB543'
                        }).showToast();

                        dataTable.ajax.reload();
                    } else {
                        //toastr.error(data.message);
                        Toastify({
                            text: "faild delete",
                            duration: 3000,
                            background: "#B33A3A",
                        }).showToast();
                    }
                },
            });
        }
    });
}

function Info(url) {
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        cache: false,
        success: function (data) {
            $("#image_popup").attr("src", data.data.imageUrl);

            $('#name_popup').val(data.data.name);

            $('#maxcap_popup').val(data.data.maxCap);

            $('#price_popup').val(data.data.pricePerNight);
        }
    });
}