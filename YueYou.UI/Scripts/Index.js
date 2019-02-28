//导航栏固定
//$(function () {
//    $(document).scroll(function () {
//        var top = $(document).scrollTop();
//        if (top > 500) {
//            $('.header').css({ "position": "fixed", "top": "0", "left": "0", "right": "0", "z-index": "1" });
//        } else {
//            $('.header').css({ "position": "relative" });
//        }
//    })
//})

//回到顶部按钮
$(function () {
    $('#to-top').hide();
    $(document).scroll(function () {
        var top = $(document).scrollTop();
        console.log(top);
        if (top > 550) {
            $('#to-top').show();
        } else {
            $('#to-top').hide();
        }
    })
    $("#to_top-images").click(function () {
        $("html, body").animate({ scrollTop: 0 }, 300)
    })
    $("#to_top-images").mouseover(function () {
        $("#to_top-images").css("opacity", "1");
    })
    $("#to_top-images").mouseout(function () {
        $("#to_top-images").css("opacity", "0.6");
    })
})

//导游展示效果
$(function () {
    $('.guide-section').hover(function () {
        $(this).children('p').stop().animate({ 'bottom': -10 }, 250);
    }, function () {
        $(this).children('p').stop().animate({ 'bottom': -54 }, 250);
    });
})
//
$(function server() {
    $('.server_list').hover(function () {
        $(this).children('.server_title').stop().animate({ 'opacity': 0 }, 250);
        $(this).children('.server_explain').stop().animate({ 'opacity': 1 }, 250);
    }, function () {
        $(this).children('.server_title').stop().animate({ 'opacity': 1 }, 250);
        $(this).children('.server_explain').stop().animate({ 'opacity': 0 }, 250);
    });
})