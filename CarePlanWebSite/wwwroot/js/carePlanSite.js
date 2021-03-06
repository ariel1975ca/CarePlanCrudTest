
//***********************************************************//
//
// Table functions
//
//***********************************************************//        

// Finds and update the care plan table row
// finds the matching row, add a new row with updated data and then delete the old one
function carePlanUpdateTableRow(carePlan) {
    // Find care plan in table
    var row = $("#carePlanTable button[data-id='" +
        carePlan.id + "']").parents("tr")[0];

    // Add changed care plan to table
    $(row).after(carePlanBuildTableRow(carePlan));

    // Remove original care plan
    $(row).remove();
}

// Add the care plan to the table
function carePlanAddTableRow(carePlan) {
    // Check if <tbody> tag exists, add one if not
    if ($("#carePlanTable tbody").length == 0) {
        $("#carePlanTable").append("<tbody></tbody>");
    }
    // Append row to <table>
    $("#carePlanTable tbody").append(
        carePlanBuildTableRow(carePlan));
}

// build the table row with the care plan data
function carePlanBuildTableRow(carePlan) {
    var ret =
        "<tr>" +
        "<td>" + carePlan.title + "</td>" +
        "<td>" + carePlan.patient_name + "</td>" +
        "<td>" + carePlan.user_name + "</td>" +
        "<td>" + carePlan.actual_start_date + "</td>" +
        "<td>" + carePlan.target_date + "</td>" +
        "<td>" + carePlan.reason + "</td>" +
        "<td>" + carePlan.action + "</td>" +
        "<td>" + carePlan.completed + "</td>";

    if (carePlan.end_date) {
        ret += "<td>" + carePlan.end_date + "</td>";
    }
    else {
        ret += "<td></td>";
    }

    if (carePlan.outcome) {
        ret += "<td>" + carePlan.outcome + "</td>";
    }
    else {
        ret += "<td></td>";
    }

    ret += "<td>" + "<button type='button' title='Edit the care plan' " + "onclick='getCarePlanClick(this);' " +
        "class='btn btn-success btn-sm' " + "data-id='" + carePlan.id + "'>" +
        "<i class='bi bi-pencil' />" + "</button>" + "</td>";

    ret += "</tr>";

    return ret;
}

//***********************************************************//
//
// Form functions
//
//***********************************************************//

var cpValidator;

$(document).ready(function () {
    cpValidator = initializeCarePlanFormValidations();
});

// Add a custom method for the End Date "Not before Actual Start Date" validation
jQuery.validator.addMethod("greaterThanEDate",
    function (value, element, params) {

        if (!/Invalid|NaN/.test(new Date(value))) {
            return new Date(value) >= new Date($(params).val());
        }
    }, 'Must be greater or equal than {0}.');

// Set the validations rules and messages of the Care Plan form
function initializeCarePlanFormValidations() {
    return $("#cpForm").validate({
        rules: {
            cpTitle: {
                required: true,
                maxlength: 450
            },
            cpPatientName: {
                required: true,
                maxlength: 450
            },
            cpUserName: {
                required: true,
                maxlength: 450
            },
            cpActualStartDate: "required",
            cpTargetDate: "required",
            cpReason: {
                required: true,
                maxlength: 1000
            },
            cpAction: {
                required: true,
                maxlength: 1000
            },
            cpEndDate: {
                required: "#cpCompleted:checked",
                greaterThanEDate: "#cpActualStartDate"
            },
            cpOutcome: {
                required: "#cpCompleted:checked",
                maxlength: 1000
            }
        },
        messages: {
            cpTitle: {
                required: "Please enter the title",
                maxlength: "The title cannot have more than 450 characters"
            },
            cpPatientName: {
                required: "Please enter the patient name",
                maxlength: "The patient name cannot have more than 450 characters"
            },
            cpUserName: {
                required: "Please enter the user name",
                maxlength: "The user name cannot have more than 450 characters"
            },
            cpActualStartDate: "Please enter the actual start date",
            cpTargetDate: "Please enter the target date",
            cpReason: {
                required: "Please enter the reason",
                maxlength: "The reason cannot have more than 1000 characters"
            },
            cpAction: {
                required: "Please enter the action",
                maxlength: "The action cannot have more than 1000 characters"
            },
            cpEndDate: {
                required: "Please enter the end date",
                greaterThanEDate: "The end date cannot be before the actual start date"
            },
            cpOutcome: {
                required: "Please enter the outcome",
                maxlength: 1000
            }
        },
        errorElement: "em",
        errorPlacement: function (error, element) {
            // Add the `help-block` class to the error element
            error.addClass("help-block");

            if (element.prop("type") === "checkbox") {
                error.insertAfter(element.parent("label"));
            } else {
                error.insertAfter(element);
            }
        },
        highlight: function (element, errorClass, validClass) {
            $(element).parents(".field").addClass("has-error").removeClass("has-success");
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).parents(".field").addClass("has-success").removeClass("has-error");
        }
    });
}

// handle the toggle visibility of completed care plans
$("#cpCompletedFields").hide();
$("#cpCompleted").click(function () {
    if ($(this).is(":checked")) {
        $("#cpCompletedFields").show();
    } else {
        $("#cpCompletedFields").hide();
    }
});

// Apply the validations rules and return true if form validates. false otherwise.
function isFormCarePlanDataValid() {
    if (cpValidator) return cpValidator.form();
    else return false;
}

