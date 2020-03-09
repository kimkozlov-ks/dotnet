'use strict'

class Checkbox {
    constructor(id, checked) {
        this.id = id;
        this.checked = checked;
    }
}

let checkboxPhone = new Checkbox("#checkboxPhone", false);
let checkboxGender = new Checkbox("#checkboxGender", false);

const data = localStorage.getItem('checkboxDevExtreme');
console.log(data);

const checkboxesFromLocalStorage = JSON.parse(data);

if (checkboxesFromLocalStorage != null) {

    checkboxPhone.checked = checkboxesFromLocalStorage[0].checked;
    checkboxGender.checked = checkboxesFromLocalStorage[1].checked;
}

$(checkboxPhone.id).prop('checked', checkboxPhone.checked);
$(checkboxGender.id).prop('checked', checkboxGender.checked);

$(function () {
    $(checkboxPhone.id).click(function () {
        checkboxPhone.checked = ($(this).is(":checked") ? true : false);
        console.log(checkboxPhone.id + ": " + checkboxPhone.checked);
    });
});

$(function () {
    $(checkboxGender.id).click(function () {
        checkboxGender.checked = ($(this).is(":checked") ? true : false);
        console.log(checkboxGender.id + ": " + checkboxGender.checked);
    });
});
  

window.onbeforeunload = function (event) {
    console.log(JSON.stringify([checkboxPhone, checkboxGender]));
    window.localStorage.setItem('checkboxDevExtreme', JSON.stringify([checkboxPhone, checkboxGender]));

    return null;
};