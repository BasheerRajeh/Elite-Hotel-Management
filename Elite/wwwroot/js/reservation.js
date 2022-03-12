/*
var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $("#tblData").DataTable({
        ajax: {
            url: "/reservation/GetAll",
            type: "Get",
            datatype: "json",
        },
        columns: [
            { data: "reservationNum", "width": "20%" },
            { data: "roomId.num", "width": "20%" },
            { data: "requestDate", "width": "20%" },
            { data: "requestStatusId", "width": "40%" },
            {
                data: "id",
                render: function (data) {
                    return `
                            <div  class="col-12 text-center">

                                <a id="btnInfo" onclick=Info("/Reservation/Accept/${data}") data-bs-toggle="modal"
                                            data-bs-target="#exampleModalScrollable" class='btn btn-sm btn-info text-dark' style='cursor: pointer; width: 80px;'>
                                    <i class="fas fa-info-circle"></i> Details
                                </a>

                                &nbsp;
                                <a id="details" onclick=Delete("/Reservation/Reject/${data}") class='btn btn-sm btn-danger text-white' style='cursor: pointer; width: 80px;'>
                                    <i class="fas fa-trash-alt"></i> Delete
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
*/
