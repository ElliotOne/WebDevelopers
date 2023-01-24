let IsValid = false;
document.getElementById("frmSearch").addEventListener("submit",function(e){
    var search =  document.getElementById("search");
    
    if(!IsValid){
        search.style.color = "white";
    }

    search.style.backgroundColor = "white";
    search.setAttribute("placeholder","جست و جو ...");

   if(search.value.toString().trim() == ""){
    search.style.backgroundColor = "var(--dark)";
    search.setAttribute("placeholder","عبارتی برای جست و جو وارد کنید");
    IsValid = false;
   }
   if (search.value.toString().trim() == "") {
    e.preventDefault();
  }
})