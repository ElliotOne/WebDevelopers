  /*======================================================
        Register Project Form File UpLoad Start
  ======================================================*/
  document.getElementById("btnFileUploder").addEventListener("click", function (e) {
      e.preventDefault();
      document.getElementById("hiddenFileUploader").click();
  });
  /*======================================================
         Register Project Form File UpLoad End
   ======================================================*/

  /*======================================================
                Register Project Validation Start
  ======================================================*/
  document.getElementById("frmRegisterProject").addEventListener("submit", function (e) {
      var inpfirstname = document.getElementById("inpfirstname");
      var inplastname = document.getElementById("inplastname");
      var inpemail = document.getElementById("inpemail");
      var inpphonenumber = document.getElementById("inpphonenumber");
      var txtdescription = document.getElementById("txtdescription");

      inpfirstname.style.backgroundColor = "white";
      inplastname.style.backgroundColor = "white";
      inpemail.style.backgroundColor = "white";
      inpphonenumber.style.backgroundColor = "white";
      txtdescription.style.backgroundColor = "white";

      

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

      if (txtdescription.value.toString().trim() == "") {
          txtdescription.style.backgroundColor = "var(--dark)";
          txtdescription.style.color = "white";
          txtdescription.setAttribute("placeholder", "توضیحات را وارد کنید");
      } else {
          txtdescription.style.color = "black";
      }

      if (inpfirstname.value.toString().trim() == "" || inplastname.value.toString().trim() == "" ||  !ValidEmail(inpemail.value.toString().trim())||inpphonenumber.value.toString().trim() == "" || txtdescription.value.toString().trim() == "") {
          e.preventDefault();
      }
  })
  /*======================================================
            Register Project Validation End
  ======================================================*/