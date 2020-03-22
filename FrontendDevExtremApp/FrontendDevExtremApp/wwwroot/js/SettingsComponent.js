'use strict'

class Checkbox {
    constructor(id, checked) {
        this.id = id;
        this.isChecked = checked;
    }
}

let checkboxes = new Array();
checkboxes.push(new Checkbox("#checkboxPhone", true));
checkboxes.push(new Checkbox("#checkboxGender", true));
checkboxes.push(new Checkbox("#checkboxCity", true));
checkboxes.push(new Checkbox("#checkboxStreet", true));
checkboxes.push(new Checkbox("#checkboxEmail", true));


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
}

else {
    for (let index in checkboxes) {
        let cookie = getCookie("settings");

        if (cookie[index] == '0') {
            checkboxes[index].isChecked = false;
        }
        else {
            checkboxes[index].isChecked = true;
        }

        $(checkboxes[index].id).prop('checked', checkboxes[index].isChecked);
    }
}

window.onbeforeunload = function (event) {
    let cookieStr = 'settings=';
    for (let checkbox of checkboxes) {
        cookieStr += checkbox.isChecked ? 1 : 0;
    }

    this.document.cookie = cookieStr;

    return null;
};