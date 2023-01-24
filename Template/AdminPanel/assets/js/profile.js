document.getElementById("btnDeletePic").addEventListener("click", function () {

    //============================ Php =======================

})


document.getElementById("btnEditPic").addEventListener("click", function () {
    document.getElementById("imgUploader").click();

    //============================ Php =======================


    //Get the uploaded image and then add it to database and aslo DOM of html page 
    //inside the box that shows the avater picture!

    //============================ Php =======================
})




//Use to send form
let userName = document.getElementById("userName"),
    password = document.getElementById("password"),
    passwordConfirm = document.getElementById("passwordConfirm"),
    email = document.getElementById("email");
description = document.getElementById("description")
document.getElementById("btnEditInfo").addEventListener("click", function (e) {

    userName.setAttribute("class", "form-control");
    password.setAttribute("class", "form-control");
    passwordConfirm.setAttribute("class", "form-control");
    email.setAttribute("class", "form-control");
    description.setAttribute("class", "form-control");

    if (userName.value.toString().trim() == "") {
        userName.setAttribute("class", "form-control validationError");
    } else if (password.value.toString().trim() == "") {
        password.setAttribute("class", "form-control validationError");
    } else if (passwordConfirm.value.toString().trim() == "") {
        passwordConfirm.setAttribute("class", "form-control validationError");
    } else if (password.value.toString().trim() != passwordConfirm.value.toString().trim()) {
        passwordConfirm.setAttribute("class", "form-control validationError");
    } else if (!validateEmail(email.value.toString().trim())) {
        email.setAttribute("class", "form-control validationError");
    } else if (description.value.toString().trim() == "") {
        description.setAttribute("class", "form-control validationError");
    }

    if (userName.value.toString().trim() == "" || password.value.toString().trim() == "" || (password.value.toString().trim() != passwordConfirm.value.toString().trim()) || description.value.toString().trim() == "") {
        e.preventDefault();
    } else {



        //============================ Php =======================
        
        // Send form

        //============================ Php =======================

    }


    function validateEmail(email) {
        var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(email);
    }
})