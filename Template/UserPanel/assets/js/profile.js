document.getElementById("btnImgUploader").addEventListener("click", function () {
    document.getElementById("hiddenImgUploader").click();
})

document.getElementById("btnSubmit").addEventListener("click", function (e) {
    document.getElementById("hiddenSubmit").click();
})




/*======================================================
                Validation Start
  ======================================================*/
document.getElementById("frmProfileEdit").addEventListener("submit", function (e) {

    var inpfirstname = document.getElementById("inpfirstname");
    var inplastname = document.getElementById("inplastname");
    var inpemail = document.getElementById("inpemail");
    var inpphonenumber = document.getElementById("inpphonenumber");
    var inpusername = document.getElementById("inpusername");
    var inppassword = document.getElementById("inppassword");
    var inppasswordConfirm = document.getElementById("inppasswordConfirm");


    inpfirstname.style.backgroundColor = "white";
    inplastname.style.backgroundColor = "white";
    inpemail.style.backgroundColor = "white";
    inpphonenumber.style.backgroundColor = "white";
    inpusername.style.backgroundColor = "white";
    inppassword.style.backgroundColor = "white";
    inppasswordConfirm.style.backgroundColor = "white";


    if (inpfirstname.value.toString().trim() == "") {
        inpfirstname.style.backgroundColor = "var(--dark)";
        inpfirstname.style.color = "white";
        inpfirstname.setAttribute("placeholder", "نام را وارد کنید");
    } else {
        inpfirstname.style.color = "black";
    }

    if (inplastname.value.toString().trim() == "") {
        inplastname.style.backgroundColor = "var(--dark)";
        inplastname.style.color = "white";
        inplastname.setAttribute("placeholder", "نام خانوادگی را وارد کنید");
    } else {
        inplastname.style.color = "black";
    }

    if (!ValidEmail(inpemail.value.toString().trim())) {
        inpemail.style.backgroundColor = "var(--dark)";
        inpemail.style.color = "white";
        inpemail.setAttribute("placeholder", "آدرس ایمیل را به درستی وارد کنید");
    } else {
        inpemail.style.color = "black";
    }

    function ValidEmail() {
        var myCk = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return myCk.test(inpemail.value);
    }


    if (inpphonenumber.value.toString().trim() == "") {
        inpphonenumber.style.backgroundColor = "var(--dark)";
        inpphonenumber.style.color = "white";
        inpphonenumber.setAttribute("placeholder", "شماره تلفن را وارد کنید");
    } else {
        inpphonenumber.style.color = "black";
    }

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
        inppasswordConfirm.setAttribute("placeholder", "تکرار رمز عبور را وارد کنید");
    } else {
        inppasswordConfirm.style.color = "black";
    }


    if (inppassword.value.toString().trim() != inppasswordConfirm.value.toString().trim()) {
        inppasswordConfirm.style.backgroundColor = "var(--dark)";
        inppasswordConfirm.style.color = "white";
        inppasswordConfirm.setAttribute("placeholder", "تکرار رمز عبور با رمز عبور مطابقت ندارد");
    }





    if (inpfirstname.value.toString().trim() == "" || inplastname.value.toString().trim() == "" ||
        !ValidEmail(inpemail.value.toString().trim()) || inpphonenumber.value.toString().trim() == "" ||
        inpusername.value.toString().trim() == "" || inppassword.value.toString().trim() == "" ||
        inppasswordConfirm.value.toString().trim() == "" || inppassword.value.toString().trim() != inppasswordConfirm.value.toString().trim()) {
        e.preventDefault();
    }
})
/*======================================================
         Validation End
======================================================*/





// وقتی مقدار تکست باکس برابر
// "حساب کاربری من را پاک کن"
//یاشد باید فرم ارسال شود
//اما جاوا اسکریپت این تساوی را تشخیص نمیدهد 
// :(
//من که نفهمیدم چرا ولی شاید تو فهمیدی
document.getElementById("frmDeleteAccount").addEventListener("submit", function (e) {


    var inpDeleteConfirm = document.getElementById("inpDeleteConfirm");
    inpDeleteConfirm.style.backgroundColor = "white";

    if (inpDeleteConfirm.value.toString().trim() == "" || inpDeleteConfirm.value.toString().trim() !== "حساب کاربری من را پاک کن") {
        inpDeleteConfirm.style.backgroundColor = "var(--dark)";
        inpDeleteConfirm.style.color = "white";
        inpDeleteConfirm.setAttribute("placeholder", "عبارت را به درستی وارد کنید");
    } else {
        inpDeleteConfirm.style.color = "black";
    }

    if (inpfirstname.value.toString().trim() == "" || inpDeleteConfirm.value.toString().trim() !== "حساب کاربری من را پاک کن") {
        e.preventDefault();
    }


})