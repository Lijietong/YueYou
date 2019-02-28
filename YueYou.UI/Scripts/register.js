var name = false;
var rname = false;
var pwd = false;
var rpwd = false;
var code1 = false;


//用户名验证
$(function () {
    $("#user_name").blur(function () {
        var input = $(this).val();
        if(input ==""){
            $(".form-group:eq(1)").css("border-color","red");
        } else {
            $(".form-group:eq(1)").css("border-color","green");
            name=true;
        }
   
    })
})

//真实姓名验证
$(function () {
    $("#user_rname").blur(function () {
        var input = $(this).val();
        if (input == ""){
            $(".form-group:eq(2)").css("border-color", "red");
        } else {
            $(".form-group:eq(2)").css("border-color", "green");
            rname=true;
        }
    })
})


//密码验证
$(function () {
   
    var regpwd = /^\w{6,20}$/;
    $('#user_pwd').blur(function () {
        var pwd = null;
        var val = $('#user_pwd').val();
        if (val == '') {
            pwd = false;  
        } else {
            if (!(regpwd.test(val))) {
                pwd = false;
            } else {
                pwd = true;   
            }
        }
        if (pwd!=true) {
            $(".form-group:eq(3)").css("border-color", "red");
        }
        else {
            $(".form-group:eq(3)").css("border-color", "green");
        }
    })
})

//再次输入密码验证
$(function () {
    $('#user_pwd-refresh').blur(function () {
        var val = $('#user_pwd').val();
        var again = $('#user_pwd-refresh').val();
        var rpwd = null;
        if (again != val||again=='') {
            //$('#user_pwd-refresh').html('密码输入不一致');
            $(".form-group:eq(4)").css("border-color", "red");
        } else {
            $(".form-group:eq(4)").css("border-color", "green");
            rpwd = true;
        }
    })    
})


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
//function validateCode(ev) {
//    var code1=null;
//    var inputCode = document.getElementById("inputCode").value;
//    if (inputCode.length <= 0) {
//        alert("请输入验证码！");
//    }
//    else if (inputCode.toUpperCase() != code.toUpperCase()) {
//        alert("验证码输入有误！");
//        createCode();
//        ev.preventDefault();
//    }
//    else{
//        code1=true;
//    }
//}

//首次加载执行生成验证码
createCode();


//注册按钮点击
$(function () {
    $('#btnRegister').click(function () {
        var code1 = null;
        var inputCode = document.getElementById("inputCode").value;
        if (inputCode.length <= 0) {
            alert("请输入验证码！");
            window.open('" + Url.Content("~/User/Register") + "', '_self');
        } else if (inputCode.toUpperCase() != code.toUpperCase()) {
            alert("验证码输入有误！");
            window.open('" + Url.Content("~/User/Register") + "', '_self');
            createCode();
        }else{
            code1 = true;
        }
        if (name && rname && pwd && rpwd && code1) {
            alert('用户注册成功！');
        }
    })
})