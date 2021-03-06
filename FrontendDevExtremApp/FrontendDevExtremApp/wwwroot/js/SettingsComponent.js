﻿'use strict'

class checkableControl {
    constructor(id, checked) {
        this.id = id;
        this.isChecked = checked;
    }
}

let cookie = document.cookie;

let checkboxes = new Array();
let radioButtonsGender = new Array();

if (cookie != undefined && cookie != null && cookie != "settings=") {

    cookie = cookie.substring(cookie.indexOf("settings"));

    if (cookie.includes(';')) {
        cookie = cookie.substring(0, cookie.indexOf(';'));
    }

    checkboxes.push(new checkableControl("#checkboxPhone", cookie.includes("Phone")));
    checkboxes.push(new checkableControl("#checkboxGender", cookie.includes("Gender")));
    checkboxes.push(new checkableControl("#checkboxCity", cookie.includes("City")));
    checkboxes.push(new checkableControl("#checkboxStreet", cookie.includes("Street")));
    checkboxes.push(new checkableControl("#checkboxEmail", cookie.includes("Email")));

    radioButtonsGender.push(new checkableControl("#radio-gender-any", !cookie.includes("male") && !cookie.includes("female")));
    radioButtonsGender.push(new checkableControl("#radio-gender-male", cookie.includes("male")));
    radioButtonsGender.push(new checkableControl("#radio-gender-female", cookie.includes("female")));

    if ($('#checkboxGender').prop('checked') === true) {
        $("#gender-radio-container").removeClass("d-none");
    }
}
else {
    checkboxes.push(new checkableControl("#checkboxPhone", false));
    checkboxes.push(new checkableControl("#checkboxGender", false));
    checkboxes.push(new checkableControl("#checkboxCity", false));
    checkboxes.push(new checkableControl("#checkboxStreet", false));
    checkboxes.push(new checkableControl("#checkboxEmail", false));

    radioButtonsGender.push(new checkableControl("#radio-gender-any", true));
    radioButtonsGender.push(new checkableControl("#radio-gender-male", false));
    radioButtonsGender.push(new checkableControl("#radio-gender-female", false));
}

for (let checkbox of checkboxes) {
    $(checkbox.id).prop('checked', checkbox.isChecked);

    $(function () {
        $(checkbox.id).click(function () {
            checkbox.isChecked = ($(this).is(":checked") ? true : false);
            if (checkbox.id == "#checkboxGender") {
                if (checkbox.isChecked) {
                    $("#gender-radio-container").removeClass("d-none");
                } else {
                    $("#radio-gender-any").prop("checked", true);
                    $("#radio-gender-male").prop("checked", false);
                    $("#radio-gender-female").prop("checked", false);
                    $("#gender-radio-container").addClass("d-none");
                }
            }
        });
    });
}

for (let raidobutton of radioButtonsGender) {
    $(raidobutton.id).prop('checked', raidobutton.isChecked);
}

$(function () {
    $('#confirm-button').click(function () {
        location.reload();
    });
});

window.onbeforeunload = function (event) {
    let cookieStr = 'settings=';
    let isSomethingChanged = false;
    for (let checkbox of checkboxes) {
        if (checkbox.isChecked) {     
            cookieStr += checkbox.isChecked ? checkbox.id.replace('#checkbox', '') : '';
            cookieStr += '_';
            isSomethingChanged = true;
        }
    }

    if(isSomethingChanged) {
        cookieStr = cookieStr.substring(0, cookieStr.length - 1);
    }

    const index = $('input[name=genderradio]:checked', "#gender-radio-container").val();

    if (index != 0) {
        cookieStr += '&gender=' + radioButtonsGender[index].id.replace('#radio-gender-', '');
    }
    
    this.document.cookie = cookieStr + ' ; expires=Tue, 1 Jan 2038 00:00:00 GMT;';

    return null;
};