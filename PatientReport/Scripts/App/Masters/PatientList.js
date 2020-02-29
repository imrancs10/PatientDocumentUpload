$(document).ready(function () {
    $('#btnSearch').click(function () {
        let PatientType = $('#ddlPatientType option:selected').val();

        if (PatientType !== '' && PatientType !== undefined) {
            $.ajax({
                dataType: 'json',
                type: 'POST',
                url: '/Masters/PatientList',
                data: '{patienttype: "' + PatientType + '" }',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.length > 0) {
                        $('#noRecordFound').addClass('hidden');
                        $("#tablePatient thead").empty();
                        $("#tablePatient tbody").empty();
                        addColumns($('#ddlPatientType option:selected').val());
                        if ($('#ddlPatientType option:selected').val() == 'IPD') {
                            $('#reportdetail').html('Patient Details - IPD List');
                            $.each(data, function (index, patientRow) {
                                var column = '<td>' + (index + 1) + '</td>';
                                column += '<td>' + patientRow.PCode + '</td>';
                                column += '<td>' + patientRow.DoR + '</td>';
                                column += '<td>' + patientRow.Title + patientRow.Firstname + ' ' + patientRow.Middlename + ' ' + patientRow.Lastname + '</td>';
                                column += '<td>' + patientRow.Sex + '</td>';
                                column += '<td>' + patientRow.ipno + '</td>';
                                column += '<td>' + patientRow.iage + '</td>';
                                column += '<td>' + patientRow.name + '</td>';
                                column += '<td>' + patientRow.bedno + '</td>';
                                column += '<td>' + patientRow.roomno + '</td>';
                                column += '<td>' + patientRow.admittime + '</td>';
                                column += '<td><a style="color:blue;" href="/Masters/PatientDetail?crNumber=' + patientRow.PCode.replace(':', '~').replace('/', '_') + '">Detail</a></td>';
                                var row = '<tr>' + column + '</tr>';
                                $('#tablePatient tbody').append(row);
                            });
                        }
                        else if ($('#ddlPatientType option:selected').val() == 'OPD') {
                            $('#reportdetail').html('Patient Details - OPD List');
                            $.each(data, function (index, patientRow) {
                                var column = '<td>' + (index + 1) + '</td>';
                                column += '<td>' + patientRow.PCode + '</td>';
                                column += '<td>' + patientRow.DoR + '</td>';
                                column += '<td>' + patientRow.Title + patientRow.Firstname + ' ' + patientRow.Middlename + ' ' + patientRow.Lastname + '</td>';
                                column += '<td>' + patientRow.Sex + '</td>';
                                column += '<td>' + patientRow.Age + '</td>';
                                column += '<td>' + patientRow.timeoftran + '</td>';
                                column += '<td><a style="color:blue;" href="/Masters/PatientDetail?crNumber=' + patientRow.PCode.replace(':', '~').replace('/', '_') + '">Detail</a></td>';
                                var row = '<tr>' + column + '</tr>';
                                $('#tablePatient tbody').append(row);
                            });
                        }
                        $('#tablePatient').removeClass('hidden');
                    }
                    else {
                        $('#tablePatient').addClass('hidden');
                        $('#noRecordFound').removeClass('hidden');
                    }
                },
                failure: function (response) {
                    alert(response);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });
        }
        else {
            utility.alert.setAlert(utility.alert.alertType.warning, 'Please Patient Type');
        }
    });

    $('#btnSearchPatientEmployee').click(function () {
        let PatientCRNumber = $('#crNumber').val().replace(':', '~').replace('/', '_');

        if (PatientCRNumber !== '' && PatientCRNumber !== undefined) {
            $.ajax({
                dataType: 'json',
                type: 'POST',
                url: '/Masters/PatientListBYCRNumber',
                data: '{crNumber: "' + PatientCRNumber + '" }',
                contentType: "application/json; charset=utf-8",
                success: function (patientRow) {
                    if (patientRow == "NoPatient") {
                        $('#tablePatient').addClass('hidden');
                        $('#noRecordFound').removeClass('hidden');
                    }
                    else if (patientRow != null && patientRow != undefined) {
                        $('#noRecordFound').addClass('hidden');
                        $("#tablePatient thead").empty();
                        $("#tablePatient tbody").empty();
                        addColumns();
                        var column = '<td>' + 1 + '</td>';
                        column += '<td>' + patientRow.Title + patientRow.Firstname + ' ' + patientRow.Middlename + ' ' + patientRow.Lastname + '</td>';
                        column += '<td>' + patientRow.Email + '</td>';
                        column += '<td>' + patientRow.Age + '</td>';
                        column += '<td>' + patientRow.Gender + '</td>';
                        column += '<td>' + patientRow.Address + '</td>';
                        column += '<td>' + patientRow.City + '</td>';
                        column += '<td>' + patientRow.Pincode + '</td>';
                        column += '<td>' + patientRow.Religion + '</td>';
                        column += '<td>' + patientRow.Registrationnumber + '</td>';
                        column += '<td>' + patientRow.FatherOrHusbandName + '</td>';
                        column += '<td>' + patientRow.MaritalStatus + '</td>';

                        column += '<td>' + patientRow.MaritalStatus + '</td>';
                        column += '<td>' + patientRow.AadharNo + '</td>';
                        column += '<td>' + patientRow.Pid + '</td>';
                        column += '<td><a style="color:blue;" href="/Masters/PatientDetail?crNumber=' + PatientCRNumber + '">Detail</a></td>';
                        var row = '<tr>' + column + '</tr>';
                        $('#tablePatient tbody').append(row);
                        $('#tablePatient').removeClass('hidden');
                    }
                },
                failure: function (response) {
                    alert(response);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });
        }
        else {
            utility.alert.setAlert(utility.alert.alertType.warning, 'Please Patient Type');
        }
    });
});

function addColumns(patientType) {
    var columns = '';
    if (patientType === "IPD") {
        columns = '<tr>' +
            '<th style="width: 10%">Sr. No.</th>' +
            '<th> PCode</th> ' +
            '<th> DoR</th> ' +
            '<th> Name</th> ' +
            '<th> Sex</th> ' +
            '<th> ipno</th> ' +
            '<th> iage</th> ' +
            '<th> department</th> ' +
            '<th> bedno</th> ' +
            '<th> roomno</th> ' +
            '<th> admittime</th> ' +
            '<th> Action</th> ' +
            '</tr>';
    }
    else if (patientType === "OPD") {
        columns = '<tr>' +
            '<th style="width: 10%">Sr. No.</th>' +
            '<th> PCode</th> ' +
            '<th> DoR</th> ' +
            '<th> Name</th> ' +
            '<th> Sex</th> ' +
            '<th> Age</th> ' +
            '<th> timeoftran</th> ' +
            '<th> Action</th> ' +
            '</tr>';
    }
    else {
        columns = '<tr>' +
            '<th style="width: 10%">Sr. No.</th>' +
            '<th> Name</th> ' +
            '<th> Email</th> ' +
            '<th> Age</th> ' +
            '<th> Gender</th> ' +
            '<th> Address</th> ' +
            '<th> City</th> ' +
            '<th> Pincode</th> ' +
            '<th> Religion</th> ' +
            '<th> Registrationnumber</th> ' +
            '<th> FatherOrHusbandName</th> ' +
            '<th> MaritalStatus</th> ' +
            '<th> MaritalStatus</th> ' +
            '<th> AadharNo</th> ' +
            '<th> Pid</th> ' +
            '<th> Action</th> ' +
            '</tr>';
    }
    $('#tablePatient thead').append(columns);
}