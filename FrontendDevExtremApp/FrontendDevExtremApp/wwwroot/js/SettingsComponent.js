'use strict'

class Checkbox {
    constructor(id, checked) {
        this.id = id;
        this.isChecked = checked;
    }
}

let checkboxes = new Array();
checkboxes.push(new Checkbox("#checkboxPhone", false));
checkboxes.push(new Checkbox("#checkboxGender", false));
checkboxes.push(new Checkbox("#checkboxCity", false));
checkboxes.push(new Checkbox("#checkboxStreet", false));
checkboxes.push(new Checkbox("#checkboxEmail", false));

let radioButtonsGender = new Array();
radioButtonsGender.push(new Checkbox("#radio-gender-any", true));
radioButtonsGender.push(new Checkbox("#radio-gender-male", false));
radioButtonsGender.push(new Checkbox("#radio-gender-female", false));


for (let checkbox of checkboxes) {
    $(function () {
        $(checkbox.id).click(function () {
            checkbox.isChecked = ($(this).is(":checked") ? true : false);

            if (checkbox.id == "#checkboxGender") {
                if (checkbox.isChecked) {
                    $("#gender-radio-container").removeClass("d-none")

                } else {
                    $("#gender-radio-container").addClass("d-none");
                }
            }
        });
    });
}

for (let radiobutton of radioButtonsGender) {
    $("#gender-radio-container").on('change', function () {

        const selectedIndex = $('input[name=genderradio]:checked', "#gender-radio-container").val();
        console.log(selectedIndex);
        for (let index in radioButtonsGender) {
            if (index === selectedIndex)
            {
                radioButtonsGender[index].isChecked = true;
            } else {
                radioButtonsGender[index].isChecked = false;
            };
        }
    });
}

$(function () {
    $('#confirm-button').click(function () {
        location.reload();
    });
});

for(let checkbox of checkboxes) {
    $(checkbox.id).prop('checked', checkbox.isChecked);
}

function getCookie(name) {
    let matches = document.cookie.match(new RegExp(
        "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
}

if (getCookie("settings") == undefined) {
    for (let checkbox of checkboxes) {
        checkbox.isChecked = false;
    }

    for (let radiobutton of radioButtonsGender) {
        radiobutton.isChecked = false;
    }
} else {
    let cookie = getCookie("settings");

    console.log(cookie);
    for (let index in checkboxes) {
        if (cookie[index] == '0') {
            checkboxes[index].isChecked = false;
        }
        else {
            checkboxes[index].isChecked = true;
        }

        $(checkboxes[index].id).prop('checked', checkboxes[index].isChecked);
    }

    for (let index in radioButtonsGender) {
        if (cookie[index + 5] == '0') {
            radioButtonsGender[index].isChecked = false;
        }
        else {
            radioButtonsGender[index].isChecked = true;
        }

        $(radioButtonsGender[index].id).prop('checked', radioButtonsGender[index].isChecked);
    }
}

window.onbeforeunload = function (event) {
    let cookieStr = 'settings=';
    for (let checkbox of checkboxes) {
        if (checkbox.isChecked) {     
            cookieStr += checkbox.isChecked ? checkbox.id.replace('#checkbox', '') : '';
            cookieStr += '_';
        }
    }

    cookieStr = cookieStr.substring(0, cookieStr.length - 1);

    const index = $('input[name=genderradio]:checked', "#gender-radio-container").val();
    if (index != 0) {
        cookieStr += '&gender=' + radioButtonsGender[1].id.replace('#radio-gender-', '');
    }
    
    this.document.cookie = cookieStr + ' ;';

    return null;
};