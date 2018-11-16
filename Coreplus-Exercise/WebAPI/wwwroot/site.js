const uriAppointment = "api/appointment";
const uriAppointmentPractitionerById = "api/appointment/practitionerid";
const uriPractitioner = "api/practitioner";


$(document).ready(function () {

    hideTables();

    getPractitioners();
});

function getPractitioners() {
    $.ajax({
        type: "GET",
        url: uriPractitioner,
        cache: false,
        success: function (data) {
            $.each(data, function (key, item) {
                $('#practitioner_select').append('<option value="' + item.id + '">' + item.name + '</option>');
            });
        }
    });
}

function sendAppointmentForm() {

    //alert('send appointment form');

    const item = {
        ids: $("#practitioner_select").val(),
        startDate: $("#startDate").val(),
        endDate: $("#endDate").val()
    };

    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: uriAppointment,
        contentType: "application/json",
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (result) {

            const tBody = $("#appointmentDataTable > table > tbody");

            $(tBody).empty();

            $.each(result, function (key, item) {
                const tr = $("<tr></tr>")
                    //.append($("<td></td>").text(item.practitioner_id))
                    .append($("<td></td>").text(item.practitionerName))
                    .append($("<td></td>").text(item.id))
                    .append($("<td></td>").text(item.cost))
                    .append($("<td></td>").text(item.revenue))
                    .append($("<td></td>").text(item.groupbyitems))

                tr.on("click", function () {
                    getAllAppointmentsForPractitioner(item.practitioner_id);
                })

                tr.appendTo(tBody);
            });
        }
    });

    $('#appointmentDataTable').show();
}


function getAllAppointmentsForPractitioner(practitioner_id) {
    //alert('getAllAppointmentsForPractitioner');

    $.ajax({
        url: uriAppointmentPractitionerById + "/" + practitioner_id,
        type: "GET",
        success: function (data) {

            const tBody = $("#practitionerAppointmentDataTable > table > tbody");

            $(tBody).empty();

            $.each(data, function (key, item) {
                const tr = $("<tr></tr>")
                    .append($("<td></td>").text(item.id))
                    .append($("<td></td>").text(item.cost))
                    .append($("<td></td>").text(item.revenue))

                tr.on("click", function () {
                    getAppointmentDetail(item.id);
                })

                tr.appendTo(tBody);
            });
        }
    });

    $('#practitionerAppointmentDataTable').show();
    $('#appointmentDetailTable').hide();
}

function getAppointmentDetail(id) {
    $.ajax({
        url: uriAppointment + "/" + id,
        type: "GET",
        success: function (result) {

            const tBody = $("#appointmentDetailTable > table > tbody");

            $(tBody).empty();

            const tr = $("<tr></tr>")
                .append($("<td></td>").text(result.date))
                .append($("<td></td>").text(result.client_name))
                .append($("<td></td>").text(result.appointment_type))
                .append($("<td></td>").text(result.duration))
                .append($("<td></td>").text(result.revenue))
                .append($("<td></td>").text(result.cost))

            tr.appendTo(tBody);
        }
    });

    $('#appointmentDetailTable').show();
}

function hideTables() {
    $('#appointmentDataTable').hide();
    $('#practitionerAppointmentDataTable').hide();
    $('#appointmentDetailTable').hide();
}

$("#practitionerForm").submit(function (e) {

    //alert('submit clicked');

    //prevent Default functionality
    e.preventDefault();

    //hide all tables
    hideTables();

    sendAppointmentForm();
});