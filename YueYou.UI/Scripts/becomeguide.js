$(document).ready(function () {
    $('.video-box i').on('click', function () {
        $('.video_main').get(0).play();
        $(this).hide();
        $(this).siblings('img').hide();
    });
    $('.video_main').on('ended', function () {
        $('.video-box i').show();
        $(this).siblings('img').show();
    });
    $('.video_main').on('play', function () {
        $('.video-box i').hide();
        $(this).children('img').hide();
    });
})