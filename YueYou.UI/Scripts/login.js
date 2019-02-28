$(document).ready(function () {
    $(".globalLoginBtn").click(function () {
        $("#loginModal").show();
    })

    $("#login_close").click(function () {
        $("#loginModal").hide();
    })

    // 在键盘按下并释放及提交后验证提交表单
    //console.log($.fn.validate)
    $("#box-login")
        //.validate({
        //    rules: {
        //        id_account_l: "required",
        //        id_password_l: "required"
        //    },
        //    messages: {
        //        id_account_l: "用户名不得为空",
        //        id_password_l: "密码不得为空"
        //    }
        //});

    $("#login_btn").click(function () {
        $.ajax({
            url: "/UserInfo/Login",
            type: "post",
            data: { User_name: $("#id_account_l").val(), User_pwd: $("#id_password_l").val() },
            success: function (data) {
                $("#loginModal").css("display", "none");
                if (data == "登录成功") {
                    location.reload();
                } else {
                    alert("用户名或密码错误");
                    $("#loginModal").css("display", "block");
                }
            }
        });
    });

    //表单信息提交验证
    $.validator.setDefaults({
        submitHandler: function () {
            alert("提交事件!");
        }
    });

    //登录验证码js
    var code;
    //生成验证码
    function createCode() {
        code = "";
        var codeLength = 6; //验证码的长度
        var checkCode = document.getElementById("checkCode");
        var codeChars = new Array(0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
             'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
             'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'); //所有候选组成验证码的字符，当然也可以用中文的
        for (var i = 0; i < codeLength; i++) {
            var charNum = Math.floor(Math.random() * 52);
            code += codeChars[charNum];
        }
        if (checkCode) {
            checkCode.className = "code";
            checkCode.innerHTML = code;
        }
    }
    //对验证码进行验证
    function validateCode(ev) {

        var inputCode = document.getElementById("inputCode").value;
        if (inputCode.length <= 0) {
            alert("请输入验证码！");
        }
        else if (inputCode.toUpperCase() != code.toUpperCase()) {
            alert("验证码输入有误！");
            createCode();
            ev.preventDefault();
        }
    }

    //首次加载执行生成验证码
    createCode();

})