// clears the Care Plan Form data
function clearCarePlanForm() {
    $("#cpId").val(0);

    $("#cpTitle").val("");
    $("#cpPatientName").val("");
    $("#cpUserName").val("");
    $("#cpActualStartDate").val("");
    $("#cpTargetDate").val("");
    $("#cpReason").val("");
    $("#cpAction").val("");
    $("#cpCompleted").prop("checked", false);
    $("#cpEndDate").val("");
    $("#cpOutcome").val("");

    // hide completed extra fields
    $("#cpCompletedFields").hide();

    // Change back to Add Button Text
    $("#cpUpdateBtn").text("Add");

    // reset the form validations
    if (cpValidator) cpValidator.resetForm();
}

// sets the forms fields with the care plan data
function setCarePlanToForm(carePlan) {
    $("#cpId").val(carePlan.id);

    $("#cpTitle").val(carePlan.title);
    $("#cpPatientName").val(carePlan.patient_name);
    $("#cpUserName").val(carePlan.user_name);
    $("#cpActualStartDate").val(carePlan.actual_start_date);
    $("#cpTargetDate").val(carePlan.target_date);
    $("#cpReason").val(carePlan.reason);
    $("#cpAction").val(carePlan.action);
    if (carePlan.completed) {
        $("#cpCompleted").prop("checked", true);
        $("#cpEndDate").val(carePlan.end_date);
        $("#cpOutcome").val(carePlan.outcome);

        $("#cpCompletedFields").show();
    }
    else {
        $("#cpCompleted").prop("checked", false);
        $("#cpEndDate").val("");
        $("#cpOutcome").val("");

        $("#cpCompletedFields").hide();
    }

    // reset the form validations
    if (cpValidator) cpValidator.resetForm();
}

// sets the carePlan objects data from form fields
function setCarePlanFromForm(carePlan) {
    carePlan.id = $("#cpId").val();

    carePlan.title = $("#cpTitle").val();
    carePlan.patient_name = $("#cpPatientName").val();
    carePlan.user_name = $("#cpUserName").val();
    carePlan.actual_start_date = $("#cpActualStartDate").val();
    carePlan.target_date = $("#cpTargetDate").val();
    carePlan.reason = $("#cpReason").val();
    carePlan.action = $("#cpAction").val();
    carePlan.completed = $("#cpCompleted").is(':checked');

    if (carePlan.completed) {
        var endDate = $("#cpEndDate").val();
        if (endDate) {
            carePlan.end_date = $("#cpEndDate").val();
        }
        else {
            carePlan.end_date = null;
        }

        carePlan.outcome = $("#cpOutcome").val();
    }
    else {
        carePlan.end_date = null;
        carePlan.outcome = null;
    }
}

//***********************************************************//
//
// API Calls
//
//***********************************************************//

// API Care Plan Base url
var carePlanApiBaseUrl = "http://localhost:33926/careplans/";

// Call Web API to get the care plans
function getCarePlans() {
    $.ajax({
        url: carePlanApiBaseUrl,
        type: 'GET',
        dataType: 'json',
        success: function (carePlans) {
            getCarePlansSuccess(carePlans);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

// Call Web API to get the specified care plan
function getCarePlan(id) {
    $.ajax({
        url: carePlanApiBaseUrl + id,
        type: 'GET',
        dataType: 'json',
        success: function (carePlan) {
            getCarePlanSuccess(carePlan);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

// Call Web API to add the specified care plan
function addCarePlan(carePlan) {
    $.ajax({
        url: carePlanApiBaseUrl,
        type: 'POST',
        contentType:
            "application/json;charset=utf-8",
        data: JSON.stringify(carePlan),
        success: function (carePlan) {
            addCarePlanSuccess(carePlan);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

// Call Web API to update the specified care plan
function updateCarePlan(carePlan) {
    $.ajax({
        url: carePlanApiBaseUrl + carePlan.id,
        type: 'PUT',
        contentType:
            "application/json;charset=utf-8",
        data: JSON.stringify(carePlan),
        success: function (carePlan) {
            updateCarePlanSuccess(carePlan);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

// Handles the API call errors with an alert dialog
function handleException(request, message, error) {
    var msg = "";
    msg += "Code: " + request.status + "\n";
    msg += "Text: " + request.statusText + "\n";
    if (request.responseJSON && request.responseJSON.error) {
        msg += "Message: " + request.responseJSON.error.message + "\n";
    }
    alert(msg);
}

// Add the care plans we got from API to the table
function getCarePlansSuccess(carePlans) {
    // Iterate over the collection of data
    $.each(carePlans, function (index, carePlan) {
        // Add a row to the care plans table
        carePlanAddTableRow(carePlan);
    });
}

// Add the care plan we got from API to the table
function getCarePlanSuccess(carePlan) {
    // sets the forms fields with the care plan data
    setCarePlanToForm(carePlan);

    // Change Update Button Text
    $("#cpUpdateBtn").text("Update");
}

// Add the care plan to the table
function addCarePlanSuccess(carePlan) {
    // Add a row to the care plans table
    carePlanAddTableRow(carePlan);

    // clear the forms fields data
    clearCarePlanForm();
}

// Update the care plan table row
function updateCarePlanSuccess(carePlan) {

    //*** for this test the table is manipulated to update the specified row.
    // another approach is to refresh the whole table from the API ***

    // Update the care plans table row
    carePlanUpdateTableRow(carePlan);

    // clear the forms fields data
    clearCarePlanForm();
}