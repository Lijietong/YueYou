$(document).ready(function () {
    var time = new Date(), m = time.getMonth() + 1;
    var t = time.getFullYear() + "-" + m + "-" + time.getDate();
    //定制行程接送机点击效果
    //$('.car_radio label').toggle(function () {      
    //    $(this).addClass('current');
    //    $(this).find('input').val('1');
    //}, function () {
    //    $(this).removeClass('current');    
    //    $(this).find('input').val('0');
    //    }
    //);
    
    //定制行程人数点击效果
    $('.order-min').on('click', function () {
        var _num = $('#person-num').val() - 0;
        _num--;
        if (_num <= 0) {
            $(this).siblings('#person-num').val(0);
            _num = 1;
        }
        else {
            $(this).siblings('#person-num').val(_num);
        }
    });
    $('.order-add').on('click', function () {
        var _num = $('#person-num').val() - 0;
        _num++;
        $(this).siblings('#person-num').val(_num);
    });
    //定制行程添加城市删除图片显示隐藏
    var count = 1, isOk = false;
    $('.city-section1').on('focus','input', function () {
        $(this).siblings('i').hide();
    }).on('blur','input', function () {
        $(this).siblings('i').show();
    });
    //添加目的地
    $('.add-btn i').on('click', function () {
        if (count > 5) {
            $('.add-btn span').html('目前最多只能选择6个目的地').css('margin', '5px 0 0 10px');
            $('.add-btn i').css('margin', '5px 0 0');
            $('.city-section1').css('margin-bottom', 20);
            return false;
        }
        isOk = false;
        $('.city-section1 input').each(function () {
            if (!$(this).val()) {
                isOk = true;
            }
        });
        if (isOk) {
            return false;
        }
        addCity();
        count++;
    });
    //备注文字统计
    $('.remarks-text textarea').bind('propertychange input', function () {
        len = $(this).val().length;
        if (len > 501) {
            $(this).siblings('span').css('color', '#f00');
            len = 500;
        }
        $(this).siblings('span').html('您还可以输入' + (500 - len) + '字');
    });
    //点击删城市
    $('body').on('click','.order-move',function () {
        $(this).parent('.city-name').remove();
        if ($('.city-section1').find('input').length < 6) {
            $('.add-btn span').html('');
        }
        count--;
    });
    $('.order-delt').on('click', function () {
        $(this).siblings('input').val('');
    });
    //添加城市
    function addCity() {
        var html = '';
        html = '<span class="city-name"><input type="text"  required="required" name="area[]"  class="form-control add-city text-overflow" placeholder="输入您想去的地方"><i class="order-move"></i></span>';
        $('.add-btn').before(html);
    }
    //提交需求开始形成时间日历
    $('#demand-start').datetimepicker({
        bootcssVer: 3,
        format: 'yyyy-mm-dd',
        language: 'zh-CN',
        weekStart: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 2,
        minView: 2,
        forceParse: 1,
        linkField: "mirror_start",
        linkFormat: "yyyy-mm-dd"
    }).on('changeDate', function (ev) {
        if (changeTime($(this).val()) < changeTime(t)) {
            $().popup('不能小于当前时间');
            $(this).val('');
            return false;
        }
        if (changeTime($(this).val()) > changeTime($('#demand-end').val())) {
            $().popup('不能大于结束时间');
            $(this).val('');
            return false;
        }
        if (!$('#demand-end').val()) {
            $('#demand-end').val($(this).val());
        }
    });
    //提交需求结束形成时间日历
    $('#demand-end').datetimepicker({
        bootcssVer: 3,
        format: 'yyyy-mm-dd',
        language: 'zh-CN',
        weekStart: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 2,
        minView: 2,
        forceParse: 1,
        linkField: "mirror_end",
        linkFormat: "yyyy-mm-dd"
    }).on('changeDate', function (ev) {
        if (changeTime($(this).val()) < changeTime(t)) {
            $().popup('不能小于当前时间');
            $(this).val('');
            return false;
        }
        if (changeTime($(this).val()) < changeTime($('#demand-start').val())) {
            $().popup('不能小于开始时间');
            $(this).val('');
            return false;
        }
    });

    //需求提交表单
    $('#intent-form').submit(function () {
        var area = '';
        $('.city-name input').each(function () {
            if ($(this).val()) {
                area += $(this).val();
            }
        });
        if (!$('#demand-start').val() || !$('#demand-end').val() || !$('#person-num').val() || !$('#content').val() || !area) {
            $(this).popup('请将信息填写完整再进行提交');
            return false;
        }
        $(this).loading();
        $.post('/intent/addOlister', $(this).serialize(), function (result) {
            $(this).unload();
            if (result.code == 1000) {
                window.location.href = '/site/demandSuccess/id/' + result.result;
            } else {
                $(this).popup(result.error);
            }
        }, 'json');
        return false;
    })
});