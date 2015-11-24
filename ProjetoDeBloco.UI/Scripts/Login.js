
var autenficacao = {

    login: $('#login'),
    senha: $('#senha')
}

function Logar() {
    var url = "/AutentificarUsuario/Logar";

    $.ajax({
        url: url,
        data: {
            login: autenficacao.login.val(),
            senha: autenficacao.senha.val()
        },
        dataType: "json",
        type: "GET",
        async: true,
        beforeSend: function () {
            waitingDialog.show("Carregando informações....");
        },
        success: function (dados) {
            if (dados.ok) {
                LimparCampos();
                window.location.href = "/Home/Index";
            }
            else {
                waitingDialog.hide();
                swal({ title: "Não foi possivel realizar a operação!", text: dados.mensagem, type: "error", confirmButtonText: "Ok" });
            }
        },
        error: function () {
            waitingDialog.hide();
        }
    });
}

function LimparCampos() {
    autenficacao.login.val("");
    autenficacao.senha.val("");

    $("#validarLogin").html("").removeClass("alert-danger");
    $("#validarSenha").html("").removeClass("alert-danger");
}

function ValidarCampos() {

    var valido = true;

    if (autenficacao.login.val() == "") {
        $("#validarLogin").html("Informe o campo de login!").addClass("alert-danger");
        valido = false;
    }

    if (autenficacao.senha.val() == "") {
        $("#validarSenha").html("Informe o campo de senha!").addClass("alert-danger");
        valido = false;
    }

    return valido;
}


$(document).ready(function () {

    $("#Logar").click(function () {

        if (ValidarCampos()) {
            Logar();
            LimparCampos();
        }
    });
});