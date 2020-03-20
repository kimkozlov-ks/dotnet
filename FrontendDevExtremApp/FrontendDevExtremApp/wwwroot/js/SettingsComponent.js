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

const dataFromLocalStorage = localStorage.getItem('checkboxDevExtreme');
const checkboxesFromLocalStorage = JSON.parse(dataFromLocalStorage);

if (checkboxesFromLocalStorage != null) {
    for (let index in checkboxesFromLocalStorage) {
        checkboxes[index].isChecked = checkboxesFromLocalStorage[index].isChecked;
    }
}

for (let checkbox of checkboxes) {
    $(function () {
        $(checkbox.id).click(function () {
            checkbox.isChecked = ($(this).is(":checked") ? true : false);
            console.log(checkbox.id + ": " + checkbox.isChecked);
            
        });
    });
}

$(function () {
    $('#confirm-button').click(function () {
        $.ajax({
            url: 'Component/SetState',
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(checkboxes),
        });

        location.reload();
    });
});

for(let checkbox of checkboxes) {
    $(checkbox.id).prop('checked', checkbox.isChecked);
}

$.ajax({
    url: 'Component/SetState',
    type: 'POST',
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    data: JSON.stringify(checkboxes),
});

window.onbeforeunload = function (event) {
    window.localStorage.setItem('checkboxDevExtreme', JSON.stringify(checkboxes));

    let cookieStr = 'settings=';
    for (let checkbox of checkboxes) {
        cookieStr += checkbox.isChecked ? 1 : 0;
    }

    this.document.cookie = cookieStr;

    return null;
};