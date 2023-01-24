/*======================================================
                Validation Start
  ======================================================*/

//وقتی عنوان
//دیگر
//یعنی اخرین آپشن انتخاب میشود باید تکست باکس نوشتن عنوان ظاهر شود
//شماره 4 همان شماره آپشن مورد نظر است

function isTicketTitleSelected() {
    var selTicketTitle = document.getElementById("selTicketTitle");
    if (selTicketTitle.value == 4) {
        return false;
        //مقداری انتخاب نشده پس باید تکست باکس نشان داده شود
    } else {
        return true;
        //مقداری از داخل سلکت انتخاب شده است
    }
}


document.getElementById("selTicketTitle").addEventListener("change", function (e) {
    let divOtherTicketTitle = document.getElementById("divOtherTicketTitle");
    if (isTicketTitleSelected()) {
        divOtherTicketTitle.removeAttribute("style");
    } else {
        divOtherTicketTitle.setAttribute("style", "display:block !important");
    }
})

document.getElementById("frmSendTicket").addEventListener("submit", function (e) {

    var selTicketTitle = document.getElementById("selTicketTitle");
    var inpTicketTitle = document.getElementById("inpTicketTitle");
    var selProject = document.getElementById("selProject");
    var txtdescription = document.getElementById("txtdescription");

    selTicketTitle.style.backgroundColor = "white";
    inpTicketTitle.style.backgroundColor = "white";
    selProject.style.backgroundColor = "white";
    txtdescription.style.background = "white";

    let isTickTitleValid = false;

    if (isTicketTitleSelected()) {
        if (selTicketTitle.value == 0) {
            selTicketTitle.style.backgroundColor = "var(--dark)";
            selTicketTitle.style.color = "white";
            isTickTitleValid = false;
        } else {
            selTicketTitle.style.color = "black";
            isTickTitleValid = true;
        }
    } else {
        if (inpTicketTitle.value.toString().trim() == "") {
            inpTicketTitle.style.backgroundColor = "var(--dark)";
            inpTicketTitle.style.color = "white";
            isTickTitleValid = false;
        } else {
            inpTicketTitle.style.color = "black";
            isTickTitleValid = true;
        }
    }


    if (selProject.value == 0) {
        selProject.style.backgroundColor = "var(--dark)";
        selProject.style.color = "white";
    } else {
        selProject.style.color = "black";
    }

    if (txtdescription.value.toString().trim() == "") {
        txtdescription.style.backgroundColor = "var(--dark)";
        txtdescription.style.color = "white";
    } else {
        txtdescription.style.color = "black";
    }


    if (!isTickTitleValid || selProject.value == "" || txtdescription.value.toString().trim() == "") {
        e.preventDefault();
    }

})
/*======================================================
         Validation End
======================================================*/