$(function () {

    let table = document.getElementById("projectsTable");
    let selctedRowColor = "rgb(255, 0, 64)";

    document.getElementById("projectsTable").addEventListener("click", function (e) {
        //Get the selected row to apply delete or edit operation
        if (e.srcElement.tagName == "TD") {
            let srcElement = e.srcElement;
            let parent = srcElement.parentElement;
            if (parent.style.backgroundColor == selctedRowColor) {
                parent.style.backgroundColor = "transparent";
            } else {
                parent.style.backgroundColor = selctedRowColor;
            };
        }
    });



    //================== Open Edit Modal ================
    let isSelected;
    document.getElementById("btnEdit").addEventListener("click", function (e) {
        e.preventDefault();
        let rows = table.children[1];
        for (i = 0; i < rows.children.length; i++) {
            if (rows.children[i].style.backgroundColor == selctedRowColor) {
                isSelected = true;
                $("#modalEditProject").modal("show");
                document.getElementById("edit_firstName").value = rows.children[i].children[2].innerHTML;
                document.getElementById("edit_lastName").value = rows.children[i].children[3].innerHTML;
                document.getElementById("edit_email").value = rows.children[i].children[5].innerHTML;
                document.getElementById("edit_phoneNumber").value = rows.children[i].children[4].innerHTML;
                document.getElementById("edit_ProjectType").value = rows.children[i].children[1].innerHTML;
                document.getElementById("edit_description").value = rows.children[i].children[6].innerHTML;
            }
        }

        if (isSelected == false || isSelected == null) {
            alert(" یک پروژه را برای ویرایش اطلاعات انتخاب کنید.");
        }
    })


    //================== Edit Modal Buttons ================
    document.getElementById("edit_btnConfirm").addEventListener("click", function (e) {
        e.preventDefault();
        let accepetChanges = confirm("آیا از ذخیره تغییرات مطمئن هستید؟");
        if (accepetChanges == true) {



            //=================================== php ===================================


            //Save changes to the current row in the database


            //=================================== php ===================================

        }
    })

    document.getElementById("edit_btnCancel").addEventListener("click", function (e) {
        $("modalEditProject").modal("hide");
    })


    //================== Open Delete Modal ================
    document.getElementById("btnDelete").addEventListener("click", function (e) {
        e.preventDefault();
        let rows = table.children[1];
        let deletingItemsTable = document.getElementById("deletingItemsTable").children[1];
        deletingItemsTable.innerHTML = "";
        let deletingItemsCounter = 0;
        for (let i = 0; i < rows.children.length; i++) {
            if (rows.children[i].style.backgroundColor == selctedRowColor) {
                deletingItemsCounter++;
                let newRow = document.createElement("tr");
                newRow.innerHTML = `
                <td>${rows.children[i].children[0].innerHTML}</td>
                <td>${rows.children[i].children[1].innerHTML}</td>
                <td>${rows.children[i].children[2].innerHTML} ${rows.children[i].children[3].innerHTML}</td>
                <td>${rows.children[i].children[4].innerHTML}</td>
                <td>${rows.children[i].children[7].innerHTML}</td>
                <td>${rows.children[i].children[8].innerHTML}</td>
            `
                deletingItemsTable.appendChild(newRow);
            }
        }
        document.getElementById("deletingItemsCount").innerHTML = deletingItemsCounter;
    })





    document.getElementById("btnDeleteConfirm").addEventListener("click", function (e) {
        let deletingItemsTable = document.getElementById("deletingItemsTable").children[1];
        for (let i = 0; i < deletingItemsTable.children.length; i++) {


            //=================================== php ===================================


            //This is the index(id) of the selected item , get it with php and delete its query from database

            //let Index = deletingItemsTable.children[i].children[0].textContent;


            //=================================== php ===================================



        }


        $("#modalDeleteProject").modal("hide");
    })
})