document.getElementById("frmSignUp").addEventListener("submit", function (e) {

    var inpusername = document.getElementById("inpusername");
    var inppassword = document.getElementById("inppassword");
    var inppasswordConfirm = document.getElementById("inppasswordConfirm");
    var chkAgree = document.getElementById("chkAgree");

    inpusername.style.backgroundColor = "white";
    inppassword.style.backgroundColor = "white";
    inppasswordConfirm.style.backgroundColor = "white";


    if (inpusername.value.toString().trim() == "") {
        inpusername.style.backgroundColor = "var(--dark)";
        inpusername.style.color = "white";
        inpusername.setAttribute("placeholder", "نام کاربری را وارد کنید");
    } else {
        inpusername.style.color = "black";
    }

    if (inppassword.value.toString().trim() == "") {
        inppassword.style.backgroundColor = "var(--dark)";
        inppassword.style.color = "white";
        inppassword.setAttribute("placeholder", "رمز عبور را وارد کنید");
    } else {
        inppassword.style.color = "black";
    }


    if (inppasswordConfirm.value.toString().trim() == "") {
        inppasswordConfirm.style.backgroundColor = "var(--dark)";
        inppasswordConfirm.style.color = "white";
        inppasswordConfirm.setAttribute("placeholder", "رمز عبور را دوباره وارد کنید");
    } else {
        inppasswordConfirm.style.color = "black";
    }

    if(inppassword.value.toString().trim() !== inppasswordConfirm.value.toString().trim()){
        inppasswordConfirm.style.backgroundColor = "var(--dark)";
        inppasswordConfirm.style.color = "white";
        inppasswordConfirm.value = "";
        inppasswordConfirm.setAttribute("placeholder", "تکرار رمز عبور با رمز عبور مطابقت ندارد");
    }

    if(!chkAgree.checked){
        alert("Agree to this form to continue!!! \n Implement this alert message with bootstrap alert next time");
    }
    

    if (inpusername.value.toString().trim() == "" || inppassword.value.toString().trim() == "" || inppasswordConfirm.value.toString().trim() == "" || inppassword.value.toString().trim() !== inppasswordConfirm.value.toString().trim()) {
        e.preventDefault();
    }


})