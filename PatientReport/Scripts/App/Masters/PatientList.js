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
                        $("#tablePatient thead").empty();
                        $("#tablePatient tbody").empty();
                        addColumns($('#ddlPatientType option:selected').val());
                        if ($('#ddlPatientType option:selected').val() == 'IPD') {
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
                                column += '<td><a style="color:blue;" href="/Masters/PatientDetail/' + patientRow.PCode.replace(':', '~').replace('/', '_') + '">Detail</a></td>';
                                var row = '<tr>' + column + '</tr>';
                                $('#tablePatient tbody').append(row);
                            });
                        }
                        else if ($('#ddlPatientType option:selected').val() == 'OPD') {
                            $.each(data, function (index, patientRow) {
                                var column = '<td>' + (index + 1) + '</td>';
                                column += '<td>' + patientRow.PCode + '</td>';
                                column += '<td>' + patientRow.DoR + '</td>';
                                column += '<td>' + patientRow.Title + patientRow.Firstname + ' ' + patientRow.Middlename + ' ' + patientRow.Lastname + '</td>';
                                column += '<td>' + patientRow.Sex + '</td>';
                                column += '<td>' + patientRow.Age + '</td>';
                                column += '<td>' + patientRow.timeoftran + '</td>';
                                column += '<td><a style="color:blue;" href="/Masters/PatientDetail/' + patientRow.PCode.replace(':', '~').replace('/', '_') + '">Detail</a></td>';
                                var row = '<tr>' + column + '</tr>';
                                $('#tablePatient tbody').append(row);
                            });
                        }
                        $('#tablePatient').removeClass('hidden');
                    }
                    else {
                        $('#tablePatient').addClass('hidden');
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
    $('#tablePatient thead').append(columns);
}