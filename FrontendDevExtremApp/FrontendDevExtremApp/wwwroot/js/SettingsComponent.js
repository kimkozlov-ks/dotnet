'use strict'

class Checkbox {
    constructor(id, checked) {
        this.id = id;
        this.checked = checked;
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
        checkboxes[index].checked = checkboxesFromLocalStorage[index].checked;
    }
}

for (let checkbox of checkboxes) {
    $(function () {
        $(checkbox.id).click(function () {
            checkbox.checked = ($(this).is(":checked") ? true : false);
            console.log(checkbox.id + ": " + checkbox.checked);
        });
    });
}

for (let checkbox of checkboxes) {
    $(checkbox.id).prop('checked', checkbox.checked);
}

window.onbeforeunload = function (event) {
    window.localStorage.setItem('checkboxDevExtreme', JSON.stringify(checkboxes));

    return null;
};