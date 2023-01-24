 document.getElementById("frmSearch").addEventListener("submit", function (e) {
     var inpsearch = document.getElementById("inpsearch");
     inpsearch.style.backgroundColor = "white";
     if (inpsearch.value.toString().trim() == "") {
         inpsearch.style.backgroundColor = "var(--dark)";
         inpsearch.style.color = "white";
     } else {
         inpsearch.style.color = "black";
     }

     if (inpsearch.value.toString().trim() == "") {
         e.preventDefault();
     }
 })