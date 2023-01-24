document.getElementById("btnFileUploader").addEventListener("click", function () {
    document.getElementById("hiddenFileUploader").click();
})

document.getElementById("btnFileDownloader").addEventListener("click", function () {
    document.getElementById("hiddenFileDownloader").click();
})

document.getElementById("frmRegisterProject").addEventListener("submit", function (e) {
    e.preventDefault();


    var txtdescription = document.getElementById("txtdescription");
    txtdescription.style.backgroundColor = "white";

    if (txtdescription.value.toString().trim() == "") {
        txtdescription.style.backgroundColor = "var(--dark)";
        txtdescription.style.color = "white";
    } else {
        txtdescription.style.color = "black";
    }

    if (txtdescription.value.toString().trim() == "") {
        e.preventDefault();
    } else {

        //در این حالت فرم معتبر هست و به سمت سرور ارسال می شود

        //این پیغام باید پس از ارسال فرم به سمت سرور و موفقیت 
        //در ثبت درخواست نمایش داده شود
        //این دستور در اینجا فقط برای نمایش کارکرد نوشته شده است !!!
        document.getElementById("submitAlert").setAttribute("class", "showAlert");
    }


})
document.getElementById("btnCloseSubmitAlert").addEventListener("click", function () {
    document.getElementById("submitAlert").removeAttribute("class");
})