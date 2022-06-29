$(function () {
    $("#password").keyup(function (a) {
        if (a.keyCode === 13) {
            ingresar();
        }
    });

    $("#usuario").keyup(function (a) {
        if (a.keyCode === 13) {
            $("#password").focus();
        }
    });
});

function mouseover(id) {
    $("#" + id).attr("type", "text");
}

function mouseout(id) {
    $("#" + id).attr("type", "password");
}

function ingresar() {
    $("#ajax_wait").show();

    var usuario = $("#usuario").val();
    var password = $("#password").val();

    $.ajax({
        url: "Home/Autentica",
        dataType: "json",
        data: {
            usuario: usuario,
            password: password
        },
        success: function (result) {
            $("#ajax_wait").hide();

            if (result.estado) {
                if (result.msg == "ADMIN") {
                    window.location = "../Admin/Index";
                } else if (result.msg == "CLIENT") {
                    window.location = "../Client/Index";
                }
            } else {
                $("#dlg_message_msg").text(result.msg);
                $("#dlg_message").modal("show");
            }
        }
    });
}