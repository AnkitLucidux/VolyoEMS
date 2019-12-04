$(document).ready(function () {
    $("#EmployeeLeave_StartDate").datepicker({
        dateFormat: "d-M-yy",
        changeMonth: true,
        changeYear: true,
        minDate: -7,
        beforeShowDay: excludeHolidaysAndWeekendDates,
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
        beforeShowDay: excludeHolidaysAndWeekendDates,
        onSelect: function (selected) {
            $(this).change();
            var EndDatedt = new Date($("#EmployeeLeave_EndDate").val());
            EndDatedt.setDate(EndDatedt.getDate());
            $("#EmployeeLeave_StartDate").datepicker("option", "maxDate", EndDatedt);
        }
    });

    var empId = $("#EmployeeLeave_EmployeeId").val();
    if (empId != null) {
        getHandoverEmployeeList();
    }
});


function getHandoverEmployeeList() {
    var empId = $("#EmployeeLeave_EmployeeId").val();
    $.ajax
        ({
            url: '/Admin/Leave/GetHandoverEmployeeList',
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

function excludeHolidaysAndWeekendDates(date) {
    //console.log(date);
    //var holidayList = [];

    //$.ajax
    //    ({
    //        url: '/Leave/GetHolidayList',
    //        type: 'GET',
    //        success: function (result) {
    //            var data = $.parseJSON(result);
    //            holidayList = data;
    //            for (i = 0; i < data.length; i++) {
    //                //console.log(data[i]);
    //                holidayList.push(data[i]);
    //            }
    //            //console.log(date);
    //            //var m = date.getMonth(), d = date.getDate(), y = date.getFullYear();
    //            ////console.log(d + '-' + (m + 1) + '-' + y);
    //            //for (i = 0; i < data.length; i++) {
    //            //    //console.log($.inArray(d + '-' + (m + 1) + '-' + y, data));
    //            //    if ($.inArray(d + '-' + (m + 1) + '-' + y, data) != -1 || new Date() > date) {
    //            //        //console.log('bad:  ' + (m+1) + '-' + d + '-' + y + ' / ' + disabledDays[i]);
    //            //        //console.log("In array");
    //            //        return [false];
    //            //    }
    //            //}
    //        },
    //        error: function () {
    //            alert("Something went wrong..")
    //        },
    //    });

    //setTimeout(function () {
    //    console.log(holidayList);
    //}, 2000);

    var day = date.getDay();
    var month = date.getMonth();
    var year = date.getFullYear();
    var currDate = date.getDate();
    if (day == 0 || day == 6) {
        return [false]
    }
    else {
        return [true]
    }
}

