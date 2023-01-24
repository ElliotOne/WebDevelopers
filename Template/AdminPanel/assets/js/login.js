let userName = document.getElementById("username");
let password = document.getElementById("password");
let isNameValid, isPasswordValid;

document.getElementById("btnLogin").addEventListener("click", function (e) {

    if (userName.value.toString().trim() == "") {
        userName.setAttribute("class", "form-control validationError");
    }

    if (password.value.toString().trim() == "") {
        password.setAttribute("class", "form-control validationError");
    }

    if (userName.value.toString().trim() == "" || password.value.toString().trim() == "") {
        e.preventDefault();
    } else {

        // =================================== php ===================================

        //now the validation is completed , search database for the current username
        //and password , if it is ok so login to the panel , if not print some error

        // =================================== php ===================================

    }


})


userName.addEventListener("blur", function () {
    if (userName.classList.contains("validationError")) {
        if (userName.value.toString().trim() == "") {
            userName.setAttribute("class", "form-control validationError");
        } else {
            userName.setAttribute("class", "form-control");
        }
    } else {
        if (userName.value.toString().trim() == "") {
            userName.setAttribute("class", "form-control validationError");
        } else {
            userName.setAttribute("class", "form-control");
        }
    }
});
password.addEventListener("blur", function () {
    if (password.classList.contains("validationError")) {
        if (password.value.toString().trim() == "") {
            password.setAttribute("class", "form-control validationError");
        } else {
            password.setAttribute("class", "form-control");
        }
    } else {
        if (password.value.toString().trim() == "") {
            password.setAttribute("class", "form-control validationError");
        } else {
            password.setAttribute("class", "form-control");
        }
    }
});