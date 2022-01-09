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

                                <div id = popup>

                                </div>

                                <a href="/Category/Upsert/${data}" class='btn btn-sm btn-warning text-dark' style='cursor: pointer; width: 80px;'>
                                    <i class="far fa-edit"></i> Edit
                                </a>

                                &nbsp;

                                <a onclick=Info("/Category/Details/${data}") data-bs-toggle="modal"
                                            data-bs-target="#exampleModalScrollable" class='btn btn-sm btn-info text-dark' style='cursor: pointer; width: 80px;'>
                                    <i class="far fa-info-circle" text-dark></i> Details
                                </a>

                                &nbsp;
                                <a onclick=Delete("/Category/Delete/${data}&") class='btn btn-sm btn-danger text-white' style='cursor: pointer; width: 80px;'>
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
                        }).showToast();

                        dataTable.ajax.reload();
                    } else {
                        //toastr.error(data.message);
                        Toastify({
                            text: "faild delete",
                            duration: 3000,
                            background: "#DD6B55",
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
            document.getElementById("popup").innerHTML = `
            <div class="modal fade" id="exampleModalScrollable" tabindex="-1" role="dialog"
                aria-labelledby="exampleModalScrollableTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-scrollable" role="document">
                    <img src="${data.data.imageUrl}?cache=none" class="card-img-top img-fluid"
                                    alt="singleminded">

                    <div class="modal-content">
                        <div class="card">
                            <div class="card-content">

                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">

                                                <div class="form-group row align-items-center">
                                                    <div class="col-lg-4 col-3">
                                                        <label class="col-form-label" for="Name">Category Name</label>
                                                    </div>
                                                    <div class="col-lg-8 col-9">
                                                        <input value="${data.data.name}" class="form-control" disabled>
                                                    </div>
                                                </div>

                                                <div class="form-group row align-items-center">
                                                    <div class="col-lg-4 col-3">
                                                        <label class="col-form-label" for="MaxCap">Max Capacity</label>
                                                    </div>
                                                    <div class="col-lg-8 col-9">
                                                        <input value="${data.data.maxCap}" class="form-control" disabled>
                                                    </div>
                                                </div>

                                                <div class="form-group row align-items-center">
                                                    <div class="col-lg-4 col-3">
                                                        <label class="col-form-label" for="PricePerNight">Price Per Night</label>
                                                    </div>
                                                    <div class="col-lg-8 col-9">
                                                        <input value="${data.data.pricePerNight}" class="form-control" disabled>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                     <div class="modal-footer">
                        <button type="button" class="btn btn-light-secondary" data-bs-dismiss="modal">
                            <i class="bx bx-x d-block d-sm-none"></i>
                            <span class="d-none d-sm-block">Close</span>
                        </button>
                    </div>

                    </div>

                </div>
            </div>

`;
        },
    });

    //     $.get(url, function (data, status) {
    //         document.getElementById("popup").innerHTML = `
    //                                         <div class="modal fade" id="exampleModalScrollable" tabindex="-1" role="dialog"
    //                                             aria-labelledby="exampleModalScrollableTitle" aria-hidden="true">
    //                                             <div class="modal-dialog modal-dialog-scrollable" role="document">
    //                                                 <div class="modal-content">

    //                                                     <div class="card">
    //                                                         <div class="card-content">
    //                                                             <img src="${data.data.imageUrl}" class="card-img-top img-fluid"
    //                                                                 alt="singleminded">
    //                                                             <div class="card-body">
    //                                                                 <div class="row">
    //                                                                     <div class="col-md-12">
    //                                                                         <div class="form-group">

    //                                                                             <div class="form-group row align-items-center">
    //                                                                                 <div class="col-lg-4 col-3">
    //                                                                                     <label class="col-form-label" for="Name">Category Name</label>
    //                                                                                 </div>
    //                                                                                 <div class="col-lg-8 col-9">
    //                                                                                     <input value="${data.data.name}" class="form-control" disabeld>
    //                                                                                 </div>
    //                                                                             </div>

    //                                                                             <div class="form-group row align-items-center">
    //                                                                                 <div class="col-lg-4 col-3">
    //                                                                                     <label class="col-form-label" for="MaxCap">Max Capacity</label>
    //                                                                                 </div>
    //                                                                                 <div class="col-lg-8 col-9">
    //                                                                                     <input value="${data.data.maxCap}" class="form-control" disabeld>
    //                                                                                 </div>
    //                                                                             </div>

    //                                                                             <div class="form-group row align-items-center">
    //                                                                                 <div class="col-lg-4 col-3">
    //                                                                                     <label class="col-form-label" for="PricePerNight">Price Per Night</label>
    //                                                                                 </div>
    //                                                                                 <div class="col-lg-8 col-9">
    //                                                                                     <input value="${data.data.pricePerNight}" class="form-control" disabeld>
    //                                                                                 </div>
    //                                                                             </div>

    //                                                                         </div>
    //                                                                     </div>
    //                                                                 </div>

    //                                                             </div>
    //                                                         </div>
    //                                                     </div>

    //                                                 </div>

    //                                                  <div class="modal-footer">
    //                                                     <button type="button" class="btn btn-light-secondary" data-bs-dismiss="modal">
    //                                                         <i class="bx bx-x d-block d-sm-none"></i>
    //                                                         <span class="d-none d-sm-block">Close</span>
    //                                                     </button>
    //                                                     <button type="button" class="btn btn-primary ml-1" data-bs-dismiss="modal">
    //                                                         <i class="bx bx-check d-block d-sm-none"></i>
    //                                                         <span class="d-none d-sm-block">Accept</span>
    //                                                     </button>
    //                                                 </div>

    //                                             </div>
    //                                         </div>

    // `;
    //     });
}