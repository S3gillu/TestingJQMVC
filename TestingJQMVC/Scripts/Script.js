$(document).ready(function () {
    $('#TableId').DataTable
    ({
        "columnDefs": [
          {
              "width": "5%",
              "targets": [0]
          },
          {
              "className": "text-center custom-middle-align",
              "targets": [0, 1, 2, 3, 4, 5, 6]
          }, ],
        "language":
        {
            "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
        },
        "processing": true,
        "serverSide": true,
        "ajax":
      {
          "url": "/Plugin/GetData",
          "type": "POST",
          "dataType": "JSON"
      },
        "columns": [
          {
              "data": "Id"
          },
          {
              "data": "Name"
          },
          {
              "data": "Email"
          },
          {
              "data": "Phone"
          },
          {
              "data": "Stream"
          },
          {
              "data": "PermanentAddress"
          },
          {
              "data": "FathersName"
          },
          {
              "data": "Action"
          }]

    });
})

var PupilData = db.ViewModels.OrderBy(a => a.Id).ToList();

var dataitems = [];
$.each(PupilData, function (i, item) {
    var data = [];
    data.push(item.Id);
    data.push(item.Name);
    data.push(item.Email);

    dataitems.push(data);
});

if (errorMsg != "") {
    errorMsg = "The following errors were found: \n" + errorMsg + "\n\n Please enter the required information and try again.";
    alert(errorMsg);
}
else {
    //JQuery ajax call
    $.ajax({
        method: "POST",
        url: "/Table/GetData",
        dataType: "json",
        data: {
            Id: $("#Id").val(),
            Name: $("#Name").val(),
            Email: $("#Email").val(),
            Phone: $("#Phone").val(),
            Stream: $("#Stream").val(),
            PermanentAddress: $("#PermanentAddress").val(),
           FathersName: $("#FathersName").val()
        },
        success: function (result) {
            switch (result.code) {
                case "OK":
                    $('#Customer-Info').DataTable().ajax.reload(); //refresh the datatable to reflect the changes                         
                    $('#addEditCustomer').modal('hide'); //hide the popup window
                    alert("Customer saved correctly.");
                    break;
                case "Not Valid":
                    alert("Server received invalid information.");
                    break;
                default:
                    alert("Unknown server issue." + result.code);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("AJAX Save customer error" + thrownError);
        }
    })
}

$(document).ready(function () {
    $('#Jdatatable').DataTable({
        data: dataitems,
        columns: [
            { title: "Id" },
            { title: "Name" }
        ]
    });
});






