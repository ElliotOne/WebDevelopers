document.getElementById("frmSignIn").addEventListener("submit",function(e){
    var inpUsername = document.getElementById("inpUsername");
    var inpPassword = document.getElementById("inpPassword");

    inpUsername.style.backgroundColor = "white";
    inpUsername.setAttribute("placeholder", "نام کابری");
    inpPassword.style.backgroundColor = "white";
    inpPassword.setAttribute("placeholder", "رمز عبور");
    
    
    if (inpUsername.value.toString().trim() == "") {
        inpUsername.style.backgroundColor = "var(--dark)";
        inpUsername.style.color = "white";
        inpUsername.setAttribute("placeholder", "نام کاربری را وارد کنید");
      } else {
        inpUsername.style.color = "black";
      }
      
      if (inpPassword.value.toString().trim() == "") {
        inpPassword.style.backgroundColor = "var(--dark)";
        inpPassword.style.color = "white";
        inpPassword.setAttribute("placeholder", "رمز عبور را وارد کنید");
      } else {
        inpPassword.style.color = "black";
      }
      if (inpUsername.value.toString().trim() == "" || inpPassword.value.toString().trim() == "") {
        e.preventDefault();
      }

})