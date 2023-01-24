$(function () {
  /*======================================================
              Typing Effect Start
  ======================================================*/

  $(".animatedText").typed({
    strings: ["<strong class='animatedTextColor1'> توسعه دهندگان</strong> <strong class='animatedTextColor2'> وب </strong>", "<strong class='animatedTextColor1'> پروژه های خود را </strong> <strong class='animatedTextColor3'>  به ما بسپارید!</strong>"],
    typespeed: 0,
    loop: true
  });




  /*======================================================
              Typing Effect End
  ======================================================*/
  $('#topSlider').slick({
    infinite: true,
    rtl: true,
    slidesToShow: 1,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 10000,
    arrows: false
  });


  /*======================================================
                Team Slider Start
  ======================================================*/

  $('#teamSlider').slick({
    infinite: true,
    rtl: true,
    slidesToShow: 3,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 10000,
    arrows: false,
    dots: true,
    responsive: [{
      breakpoint: 1024,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 2,
        infinite: true,
        dots: true
      }
    },
    {
      breakpoint: 800,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1
      }
    },
    {
      breakpoint: 600,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1
      }
    }
    ]
  });


  /*======================================================
                 Team Slider End
   ======================================================*/


  /*======================================================
                overview Slider Start
  ======================================================*/

  $('#overviewSlider').slick({
    infinite: true,
    slidesToShow: 1,
    slidesToScroll: 1,
    autoplay: true,
    vertical: true,
    autoplaySpeed: 10000,
    arrows: false,
    dots: true
  });

  /*======================================================
                 overview Slider End
   ======================================================*/

  /*======================================================
                comments Slider Start
  ======================================================*/

  $('#commentsSlider').slick({
    infinite: true,
    slidesToShow: 2,
    slidesToScroll: 2,
    autoplay: true,
    rtl: true,
    autoplaySpeed: 1000,
    arrows: false,
    dots: true,
    responsive: [{
      breakpoint: 1024,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 2,
        infinite: true,
        dots: true
      }
    },
    {
      breakpoint: 800,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1
      }
    },
    {
      breakpoint: 600,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1
      }
    }
    ]
  });

  /*======================================================
                 comments Slider End
   ======================================================*/

  /*======================================================
                 Counter Start
   ======================================================*/

  let SpanViews = document.getElementById("CounterViews");
  let SpanFinishedProjects = document.getElementById("CounterFinishedProjects");
  let SpanActiveTime = document.getElementById("CounterActiveTime");
  let SpanPosts = document.getElementById("CounterPosts");
  let TotalViews = 321,
    TotalProjects = 25,
    TotalActiveTime = 2,
    TotalPosts = 107;
  let StartViews = 0,
    StartProjects = 0,
    StartActiveTime = 0,
    StartPosts = 0;
  let speed = 0.5;

  let AlreadyCounted = false;

  window.onscroll = myScroll;

  function myScroll() {
    if (window.pageYOffset >= 3750) {
      if (!AlreadyCounted) {
        ViewsCounter();
        ProjectsCounter();
        ActiveTimeCounter();
        PostsCounter();
        AlreadyCounted = true;
      }
    }
  }

  function ViewsCounter() {
    go();
    setInterval(function () {
      go();
    }, speed);

    function go() {
      if (StartViews == TotalViews) {
        return false;
      }
      SpanViews.innerHTML = StartViews.toFixed(0);
      StartViews += 0.125;
    }
  }

  function ProjectsCounter() {
    go();
    setInterval(function () {
      go();
    }, speed);

    function go() {
      if (StartProjects == TotalProjects) {
        return false;
      }
      SpanFinishedProjects.innerHTML = StartProjects.toFixed(0);
      StartProjects += 0.125;
    }
  }

  function ActiveTimeCounter() {
    go();
    setInterval(function () {
      go();
    }, speed);

    function go() {
      if (StartActiveTime == TotalActiveTime) {
        return false;
      }
      SpanActiveTime.innerHTML = StartActiveTime.toFixed(0);
      StartActiveTime += 0.125;
    }
  }

  function PostsCounter() {
    go();
    setInterval(function () {
      go();
    }, speed);

    function go() {
      if (StartPosts == TotalPosts) {
        return false;
      }
      SpanPosts.innerHTML = StartPosts.toFixed(0);
      StartPosts += 0.125;
    }
  }




  /*======================================================
                  Counter End
  ======================================================*/
})