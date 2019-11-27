$(document).ready(function () {
    $("#EmployeeLeave_StartDate").datepicker({
        dateFormat: "d-M-yy",
        changeMonth: true,
        changeYear: true,
        minDate: -7,
        //beforeShowDay: holidaysAndWeekendDates(),
        onSelect: function (selected) {
            $(this).change();
            var StartDatedt = new Date($("#EmployeeLeave_StartDate").val());
            StartDatedt.setDate(StartDatedt.getDate());
            $("#EmployeeLeave_EndDate").datepicker("option", "minDate", StartDatedt);
        }
    });

    $("#EmployeeLeave_EndDate").datepicker({
        dateFormat: "d-M-yy",
        changeMonth: true,
        changeYear: true,
        minDate: -7,
        //beforeShowDay: $.datepicker.noWeekends,
        //beforeShowDay: holidaysAndWeekendDates(),
        onSelect: function (selected) {
            $(this).change();
            var EndDatedt = new Date($("#EmployeeLeave_EndDate").val());
            EndDatedt.setDate(EndDatedt.getDate());
            $("#EmployeeLeave_StartDate").datepicker("option", "maxDate", EndDatedt);
        }
    });

    getHandoverEmployeeList();
});


function getHandoverEmployeeList() {
    var empId = $("#EmployeeLeave_EmployeeId").val();
    $.ajax
        ({
            url: '/Leave/GetHandoverEmployeeList',
            type: 'POST',
            data: { empId: empId },

            success: function (result) {
                $("#EmployeeLeave_HandoverTo").html("");
                $.each($.parseJSON(result), function (i, employee) {
                    $("#EmployeeLeave_HandoverTo").append($('<option></option>').val(employee.Value).html(employee.Text))
                })
            },
            error: function () {
                alert("Something went wrong..")
            },
        });
}

function holidaysAndWeekendDates() {
    debugger;
    var data = $.datepicker.noWeekends;
    return data;
    //debugger;
    //$.ajax
    //    ({
    //        url: '/Leave/HolidaysAndWeekendDates',
    //        type: 'GET',
    //        success: function (result) {
    //            console.log(result);
    //        },
    //        error: function () {
    //            alert("Something went wrong..")
    //        },
    //    });
}

