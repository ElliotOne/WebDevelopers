$(function () {
    /*======================================================
              Top Scroll Effects Start
  ======================================================*/
    $(window).scroll(function () {
        var GotoTop = $(window).scrollTop();
        var navbar = $(window).scrollTop();
        if (GotoTop >= 400) {
            $("#GoToTopArrow").addClass("GoToTopArrowSecond");
        } else {
            if ($("#GoToTopArrow").hasClass("GoToTopArrowSecond")) {
                $("#GoToTopArrow").removeClass("GoToTopArrowSecond");
            }
        }

        if (navbar >= 100) {
            $("#navigation").removeClass("navigationBefore");
            $("#navigation").addClass("navigationAfter");
        } else {
            $("#navigation").removeClass("navigationAfter");
            $("#navigation").addClass("navigationBefore");
        }


        var winScroll = document.body.scrollTop || document.documentElement.scrollTop;
        var height = document.documentElement.scrollHeight - document.documentElement.clientHeight;
        var scrolled = (winScroll / height) * 100;
        document.getElementById("innerBar").style.width = scrolled + "%";

    });


    /*======================================================
                Top Scroll Effects End
    ======================================================*/

    /*======================================================
                 Side Menu (Tablet And Mobile) Start
   ======================================================*/
    var show = false;
    $("#sideToggler").click(function () {
        if (show == false) {
            $("#side").addClass("sideShow");
            $("#sideContent").fadeIn(200);
            $("#sideClose").fadeIn(200);
            show = true;
        } else {
            $("#side").removeClass("sideShow");
            $("#sideContent").fadeOut(200);
            $("#sideClose").fadeOut(200);
            show = false;
        }
    })

    $("#sideClose").click(function () {
        $("#side").removeClass("sideShow");
        $("#sideContent").fadeOut(200);
        $("#sideClose").fadeOut(200);
        show = false;
    })

    //fill side menu data with desktop menu data dynamically - just change desktop navbar
    let menu = document.getElementById("navLinks");
    let sidemenu = document.getElementById("sideContent");

    for (let i = 0; i < menu.children.length; i++) {

        let listItem = document.createElement("li");
        let link = document.createElement("a");

        if (menu.children[i].getAttribute("class") == "drop") {

            listItem.setAttribute("class", "drop");
            link.setAttribute("href", `${menu.children[i].children[0].getAttribute("href")}`);
            link.textContent = `${menu.children[i].children[0].textContent}`;

            let divDrop = document.createElement("div");
            divDrop.setAttribute("class", "dropContent");

            for (let j = 0; j < menu.children[i].children[1].children.length; j++) {

                let dropLink = document.createElement("a");
                dropLink.setAttribute("href", `${menu.children[i].children[1].children[j].getAttribute("href")}`);
                dropLink.textContent = `${menu.children[i].children[1].children[j].textContent}`;
                divDrop.appendChild(dropLink);
            }
            listItem.appendChild(link);
            listItem.appendChild(divDrop);
            sidemenu.appendChild(listItem);

        } else {

            link.setAttribute("href", `${menu.children[i].children[0].getAttribute("href")}`);
            link.textContent = `${menu.children[i].children[0].textContent}`;
            listItem.append(link);
            sidemenu.appendChild(listItem);

        }
    }

    /*======================================================
                  Side Menu (Tablet And Mobile) End
    ======================================================*/

    /*======================================================
                 viewpoint Form Validation Start
 ======================================================*/

    document.getElementById("viewpointForm").addEventListener("submit", function (e) {

        var fullname = document.getElementById("fullname");
        var email = document.getElementById("email");
        var description = document.getElementById("description");


        fullname.style.backgroundColor = "white";
        fullname.setAttribute("placeholder", "نام");
        email.style.backgroundColor = "white";
        email.setAttribute("placeholder", "ایمیل");
        description.style.backgroundColor = "white";
        description.setAttribute("placeholder", "نظر شما");


        if (fullname.value.toString().trim() == "") {
            fullname.style.backgroundColor = "var(--dark)";
            fullname.style.color = "white";
            fullname.setAttribute("placeholder", "اسمت رو وارد نکردی !");
        } else {
            fullname.style.color = "black";
        }

        if (!ValidEmail(email.value.toString().trim())) {
            email.style.backgroundColor = "var(--dark)";
            email.style.color = "white";
            email.setAttribute("placeholder", "آدرس ایمیلت رو چک کن !");
        } else {
            email.style.color = "black";
        }

        function ValidEmail() {
            var myCk = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return myCk.test(email.value.toString().trim());
        }


        if (description.value.toString().trim() == "") {
            description.style.backgroundColor = "var(--dark)";
            description.style.color = "white";
            description.setAttribute("placeholder", "نظر یادت رفت !");
        } else {
            description.style.color = "black";
        }
        if (fullname.value.toString().trim() == "" || !ValidEmail(email.value.toString().trim()) || description.value.toString().trim() == "") {
            e.preventDefault();
        }
    })




    /*======================================================
                      viewpoint Form Validation End
    ======================================================*/


})